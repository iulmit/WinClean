﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

using CsvHelper;
using CsvHelper.Configuration;
using RaphaëlBardini.WinClean.Logic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace RaphaëlBardini.WinClean;

/// <summary>
/// Provides CSV logging.
/// </summary>
public static class LogManager
{
    #region Public Constructors

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1810",
        Justification = "Properties rely on each other for their initialization - They must be assigned in a specific order")]
    static LogManager()
    {
        s_logDir = new(Path.Join(Program.InstallDir.FullName, "Logs"));
        s_currentLogFile = new(Path.Join(s_logDir.FullName, $"{Process.GetCurrentProcess().StartTime.ToString(DateTimeFilenameFormat, DateTimeFormatInfo.InvariantInfo)}.csv"));
        CreateLogDir();
        s_csvWriter = new(new StreamWriter(s_currentLogFile.FullName, true, System.Text.Encoding.Unicode), new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = LogDelimiter });
        s_csvWriter.WriteHeader<LogEntry>();
        s_csvWriter.NextRecord();
        s_csvWriter.Flush();
    }

    #endregion Public Constructors

    #region Public Properties

    public static LogLevel MinLogLevel { get; set; } = (LogLevel)Properties.Settings.Default.LogLevel;

    #endregion Public Properties

    #region Private Fields

    #region Constants

    private const string DateTimeFilenameFormat = "yyyy-MM-dd--HH-mm-ss";

    private const string LogDelimiter = ";";

    private static readonly FileInfo s_currentLogFile;

    private static readonly DirectoryInfo s_logDir;

    #endregion Constants

    private static readonly CsvWriter s_csvWriter;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Empties the log folder, except for the current log file.
    /// </summary>
    public static async void ClearLogsFolderAsync()
        => await Task.Run(() =>
        {
            IEnumerable<FileInfo> deletableLogFiles = s_logDir.EnumerateFiles("*.csv").Where(csvFile => CanLogFileBeDeleted(csvFile));

            $"Deleting {deletableLogFiles.Count()} files".Log("Clearing logs folder");

            foreach (FileInfo logFile in deletableLogFiles)
            {
                DeleteLogFile(logFile);
            }
        }

    /// <summary>
    /// Logs a string.
    /// </summary>
    /// <param name="str">The string to log.</param>
    /// <param name="happening">What's happening right now.</param>
    /// <param name="lvl">The level of the log entry.</param>
    /// <param name="caller"><see cref="CallerMemberNameAttribute"/> - Don't specify</param>
    /// <param name="callLine"><see cref="CallerLineNumberAttribute"/> - Don't specify</param>
    /// <param name="callFile"><see cref="CallerFilePathAttribute"/> - Don't specify</param>
    public static void Log(this string? str, string happening, LogLevel lvl = LogLevel.Verbose,
                           [CallerMemberName] string caller = "Not Found",
                           [CallerLineNumber] int callLine = 0,
                           [CallerFilePath] string callFile = "Not Found")
    {
        if (MinLogLevel <= lvl)
        {
            s_csvWriter.WriteRecord(new LogEntry()
            {
                Date = DateTime.Now,
                Level = lvl,
                Happening = happening,
                Message = str ?? string.Empty,
                Caller = caller,
                CallFileFullPath = callFile,
                CallLine = callLine
            });

            s_csvWriter.NextRecord();
            s_csvWriter.Flush();
        }
    }

    /// <summary>
    /// Logs an exception and it's details.
    /// </summary>
    /// <param name="e">The exception to log.</param>
    /// <param name="lvl">The level of the entry.</param>
    /// <param name="caller"><see cref="CallerMemberNameAttribute"/> - Don't specify</param>
    /// <param name="callLine"><see cref="CallerLineNumberAttribute"/> - Don't specify</param>
    /// <param name="callFile"><see cref="CallerFilePathAttribute"/> - Don't specify</param>
    public static void Log(this Exception e, LogLevel lvl,
                           [CallerMemberName] string caller = "Not Found",
                           [CallerLineNumber] int callLine = 0,
                           [CallerFilePath] string callFile = "Not Found")
        => Log((e ?? throw new ArgumentNullException(nameof(e))).ToString(), e.Message, lvl, caller, callLine, callFile);

    #endregion Public Methods

    #region Private Methods
 
    private static bool CanLogFileBeDeleted(FileInfo logFile)
        => DateTime.TryParseExact(Path.GetFileNameWithoutExtension(logFile.Name), DateTimeFilenameFormat,
                                  DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out _) && logFile.Name != s_currentLogFile.Name;

    private static void CreateLogDir()
    {
        try
        {
            s_logDir.Create();
        }
        catch (IOException e)
        {
            ErrorDialog.CantCreateLogDir(e, CreateLogDir, Program.Exit);
        }
    }

    private static void DeleteLogFile(FileInfo path)
    {
        try
        {
            path.Delete();
        }
        catch (Exception e) when (e.FileSystem())
        {
            ErrorDialog.CantDeleteLogFile(e, () => DeleteLogFile(path));
        }
    }

    #endregion Private Methods

    #region Private Structs

    ///<remarks>The fields are in the order we want the CSV header to be in. Topmost = leftmost</remarks>
    private record LogEntry
    {
        #region Public Properties

        public LogLevel Level { get; init; }
        public DateTime Date { get; init; }
        public string Happening { get; init; }
        public string Message { get; init; }
        public string Caller { get; init; }
        public int CallLine { get; init; }
        public string CallFileFullPath { get; init; }
        
        #endregion Public Properties
    }

    #endregion Private Structs
}
