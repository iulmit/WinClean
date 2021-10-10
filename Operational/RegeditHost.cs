// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

using static System.IO.Path;

namespace RaphaëlBardini.WinClean.Operational
{
    public class Regedit : ScriptHost
    {
        #region Public Constructors

        public Regedit(Path script) : base(script)
        {
        }

        #endregion Public Constructors

        #region Protected Properties

        protected override string Arguments => $"/s {ScriptPath}";
        protected override Path Executable => new(Combine(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe"));
        protected override IEnumerable<Extension> SupportedExtensions => new Extension[] { new(".reg") };

        #endregion Protected Properties
    }
}
