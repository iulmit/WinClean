using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation.ScriptExecution;

public class ProgressPage : TaskDialogPage
{
    #region Private Fields

    private readonly TaskDialogButton _cancel = TaskDialogButton.Cancel;
    private readonly IReadOnlyList<IScript> _scripts;
    private TimeSpan _elapsed;
    private int _scriptIndex;

    #endregion Private Fields

    #region Public Constructors

    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public ProgressPage(IReadOnlyList<IScript> scripts)
    {
        _scripts = scripts ?? throw new ArgumentNullException(nameof(scripts));

        AllowCancel = AllowMinimize = true;
        Buttons = new TaskDialogButtonCollection() { _cancel };
        Caption = string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutionWizard.ProgressPageCaption, 0);
        Expander = new(string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutionWizard.ProgressPageExpander, null, null))
        {
            Expanded = Program.Settings.ShowScriptExecutionProgressDetails,
        };

        using StockIcon software = new(StockIconIdentifier.Software);
        // software.Icon alone causes ComException at ShowDialog, even though TaskDialogIcon's constructor accepts an Icon object.
        Icon = new TaskDialogIcon(software.Icon.ToBitmap());

        ProgressBar = new() { Maximum = scripts.Count };
        Text = Resources.ScriptExecutionWizard.ProgressPageText;
        Verification = new(Resources.ScriptExecutionWizard.ProgressPageVerification);

        Verification.CheckedChanged += (_, _) => AutoRestart = Verification.Checked;

        Expander.ExpandedChanged += (_, _)
            => Program.Settings.ShowScriptExecutionProgressDetails = Expander.Expanded;
    }

    #endregion Public Constructors

    #region Public Events

    public event EventHandler CancelClicked { add => _cancel.Click += value; remove => _cancel.Click -= value; }

    #endregion Public Events

    #region Public Properties

    public bool AutoRestart { get; private set; }

    public int CurrentScriptIndex
    {
        get => _scriptIndex;
        set
        {
            _scriptIndex = value;
            Update();
        }
    }

    public TimeSpan Elapsed
    {
        get => _elapsed;
        set
        {
            _elapsed = value;
            Update();
        }
    }

    #endregion Public Properties

    #region Private Methods

    private void Update()
    {
        Caption = string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutionWizard.ProgressPageCaption, CurrentScriptIndex / (double)_scripts.Count);

        if (Expander is not null)
        {
            Expander.Text = string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutionWizard.ProgressPageExpander, _scripts[CurrentScriptIndex].Name, Elapsed);
        }

        if (ProgressBar is not null)
        {
            ProgressBar.Value = CurrentScriptIndex;
        }
    }

    #endregion Private Methods
}
