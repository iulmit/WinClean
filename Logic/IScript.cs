// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>If a script is advised for general purpose</summary>
    public enum ScriptAdvised
    {
        /// <summary>
        /// The script is advised for any user. It has almost no side effects and won't hinder features the said user might want
        /// to use. It can be selected automatically.
        /// </summary>
        Yes,

        /// <summary>
        /// The script only advised for users who want advanced optimisation. It may hinder useful system features. It should be
        /// selected individually by the user.
        /// </summary>
        Limited,

        /// <summary>
        /// The script must be selected only by users who know what they are doing. It will almost certainly hinder useful
        /// system features. It should be selected by the user, only if specifically needed.
        /// </summary>
        No
    }

    /// <summary>Represents an executable script associated to a script host program.</summary>
    public interface IScript
    {
        #region Private Methods

        private static DirectoryInfo CreateScriptsDir()
        {
            DirectoryInfo tmpScriptsDir = null;
            try
            {
                tmpScriptsDir = Directory.CreateDirectory(Path.Combine(Constants.AppInstallDir.FullName, "Scripts"));
            }
            catch (UnauthorizedAccessException e)
            {
                ErrorDialog.CantCreateScriptsDir(e, () => tmpScriptsDir = CreateScriptsDir(), Program.Exit);
            }
            return tmpScriptsDir;
        }

        #endregion Private Methods

        #region Protected Fields

        /// <summary>Scripts storage directory.</summary>
        protected static readonly DirectoryInfo ScriptsDir = CreateScriptsDir();

        #endregion Protected Fields

        #region Public Properties

        /// <summary>If running this script is advised in general purpose.</summary>
        ScriptAdvised Advised { get; set; }

        /// <summary>Details on how this scripts work and what the effects of executing it would be.</summary>
        string Description { get; set; }

        /// <summary>The path of the script file.</summary>
        FileInfo File { get; }

        /// <summary>The associated group when displayed in a <see cref="ListView"/> control.</summary>
        ListViewGroup Group { get; set; }

        /// <summary>Script host program associated to the instance.</summary>
        IScriptHost Host { get; }

        /// <summary>System impacts of running this script.</summary>
        IEnumerable<Impact> Impacts { get; init; }

        /// <summary>A brief infinitive sentence that describes the functionnality of this script.</summary>
        string Name { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Executes the script in a new process.</summary>
        void Execute();

        #endregion Public Methods
    }
}
