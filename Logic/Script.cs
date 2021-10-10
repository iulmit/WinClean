// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    public class CmdScript : Script
    {
        #region Public Constructors

        public CmdScript(Path path, string name, string description, IEnumerable<Impact> impacts, ListViewGroup group) : base(name, description, impacts, group)
            => Host = new(path);

        #endregion Public Constructors

        #region Protected Properties

        protected override Cmd Host { get; }

        #endregion Protected Properties
    }

    public class Ps1Script : Script
    {
        #region Public Constructors

        public Ps1Script(Path path, string name, string description, IEnumerable<Impact> impacts, ListViewGroup group) : base(name, description, impacts, group)
            => Host = new(path);

        #endregion Public Constructors

        #region Protected Properties

        protected override PowerShell Host { get; }

        #endregion Protected Properties
    }

    public class RegScript : Script
    {
        #region Public Constructors

        public RegScript(Path path, string name, string description, IEnumerable<Impact> impacts, ListViewGroup group) : base(name, description, impacts, group)
            => Host = new(path);

        #endregion Public Constructors

        #region Protected Properties

        protected override Regedit Host { get; }

        #endregion Protected Properties
    }

    /// <summary>A script that can be executed from a script host program.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237", Justification = $"{nameof(Script)} does not support serialization.")]
    public abstract class Script : ListViewItem
    {
        #region Private Fields

        protected abstract ScriptHost Host { get; }

        #endregion Private Fields

        #region Public Constructors

        protected Script(string name, string description, IEnumerable<Impact> impacts, ListViewGroup group)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Impacts = impacts ?? throw new ArgumentNullException(nameof(impacts));
            Group = group ?? throw new ArgumentNullException(nameof(group));
        }

        #endregion Public Constructors

        #region Public Properties

        public string Description { get => base.ToolTipText; set => base.ToolTipText = value; }
        public IEnumerable<Impact> Impacts { get; }
        public new string Name { get => base.Text; set => base.Text = value; }
        public Path Path => Host.ScriptPath;

        #endregion Public Properties

        #region Private Properties

        private new string Text { get; set; }
        private new string ToolTipText { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <inheritdoc cref="ScriptHost.Execute()"/>
        public void Execute() => Host.Execute();

        #endregion Public Methods
    }

    public class WshScript : Script
    {
        #region Public Constructors

        public WshScript(Path path, string name, string description, IEnumerable<Impact> impacts, ListViewGroup group) : base(name, description, impacts, group)
            => Host = new(path);

        #endregion Public Constructors

        #region Protected Properties

        protected override WindowsScriptHost Host { get; }

        #endregion Protected Properties
    }
}
