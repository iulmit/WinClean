using RaphaëlBardini.WinClean.Operational;

using System.Xml;

namespace RaphaëlBardini.WinClean.Logic;

public class ScriptXmlSerializer : IScriptSerializer
{
    #region Constants

    private const string LCIDTagNamePrefix = "lcid";

    #endregion Constants

    #region Private Fields

    private readonly DirectoryInfo _scriptsDir;
    private string? lastSerializationPath;

    #endregion Private Fields

    #region Public Constructors

    public ScriptXmlSerializer(DirectoryInfo scriptsDir) => _scriptsDir = scriptsDir ?? throw new ArgumentNullException(nameof(scriptsDir));

    #endregion Public Constructors

    #region Public Methods

    /// <summary>Deserializes a script from an XML file.</summary>
    /// <param name="source">The XML file.</param>
    /// <returns>A new <see cref="IScript"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    /// <exception cref="XmlException"><paramref name="source"/> is not a valid XML document.</exception>
    /// <exception cref="DirectoryNotFoundException">
    /// <paramref name="source"/> is invalid (for example, it is on an unmapped drive).
    /// </exception>
    /// <exception cref="IOException">An I/O error occurred while opening <paramref name="source"/>.</exception>
    /// <exception cref="UnauthorizedAccessException">
    /// <paramref name="source"/> is readonly. -or- The caller does not have the required permission.
    /// </exception>
    /// <exception cref="FileNotFoundException"><paramref name="source"/> was not found.</exception>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    public IScript Deserialize(FileInfo source)
    {
        string groupDirName = (source ?? throw new ArgumentNullException(nameof(source))).Directory!.Name; // ! : wont return null as _file will never be a root directory

        XmlDocument doc = new();
        doc.Load(source.FullName);

        return new Script
        (
            GetLocalized("Name"),
            GetLocalized("Description"),
            GetMoreInfoUrl(),
            ScriptAdvised.ParseName(doc.GetElementsByTagName("Advised")[0].AssertNotNull().InnerText.Trim()),
            Impact.ParseName(doc.GetElementsByTagName("Impact")[0].AssertNotNull().InnerText),
            groupDirName,
            doc.GetElementsByTagName("Extension")[0].AssertNotNull().InnerText.Trim(),
            doc.GetElementsByTagName("Code")[0].AssertNotNull().InnerXml.Trim()
        );
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
        Uri? GetMoreInfoUrl()
        {
            string url = GetLocalized("MoreInfoUrl");
            return string.IsNullOrEmpty(url) ? null : new Uri(url);
        }
    }

    public void Serialize(IScript s)
    {
        _ = s ?? throw new ArgumentNullException(nameof(s));
        XmlDocument doc = new();

        _ = doc.AppendChild(doc.CreateXmlDeclaration("1.0", "Unicode", null));

        XmlElement root = doc.CreateElement(nameof(Script));

        {
            XmlElement name = doc.CreateElement("Name");
            CreateAppend(name, GetLCIDTagName(), s.Name);
            _ = root.AppendChild(name);
        }

        {
            XmlElement description = doc.CreateElement("Description");
            CreateAppend(description, GetLCIDTagName(), s.Description);
            _ = root.AppendChild(description);
        }

        {
            XmlElement moreInfoUrl = doc.CreateElement("MoreInfoUrl");
            CreateAppend(moreInfoUrl, GetLCIDTagName(), s.MoreInfoUrl?.OriginalString);
            _ = root.AppendChild(moreInfoUrl);
        }

        CreateAppend(root, "Advised", s.Advised.ToString());
        CreateAppend(root, "Extension", s.Extension);
        CreateAppend(root, "Impact", s.Impact.ToString());
        CreateAppend(root, "Code", s.Code);

        _ = doc.AppendChild(root);

        void CreateAppend(XmlElement parent, string name, string? innerText)
        {
            XmlElement e = doc.CreateElement(name);
            e.InnerText = innerText ?? string.Empty;
            _ = parent.AppendChild(e);
        }

        string GetLCIDTagName()
            => LCIDTagNamePrefix + CultureInfo.InvariantCulture.LCID.ToString(CultureInfo.InvariantCulture);

        /*
        - Supprimer lastSerializationPath
        - Creer le dossier de groupe s'il n'existe pas deja
        - Sauvegarder à serlializationPath
        */

        if (lastSerializationPath is not null)
        {
            File.Delete(lastSerializationPath);
        }
        string groupDirPath = Path.Join(_scriptsDir.FullName, s.Group);

        _ = Directory.CreateDirectory(groupDirPath);

        string serializationPath = Path.Join(groupDirPath, $"{s.Name.ToFilename()}.xml");

        doc.Save(serializationPath);

        lastSerializationPath = serializationPath;
    }

    #endregion Public Methods
}
