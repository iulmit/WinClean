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

        // chaud : a lire de puis le registre entree installation. Besoin d'un installeur pour faire ça.
        /// <summary>Application install directory.</summary>
        public static readonly DirectoryPath AppInstallDir = new(Application.StartupPath);

        /// <summary>Scripts storage directory.</summary>
        public static readonly DirectoryPath ScriptsDir = new(Combine(AppInstallDir, "Scripts"));

        #endregion Public Fields
    }
}
