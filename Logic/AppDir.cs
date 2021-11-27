// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic;

public class AppDir
{
    #region Public Properties

    public static AppDir Instance { get; } = new();

    public static ScriptsDir ScriptsDir => ScriptsDir.Instance;

    // chaud : read install dir from registry program entry. Needs an installer.
    public DirectoryInfo Info { get; } = new(Application.StartupPath);

    #endregion Public Properties
}
