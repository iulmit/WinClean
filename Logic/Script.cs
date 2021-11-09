// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

using RaphaëlBardini.WinClean.Operational;

using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>
/// A script that can be executed from a script host program.
/// </summary>
public class Script : ListViewItem, IScript
{
    #region Private Fields

    #region Constants

    private const byte RecommendedColorAlpha = 48;

    #endregion Constants

    private readonly FileInfo _scriptsDirFile;
    private ScriptAdvised _advised = ScriptAdvised.No;

    #endregion Private Fields

    #region Public Constructors

    /// <param name="filename">
    /// The name of the XML file containing this script's metadata, located in the scripts dir.
    /// </param>
    /// <param name="displayInto">The list view in which the script will be displayed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="filename"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="filename"/> is not a valid filename.</exception>
    /// <exception cref="Helpers.FileSystem(Exception)">
    /// <paramref name="filename"/> cannot be accessed.
    /// </exception>
    public Script(string filename, ListView displayInto)
    {
        _ = filename ?? throw new ArgumentNullException(nameof(filename));
        _ = displayInto ?? throw new ArgumentNullException(nameof(displayInto));

        if (!filename.IsValidFilename())
        {
            throw new ArgumentException("Not a valid filename", nameof(filename));
        }

        XmlDocument doc = CreateDoc();

        Name = doc.GetElementsByTagName(nameof(Name))[0].InnerText;

        _scriptsDirFile = new($"{Name.ToFilename()}.xml".InScriptsDir());

        Description = doc.GetElementsByTagName(nameof(Description))[0].InnerText;

        Advised = ScriptAdvised.ParseName(doc.GetElementsByTagName(nameof(Advised))[0].InnerText);

        Group = displayInto.Groups[doc.GetElementsByTagName(nameof(Group))[0].InnerText];

        Extension = doc.GetElementsByTagName(nameof(Extension))[0].InnerText;

        Code = doc.GetElementsByTagName(nameof(Code))[0].InnerXml;

        XmlElement impactElement = (XmlElement)doc.GetElementsByTagName(nameof(Impact))[0];
        Impact = new(ImpactLevel.ParseName(impactElement.GetAttribute(nameof(Impact.Level))),
                     ImpactEffect.ParseName(impactElement.GetAttribute(nameof(Impact.Effect))));

        XmlDocument CreateDoc()
        {
            XmlDocument d = new();
            try
            {
                d.Load(Path.Join(ScriptsDir.Info.FullName, filename));
            }
            catch (Exception e) when (e.FileSystem())
            {
                ErrorDialog.ScriptInacessible(filename, e, () => d = CreateDoc(), Delete, () => throw e);
            }
            return d;
        }
    }

    /// <param name="name">
    /// A brief infinitive sentence that describes the functionnality of this script.
    /// </param>
    /// <param name="description">
    /// Details on how this scripts work and what the effects of executing it would be.
    /// </param>
    /// <param name="advised">If running this script is advised in general purpose.</param>
    /// <param name="impact">System impacts of running this script.</param>
    /// <param name="group">
    /// The list view group the script will be part of. This parameter can be <see langword="null"/>.
    /// </param>
    /// <param name="source">The source script file.</param>
    /// <exception cref="ArgumentNullException">One or more parameters are <see langword="null"/>.</exception>
    /// <exception cref="Helpers.FileSystem(Exception)">
    /// <paramref name="source"/> cannot be accessed.
    /// </exception>
    /// <exception cref="BadFileExtensionException">
    /// <paramref name="source"/>'s extensions is not supported.
    /// </exception>
    public Script(string name, string description, ScriptAdvised advised, Impact impact, ListViewGroup? group, FileInfo source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        Name = name ?? throw new ArgumentNullException(nameof(name));
        _scriptsDirFile = new($"{Name.ToFilename()}.xml".InScriptsDir());
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Advised = advised;
        Impact = impact ?? throw new ArgumentNullException(nameof(impact));
        Group = group;
        Extension = source.Extension;
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
                ErrorDialog.ScriptInacessible(source.Name, e, () => code = GetCode(), Delete, Delete/*chaud : faire un retry close dialog*/);
            }
            return code;
        }
    }

    #endregion Public Constructors

    #region Public Properties

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">The property was set to <see langword="null"/>.</exception>
    public ScriptAdvised Advised
    {
        get => _advised;
        set
        {
            _advised = value ?? throw new ArgumentNullException(nameof(value));
            BackColor = EmulateAlpha(value.Color, Color.White, RecommendedColorAlpha);
        }
    }

    /// <inheritdoc/>
    public string Code { get; set; }

    /// <inheritdoc/>
    public string Description { get => ToolTipText; set => ToolTipText = value; }

    /// <inheritdoc/>
    public string Extension { get; }

    /// <inheritdoc/>
    public Impact Impact { get; init; }

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
    public void Execute() => ScriptHostFactory.FromFileExtension(Extension).Execute(this);

    /// <inheritdoc/>
    public void Save()
    {
        XmlDocument d = new();

        CreateDeclaration();

        AddProperties();

        SaveToScriptsDir();

        void CreateDeclaration()
            => _ = d.AppendChild(d.CreateXmlDeclaration("1.0", "Unicode", null));

        void AddProperties()
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
            n = d.CreateElement(nameof(Extension));
            n.InnerText = Extension;
            _ = root.AppendChild(n);

            // Impacts
            n = d.CreateElement(nameof(Impact));

            n.SetAttribute(nameof(Impact.Level), Impact.Level.ToString());
            n.SetAttribute(nameof(Impact.Effect), Impact.Effect.ToString());

            _ = root.AppendChild(n);

            // Group
            n = d.CreateElement(nameof(Group));
            n.InnerText = Group?.Name ?? string.Empty;
            _ = root.AppendChild(n);

            // Code
            n = d.CreateElement(nameof(Code));
            n.InnerText = Code;
            _ = root.AppendChild(n);

            _ = d.AppendChild(root);
        }

        void SaveToScriptsDir()
        {
            try
            {
                d.Save(_scriptsDirFile.FullName);
            }
            catch (Exception e) when (e.FileSystem())
            {
                ErrorDialog.CantCreateScriptFileInScriptsDir(e, SaveToScriptsDir, Program.Exit);
            }
        }
    }

    #endregion Public Methods

    #region Private Methods

    /// <seealso href="https://stackoverflow.com/a/3722337/11718061"/>
    private static Color EmulateAlpha(Color color, Color fadeIn, byte alpha)
    {
        double amount = alpha / (double)byte.MaxValue;
        return color.R == fadeIn.R && color.G == fadeIn.G && color.B == fadeIn.B
                    ? color
                    : Color.FromArgb((byte)(color.R * amount + fadeIn.R * (1 - amount)),
                                     (byte)(color.G * amount + fadeIn.G * (1 - amount)),
                                     (byte)(color.B * amount + fadeIn.B * (1 - amount)));
    }

    #endregion Private Methods
}
