using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using RaphaëlBardini.WinClean.Operational;
using RaphaëlBardini.WinClean.Logic;

using System.Diagnostics;

/* Steps :
 * Warning. Show a warning message. Force the user to read it using a verification checkbox.
 * InProgress. Execute the scripts asynchronously and dynamically show progress.
 * Completed. Show results and prompt a reboot. Give advice on further optimizations.
*/

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>
/// Executes scripts asynchronously and displays task dialogs tracking the progress.
/// </summary>
public class ScriptExecutor
{
    #region Public Properties

    public Properties.Settings Settings { get; set; }

    #endregion Public Properties

    #region Private Fields

    private readonly CancellationTokenSource _canceler = new();

    private readonly Progress<ProgressReport> _progress = new();

    private readonly IList<IScript> _scripts;

    private UIStep _uiStep = UIStep.NotStarted;

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
    /// <param name="settings">The program settings to use.</param>
    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public ScriptExecutor(IList<IScript> scripts, Properties.Settings settings)
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
        Settings = settings;
    }

    /// <param name="script">The script to execute</param>
    /// <param name="settings">The program settings to use.</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    public ScriptExecutor(IScript script, Properties.Settings settings) : this(new List<IScript> { script ?? throw new ArgumentNullException(nameof(script)) }, settings)
    {
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Executes the scripts without displaying a dialog.
    /// </summary>
    public async void ExecuteNoUI() => _ = await ExecuteScriptsAsync().ConfigureAwait(false);

    /// <summary>
    /// Executes the scripts and displays a dialog traking the progress.
    /// </summary>
    public void ExecuteUI() => StartUISteps();

    #endregion Public Methods

    #region Private Methods

    private static void RebootForApplicationMaintenance() => Process.Start("shutdown", $"/g /t 0 /d p:4:1");

    private TaskDialogPage CreateCompletedPage(int elapsedSeconds)
    {
        TaskDialogButton restart = new(Resources.ScriptExecutor.RestartVerb);

        TaskDialogPage p = new()
        {
            AllowCancel = true,
            AllowMinimize = true,
            Buttons = { TaskDialogButton.Close, restart },
            Caption = Resources.ScriptExecutor.CompletedPageCaption,
            Icon = TaskDialogIcon.ShieldSuccessGreenBar,
            Expander = new(string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.CompletedPageExpander, _scripts.Count, TimeSpan.FromSeconds(elapsedSeconds)))
            {
                Expanded = Settings.ShowScriptExecutionCompletedDetails,
            },
            Heading = Resources.ScriptExecutor.CompletedPageHeading,
            Text = Resources.ScriptExecutor.CompletedPageText,
        };

        restart.Click += (s, e) => RebootForApplicationMaintenance();

        p.Expander.ExpandedChanged += (sender, e) => Settings.ShowScriptExecutionCompletedDetails = p.Expander.Expanded;

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
                Expanded = Settings.ShowScriptExecutionProgressDetails,
            },
            Icon = new TaskDialogIcon(software.Icon.ToBitmap()),// software.Icon alone causes ComException at ShowDialog
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
                _canceler.Cancel();
            }
        };

        _progress.ProgressChanged += ProgressChanged;

        page.Expander.ExpandedChanged += (_, _)
            => Settings.ShowScriptExecutionProgressDetails = page.Expander.Expanded;

        page.Created += async (_, _) =>
        {
            int result = await ExecuteScriptsAsync().ConfigureAwait(true);

            _uiStep = UIStep.Completed;

            if (autoRestart)
            {
                RebootForApplicationMaintenance();
            }
            else
            {
                page.Navigate(CreateCompletedPage(result));
            }
        };

        return page;

        void ProgressChanged(object? _, ProgressReport progress)
        {
            if (_uiStep == UIStep.InProgress)
            {
                page.Caption = string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.ProgressPageCaption, progress.ScriptIndex / (double)_scripts.Count);

                page.Expander.Text = string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutor.ProgressPageExpander, _scripts[progress.ScriptIndex].Name, TimeSpan.FromSeconds(progress.ElapsedSeconds));

                page.ProgressBar.Value = progress.ScriptIndex;
            }
        }
    }

    private async Task<int> ExecuteScriptsAsync()
        => await Task.Run(() =>
        {
            int elapsedSeconds = 0, scriptIndex = 0;

            System.Timers.Timer seconds = new(1000);
            seconds.Elapsed += (s, e) =>
            {
                ++elapsedSeconds;
                ReportProgress();
            };

            seconds.Start();
            for (; scriptIndex < _scripts.Count; ++scriptIndex)
            {
                _scripts[scriptIndex].Execute(Settings.ScriptTimeout, (name, timeout) => KillIgnoreDialog.HungScript(name, timeout).ShowDialog(), (e, fSInfo, verb) => new FSErrorDialog(e, verb, fSInfo).ShowDialog(), 100/*chaud : placeholder*/);
                ReportProgress();
            }
            seconds.Stop();

            void ReportProgress() => ((IProgress<ProgressReport>)_progress).Report(new(scriptIndex, elapsedSeconds));

            return elapsedSeconds;
        }).ConfigureAwait(false);

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

    #region Private Structs

    private readonly struct ProgressReport
    {
        #region Public Constructors

        public ProgressReport(int scriptIndex, int elapsedSeconds)
        {
            ScriptIndex = scriptIndex;
            ElapsedSeconds = elapsedSeconds;
        }

        #endregion Public Constructors

        #region Public Properties

        public int ElapsedSeconds { get; }
        public int ScriptIndex { get; }

        #endregion Public Properties
    }

    #endregion Private Structs
}