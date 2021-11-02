using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

/* Steps :
 * 1. Afficher un avertissement
 * 2. Si consenti, exécuter les scripts en affichant dynamiquement la progression
 * 3. Quand c'est terminé, afficher un récapitulatif et proposer de redémarrer l'ordinateur
*/

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>
    /// Executes scripts asynchronously and displays task dialogs tracking the progress.
    /// </summary>
    public class ScriptExecutor
    {
        private enum UIStep
        {
            NotStarted,
            Warning,
            Progress,
            Completed
        }

        private readonly IList<IScript> _scripts;
        private readonly CancellationTokenSource _canceler = new();
        private readonly Progress<ProgressReport> _progress = new();
        private UIStep _currentStep = UIStep.NotStarted;

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ScriptExecutor"/> class with the specified scripts.</summary>
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

        /// <summary>Initializes a new instance of the <see cref="ScriptExecutor"/> class with the specified script.</summary>
        /// <param name="script">The script to execute</param>
        /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
        public ScriptExecutor(IScript script) : this(new List<IScript> { script ?? throw new ArgumentNullException(nameof(script)) })
        {
        }

        #endregion Public Constructors

        private void StartUISteps()
        {
            _currentStep = UIStep.Warning;

            TaskDialogButton @continue = TaskDialogButton.Continue;
            TaskDialogVerificationCheckBox verification = new("Je suis prêt à continuer.");

            TaskDialogPage p = new()
            {
                AllowCancel = true,
                AllowMinimize = true,
                Buttons = { @continue, TaskDialogButton.Cancel },
                Caption = Resources.ErrorStrings.Warning,
                Heading = "Avant de commencer l'opération, veuillez confirmer :",
                Text = @"L'ordinateur est branché sur secteur
- L'ordinateur doit resté branché sur secteur durant toute la durée de l'opération afin d'éviter un échec du system à un moment critique.

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
            @continue.Click += (s, e)
                => p.Navigate(CreateProgressPage());

            _ = p.ShowDialog(Form.ActiveForm);

        }

        private TaskDialogPage CreateProgressPage()
        {
            _currentStep = UIStep.Progress;

            TaskDialogButton cancel = TaskDialogButton.Cancel;

            using StockIcon software = new(StockIconIdentifier.Software);
            TaskDialogPage p = new()
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
                ProgressBar = new() { Maximum = _scripts.Count - 1 },
                Text = "Nettoyage en cours. Il est possible que des fenêtres de console s'affichent.",
                Footnote = new("L'ordinateur redémarrera automatiquement à la fin de l'opération.") { Icon = TaskDialogIcon.Information },
            };
            cancel.Click += (s, e) =>
            {
                if (ErrorDialog.ConfirmAbortOperation())
                {
                    _canceler.Cancel();
                }
            };
            _progress.ProgressChanged += ProgressChanged;
            p.Expander.ExpandedChanged += (_, _)
                => Properties.Settings.Default.ShowScriptExecutionProgressDetails = p.Expander.Expanded;
            p.Created += (_, _)
                => p.Navigate(CreateCompletedPage(ExecuteScriptsAsync().Result));

            return p;

            void ProgressChanged(object? _, ProgressReport progress)
            {
                if (_currentStep == UIStep.Progress)
                {
                    p.Caption = $"{progress.ScriptIndex / _scripts.Count:p} terminé";
                    p.Expander.Text = $"Script actuel : {_scripts[progress.ScriptIndex].Name}\nTemps écoulé : {TimeSpan.FromSeconds(progress.ElapsedSeconds)}";
                    p.ProgressBar.Value = progress.ScriptIndex;
                }
            }
        }

        private TaskDialogPage CreateCompletedPage(int elapsedSeconds)
        {
            _currentStep = UIStep.Completed;

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

        /// <summary>Executes the scripts and displays a dialog traking the progress.</summary>
        public void ExecuteUI() => StartUISteps();

        /// <summary>Executes the scripts without displaying a dialog.</summary>
        public async void ExecuteNoUI() => _ = await ExecuteScriptsAsync().ConfigureAwait(false);

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
                for (; scriptIndex < _scripts.Count; scriptIndex++)
                {
                    ReportProgress();
                    _scripts[scriptIndex].Execute();
                }
                seconds.Stop();

                void ReportProgress() => ((IProgress<ProgressReport>)_progress).Report(new(scriptIndex, elapsedSeconds));

                return elapsedSeconds;

            }).ConfigureAwait(false);

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
}
