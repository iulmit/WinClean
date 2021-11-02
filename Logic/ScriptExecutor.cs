// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

/* STEPS
 * 
 * 1 : Warning page, warn user about the risks of the operation.
 * 2 : Progress page, dynamically displays progress
 * 3 : Completed page, shows the result of the operations and prompts a reboot.
 */
namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents a <see cref="Script"/> collection that can be executed.</summary>
    public sealed class ScriptExecutor : IDisposable
    {
        #region Private Fields

        private readonly BackgroundWorker _worker = new() { WorkerSupportsCancellation = true, WorkerReportsProgress = true };

        private readonly IList<IScript> _scripts = Array.Empty<IScript>();

        private readonly TaskDialogPage _progressPageStep2;

        private int _elapsedSeconds;

        #endregion Private Fields

        private TaskDialogProgressBar ProgressPageProgressBar
        {
            get
            {
                Assert(_progressPageStep2.ProgressBar is not null);
                return _progressPageStep2.ProgressBar;
            }
        }
        private TaskDialogExpander ProgressPageExpander
        {
            get
            {
                Assert(_progressPageStep2.Expander is not null);
                return _progressPageStep2.Expander;
            }
        }

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ScriptExecutor"/> class with the specified scripts.</summary>
        /// <param name="scripts">The scripts to execute.</param>
        /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
        public ScriptExecutor(IList<IScript> scripts)
        {
            _scripts = scripts ?? throw new ArgumentNullException(nameof(scripts));
            _worker.DoWork += ScriptsRunnerDoWork;
            _worker.ProgressChanged += ScriptsRunnerProgressChanged;

            TaskDialogButton cancel = TaskDialogButton.Cancel;
            cancel.Click += (s, e) =>
            {
                cancel.AllowCloseDialog = CanExitDialog();
                if (cancel.AllowCloseDialog)
                {
                    _worker.CancelAsync();
                }
            };
            using StockIcon software = new(StockIconIdentifier.Software);
            _progressPageStep2 = new()
            {
                AllowCancel = true,
                AllowMinimize = true,
                Buttons = { cancel },
                Caption = $"{0:p} terminé",
                Expander = new("Script actuel : \nTemps écoulé : ")
                {
                    Expanded = Properties.Settings.Default.ProgressPageDetails,
                },
                Icon = new TaskDialogIcon(software.Icon.ToBitmap()),// software.Icon alone causes ComException at ShowDialog
                ProgressBar = new() { Maximum = scripts.Count },
                Text = "Nettoyage en cours. Cette opération peut prendre jusqu'à une heure, selon les performances de votre ordinateur.",
                Footnote = new("L'ordinateur redémarrera automatiquement à la fin de l'opération.") { Icon = TaskDialogIcon.Information },
            };
            _worker.RunWorkerCompleted += (s, e) => _progressPageStep2.Navigate(CreateCompletedPageStep3());
            _progressPageStep2.Expander.ExpandedChanged += (sender, e) => Properties.Settings.Default.ProgressPageDetails = _progressPageStep2.Expander.Expanded;
            _progressPageStep2.Created += (sender, e) => _worker.RunWorkerAsync();
        }

        /// <summary>Initializes a new instance of the <see cref="ScriptExecutor"/> class with the specified script.</summary>
        /// <param name="script">The script to execute</param>
        /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
        public ScriptExecutor(IScript script) : this(new List<IScript> { script ?? throw new ArgumentNullException(nameof(script)) })
        {
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc/>
        public void Dispose() => _worker.Dispose();

        /// <summary>Executes the scripts and displays a dialog traking the progress.</summary>
        public void ExecuteUI() => _ = CreateWarningPageStep1().ShowDialog(Form.ActiveForm);

        /// <summary>Executes the scripts without displaying a dialog.</summary>
        public void ExecuteNoUI() => _worker.RunWorkerAsync();
        #endregion Public Methods

        #region Private Methods

        #region Creators

        private TaskDialogPage CreateWarningPageStep1()
        {
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
            @continue.Click += (s, e) => p.Navigate(_progressPageStep2);
            verification.CheckedChanged += (s, e) => @continue.Enabled = verification.Checked;

            return p;
        }

        private TaskDialogPage CreateCompletedPageStep3()
        {
            TaskDialogButton restart = new("Redémarrer");

            TaskDialogPage p = new()
            {
                AllowCancel = true,
                AllowMinimize = true,
                Buttons = { TaskDialogButton.Close, restart },
                Caption = "Redémarrage requis",
                Icon = TaskDialogIcon.ShieldSuccessGreenBar,
                Expander = new($@"Un total de {_scripts.Count} scripts ont été exécutés avec succès en {TimeSpan.FromSeconds(_elapsedSeconds):g}.

Pour un nettoyage plus avancé :

Winaero Tweaker - Personnalisation de l'apparence
O&O ShutUp10 - Confidentialité et protection de la vie privée
TCPOptimizer - Optimisations réseau")
                {
                    Expanded = Properties.Settings.Default.CompletedPageDetails,
                },
                Heading = "Nettoyage terminé",
                Text = "Pour valider les changements, il est recommandé de redémarrer le système.",
            };

            restart.Click += (s, e) => Helpers.RebootForApplicationMaintenance();
            p.Expander.ExpandedChanged += (sender, e) => Properties.Settings.Default.CompletedPageDetails = p.Expander.Expanded;

            return p;
        }

        #endregion Creators

        private bool CanExitDialog()
        {
            bool canExit = !_worker.IsBusy;
            if (!canExit)
            {
                ErrorDialog.ConfirmAbortOperation(
                yes: () => canExit = true);
            }
            return canExit;
        }

        #region Event Methods

        private void ScriptsRunnerDoWork(object? sender, DoWorkEventArgs? e)
        {
            int scriptIndex = 0;

            using System.Timers.Timer secondsTimer = new(1000) { Enabled = true };
            secondsTimer.Elapsed += (sender, e) =>
            {
                _elapsedSeconds++;
                _worker.ReportProgress(0, new ProgressReport(scriptIndex, _elapsedSeconds));
            };

            for (scriptIndex = 0; scriptIndex < _scripts.Count; scriptIndex++)
            {
                _worker.ReportProgress(0, new ProgressReport(scriptIndex, _elapsedSeconds));
                RunScriptThrow();
            }
            void RunScriptThrow()
            {
                try
                {
                    _scripts[scriptIndex].Execute();
                }
                catch (Exception e) when (e.FileSystem())
                {
                    ProgressPageProgressBar.State = TaskDialogProgressBarState.Error;
                    ErrorDialog.ScriptInacessible(_scripts[scriptIndex].Name, e, RunScriptThrow, _scripts[scriptIndex].Delete);
                    ProgressPageProgressBar.State = TaskDialogProgressBarState.Normal;
                }
            }
        }

        // This runs in the thread _progressPage was created in
        private void ScriptsRunnerProgressChanged(object? sender, ProgressChangedEventArgs? e)
        {
            Assert(e is not null);
            Assert(e.UserState is ProgressReport);
            ProgressReport progress = (ProgressReport)e.UserState;

            _progressPageStep2.Caption = $"{progress.ScriptIndex / _scripts.Count:p} terminé";
            ProgressPageExpander.Text = $"Script actuel : {_scripts[progress.ScriptIndex].Name}\nTemps écoulé : {TimeSpan.FromSeconds(progress.ElapsedSeconds):g}";
            ProgressPageProgressBar.Value = progress.ScriptIndex;
        }

        #endregion Event Methods

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
}
