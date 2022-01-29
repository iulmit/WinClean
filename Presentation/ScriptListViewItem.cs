using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Presentation;

// Implementation of the Adapter pattern between IScript and ListViewItem Hosts policies for displaying scripts as ListViewItems
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237:Marquer les types ISerializable avec serializable", Justification = "Nah")]
public class ScriptListViewItem : ListViewItem, IScript
{
    #region Constants

    private const byte AdvisedColorAlpha = 48;

    #endregion Constants

    #region Private Fields

    private readonly IScript _adaptee;
    private readonly ListView _owner;

    #endregion Private Fields

    #region Public Constructors

    public ScriptListViewItem(IScript adaptee, ListView owner)
    {
        _owner = owner ?? throw new ArgumentNullException(nameof(owner));
        _adaptee = adaptee ?? throw new ArgumentNullException(nameof(adaptee));
        ToolTipText = adaptee.Description;
        Text = adaptee.Name;
        base.Group = GetOrCreateScriptGroup(adaptee.Group);
        BackColor = EmulateAlpha(adaptee.Advised.Color, Color.White, AdvisedColorAlpha);
    }

    #endregion Public Constructors

    #region Public Properties

    public ScriptAdvised Advised
    {
        get => _adaptee.Advised;
        set
        {
            _adaptee.Advised = value ?? throw new ArgumentNullException(nameof(value));
            BackColor = EmulateAlpha(value.Color, Color.White, AdvisedColorAlpha);
        }
    }

    public string Code { get => _adaptee.Code; set => _adaptee.Code = value; }
    public string Description { get => ToolTipText; set => _adaptee.Description = ToolTipText = value; }

    public Uri? MoreInfoUrl { get => _adaptee.MoreInfoUrl; set => _adaptee.MoreInfoUrl = value; }
    public string Extension => _adaptee.Extension;

    public new string Group
    {
        get => _adaptee.Group;
        set
        {
            _adaptee.Group = value;
            base.Group = GetOrCreateScriptGroup(value);
        }
    }

    public Impact Impact { get => _adaptee.Impact; set => _adaptee.Impact = value; }

    public new string Name { get => Text; set => Text = value; }

    #endregion Public Properties

    #region Public Methods

    public void Delete() => Remove();

    public void Execute(TimeSpan timeout, Func<string, bool> promptKillOnHung, Func<Exception, FileSystemInfo, FSVerb, bool> promptRetryOnFSError, int promptLimit)
        => _adaptee.Execute(timeout, promptKillOnHung, promptRetryOnFSError, promptLimit);

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

    private ListViewGroup GetOrCreateScriptGroup(string header)
        // search for the group in the owner list view, if not found, add a new group to the owner list view with the specified header.
        => _owner.Groups.OfType<ListViewGroup>().FirstOrDefault(group => group.Header == header) ?? _owner.Groups.Add(null, header);

    #endregion Private Methods
}
