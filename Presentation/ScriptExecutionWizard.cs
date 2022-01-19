using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Operational;

using System.Diagnostics;

/* Steps :
 * Warning. Show a warning message. Force the user to read it using a verification checkbox.
 * InProgress. Execute the scripts asynchronously and dynamically show progress.
 * Completed. Show results and prompt a reboot. Give advice on further optimizations.
*/

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>Walk the user through the asynchronous execution of scripts by displaying a task dialog tracking the progress.</summary>
public class ScriptExecutionWizard
{
    #region Private Fields

    private readonly IList<IScript> _scripts;

    private UIStep _uiStep = UIStep.NotStarted;

    private readonly ScriptExecutor _executor = new();

    #endregion Private Fields

    #region Private Enums

    private enum UIStep
    {
        NotStarted,
        Warning,
        InProgress,
        Completed
    }

    #endregion Private Enums

    #region Public Constructors

    /// <param name="scripts">The scripts to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public ScriptExecutionWizard(IList<IScript> scripts)
    {
        if (scripts is null)
        {
            throw new ArgumentNullException(nameof(scripts));
        }
        if (scripts.Contains(null!))
        {
            throw new ArgumentException(Resources.DevException.CollectionContainsNull, nameof(scripts));
        }
        _scripts = scripts;
    }

    /// <param name="script">The script to execute</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    public ScriptExecutionWizard(IScript script) : this(new List<IScript> { script ?? throw new ArgumentNullException(nameof(script)) })
    {
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>Executes the scripts without displaying a dialog.</summary>
    public async void ExecuteNoUI() => await _executor.ExecuteScriptsAsync(_scripts, Program.Settings.ScriptTimeout, (name) => KillIgnoreDialog.HungScript(name, Program.Settings.ScriptTimeout).ShowDialog(), (e, fSInfo, verb) => new FSErrorDialog(e, verb, fSInfo).ShowDialog(), 100/*chaud : placeholder*/).ConfigureAwait(false);

    /// <summary>Executes the scripts and displays a dialog tracking the progress.</summary>
    public void ExecuteUI() => StartUISteps();

    #endregion Public Methods

    #region Private Methods

    private static void RebootForApplicationMaintenance() => Process.Start("shutdown", $"/g /t 0 /d p:4:1");

    private TaskDialogPage CreateCompletedPage(TimeSpan elapsed)
    {
        TaskDialogButton restart = new(Resources.ScriptExecutor.RestartVerb);

        TaskDialogPage p = new()
        {
            AllowCancel = true,
            AllowMinimize = true,
            Buttons = { TaskDialogButton.Close, restart },
            Caption = Resources.ScriptExecutor.CompletedPageCaption,
            Icon = TaskDialogIcon.ShieldSuccessGreenBar,
            Expander = new(string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.CompletedPageExpander, _scripts.Count, elapsed))
            {
                Expanded = Program.Settings.ShowScriptExecutionCompletedDetails,
            },
            Heading = Resources.ScriptExecutor.CompletedPageHeading,
            Text = Resources.ScriptExecutor.CompletedPageText,
        };

        restart.Click += (s, e) => RebootForApplicationMaintenance();

        p.Expander.ExpandedChanged += (sender, e) => Program.Settings.ShowScriptExecutionCompletedDetails = p.Expander.Expanded;

        return p;
    }

    private TaskDialogPage CreateProgressPageAndExecuteScriptsAsync()
    {
        TaskDialogButton cancel = TaskDialogButton.Cancel;

        using StockIcon software = new(StockIconIdentifier.Software);
        TaskDialogPage page = new()
        {
            AllowCancel = true,
            AllowMinimize = true,
            Buttons = { cancel },
            Caption = string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.ProgressPageCaption, 0),
            Expander = new(string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.ProgressPageExpander, null, null))
            {
                Expanded = Program.Settings.ShowScriptExecutionProgressDetails,
            },

            // software.Icon alone causes ComException at ShowDialog, even though TaskDialogIcon's constructor accepts an Icon object.
            Icon = new TaskDialogIcon(software.Icon.ToBitmap()),

