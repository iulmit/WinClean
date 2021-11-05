// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.
namespace RaphaëlBardini.WinClean
{
    /// <summary>
    /// Specifies a minimum log level.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// All entries are logged.
        /// </summary>
        Verbose,

        /// <summary>
        /// Informational entries minimum.
        /// </summary>
        Info,

        /// <summary>
        /// Warning-level entries minimum.
        /// </summary>
        Warning,

        /// <summary>
        /// Error-level entries minimum.
        /// </summary>
        Error,

        /// <summary>
        /// Unrecoverable errors. The application can't continue.
        /// </summary>
        Critical
    }
}