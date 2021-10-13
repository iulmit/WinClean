// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

global using System;
using System.Windows.Forms;

using static System.IO.Path;

namespace RaphaëlBardini.WinClean
{
    /// <summary>Constant and readonly fields used to configure the application.</summary>
    // TODO : faire des paramètres configurables.
    public static class Constants
    {
        #region Public Fields

        /// <summary>Application minimum log level.</summary>
        public const LogLevel AppLogLevel = LogLevel.Verbose;

        /// <summary>Number of milliseconds the program should wait for a script to finish executing.</summary>
        public const int ScriptTimeoutMilliseconds = 20 * 60 * 1000;// 20 minutes

        // chaud : a lire de puis le registre entree installation. Besoin d'un installeur pour faire ça.
        /// <summary>Application install directory.</summary>
        public static readonly Path InstallDir = new(Application.StartupPath);

        /// <summary>Application logging directory.</summary>
        public static readonly Path LogsDir = new(Combine(InstallDir, "Logs"));

        /// <summary>Scripts storage directory.</summary>
        public static readonly Path ScriptsDir = new(Combine(InstallDir, "Scripts"));

        #endregion Public Fields
    }
}
