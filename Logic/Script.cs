// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A script that can be executed from a script host program.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237", Justification = $"{nameof(Script)} does not support serialization.")]
    public class Script : ListViewItem, IScript
    {
        #region Public Constructors

        /// <summary>
        /// Instanciates a new <see cref="Script"/> object.
        /// </summary>
        /// <param name="host">The associated script host program.</param>
        /// <param name="path">The path of the script file.</param>
        public Script(IScriptHost host, Path path)
        {
            Path = path;
            Host = host;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Description { get => ToolTipText; set => ToolTipText = value; }
        public IEnumerable<Impact> Impacts { get; init; }
        public new string Name { get => Text; set => Text = value; }
        public Path Path { get; set; }
        public IScriptHost Host { get; }

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc cref="ScriptHost.Execute()" path="/summary"/>
        public void Execute(IWin32Window owner = null)
        {
            try
            {
                Host.Execute(Path);
            }
            catch (System.IO.FileNotFoundException)
            {
                ErrorDialog.ScriptNotFound(Path, owner, () => Execute(owner), null/*chaud : delete script from settings*/);
            }
        }

        #endregion Public Methods
    }
}
