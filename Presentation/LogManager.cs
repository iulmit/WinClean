using CsvHelper;
using CsvHelper.Configuration;

using RaphaëlBardini.WinClean.Operational;

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>Provides CSV logging.</summary>
public class LogManager
{
    #region Private Constructors

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1810",
        Justification = "Properties rely on each other for their initialization - They must be assigned in a specific order")]
    private LogManager()
    {
        _logDir = new(Path.Join(AppDir.Instance.Info.FullName, "Logs"));
        CreateLogDir();
        _currentLogFile = new(Path.Join(_logDir.FullName, $"{Process.GetCurrentProcess().StartTime.ToString(DateTimeFilenameFormat, DateTimeFormatInfo.InvariantInfo)}.csv"));
        _csvWriter = new(new StreamWriter(_currentLogFile.FullName, true, System.Text.Encoding.Unicode), new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = LogDelimiter });
        _csvWriter.WriteHeader<LogEntry>();
    }

    #endregion Private Constructors

    #region Private Fields

    #region Constants

    private const string DateTimeFilenameFormat = "yyyy-MM-dd--HH-mm-ss";

    private const string LogDelimiter = ";";

    #endregion Constants

    private readonly CsvWriter _csvWriter;
    private readonly FileInfo _currentLogFile;

    private readonly DirectoryInfo _logDir;

    #endregion Private Fields

    #region Public Properties

    public static LogManager Instance { get; } = new();

    #endregion Public Properties

    #region Public Methods

    /// <summary>Empties the log folder, except for the current log file.</summary>
    public async void ClearLogsFolderAsync()
        => await Task.Run(() =>
        {
            IEnumerable<FileInfo> deletableLogFiles = _logDir.EnumerateFiles("*.csv").Where(csvFile => CanLogFileBeDeleted(csvFile));

            Log("Clearing logs folder", $"Deleting {deletableLogFiles.Count()} files");

            foreach (FileInfo logFile in deletableLogFiles)
            {
                DeleteLogFile();

                void DeleteLogFile()
                {
                    try
                    {
                        logFile.Delete();
                    }
                    catch (Exception e) when (e.FileSystem())
                    {
                        new FSErrorDialog(e, FSVerb.Delete, logFile).ShowDialog(DeleteLogFile);
                    }
                }
            }
        }).ConfigureAwait(false);

    /// <summary>Logs a string.</summary>
    /// <param name="happening">What's happening right now.</param>
    /// <param name="message">The string to log.</param>
    /// <param name="lvl">The level of the log entry.</param>
    /// <param name="caller"><see cref="CallerMemberNameAttribute"/> - Don't specify</param>
    /// <param name="callLine"><see cref="CallerLineNumberAttribute"/> - Don't specify</param>
    /// <param name="callFile"><see cref="CallerFilePathAttribute"/> - Don't specify</param>
    public void Log(string happening, string message, LogLevel lvl = LogLevel.Verbose,
                           [CallerMemberName] string caller = "Not Found",
                           [CallerLineNumber] int callLine = 0,
                           [CallerFilePath] string callFile = "Not Found")
    {
        if ((LogLevel)Program.Settings.LogLevel <= lvl)
        {
            _csvWriter.NextRecord();
            _csvWriter.WriteRecord(new LogEntry()
            {
                Date = DateTime.Now,
                Level = lvl,
                Happening = happening,
                Message = message,
                Caller = caller,
                CallFileFullPath = callFile,
                CallLine = callLine
            });
        }
    }

    #endregion Public Methods

    #region Private Methods

    private bool CanLogFileBeDeleted(FileInfo logFile)
        => DateTime.TryParseExact(Path.GetFileNameWithoutExtension(logFile.Name), DateTimeFilenameFormat,
                                  DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out _) && logFile.Name != _currentLogFile.Name;

    private void CreateLogDir()
    {
        try
        {
            _logDir.Create();
        }
        catch (Exception e) when (e.FileSystem())
        {
            new FSErrorDialog(e, FSVerb.Create, _logDir).ShowDialog(CreateLogDir);
        }
    }

    #endregion Private Methods

    #region Private Records

    ///<remarks>The fields are in the order we want the CSV header to be in. Topmost = leftmost</remarks>
    private record LogEntry
    {
        #region Public Properties

        public LogLevel Level { get; init; }
        public DateTime Date { get; init; }
        public string Happening { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;
        public string Caller { get; init; } = string.Empty;
        public int CallLine { get; init; }
        public string CallFileFullPath { get; init; } = string.Empty;

        #endregion Public Properties
    }

    #endregion Private Records
}

public static class LogExtensions
{
    #region Public Methods

    /// <inheritdoc cref="LogManager.Log(string, string, LogLevel, string, int, string)"/>
    public static void Log(this string str, string happening, LogLevel lvl = LogLevel.Verbose,
                           [CallerMemberName] string caller = "Not Found",
                           [CallerLineNumber] int callLine = 0,
                           [CallerFilePath] string callFile = "Not Found")
        => LogManager.Instance.Log(happening, str, lvl, caller, callLine, callFile);

    /// <summary>Logs an exception and it's details.</summary>
    /// <param name="e">The exception to log.</param>
    /// <param name="lvl">The level of the entry.</param>
    /// <param name="caller"><see cref="CallerMemberNameAttribute"/> - Don't specify</param>
    /// <param name="callLine"><see cref="CallerLineNumberAttribute"/> - Don't specify</param>
    /// <param name="callFile"><see cref="CallerFilePathAttribute"/> - Don't specify</param>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is <see langword="null"/>.</exception>
    public static void Log(this Exception e, LogLevel lvl = LogLevel.Error,
                           [CallerMemberName] string caller = "Not Found",
                           [CallerLineNumber] int callLine = 0,
                           [CallerFilePath] string callFile = "Not Found")
        => Log((e ?? throw new ArgumentNullException(nameof(e))).ToString(), "Exception", lvl, caller, callLine, callFile);

    #endregion Public Methods
}
