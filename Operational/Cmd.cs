// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Text;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>Represents the Windows Command Line Interpreter (cmd.exe) script host.</summary>
    public sealed class Cmd : IScriptHost
    {
        #region Public Properties

        IScriptHost.IncompleteArguments IScriptHost.Arguments => new("/d /c \"\"{0}\"\"");
        Encoding IScriptHost.Encoding => Encoding.GetEncoding(850);
        FileInfo IScriptHost.Executable => new(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine));
        IReadOnlyCollection<string> IScriptHost.SupportedExtensions => new string[] { ".cmd", ".bat" };

        #endregion Public Properties
    }
}
