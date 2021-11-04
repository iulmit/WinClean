// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>The Windows Command Line interpreter (cmd.exe) script host.</summary>
public class Cmd : ScriptHost
{
    /// <inheritdoc/>
    public override ExtensionGroup SupportedExtensions => new(".cmd", ".bat");

    /// <inheritdoc/>
    protected override IncompleteArguments Arguments => new("/d /c \"\"{0}\"\"");

    /// <inheritdoc/>
    protected override FileInfo Executable => new(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine)!);// ! : comspec exists on any windows machine
}
