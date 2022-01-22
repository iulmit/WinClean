using RaphaëlBardini.WinClean.Operational;
using RaphaëlBardini.WinClean.Presentation.Dialogs;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>Represents the scripts dir of the application root directory.</summary>
public class ScriptsDir
{
    #region Private Constructors

    private ScriptsDir()
    {
        Info = GetOrCreate();

        static DirectoryInfo GetOrCreate()
        {
            DirectoryInfo dir = new(Path.Join(AppDir.Instance.Info.FullName, "Scripts"));
            try
            {
                dir.Create();
            }
            catch (Exception e) when (e.FileSystem())
            {
                new FSErrorDialog(e, FSVerb.Create, dir).ShowDialog(() => dir = GetOrCreate());
            }
            return dir;
        }
    }

    #endregion Private Constructors

    #region Public Properties

    public static ScriptsDir Instance { get; } = new();

    /// <summary>The group directories contained in the scripts dir.</summary>
    public IEnumerable<GroupDir> Groups => Info.EnumerateDirectories().Select((dir) => new GroupDir(dir));

    public DirectoryInfo Info { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Joins the specified path components with the path of the scripts directory.</summary>
    /// <param name="paths">The path components to join with the scripts dir.</param>
    /// <returns>The concatenated path.</returns>
    public string Join(params string[] paths) => Path.Join(paths.Prepend(Info.FullName).ToArray());

    /// <summary>Loads all the scripts present in the scripts directory.</summary>
    /// <param name="owner">The listView to load the scripts into.</param>
    /// <returns>The scripts previously saved into the scripts dir.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/> is <see langword="null"/>.</exception>
    public void LoadScripts(ListView owner)
    {
        _ = owner ?? throw new ArgumentNullException(nameof(owner));
        foreach (FileInfo script in Info.EnumerateFiles("*.xml", SearchOption.AllDirectories))
        {
            _ = owner.Items.Add(new ScriptListViewItem(new ScriptXmlSerializer(Info).Deserialize(script), owner));
        }
    }

    #endregion Public Methods
}
