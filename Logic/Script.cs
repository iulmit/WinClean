﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Operational;

using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>A script that can be executed from a script host program.</summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237", Justification = "Binary serialization is not supported")]
public class Script : ListViewItem, IScript
{
    #region Private Fields

    #region Constants

    private const byte RecommendedColorAlpha = 48;

    #endregion Constants

    private readonly FileInfo _file;
    private ScriptAdvised _advised = ScriptAdvised.No;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>Initializes a new instance of the <see cref="Script"/> class from the specified XML script file.</summary>
    /// <param name="filename">The name of the XML file containing this script's metadata, located in the scripts dir.</param>
    /// <param name="displayInto">The list view in which the script will be displayed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="filename"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="filename"/> is not a valid filename.</exception>
    /// <exception cref="Helpers.FileSystem(Exception)"><paramref name="filename"/> cannot be accessed.</exception>
    public Script(string filename, ListView displayInto)
    {
        _ = filename ?? throw new ArgumentNullException(nameof(filename));
        _ = displayInto ?? throw new ArgumentNullException(nameof(displayInto));

        if (!filename.IsValidFilename())
        {
            throw new ArgumentException("Not a valid filename", nameof(filename));
        }

        XmlDocument doc = CreateDoc();

        Name = doc.GetElementsByTagName(nameof(Name))[0].FailNull().InnerText;

        _file = new($"{Name.ToFilename()}.xml".InScriptsDir());

        Description = doc.GetElementsByTagName(nameof(Description))[0].FailNull().InnerText;

        Advised = ScriptAdvised.ParseName(doc.GetElementsByTagName(nameof(Advised))[0].FailNull().InnerText);

        Group = displayInto.Groups[doc.GetElementsByTagName(nameof(Group))[0].FailNull().InnerText];

        Extension = doc.GetElementsByTagName(nameof(Extension))[0].FailNull().InnerText;

        Code = doc.GetElementsByTagName(nameof(Code))[0].FailNull().InnerXml;

        XmlElement impactElement = (XmlElement)doc.GetElementsByTagName(nameof(Impact))[0].FailNull();
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
                ErrorDialog.ScriptInacessible(filename, e, () => d = CreateDoc(), Program.Exit);
            }
            return d;
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Script"/> class with the specified data.</summary>
    /// <param name="name">A brief infinitive sentence that describes the functionnality of this script.</param>
    /// <param name="description">Details on how this scripts work and what the effects of executing it would be.</param>
    /// <param name="advised">If running this script is advised in general purpose.</param>
    /// <param name="impact">System impacts of running this script.</param>
    /// <param name="group">The list view group the script will be part of. This parameter can be <see langword="null"/>.</param>
    /// <param name="source">The source script file.</param>
    /// <exception cref="ArgumentNullException">One or more parameters are <see langword="null"/>.</exception>
    /// <exception cref="Helpers.FileSystem(Exception)"><paramref name="source"/> cannot be accessed.</exception>
    public Script(string name, string description, ScriptAdvised advised, Impact impact, ListViewGroup? group, FileInfo source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        Name = name ?? throw new ArgumentNullException(nameof(name));
        _file = new($"{Name.ToFilename()}.xml".InScriptsDir());
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
                ErrorDialog.ScriptInacessible(source.Name, e, () => code = GetCode(), Program.Exit);
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

    public string Code { get; set; }

    public string Description { get => ToolTipText; set => ToolTipText = value; }

    public string Extension { get; }

    public Impact Impact { get; init; }

    public new string Name { get => Text; set => Text = value; }

    #endregion Public Properties

    #region Public Methods

    public void Delete()
    {
        base.Remove();
        try
        {
            _file.Delete();
        }
        catch (Exception e) when (e.FileSystem())
        {
            ErrorDialog.CantDeleteScript(e, Delete);
        }
    }

    public void Execute() => ScriptHostFactory.FromFileExtension(Extension).Execute(this);

    public void Save()
    {
        XmlDocument doc = new();

        CreateDeclaration();

        AddProperties();

        SaveToScriptsDir();

        void CreateDeclaration()
            => _ = doc.AppendChild(doc.CreateXmlDeclaration("1.0", "Unicode", null));

        void AddProperties()
        {
            XmlElement root = doc.CreateElement(nameof(Script));

            XmlElement current;

            // Name
            current = doc.CreateElement(nameof(Name)); // Creation
            current.InnerText = Name;                // Assignment
            _ = root.AppendChild(current);           // Addition

            // Description
            current = doc.CreateElement(nameof(Description));
            current.InnerText = Description;
            _ = root.AppendChild(current);

            // Advised
            current = doc.CreateElement(nameof(Advised));
            current.InnerText = _advised.ToString();
            _ = root.AppendChild(current);

            // Host
            current = doc.CreateElement(nameof(Extension));
            current.InnerText = Extension;
            _ = root.AppendChild(current);

            // Impacts
            current = doc.CreateElement(nameof(Impact));

            current.SetAttribute(nameof(Impact.Level), Impact.Level.ToString());
            current.SetAttribute(nameof(Impact.Effect), Impact.Effect.ToString());

            _ = root.AppendChild(current);

            // Group
            current = doc.CreateElement(nameof(Group));
            current.InnerText = Group?.Name ?? string.Empty;
            _ = root.AppendChild(current);

            // Code
            current = doc.CreateElement(nameof(Code));
            current.InnerText = Code;
            _ = root.AppendChild(current);

            _ = doc.AppendChild(root);
        }

        void SaveToScriptsDir()
        {
            try
            {
                doc.Save(_file.FullName);
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
