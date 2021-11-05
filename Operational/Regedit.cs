﻿using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>
/// Windows Registry Editor
/// </summary>
public class Regedit : ScriptHost
{
    #region Public Properties

    /// <inheritdoc/>
    public override ExtensionGroup SupportedExtensions => new(".reg");

    #endregion Public Properties

    #region Protected Properties

    /// <inheritdoc/>
    protected override IncompleteArguments Arguments => new("/s {0}");

    /// <inheritdoc/>
    protected override FileInfo Executable => new(Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe"));

    #endregion Protected Properties
}