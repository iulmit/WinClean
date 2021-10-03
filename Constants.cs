// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

global using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean
{
    /// <summary>Constant and readonly fields that manages config settings for the whole program.</summary>
    public static class Constants
    {
        #region Public Constructors

#if DEBUG

        static Constants()
        {
            // If no invalid filename chars are found
            System.Diagnostics.Debug.Assert(DateTimeFilenameFormat.IndexOfAny(Path.GetInvalidFileNameChars()) == -1);
        }

#endif

        #endregion Public Constructors

        #region Public Fields

        #region Constants

        /// <summary>Format string used by <see cref="DateTime.ToString(string?)"/> used for NTFS filenames.</summary>
        public const string DateTimeFilenameFormat = "yyyy-MM-dd--HH-mm-ss";

        /// <summary>CSV Log entry column delimiter.</summary>
        public const char LogDelimiter = ';';

        /// <summary>Global TraceSource log level.</summary>
        public const System.Diagnostics.SourceLevels TraceLevel = System.Diagnostics.SourceLevels.All;

        /// <summary>Number of milliseconds the program will wait for a script to finish executing.</summary>
        public const int ScriptTimeoutMilliseconds = 20 * 60 * 1000;// 20 minutes

        #endregion Constants

        #region File and Folder Paths

        // chaud : a lire de puis le registre entree installation. Besoin d'un installeur pour faire ça.
        /// <summary>Application install dir full path</summary>
        public static readonly string InstallDir = Application.StartupPath;

        /// <summary>Full path of the log file for this session of the application.</summary>
        public static readonly string LogFilePath = Path.Combine(InstallDir, "Logs", $"{System.Diagnostics.Process.GetCurrentProcess().StartTime.ToString(DateTimeFilenameFormat, DateTimeFormatInfo.InvariantInfo)}.csv");

        /// <summary>Full path of the scripts dir.</summary>
        public static readonly string ScriptsDirPath = Path.Combine(InstallDir, "Scripts");

        #endregion File and Folder Paths

        public static readonly string NL = Environment.NewLine;

        #endregion Public Fields
    }
}
