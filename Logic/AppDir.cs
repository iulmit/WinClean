// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    public class AppDir
    {
        #region Public Properties

        public static AppDir Instance { get; } = new();

        // chaud : read install dir from registry program entry. Needs an installer.
        public DirectoryInfo Info => new(Application.StartupPath);

        public ScriptsDir ScriptsDir => ScriptsDir.Instance;

        #endregion Public Properties
    }
}
