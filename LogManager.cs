// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

using CsvHelper;
using CsvHelper.Configuration;

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean
{
    /// <summary>Provides CSV and TraceSource logging.</summary>
    public static class LogManager
    {
        #region Private Fields

        private static readonly CsvWriter s_csvWriter;

        private static readonly StreamWriter s_streamWriter;

#if TRACE
        private static readonly TraceSource s_trace = new($"{System.Windows.Forms.Application.ProductName} {System.Windows.Forms.Application.ProductVersion}", Constants.TraceLevel);
#endif

        /// <summary>Count of log entries wrote.</summary>
        private static int s_logIndex = 0;

        #endregion Private Fields

        #region Public Constructors

        static LogManager()
        {
            CreateLogDir();
            s_streamWriter = new(Constants.LogFilePath, true, System.Text.Encoding.Unicode);
            s_csvWriter = new(s_streamWriter, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = Constants.LogDelimiter.ToString() });
        }

        #endregion Public Constructors

        #region Public Methods

        public static void ClearLogsFolder() => Directory.EnumerateFiles(Path.GetDirectoryName(Constants.LogFilePath), "*.csv")
                        .Where((csvFile) => CanLogFileBeDeleted(csvFile))
                        .ForEach((path) =>
                        {
                            try
                            {
                                File.Delete(path);
                            }
                            // For IOException, we don't want to handle derived classes. The "is" operator covers base classes too.
                            catch (Exception e) when (e is DirectoryNotFoundException or UnauthorizedAccessException || e.GetType().Equals(typeof(IOException)))
                            {
                                e.Handle(Error.Level.Error, Resources.ErrorMessages.CantDeleteLogFile(path));
                            }
                        });

        public static void Dispose()
        {
            // If disposed the other way around, throws an ObjectDisposedException.
            s_csvWriter.Dispose();
            s_streamWriter.Dispose();
#if TRACE
            s_trace.Close();
#endif
        }

        public static void Log(this string str, string happening, Error.Level lvl,
                               [CallerMemberName] string caller = "Not Found",
                               [CallerLineNumber] int callLine = 0,
                               [CallerFilePath] string callFile = "Not Found")
        => Log(str, happening, ToTraceEventType(lvl), caller, callLine, callFile);

        /// <summary>Logs a string.</summary>
        /// <param name="str">The string to log.</param>
        /// <param name="happening">What we're doing right now.</param>
        /// <param name="lvl">The level of the log entry.</param>
        public static void Log(this string str, string happening, TraceEventType lvl = TraceEventType.Verbose,
                               [CallerMemberName] string caller = "Not Found",
                               [CallerLineNumber] int callLine = 0,
                               [CallerFilePath] string callFile = "Not Found")
        {
            if (s_logIndex == 0)
                WriteHeader(s_csvWriter);
            s_csvWriter.WriteRecord(new LogEntry()
            {
                Date = DateTime.Now,
                Index = s_logIndex,
                Level = lvl,
                Happening = happening,
                Message = str,
                Caller = caller,
                CallFile = callFile,
                CallLine = callLine
            });
            s_csvWriter.NextRecord();
            s_logIndex++;
#if TRACE
            s_trace.TraceEvent(lvl, s_logIndex, $"{happening} : {str} in {caller} at line {callLine}, in {callFile}");
#endif
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>Checks that a log file is valid for deletion. Doesn't throw.</summary>
        /// <param name="fileNameOrPath">The filename or path of the log file.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="fileNameOrPath"/> is a valid path, it's
        /// filename is a valid log filename, and it's not the current session's log file. If one or
        /// more of these conditions are not met, <see langword="false"/>.
        /// </returns>
        private static bool CanLogFileBeDeleted(string fileNameOrPath)
        {
            try
            {
                return DateTime.TryParseExact(Path.GetFileNameWithoutExtension(fileNameOrPath), Constants.DateTimeFilenameFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out _)
                       && fileNameOrPath != Constants.LogFilePath;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>Creates the appropriate log folder if missing.</summary>
        private static void CreateLogDir()
        {
            try
            {
                _ = Directory.CreateDirectory(Path.GetDirectoryName(Constants.LogFilePath));
            }
            catch (IOException e)
            {
                e.HandleDontLog(Error.Level.Critical, Resources.ErrorMessages.CantCreateLogDir(Constants.LogFilePath));
            }
        }

        private static void WriteHeader(in CsvWriter writer)
        {
            writer.WriteHeader<LogEntry>();
            writer.NextRecord();
            s_logIndex++;
        }

        /// <summary>Converts an <see cref="Error.Level"/> to a <see cref="TraceEventType"/> enumeration.</summary>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><paramref name="level"/> is not a defined <see cref="Error.Level"/> constant.</exception>
        private static TraceEventType ToTraceEventType(Error.Level level)
        {
            return level switch
            {
                Error.Level.Critical => TraceEventType.Critical,
                Error.Level.Error => TraceEventType.Error,
                Error.Level.Warning => TraceEventType.Warning,
                Error.Level.Information => TraceEventType.Information,
                _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(level), (int)level, typeof(Error.Level))
            };
        }
        #endregion Private Methods

        #region Private Structs

        ///<remarks>The fields are in the order we want the CSV header to be in. Topmost = leftmost</remarks>
        private struct LogEntry
        {
            #region Public Properties

            public int Index { get; set; }
            public TraceEventType Level { get; set; }
            public string Caller { get; set; }
            public int CallLine { get; set; }
            public string Happening { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
            public string CallFile { get; set; }

            #endregion Public Properties
        }

        #endregion Private Structs
    }
}
