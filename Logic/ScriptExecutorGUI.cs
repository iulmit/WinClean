// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents a <see cref="Script"/> collection that can be executed.</summary>
    public sealed class ScriptExecutorGUI : IDisposable
    {
        #region Private Fields

        private readonly TaskDialogPage _progressPage;

        private readonly IReadOnlyList<IScript> _scripts;

        private readonly BackgroundWorker _scriptsRunner = new() { WorkerSupportsCancellation = true, WorkerReportsProgress = true };

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ScriptExecutorGUI"/> class.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
        public ScriptExecutorGUI(IEnumerable<IScript> scripts)
        {
            _scripts = (scripts ?? throw new ArgumentNullException(nameof(scripts))).ToList();

            _scriptsRunner.DoWork += ScriptsRunnerDoWork;
            _scriptsRunner.RunWorkerCompleted += ScriptsRunnerCompleted;
            _scriptsRunner.ProgressChanged += ScriptsRunnerProgressChanged;
            _progressPage = CreateProgressPage();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc/>
        public void Dispose() => _scriptsRunner.Dispose();

        /// <summary>Executes all the scripts and displays a dialog tracking the progress.</summary>
        public void ExecuteAll() => _ = (Form.ActiveForm is null) ? TaskDialog.ShowDialog(_progressPage) : TaskDialog.ShowDialog(Form.ActiveForm, _progressPage);

        #endregion Public Methods

        #region Private Methods

        #region Creators

        private TaskDialogPage CreateProgressPage()
        {
            TaskDialogButton cancel = TaskDialogButton.Cancel;
            cancel.Click += (s, e) =>
            {
                cancel.AllowCloseDialog = CanExitDialog();
                if (cancel.AllowCloseDialog)
                {
                    _scriptsRunner.CancelAsync();
                }
            };

            using StockIcon software = new(StockIconIdentifier.Software);
            TaskDialogPage p = new()
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
                ProgressBar = new() { Maximum = _scripts.Count },
                Text = "Nettoyage en cours. Cette opération peut prendre jusqu'à une heure, selon les performances de votre ordinateur.",
                Footnote = new("L'ordinateur redémarrera automatiquement à la fin de l'opération.") { Icon = TaskDialogIcon.Information },
            };
            p.Expander.ExpandedChanged += (sender, e) => Properties.Settings.Default.ProgressPageDetails = p.Expander.Expanded;
            p.Created += (sender, e) => _scriptsRunner.RunWorkerAsync();
            return p;
        }

        private static TaskDialogPage CreateCompletedPage()
        {
            TaskDialogButton restart = new("Redémarrer");
            restart.Click += (s, e) => Operational.NativeMethods.RebootForApplicationMaintenance();

            TaskDialogPage p = new()
            {
                AllowCancel = true,
                AllowMinimize = true,
                Buttons = { TaskDialogButton.Cancel, restart },
                Caption = "Redémarrage requis",
                Icon = TaskDialogIcon.ShieldSuccessGreenBar,
                Expander = new("Pour un nettoyage plus avancé :\n\nWinaero Tweaker - Personnalisation de l'apparence\nO&O ShutUp10 - Confidentialité et protection de la vie privée\nTCPOptimizer - Optimisations réseau")
                {
                    Expanded = Properties.Settings.Default.CompletedPageDetails,
                },
                Heading = "Nettoyage terminé",
                Text = "Pour valider les changements, il est recommandé de redémarrer le système.",
            };
            p.Expander.ExpandedChanged += (sender, e) => Properties.Settings.Default.CompletedPageDetails = p.Expander.Expanded;
            return p;
        }
        #endregion Creators

        private bool CanExitDialog()
        {
            bool canExit = !_scriptsRunner.IsBusy;
            if (!canExit)
            {
                ErrorDialog.ConfirmAbortOperation(
                yes: () => canExit = true);
            }
            return canExit;
        }

        #region Event Methods

        private void ScriptsRunnerCompleted(object sender = null, RunWorkerCompletedEventArgs e = null) => _progressPage.Navigate(CreateCompletedPage());

        private void ScriptsRunnerDoWork(object sender = null, DoWorkEventArgs e = null)
        {
            int secondsElapsed = 0, scriptIndex = 0;

            using System.Timers.Timer secondsTimer = new(1000) { Enabled = true };
            secondsTimer.Elapsed += (sender, e) =>
            {
                secondsElapsed++;
                _scriptsRunner.ReportProgress(0, new ProgressReport(scriptIndex, secondsElapsed));
            };

            for (scriptIndex = 0; scriptIndex < _scripts.Count; scriptIndex++)
            {
                _scriptsRunner.ReportProgress(0, new ProgressReport(scriptIndex, secondsElapsed));
                RunScriptThrow();
            }

            void RunScriptThrow()
            {
                try
                {
                    _scripts[scriptIndex].Execute();
                }
                catch (FileNotFoundException)
                {
                    _progressPage.ProgressBar.State = TaskDialogProgressBarState.Error;
                    ErrorDialog.ScriptNotFound(_scripts[scriptIndex].File, RunScriptThrow, null/*chaud : supprimer le script des settings*/);
                    _progressPage.ProgressBar.State = TaskDialogProgressBarState.Normal;
                }
            }
        }

        // This runs in the thread _progressPage was created in
        private void ScriptsRunnerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            System.Diagnostics.Debug.Assert(e.UserState is ProgressReport);

            ProgressReport progress = (ProgressReport)e.UserState;

            _progressPage.Expander.Text = $"Script actuel : {_scripts[progress.ScriptIndex].File.Name}\nTemps écoulé : {TimeSpan.FromSeconds(progress.ElapsedSeconds):g}";
            _progressPage.Caption = $"{progress.ScriptIndex / _scripts.Count:p} terminé";
            _progressPage.ProgressBar.Value = progress.ScriptIndex;
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
