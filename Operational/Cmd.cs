// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>The Windows Command Line interpreter (cmd.exe) script host.</summary>
public class Cmd : ScriptHost
{
    #region Public Properties

    public override ExtensionGroup SupportedExtensions => new(".cmd", ".bat");

    #endregion Public Properties

    #region Protected Properties

    protected override IncompleteArguments Arguments => new("/d /c \"\"{0}\"\"");

    protected override FileInfo Executable => new(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine)!);// ! : comspecs exists natively on windows

    #endregion Protected Properties
}
