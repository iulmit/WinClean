﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents an executable script associated to a script host program.</summary>
    public interface IScript
    {
        #region Public Properties

        string Description { get; set; }
        ListViewGroup Group { get; set; }

        /// <summary>Script host program associated to the instance.</summary>
        IScriptHost Host { get; }

        /// <summary>System impacts of running this script.</summary>
        IEnumerable<Impact> Impacts { get; init; }

        string Name { get; set; }

        /// <summary>The path of the script file.</summary>
        Path Path { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Executes the script in a new process.</summary>
        /// <param name="owner"></param>
        void Execute(IWin32Window owner = null);

        #endregion Public Methods
    }
}
