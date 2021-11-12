using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Steps :
 * Warning. Show a warning message. Force the user to read it using a verification checkbox.
 * InProgress. Execute the scripts asynchronously and dynamically show progress.
 * Completed. Show results and prompt a reboot. Give advice on further optimizations.
*/

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Executes scripts asynchronously and displays task dialogs tracking the progress.</summary>
public class ScriptExecutor
{
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
    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public ScriptExecutor(IList<IScript> scripts)
    {
        if (scripts is null)
        {
            throw new ArgumentNullException(nameof(scripts));
        }
        if (scripts.Contains(null!))
        {
            throw new ArgumentException("Contains null", nameof(scripts));
        }
        _scripts = scripts;
    }

    /// <param name="script">The script to execute</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    public ScriptExecutor(IScript script) : this(new List<IScript> { script ?? throw new ArgumentNullException(nameof(script)) })
    {
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>Runs the specified scripts.</summary>
    /// <remarks>If there is more than 1 script to run, shows a GUI.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public static void ConfirmAndExecute(IList<IScript> scripts)
    {
        ScriptExecutor executor = new(scripts ?? throw new ArgumentNullException(nameof(scripts)));
        if (scripts.Count > 1)
        {
            executor.ExecuteUI();
        }
        else
        {
            executor.ExecuteNoUI();
        }
    }

    /// <summary>Executes the scripts without displaying a dialog.</summary>
    public async void ExecuteNoUI() => _ = await ExecuteScriptsAsync().ConfigureAwait(false);

    /// <summary>Executes the scripts and displays a dialog traking the progress.</summary>
    public void ExecuteUI() => StartUISteps();

    #endregion Public Methods

    #region Private Methods

    private TaskDialogPage CreateCompletedPage(int elapsedSeconds)
    {
        TaskDialogButton restart = new("Redémarrer");

        TaskDialogPage p = new()
        {
            AllowCancel = true,
            AllowMinimize = true,
            Buttons = { TaskDialogButton.Close, restart },
            Caption = "Redémarrage requis",
            Icon = TaskDialogIcon.ShieldSuccessGreenBar,
            Expander = new($@"Un total de {_scripts.Count} scripts ont été exécutés avec succès en {TimeSpan.FromSeconds(elapsedSeconds):g}.

Pour un nettoyage plus avancé :

Winaero Tweaker - Personnalisation de l'apparence
O&O ShutUp10 - Confidentialité et protection de la vie privée
TCPOptimizer - Optimisations réseau")
            {
                Expanded = Properties.Settings.Default.ShowScriptExecutionCompletedDetails,
            },
            Heading = "Nettoyage terminé",
            Text = "Pour valider les changements, il est recommandé de redémarrer le système.",
        };

        restart.Click += (s, e) => Helpers.RebootForApplicationMaintenance();

        p.Expander.ExpandedChanged += (sender, e) => Properties.Settings.Default.ShowScriptExecutionCompletedDetails = p.Expander.Expanded;

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
            Caption = $"{0:p} terminé",
            Expander = new("Script actuel : \nTemps écoulé : ")
            {
                Expanded = Properties.Settings.Default.ShowScriptExecutionProgressDetails,
            },
            Icon = new TaskDialogIcon(software.Icon.ToBitmap()),// software.Icon alone causes ComException at ShowDialog
            ProgressBar = new() { Maximum = _scripts.Count },
            Text = "Exécution des scripts. Il est possible que des fenêtres de console s'affichent. Cette opération peut prendre un certain temps.",
            Verification = new("À la fin de l'opération, redémarrer automatiquement")
        };

        bool autoRestart = false;
        page.Verification.CheckedChanged += (_, _) => autoRestart = page.Verification.Checked;

        cancel.Click += (s, e) =>
        {
            if (ErrorDialog.ConfirmAbortOperation())
            {
                _canceler.Cancel();
            }
        };

        _progress.ProgressChanged += ProgressChanged;

        page.Expander.ExpandedChanged += (_, _)
            => Properties.Settings.Default.ShowScriptExecutionProgressDetails = page.Expander.Expanded;

        page.Created += async (_, _) =>
        {
            int result = await ExecuteScriptsAsync().ConfigureAwait(true);

            _uiStep = UIStep.Completed;

            if (autoRestart)
            {
                Helpers.RebootForApplicationMaintenance();
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
                page.Caption = $"{progress.ScriptIndex / (double)_scripts.Count:p0} terminé";

                page.Expander.Text = $"Script actuel : {_scripts[progress.ScriptIndex].Name}\nTemps écoulé : {TimeSpan.FromSeconds(progress.ElapsedSeconds)}";

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
                elapsedSeconds++;
                ReportProgress();
            };

            seconds.Start();
            for (; scriptIndex < _scripts.Count; ++scriptIndex)
            {
                _scripts[scriptIndex].Execute();
                ReportProgress();
            }
            seconds.Stop();

            void ReportProgress() => ((IProgress<ProgressReport>)_progress).Report(new(scriptIndex, elapsedSeconds));

            return elapsedSeconds;
        }).ConfigureAwait(false);

    private void StartUISteps()
    {
        TaskDialogButton @continue = TaskDialogButton.Continue;
        TaskDialogVerificationCheckBox verification = new("Je suis prêt à continuer.");

        TaskDialogPage warningPage = new()
        {
            AllowCancel = true,
            AllowMinimize = true,
            Buttons = { @continue, TaskDialogButton.Cancel },
            Caption = Resources.ErrorStrings.Warning,
            Heading = "Avant de commencer l'opération, veuillez confirmer :",
            Text = @"L'ordinateur est branché sur secteur
- L'ordinateur doit resté branché sur secteur durant toute la durée de l'opération afin d'éviter un échec du système.

J'ai sauvegardé tout travail non enregistré
- L'opération aboutira par le redémarrage de l'ordinateur. Sauvegardez tout document non enregistré.

J'ai fermé tout programme non essentiel
- Afin d'éviter les conflits, quittez toute application non essentielle.",
            Icon = TaskDialogIcon.Warning,
            SizeToContent = true,
            Verification = verification,
        };

        @continue.AllowCloseDialog = @continue.Enabled = false;
        verification.CheckedChanged += (s, e)
            => @continue.Enabled = verification.Checked;

        @continue.Click += (_, _) =>
        {
            _uiStep = UIStep.InProgress;
            warningPage.Navigate(CreateProgressPageAndExecuteScriptsAsync());
        };

        _uiStep = UIStep.Warning;
        _ = warningPage.ShowDialog(Form.ActiveForm);
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
