// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A script that can be executed from a script host program.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237", Justification = "This class does not support serialization.")]
    public class Script : ListViewItem, IScript
    {
        #region Private Fields

        private const byte RecommendedColorAlpha = 63;
        private readonly string _extension;
        private readonly IScriptHost _host;
        private readonly FileInfo _scriptsDirFile;
        private ScriptAdvised _advised;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Script"/> class from the specified file in the scripts dir.
        /// </summary>
        /// <param name="scriptFilename">The filename of the script file in the scripts dir.</param>
        /// <param name="displayInto">The list view in which the script will be displayed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="scriptFilename"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="scriptFilename"/> is not a valid filename.</exception>
        /// <exception cref="Helpers.FileSystem(Exception)"><paramref name="scriptFilename"/> cannot be accessed.</exception>
        public Script(string scriptFilename, ListView displayInto)
        {
            _ = scriptFilename ?? throw new ArgumentNullException(nameof(scriptFilename));
            _ = displayInto ?? throw new ArgumentNullException(nameof(displayInto));

            if (!scriptFilename.IsValidFilename())
            {
                throw new ArgumentException("Not a valid filename", nameof(scriptFilename));
            }

            XmlDocument doc = CreateDoc();

            Name = doc.GetElementsByTagName(nameof(Name))[0].InnerText;
            _scriptsDirFile = new($"{Name.ToFilename()}.xml".InScriptsDir());

            Description = doc.GetElementsByTagName(nameof(Description))[0].InnerText;
            Advised = Enum.Parse<ScriptAdvised>(doc.GetElementsByTagName(nameof(Advised))[0].InnerText);

            string groupKey = doc.GetElementsByTagName(nameof(Group))[0].InnerText;
            Group = displayInto.Groups[groupKey];

            _extension = doc.GetElementsByTagName("Extension")[0].InnerText;

            _host = ScriptHost.FromFileExtension(_extension);

            foreach (XmlElement impactElement in doc.GetElementsByTagName(nameof(Impact)))
            {
                Impacts.Add(new(Enum.Parse<ImpactLevel>(impactElement.GetAttribute(nameof(Impact.Level))),
                                Enum.Parse<ImpactEffect>(impactElement.GetAttribute(nameof(Impact.Effect)))));
            }

            Code = doc.GetElementsByTagName("Code")[0].InnerXml;

            XmlDocument CreateDoc()
            {
                XmlDocument d = new();
                try
                {
                    d.Load(Path.Join(ScriptsDir.Info.FullName, scriptFilename));
                }
                catch (Exception e) when (e.FileSystem())
                {
                    ErrorDialog.ScriptInacessible(scriptFilename, e, () => d = CreateDoc(), Delete, () => throw e);
                }
                return d;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Script"/> class.</summary>
        /// <param name="name">A brief infinitive sentence that describes the functionnality of this script.</param>
        /// <param name="description">Details on how this scripts work and what the effects of executing it would be.</param>
        /// <param name="advised">If running this script is advised in general purpose.</param>
        /// <param name="impacts">System impacts of running this script.</param>
        /// <param name="group">The list view group the script will be part of. This parameter can be <see langword="null"/>.</param>
        /// <param name="source">The source script file.</param>
        /// <exception cref="ArgumentNullException">One or more parameters are <see langword="null"/>.</exception>
        /// <exception cref="Helpers.FileSystem(Exception)"><paramref name="source"/> cannot be accessed.</exception>
        /// <exception cref="BadFileExtensionException"><paramref name="source"/>'s extensions is not supported.</exception>
        public Script(string name, string description, ScriptAdvised advised, ICollection<Impact> impacts, ListViewGroup group, FileInfo source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            _host = ScriptHost.FromFileExtension(source.Extension);
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _scriptsDirFile = new($"{Name.ToFilename()}.xml".InScriptsDir());
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Advised = advised;
            Impacts = impacts ?? throw new ArgumentNullException(nameof(impacts));
            Group = group;
            _extension = source.Extension;
            Code = GetCode();

            string GetCode()
            {
                string code = string.Empty;
                try
                {
                    code = File.ReadAllText(source.FullName);
                }
                catch (Exception e) when (e.FileSystem())
                {
                    ErrorDialog.ScriptInacessible(source.Name, e, () => code = GetCode(), Delete, () => throw e);
                }
                return code;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <inheritdoc/>
        /// <remarks>Set accessor changes the background color.</remarks>
        public ScriptAdvised Advised
        {
            get => _advised;
            set
            {
                _advised = value;
                BackColor = EmulateAlpha(GetColor(value), Color.White, RecommendedColorAlpha);
            }
        }

        /// <inheritdoc/>
        public string Code { get; }

        /// <inheritdoc/>
        public string Description { get => ToolTipText; set => ToolTipText = value; }

        /// <inheritdoc/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227", Justification = "Bug")]
        public ICollection<Impact> Impacts { get; init; } = new List<Impact>();

        /// <inheritdoc/>
        public new string Name { get => Text; set => Text = value; }

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc/>
        public void Delete()
        {
            base.Remove();
            try
            {
                _scriptsDirFile.Delete();
            }
            catch (Exception e) when (e.FileSystem())
            {
                ErrorDialog.CantDeleteScript(e, Delete);
            }
        }

        /// <inheritdoc/>
        public void Execute() => _host.Execute(this);

        /// <inheritdoc/>
        public void Save()
        {
            XmlDocument doc = new();

            CreateDeclaration(doc);

            AddProperties(doc);

            SaveToScriptsDir(doc);

            static void CreateDeclaration(XmlDocument d)
                => _ = d.AppendChild(d.CreateXmlDeclaration("1.0", "Unicode", null));

            void AddProperties(XmlDocument d)
            {
                XmlElement root = d.CreateElement("Script");

                XmlElement n;

                // Name
                n = d.CreateElement(nameof(Name)); // Creation
                n.InnerText = Name;                // Assignment
                _ = root.AppendChild(n);           // Addition

                // Description
                n = d.CreateElement(nameof(Description));
                n.InnerText = Description;
                _ = root.AppendChild(n);

                // Advised
                n = d.CreateElement(nameof(Advised));
                n.InnerText = _advised.ToString();
                _ = root.AppendChild(n);

                // Host
                n = d.CreateElement("Extension");
                n.InnerText = _extension;
                _ = root.AppendChild(n);

                // Impacts
                n = d.CreateElement(nameof(Impacts));
                foreach (Impact impact in Impacts)
                {
                    XmlElement impactElement = d.CreateElement(nameof(Impact));

                    impactElement.SetAttribute(nameof(Impact.Level), impact.Level.ToString());
                    impactElement.SetAttribute(nameof(Impact.Effect), impact.Effect.ToString());

                    _ = n.AppendChild(impactElement);
                }
                _ = root.AppendChild(n);

                // Group
                n = d.CreateElement(nameof(Group));
                n.InnerText = Group.Name;
                _ = root.AppendChild(n);

                // Code
                n = d.CreateElement("Code");
                n.InnerText = Code;
                _ = root.AppendChild(n);

                _ = d.AppendChild(root);
            }

            void SaveToScriptsDir(XmlDocument d)
            {
                try
                {
                    d.Save(_scriptsDirFile.FullName);
                }
                catch (Exception e) when (e.FileSystem())
                {
                    ErrorDialog.CantCreateScriptFileInScriptsDir(e, () => SaveToScriptsDir(d), Program.Exit);
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>Emulates alpha transparency to a specified color.</summary>
        /// <param name="color">The main color.</param>
        /// <param name="fadeIn">The color "behind" the main color.</param>
        /// <param name="alpha">The alpha byte color component to use.</param>
        /// <returns><paramref name="color"/>, blended into <paramref name="fadeIn"/>.</returns>
        /// <remarks>Real alpha values of <paramref name="color"/> and <paramref name="fadeIn"/> are ignored.</remarks>
        /// .
        /// <seealso href="https://stackoverflow.com/a/3722337/11718061"/>
        private static Color EmulateAlpha(Color color, Color fadeIn, byte alpha)
            => color.R == fadeIn.R && color.G == fadeIn.G && color.B == fadeIn.B
                ? color
                : Color.FromArgb((byte)(color.R * (alpha / (double)byte.MaxValue) + fadeIn.R * (1 - alpha / (double)byte.MaxValue)),
                                 (byte)(color.G * (alpha / (double)byte.MaxValue) + fadeIn.G * (1 - alpha / (double)byte.MaxValue)),
                                 (byte)(color.B * (alpha / (double)byte.MaxValue) + fadeIn.B * (1 - alpha / (double)byte.MaxValue)));

        /// <exception cref="InvalidEnumArgumentException">
        /// <paramref name="scriptAdvised"/> is not a defined <see cref="ScriptAdvised"/> constant.
        /// </exception>
        private static Color GetColor(ScriptAdvised scriptAdvised) => scriptAdvised switch
        {
            ScriptAdvised.Unspecified => Color.White,
            ScriptAdvised.Yes => Color.Green,
            ScriptAdvised.Limited => Color.Orange,
            ScriptAdvised.No => Color.Red,
            _ => throw new InvalidEnumArgumentException(nameof(scriptAdvised), (int)scriptAdvised, typeof(ScriptAdvised))
        };

        #endregion Private Methods
    }
}
