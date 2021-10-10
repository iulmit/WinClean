// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace RaphaëlBardini.WinClean.Operational
{
    public class Cmd : ScriptHost
    {
        #region Public Constructors

        public Cmd(Path script) : base(script)
        {
        }

        #endregion Public Constructors

        #region Protected Properties

        protected override string Arguments => $"/d /c \"{ScriptPath}\"";
        protected override Path Executable => new(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine));
        protected override IEnumerable<Extension> SupportedExtensions => new Extension[] { new(".cmd"), new(".bat") };

        #endregion Protected Properties
    }
}
