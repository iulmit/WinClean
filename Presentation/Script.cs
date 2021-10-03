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
        #region Public Constructors

        /// <inheritdoc cref="Logic.Script.Script(string, string, string, IEnumerable{Impact})"/>
        /// <param name="group">The list view group of the instance.</param>
        protected Script(string name, string description, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : base(name, description, filenameOrPath, impacts) =>
            Group = group ?? throw new ArgumentNullException(nameof(group));

        /// <inheritdoc cref="Script(string, string, ListViewGroup, string, IEnumerable{Impact})"/>
        protected Script(string name, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : this(name, string.Empty, group, filenameOrPath, impacts)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public ListViewGroup Group { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Retrieves a <see cref="Logic.Script"/> object from the <see cref="ListViewItem.Tag">Tag</see> property of the instance.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="item"/> does not contain a valid <see cref="Logic.Script"/> object in it's <see cref="ListViewItem.Tag">Tag</see> property.</exception>
        public static Script Retrieve(ListViewItem item) => item is null
                ? throw new ArgumentNullException(nameof(item))
                : item.Tag is not Script s
                ? throw new ArgumentException($"Must be a valid {nameof(Script)}", nameof(item))
                : s;

        /// <summary>Creates a <see cref="ListViewItem"/> from the instance and references it into it's <see cref="ListViewItem.Tag">Tag</see> property.</summary>
        /// <returns>
        /// A <see langword="new"/><see cref="ListViewItem"/> with it's <see cref="ListViewItem.Text"/> assigned to the <see cref="Logic.Script.Name">Name</see> and <see
        /// cref="ListViewItem.ToolTipText"/> assigned to the <see cref="Logic.Script.Description">Description</see>.
        /// </returns>
        public ListViewItem ToListViewItem() => new(Group)
        {
            Text = Name,
            Name = Name,
            ToolTipText = Description,
            Tag = this
        };

        #endregion Public Methods
    }

    #region Concrete Classes

    public class CmdScript : Script
    {
        #region Public Constructors

        /// <inheritdoc cref="Script(string, string, ListViewGroup, string, IEnumerable{Impact})"/>
        public CmdScript(string name, string description, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : base(name, description, group, filenameOrPath, impacts)
        {
            if (!Extensions.Contains(Path.GetExtension(filenameOrPath)))
                throw new BadFileExtensionException(Path.GetExtension(filenameOrPath));
            ScriptHostExecutable = "cmd.exe";
            ScriptHostArguments = $"/d /c \"{FullPath}\"";
            Comments = new StringTag[]
            {
                new StringTag("rem ", Constants.NL, true),
                new StringTag("::", Constants.NL, false)
            };
        }

        /// <inheritdoc cref="CmdScript(string, string, ListViewGroup, string, IEnumerable{Impact})"/>
        public CmdScript(string name, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : this(name, string.Empty, group, filenameOrPath, impacts)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public override string[] Extensions => new string[] { ".cmd", ".bat" };
        public override string HostDisplayName => Operational.ShellPropertiesHelpers.GetFileDescription(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine));

        #endregion Public Properties
    }

    public class Ps1Script : Script

    {
        #region Public Constructors

        /// <inheritdoc cref="Logic.Script(IEnumerable{Impact}, string, string, string)"/>
        public Ps1Script(string name, string description, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : base(name, description, group, filenameOrPath, impacts)
        {
            if (!Extensions.Contains(Path.GetExtension(filenameOrPath)))
                throw new BadFileExtensionException(Path.GetExtension(filenameOrPath));
            ScriptHostExecutable = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe");
            ScriptHostArguments = $"-WindowStyle hidden -File {FullPath}";
            Comments = new StringTag[]
            {
                new StringTag("<#", "#>", false),
                new StringTag("#", Constants.NL, false)
            };
        }

        /// <inheritdoc cref="Ps1Script(string, string, ListViewGroup, string, IEnumerable{Impact})"/>
        public Ps1Script(string name, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : this(name, string.Empty, group, filenameOrPath, impacts)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public override string[] Extensions => new string[] { ".ps1" };
        public override string HostDisplayName => Operational.ShellPropertiesHelpers.GetFileDescription(ScriptHostExecutable);

        #endregion Public Properties
    }

    public class RegScript : Script
    {
        #region Public Constructors

        /// <inheritdoc cref="Logic.Script(IEnumerable{Impact}, string, string, string)"/>
        public RegScript(string name, string description, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : base(name, description, group, filenameOrPath, impacts)
        {
            if (!Extensions.Contains(Path.GetExtension(filenameOrPath)))
                throw new BadFileExtensionException(Path.GetExtension(filenameOrPath));
            ScriptHostExecutable = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe");
            ScriptHostArguments = $"/s {FullPath}";
            Comments = new StringTag[]
            {
                new StringTag(";", Constants.NL, false)
            };
        }

        /// <inheritdoc cref="RegScript(string, string, ListViewGroup, string, IEnumerable{Impact})"/>
        public RegScript(string name, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : this(name, string.Empty, group, filenameOrPath, impacts)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public override string[] Extensions => new string[] { ".reg" };
        public override string HostDisplayName => Operational.ShellPropertiesHelpers.GetFileDescription(ScriptHostExecutable);

        #endregion Public Properties
    }

    public class WScript : Script
    {
        #region Public Constructors

        /// <inheritdoc cref="Logic.Script(IEnumerable{Impact}, string, string, string)"/>
        public WScript(string name, string description, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : base(name, description, group, filenameOrPath, impacts)
        {
            if (!Extensions.Contains(Path.GetExtension(filenameOrPath)))
                throw new BadFileExtensionException(Path.GetExtension(filenameOrPath));
            ScriptHostExecutable = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "wscript.exe");
            ScriptHostArguments = $"{FullPath} //b //Nologo";
            Comments = new StringTag[]
            {
                new StringTag("rem ", Constants.NL, true),
                new StringTag("'", Constants.NL, false),
                new StringTag("//", Constants.NL, false),
                new StringTag("/*", "*/", false),
                new StringTag("<!--", "-->", false)
            };
        }

        /// <inheritdoc cref="WScript(string, string, ListViewGroup, string, IEnumerable{Impact})"/>
        public WScript(string name, ListViewGroup group, string filenameOrPath, IEnumerable<Impact> impacts) : this(name, string.Empty, group, filenameOrPath, impacts)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public override string[] Extensions => new string[] { ".vbs", ".vbe", ".wsf", ".js", ".jse" };
        public override string HostDisplayName => Operational.ShellPropertiesHelpers.GetFileDescription(ScriptHostExecutable);

        #endregion Public Properties
    }

    #endregion Concrete Classes
}
