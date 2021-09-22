// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation
{
    public abstract class Script : Logic.Script
    {
        #region Protected Constructors

        protected Script(IEnumerable<Impact> impacts, string relativePath, string name, string description = "") : base(impacts, relativePath, name, description)
        {
        }

        #endregion Protected Constructors

        #region Public Methods

        /// <summary>Retrieves a <see cref="Logic.Script"/> object from the <see cref="ListViewItem.Tag">Tag</see> property of the instance.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="item"/> does not contain a valid <see cref="Logic.Script"/> object in it's <see cref="ListViewItem.Tag">Tag</see> property.</exception>
        public static Script RetrieveTag(ListViewItem item) => item is null
                ? throw new ArgumentNullException(nameof(item))
                : item.Tag is not Script s
                ? throw new ArgumentException($"Is not a valid {nameof(Preset)}", nameof(item.Tag))
                : s;

        /// <summary>Creates a <see cref="ListViewItem"/> from the instance and references it into it's <see cref="ListViewItem.Tag">Tag</see> property.</summary>
        /// <returns>A <see langword="new"/> <see cref="ListViewItem"/> with it's <see cref="ListViewItem.Text"/> assigned to the <see cref="Logic.Script.Name">Name</see> and
        /// <see cref="ListViewItem.ToolTipText"/> assigned to the <see cref="Logic.Script.Description">Description</see>.</returns>
        public ListViewItem ToListViewItem()
        {
            ListViewItem @new = new(Name)
            {
                ToolTipText = Description,
                Tag = this,
                Name = Name
            };
            AddStandardScriptSubItems(@new);
            return @new;
        }
        #endregion Public Methods

        #region Private Methods

        /// <summary>Adds the standard script-related <see cref="ListViewItem.ListViewSubItem"/>(s) to the specified <see cref="ListViewItem"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
        private void AddStandardScriptSubItems(ListViewItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            _ = item.SubItems.Add(Path.GetFileName(FullPath));
            _ = item.SubItems.Add(HostDisplayName);
        }

        #endregion Private Methods
    }

    #region Concrete Classes

    public class CmdScript : Script
    {
        #region Public Constructors

        /// <inheritdoc cref="Logic.Script(IEnumerable{Impact}, string, string, string)"/>
        public CmdScript(IEnumerable<Impact> impacts, string relativePath, string name, string description = "") : base(impacts, relativePath, name, description)
        {
            if (!Extensions.Contains(Path.GetExtension(relativePath)))
                throw new BadFileExtensionException(Path.GetExtension(relativePath));
            _scriptHostExecutable = "cmd.exe";
            _scriptHostArguments = $"/d /c \"{FullPath}\"";
            _comments = new StringTag[]
            {
                new StringTag("rem ", Constants.NL, true),
                new StringTag("::", Constants.NL, false)
            };
        }

        public override string[] Extensions => new string[] { ".cmd", ".bat" };
        public override string HostDisplayName => Operational.ShellPropertiesHelpers.GetFileDescription(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine));


        #endregion Public Constructors
    }

    public class Ps1Script : Script

    {
        #region Public Constructors

        /// <inheritdoc cref="Logic.Script(IEnumerable{Impact}, string, string, string)"/>
        public Ps1Script(IEnumerable<Impact> impacts, string relativePath, string name, string description = "") : base(impacts, relativePath, name, description)
        {
            if (!Extensions.Contains(Path.GetExtension(relativePath)))
                throw new BadFileExtensionException(Path.GetExtension(relativePath));
            _scriptHostExecutable = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe");
            _scriptHostArguments = $"-WindowStyle hidden -File {FullPath}";
            _comments = new StringTag[]
            {
                new StringTag("<#", "#>", false),
                new StringTag("#", Constants.NL, false)
            };
        }

        public override string[] Extensions => new string[] { ".ps1" };
        public override string HostDisplayName => Operational.ShellPropertiesHelpers.GetFileDescription(_scriptHostExecutable);

        #endregion Public Constructors
    }

    public class RegScript : Script
    {
        #region Public Constructors

        /// <inheritdoc cref="Logic.Script(IEnumerable{Impact}, string, string, string)"/>
        public RegScript(IEnumerable<Impact> impacts, string relativePath, string name, string description = "") : base(impacts, relativePath, name, description)
        {
            if (!Extensions.Contains(Path.GetExtension(relativePath)))
                throw new BadFileExtensionException(Path.GetExtension(relativePath));
            _scriptHostExecutable = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe");
            _scriptHostArguments = $"/s {FullPath}";
            _comments = new StringTag[]
            {
                new StringTag(";", Constants.NL, false)
            };
        }

        public override string[] Extensions => new string[] { ".reg" };
        public override string HostDisplayName => Operational.ShellPropertiesHelpers.GetFileDescription(_scriptHostExecutable);

        #endregion Public Constructors
    }

    public class WScript : Script
    {
        #region Public Constructors

        /// <inheritdoc cref="Logic.Script(IEnumerable{Impact}, string, string, string)"/>
        public WScript(IEnumerable<Impact> impacts, string relativePath, string name, string description = "") : base(impacts, relativePath, name, description)
        {
            if (!Extensions.Contains(Path.GetExtension(relativePath)))
                throw new BadFileExtensionException(Path.GetExtension(relativePath));
            _scriptHostExecutable = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "wscript.exe");
            _scriptHostArguments = $"{FullPath} //b //Nologo";
            _comments = new StringTag[]
            {
                new StringTag("rem ", Constants.NL, true),
                new StringTag("'", Constants.NL, false),
                new StringTag("//", Constants.NL, false),
                new StringTag("/*", "*/", false),
                new StringTag("<!--", "-->", false)
                //chaud - est-ce qu'on a tout ?
            };
        }

        public override string[] Extensions => new string[] { ".vbs", ".vbe", ".wsf", ".wsc", ".js", ".jse" };
        public override string HostDisplayName => Operational.ShellPropertiesHelpers.GetFileDescription(_scriptHostExecutable);

        #endregion Public Constructors
    }

    #endregion Concrete Classes
}
