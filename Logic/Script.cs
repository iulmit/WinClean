// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A script that can be executed from a script host program.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237", Justification = $"{nameof(Script)} does not support serialization.")]
    public class Script : ListViewItem, IScript
    {
        #region Private Fields

        private const byte RecommendedColorAlpha = 63;
        private readonly Color _initialBackColor;

        private ScriptAdvised _scriptAdvised;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Instanciates a new <see cref="Script"/> object.</summary>
        /// <param name="host">The associated script host program.</param>
        /// <param name="path">The path of the script file.</param>
        public Script(IScriptHost host, FilePath path)
        {
            Path = path;
            Host = host;
            _initialBackColor = BackColor;
        }

        #endregion Public Constructors

        #region Public Properties

        public ScriptAdvised Advised
        {
            get => _scriptAdvised;
            set
            {
                _scriptAdvised = value;
                BackColor = value.GetColor().EmulateAlpha(_initialBackColor, RecommendedColorAlpha);
            }
        }

        public string Description { get => ToolTipText; set => ToolTipText = value; }
        public IScriptHost Host { get; }
        public IEnumerable<Impact> Impacts { get; init; }
        public new string Name { get => Text; set => Text = value; }
        public FilePath Path { get; protected set; }

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc cref="ScriptHost.Execute()" path="/summary"/>
        public void Execute()
        {
            try
            {
                Host.Execute(Path);
            }
            catch (FileNotFoundException)
            {
                ErrorDialog.ScriptNotFound(Path, Execute, null/*chaud : delete script from settings*/);
            }
        }

        #endregion Public Methods
    }
}
