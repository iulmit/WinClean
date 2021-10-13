// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Text;

namespace RaphaëlBardini.WinClean.Operational
{
    public sealed class Cmd : IScriptHost
    {

        IReadOnlyCollection<Extension> IScriptHost.SupportedExtensions => new Extension[] { new(".cmd"), new(".bat") };
        IScriptHost.IncompleteArguments IScriptHost.Arguments => new("/d /c \"\"{0}\"\"");
        Path IScriptHost.Executable => new(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine));
        Encoding IScriptHost.Encoding => Encoding.GetEncoding(850);
    }
}
