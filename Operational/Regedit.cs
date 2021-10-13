// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Text;

using static System.IO.Path;

namespace RaphaëlBardini.WinClean.Operational
{
    public sealed class Regedit : IScriptHost
    {
        IReadOnlyCollection<Extension> IScriptHost.SupportedExtensions => new Extension[] { new(".reg") };
        Encoding IScriptHost.Encoding => Encoding.Unicode;
        IScriptHost.IncompleteArguments IScriptHost.Arguments => new("/s {0}");
        Path IScriptHost.Executable => new(Combine(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe"));
    }
}
