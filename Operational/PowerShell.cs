﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Text;

using static System.IO.Path;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>Represetns the Windows PowerShell script host.</summary>
    public sealed class PowerShell : IScriptHost
    {
        #region Public Properties

        IScriptHost.IncompleteArguments IScriptHost.Arguments => new("-WindowStyle hidden -NoLogo -NoProfile -NonInteractive -File & \"{0}\"");
        Encoding IScriptHost.Encoding => Encoding.GetEncoding(1252);
        FileInfo IScriptHost.Executable => new(Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe"));
        IReadOnlyCollection<string> IScriptHost.SupportedExtensions => new string[] { ".ps1" };

        #endregion Public Properties
    }
}
