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

        /// <summary>Executes the script host with the specified script file.</summary>
        /// <param name="script">The path of the script file to run.</param>
        /// <exception cref="ArgumentNullException"><paramref name="script"/>'s <see langword="null"/>.</exception>
        /// <exception cref="BadFileExtensionException"><paramref name="script"/>'s extension is not supported.</exception>
        void Execute(FileInfo script);

        /// <summary>Executes the specified code that must me in the appropriate scripting langage.</summary>
        /// <param name="code">The code to execute.</param>
        void Execute(string code);

        #endregion Public Methods
    }
}
