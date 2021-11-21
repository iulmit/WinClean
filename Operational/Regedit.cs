// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>Windows Registry Editor</summary>
public class Regedit : ScriptHost
{
    #region Public Properties

    public override ExtensionGroup SupportedExtensions { get; } = new(".reg");

    #endregion Public Properties

    #region Protected Properties

    protected override IncompleteArguments Arguments { get; } = new("/s {0}");

    protected override FileInfo Executable { get; } = new(Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe"));

    #endregion Protected Properties
}
