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
        #region Public Fields

        #region Constants

        /// <summary>Padding of errorProvider controls relative to their associated controls.</summary>
        public const int ERROR_PROVIDER_PADDING = 8;

        /// <summary>CSV Log entry column delimiter.</summary>
        public const char LOG_DELIMITER = ';';

        /// <summary>Global TraceSource log level.</summary>
        public const System.Diagnostics.SourceLevels LOG_LEVEL = System.Diagnostics.SourceLevels.All;

        /// <summary>Number of milliseconds the program will wait for a script to finish executing.</summary>
        public const int SCRIPT_TIMEOUT = 20 * 60 * 1000;// 20 minutes

        public const string DATE_TIME_FILE_FORMAT = "yyyy-MM-dd--HH-mm-ss";
        #endregion Constants

        #region File and Folder Paths

        // chaud : a lire de puis le registre entree installation
        /// <summary>Application install dir full path</summary>
        public static readonly string INSTALL_DIR = Application.StartupPath;

        /// <summary>Full path of the log file for this session of the application.</summary>
        public static readonly string LOG_FILE_PATH = Path.Combine(INSTALL_DIR, "Logs", $"{System.Diagnostics.Process.GetCurrentProcess().StartTime.ToString(DATE_TIME_FILE_FORMAT, DateTimeFormatInfo.InvariantInfo)}.csv");

        /// <summary>Full path of the scripts dir.</summary>
        public static readonly string SCRIPTS_DIR_PATH = Path.Combine(INSTALL_DIR, "Scripts");

        #endregion File and Folder Paths

        public static readonly string NL = Environment.NewLine;

        #endregion Public Fields
    }
}
