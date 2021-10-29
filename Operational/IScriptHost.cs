// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>Represents a program that accepts a file in it's command-line arguments.</summary>
    public interface IScriptHost
    {
        #region Public Properties

        /// <summary>User friendly name for the script host.</summary>
        string DisplayName { get; }

        /// <summary>Extensions of the scripts the script host program can run.</summary>
        ExtensionGroup SupportedExtensions { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Executes the specified script.</summary>
        /// <param name="script">The script to execute.</param>
        /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
        void Execute(IScript script);

        #endregion Public Methods
    }
}
