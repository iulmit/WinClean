// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>Represents a program that accepts a file in it's command-line arguments.</summary>
    public interface IScriptHost
    {
        #region Public Properties

        /// <summary>Maximum time a script can execute without displaying a warning to the user.</summary>
        static TimeSpan Timeout { get; set; } = Properties.Settings.Default.ScriptTimeout;

        #endregion Public Properties



        #region Public Properties

        /// <summary>The host user-friendly display name.</summary>
        string DisplayName { get; }

        /// <summary>The file extension filter string for an <see cref="System.Windows.Forms.OpenFileDialog"/> control.</summary>
        string Filter { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Executes the script host with the specified script file.</summary>
        /// <param name="script">The path of the script file to run.</param>
        /// <exception cref="ArgumentNullException"><paramref name="script"/>'s <see langword="null"/>.</exception>
        /// <exception cref="BadFileExtensionException"><paramref name="script"/>'s extension is not supported.</exception>
        /// <inheritdoc cref="Helpers.ThrowIfUnacessible(FileInfo, FileAccess)" path="/exception"/>
        void Execute(FileInfo script);

        #endregion Public Methods
    }
}
