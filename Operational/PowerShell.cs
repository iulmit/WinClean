// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Text;

using static System.IO.Path;

namespace RaphaëlBardini.WinClean.Operational
{
    public sealed class PowerShell : IScriptHost
    {
        IReadOnlyCollection<Extension> IScriptHost.SupportedExtensions => new Extension[] { new(".ps1") };
        Encoding IScriptHost.Encoding => Encoding.GetEncoding(1252);
        IScriptHost.IncompleteArguments IScriptHost.Arguments => new("-WindowStyle hidden -NoLogo -NoProfile -NonInteractive -File & \"{0}\"");
        Path IScriptHost.Executable => new(Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe"));
    }
}
