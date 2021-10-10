// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

using static System.IO.Path;

namespace RaphaëlBardini.WinClean.Operational
{
    public class WindowsScriptHost : ScriptHost
    {
        #region Public Constructors

        public WindowsScriptHost(Path script) : base(script)
        {
        }

        #endregion Public Constructors

        #region Protected Properties

        protected override string Arguments => $"\"{ScriptPath}\" //b //Nologo";
        protected override Path Executable => new(Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "wscript.exe"));
        protected override IEnumerable<Extension> SupportedExtensions => new Extension[] { new(".vbs"), new(".vbe"), new(".wsf"), new(".js"), new(".jse") };

        #endregion Protected Properties
    }
}
