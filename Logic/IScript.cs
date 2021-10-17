// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    public enum ScriptAdvised
    {
        Yes,
        Limited,
        No
    }

    /// <summary>Represents an executable script associated to a script host program.</summary>
    public interface IScript
    {
        #region Public Properties

        ScriptAdvised Advised { get; set; }
        string Description { get; set; }
        ListViewGroup Group { get; set; }

        /// <summary>Script host program associated to the instance.</summary>
        IScriptHost Host { get; }

        /// <summary>System impacts of running this script.</summary>
        IEnumerable<Impact> Impacts { get; init; }

        string Name { get; set; }

        /// <summary>The path of the script file.</summary>
        FilePath Path { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Executes the script in a new process.</summary>
        void Execute();

        #endregion Public Methods
    }

    public static class ScriptAdvisedExtensions
    {
        #region Public Methods

        public static Color GetColor(this ScriptAdvised scriptAdvised) => scriptAdvised switch
        {
            ScriptAdvised.Yes => Color.Green,
            ScriptAdvised.Limited => Color.Orange,
            ScriptAdvised.No => Color.Red,
            _ => throw new InvalidEnumArgumentException(nameof(scriptAdvised), (int)scriptAdvised, typeof(ScriptAdvised))
        };

        #endregion Public Methods
    }
}
