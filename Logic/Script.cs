using RaphaëlBardini.WinClean.Operational;

using System.Xml;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>A script that can be executed from a script host program.</summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237", Justification = "Binary serialization is not supported")]
public class Script : ListViewItem, IScript
{
    #region Private Fields

    #region Constants

    private const byte AdvisedColorAlpha = 48;
    private const string LCIDTagNamePrefix = "lcid";

    #endregion Constants

    private readonly FileInfo _file;
    private ScriptAdvised _advised = ScriptAdvised.No;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>Initializes a new instance of the <see cref="Script"/> class from the specified XML script file.</summary>
    /// <param name="file">The XML file containing this script's metadata, located in a group subdirectory of the scripts dir.</param>
    /// <param name="owner">The list view in which the script will be displayed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="file"/> or <paramref name="owner"/> are <see langword="null"/>.</exception>
    public Script(FileInfo file, ListView owner)
    {
        _ = owner ?? throw new ArgumentNullException(nameof(owner));
        _file = file ?? throw new ArgumentNullException(nameof(file));
        XmlDocument doc = CreateDoc();

        Name = GetLocalized(nameof(Name));
        Description = GetLocalized(nameof(Description));

        Advised = ScriptAdvised.ParseName(doc.GetElementsByTagName(nameof(Advised))[0].AssertNotNull().InnerText.Trim());

        string groupDirName = _file.Directory!.Name; // ! : wont return null as _file will never be a root directory
        Group = owner.Groups[groupDirName] ?? owner.Groups.Add(groupDirName, groupDirName);

        Extension = doc.GetElementsByTagName(nameof(Extension))[0].AssertNotNull().InnerText.Trim();

        Code = doc.GetElementsByTagName(nameof(Code))[0].AssertNotNull().InnerXml.Trim();

        Impact = Impact.ParseName(doc.GetElementsByTagName(nameof(Impact))[0].AssertNotNull().InnerText);

        XmlDocument CreateDoc()
        {
            XmlDocument d = new();
            try
            {
                d.Load(file.FullName);
            }
            catch (Exception e) when (e.FileSystem())
            {
                new Dialogs.FSErrorDialog(e, FSVerb.Acess, file).ShowDialog(() => d = CreateDoc());
            }
            return d;
        }
        string GetLocalized(string rootTagName)
        {
            IEnumerable<XmlElement> available = doc.GetElementsByTagName(rootTagName)[0].AssertNotNull().ChildNodes.OfType<XmlElement>();
            string? localized = null;
            for (CultureInfo culture = CultureInfo.CurrentUICulture; localized is null; culture = culture.Parent)
            {
                localized = available.FirstOrDefault(element => element.Name == LCIDTagNamePrefix + culture.LCID.ToString(CultureInfo.InvariantCulture))?.InnerText;
                if (culture.Equals(CultureInfo.InvariantCulture))
                {
                    break;
                }
            }
            return localized?.Trim() ?? string.Empty;
        }
    }

