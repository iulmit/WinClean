// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

using static System.IO.Path;

namespace RaphaëlBardini.WinClean.Operational
{
    public class PowerShell : ScriptHost
    {
        #region Public Constructors

        public PowerShell(Path script) : base(script)
        {
        }

        #endregion Public Constructors

        #region Protected Properties

        protected override string Arguments => $"-WindowStyle hidden -File & \"{ScriptPath}\"";
        protected override Path Executable => new(Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe"));
        protected override IEnumerable<Extension> SupportedExtensions => new Extension[] { new(".ps1") };

        #endregion Protected Properties
    }
}