            ProgressBar = new() { Maximum = _scripts.Count },
            Text = Resources.ScriptExecutor.ProgressPageText,
            Verification = new(Resources.ScriptExecutor.ProgressPageVerification)
        };

        bool autoRestart = false;
        page.Verification.CheckedChanged += (_, _) => autoRestart = page.Verification.Checked;

        cancel.Click += (s, e) =>
        {
            if (YesNoDialog.AbortOperation.ShowDialog())
            {
                _executor.CancelScriptExecution();
            }
        };

        page.Expander.ExpandedChanged += (_, _)
            => Program.Settings.ShowScriptExecutionProgressDetails = page.Expander.Expanded;

        ProgressPageTextUpdater textUpdater = new(this, page, 0, TimeSpan.Zero);

        _executor.ProgressChanged += ProgressChanged;
        
        page.Created += async (_, _) =>
        {
            TimeSpan timerInterval = TimeSpan.FromMilliseconds(1000);
            System.Timers.Timer timer = new(Convert.ToInt32(timerInterval.TotalMilliseconds));
            SynchronizationContext context = SynchronizationContext.Current!;
            timer.Elapsed += (s, e) =>
            {
                context.Send((_) => textUpdater.Elapsed += timerInterval, null);
            };

            timer.Start();
            await _executor.ExecuteScriptsAsync(_scripts, Program.Settings.ScriptTimeout, (name) => KillIgnoreDialog.HungScript(name, Program.Settings.ScriptTimeout).ShowDialog(), (e, fSInfo, verb) => new FSErrorDialog(e, verb, fSInfo).ShowDialog(), 100/*chaud : placeholder*/).ConfigureAwait(true);
            timer.Stop();

            _uiStep = UIStep.Completed;

            if (autoRestart)
            {
                RebootForApplicationMaintenance();
            }
            else
            {
                page.Navigate(CreateCompletedPage(textUpdater.Elapsed));
            }
        };

        return page;

        void ProgressChanged(object? _, ScriptExecutionProgressChangedEventArgs args)
        {
            if (_uiStep == UIStep.InProgress)
            {
                textUpdater.ScriptIndex = args.ScriptIndex;
            }
        }
    }

    private void StartUISteps()
    {
        TaskDialogButton @continue = TaskDialogButton.Continue;
        TaskDialogVerificationCheckBox verification = new(Resources.ScriptExecutor.WarningPageVerification);

        TaskDialogPage warningPage = new()
        {
            AllowCancel = true,
            AllowMinimize = true,
            Buttons = { @continue, TaskDialogButton.Cancel },
            Caption = Application.ProductName,
            Heading = Resources.ScriptExecutor.WarningPageHeading,
            Text = Resources.ScriptExecutor.WarningPageText,
            Icon = TaskDialogIcon.Warning,
            SizeToContent = true,
            Verification = verification,
        };

        @continue.AllowCloseDialog = @continue.Enabled = false;
        verification.CheckedChanged += (s, e)
            => @continue.Enabled = verification.Checked;

        @continue.Click += (_, _) =>
        {
            if (YesNoDialog.SystemRestorePoint.ShowDialog())
            {
                new RestorePoint(string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.ScriptExecution, Application.ProductName), EventType.BeginSystemChange, RestorePointType.ModifySettings).Create();
            }

            _uiStep = UIStep.InProgress;
            warningPage.Navigate(CreateProgressPageAndExecuteScriptsAsync());
        };

        _uiStep = UIStep.Warning;

        _ = warningPage.ShowPage();
    }

    #endregion Private Methods

    #region Private Classes

    private class ProgressPageTextUpdater
    {
        private readonly ScriptExecutionWizard _parent;
        private readonly TaskDialogPage _page;
        private TimeSpan elapsed;
        private int scriptIndex;

        #region Public Constructors

        public ProgressPageTextUpdater(ScriptExecutionWizard parent, TaskDialogPage page, int scriptIndex, TimeSpan elapsed)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
            _parent = parent ?? throw new ArgumentNullException(nameof(page));
            ScriptIndex = scriptIndex;
            Elapsed = elapsed;
        }

        #endregion Public Constructors

        #region Public Properties

        public TimeSpan Elapsed
        {
            get => elapsed;
            set
            {
                elapsed = value;
                Update();
            }
        }
        public int ScriptIndex
        {
            get => scriptIndex;
            set
            {
                scriptIndex = value;
                Update();
            }
        }

        #endregion Public Properties

        private void Update()
        {
            _page.Caption = string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.ProgressPageCaption, ScriptIndex / (double)_parent._scripts.Count);

            if (_page.Expander is not null)
            {
                _page.Expander.Text = string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.ProgressPageExpander, _parent._scripts[ScriptIndex].Name, Elapsed);
            }

            if (_page.ProgressBar is not null)
            {
                _page.ProgressBar.Value = ScriptIndex;
            }
        }
    }

    #endregion Private Classes
}