    /// <summary>Initializes a new instance of the <see cref="Script"/> class with the specified data.</summary>
    /// <param name="name">A brief infinitive sentence that describes the functionnality of this script.</param>
    /// <param name="description">Details on how this scripts work and what the effects of executing it would be.</param>
    /// <param name="advised">If running this script is advised in general purpose.</param>
    /// <param name="impact">System impacts of running this script.</param>
    /// <param name="group">The list view group to contain the script in.</param>
    /// <param name="source">The source script file.</param>
    /// <exception cref="ArgumentNullException">One or more parameters are <see langword="null"/>.</exception>
    public Script(string name, string description, ScriptAdvised advised, Impact impact, ListViewGroup group, FileInfo source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = group ?? throw new ArgumentNullException(nameof(group));

        Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
        _file = new(AppDir.ScriptsDir.Join(group.Header, $"{Name.ToFilename()}.xml"));
        Description = description?.Trim() ?? throw new ArgumentNullException(nameof(description));
        Advised = advised;
        Impact = impact ?? throw new ArgumentNullException(nameof(impact));
        Group = group;
        Extension = source.Extension.Trim();
        Code = GetCode();

        string GetCode()
        {
            string code = string.Empty;
            try
            {
                code = File.ReadAllText(source.FullName).Trim();
            }
            catch (Exception e) when (e.FileSystem())
            {
                new Dialogs.FSErrorDialog(e, FSVerb.Acess, source).ShowDialog(() => code = GetCode());
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
            BackColor = EmulateAlpha(value.Color, Color.White, AdvisedColorAlpha);
        }
    }

    public string Code { get; set; }

    public string Description { get => ToolTipText; set => ToolTipText = value; }

    public string Extension { get; }

    public Impact Impact { get; set; }

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
            new Dialogs.FSErrorDialog(e, FSVerb.Delete, _file).ShowDialog(Delete);
        }
    }

    public void Execute() => ScriptHostFactory.FromFileExtension(Extension).Execute(this, Program.Settings.ScriptTimeout);

    public void Save()
    {
        XmlDocument doc = new();

        _ = doc.AppendChild(doc.CreateXmlDeclaration("1.0", "Unicode", null));

        AddProperties();

        SaveToScriptsDir();

        void AddProperties()
        {
            XmlElement root = doc.CreateElement(nameof(Script));

            {
                XmlElement name = doc.CreateElement(nameof(Name));
                CreateAppend(name, GetLCIDTagName(), Name);
                _ = root.AppendChild(name);
            }

            {
                XmlElement description = doc.CreateElement(nameof(Description));
                CreateAppend(description, GetLCIDTagName(), Description);
                _ = root.AppendChild(description);
            }

            CreateAppend(root, nameof(Advised), Advised.ToString());
            CreateAppend(root, nameof(Extension), Extension);
            CreateAppend(root, nameof(Impact), Impact.ToString());

            CreateAppend(root, nameof(Code), Code);

            _ = doc.AppendChild(root);

            void CreateAppend(XmlElement parent, string name, string innerText)
            {
                XmlElement e = doc.CreateElement(name);
                e.InnerText = innerText;
                _ = parent.AppendChild(e);
            }

            string GetLCIDTagName()
                => LCIDTagNamePrefix + CultureInfo.InvariantCulture.LCID.ToString(CultureInfo.InvariantCulture);
        }

        void SaveToScriptsDir()
        {
            string correctPath = Path.Join(CreateGroupDirectory().FullName, $"{Name.ToFilename()}.xml");

            if (_file.Exists)
            {
                MoveScriptFileInAppropriateGroupDir();
            }
            else
            {
                doc.Save(correctPath);
            }

            void MoveScriptFileInAppropriateGroupDir()
            {
                DirectoryInfo oldGroupDir = _file.Directory!;// ! : _file will never be a root directory

                try
                {
                    _file.MoveTo(correctPath);
                }
                catch (Exception e) when (e.FileSystem())
                {
                    new Dialogs.FSErrorDialog(e, FSVerb.Move, _file).ShowDialog(MoveScriptFileInAppropriateGroupDir);
                }

                DeleteOldGroupDirIfEmpty();

                void DeleteOldGroupDirIfEmpty()
                {
                    if (!oldGroupDir.EnumerateFileSystemInfos().Any())
                    {
                        try
                        {
                            oldGroupDir.Delete();
                        }
                        catch (Exception e) when (e.FileSystem())
                        {
                            new Dialogs.FSErrorDialog(e, FSVerb.Delete, oldGroupDir).ShowDialog(DeleteOldGroupDirIfEmpty);
                        }
                    }
                }
            }
            DirectoryInfo CreateGroupDirectory()
            {
                DirectoryInfo groupDir = new(AppDir.ScriptsDir.Join(Group.Header));
                try
                {
                    groupDir.Create();
                }
                catch (Exception e) when (e.FileSystem())
                {
                    new Dialogs.FSErrorDialog(e, FSVerb.Create, groupDir).ShowDialog(() => groupDir = CreateGroupDirectory());
                }
                return groupDir;
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
