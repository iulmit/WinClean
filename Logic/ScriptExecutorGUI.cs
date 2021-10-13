// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents a <see cref="Script"/> collection that can be executed.</summary>
    public sealed class ScriptExecutorGUI : IDisposable
    {
        #region Private Fields

        private readonly Script[] _scripts;

        private readonly BackgroundWorker _scriptsRunner = new() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };

        private readonly TaskDialogPage _progressPage;

        #endregion Private Fields

        #region Public Constructors

        /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
        public ScriptExecutorGUI(IEnumerable<Script> scripts)
        {
            _scripts = (scripts ?? throw new ArgumentNullException(nameof(scripts))).ToArray();

            TaskDialogButton Cancel = TaskDialogButton.Cancel;
            Cancel.Enabled = false;
            Cancel.Click += (s, e) =>
            {
                if (Cancel.AllowCloseDialog = CanExitDialog())
                    _scriptsRunner.CancelAsync();
            };
            _progressPage = new()
            {
                AllowCancel = true,
                AllowMinimize = true,
                Buttons = { Cancel },
                Caption = $"{0:p} terminé",
                Expander = new("Script actuel : \nTemps écoulé : ")
                {
                    Expanded = true/*chaud : set for settings*/,
                    Tag = new ProgressReport(0, 0)
                },
                Icon = new TaskDialogIcon(NativeMethods.GetShellIcon(StockIcon.Software)),
                ProgressBar = new() { Maximum = _scripts.Length },
                Text = "Nettoyage en cours. Cette opération peut prendre jusqu'à une heure, selon les performances de votre ordinateur.",
                Footnote = new("L'ordinateur redémarrera automatiquement à la fin de l'opération.") { Icon = TaskDialogIcon.Information },
            };

            _progressPage.Created += (sender, e) =>
            {
                _scriptsRunner.RunWorkerAsync();
            };
            _scriptsRunner.DoWork += ScriptRunnerDoWork;
            _scriptsRunner.ProgressChanged += ScriptsRunnerProgressChanged;
            _scriptsRunner.RunWorkerCompleted += ScriptRunnerCompleted;
        }

        #endregion Public Constructors

        #region Private Enums

        private enum ReportProgressType
        {
            ElapsedSeconds,
            ScriptIndex
        }

        #endregion Private Enums

        #region Public Methods

        /// <summary>
        /// Executes all the scripts in an <see cref="IEnumerable{Operational.Script}"/> and displays a dialog tracking the progress.
        /// </summary>
        /// <param name="scripts">The scripts to execute.</param>
        /// <exception cref="ArgumentNullException"><paramref name="owner"/> is <see langword="null"/>.</exception>
        public void ExecuteAll(IWin32Window owner) => _ = TaskDialog.ShowDialog(owner, _progressPage);

        public void Dispose() => _scriptsRunner.Dispose();
        #endregion Public Methods

        #region Private Methods

        private bool CanExitDialog()
        {
            bool canExit = !_scriptsRunner.IsBusy;
            if (!canExit)
            {
                ErrorDialog.ConfirmAbortOperation(_progressPage.BoundDialog,
                yes: () =>
                {
                    canExit = true;
                });
            }
            return canExit;
        }

        private void ReportProgress(ProgressReport progress)
        {
            _progressPage.Expander.Tag = progress;
            _progressPage.Expander.Text = $"Script actuel : {_scripts[progress.ScriptIndex].Path.Filename}\nTemps écoulé : {TimeSpan.FromSeconds(progress.ElapsedSeconds):g}";
            _progressPage.Caption = $"{progress.ScriptIndex / _scripts.Length:p} terminé";
            _progressPage.ProgressBar.Value = progress.ScriptIndex;
        }

        private void ScriptRunnerCompleted(object sender = null, RunWorkerCompletedEventArgs e = null)
        {
            _progressPage.ProgressBar.Value = _progressPage.ProgressBar.Maximum;
            _progressPage.Buttons[0].Enabled = true;
        }

        private void ScriptRunnerDoWork(object sender = null, DoWorkEventArgs e = null)
        {
            int secondsElapsed = 0;
            using System.Timers.Timer secondsTimer = new(1000) { Enabled = true };
            secondsTimer.Elapsed += (sender, e) =>
            {
                secondsElapsed++;
                _scriptsRunner.ReportProgress(secondsElapsed, ReportProgressType.ElapsedSeconds);
            };
            for (int i = 0; i < _scripts.Length; i++)
            {
                _scriptsRunner.ReportProgress(i, ReportProgressType.ScriptIndex);
                RunThrow();

                void RunThrow()
                {
                    try
                    {
                        _scripts[i].Execute();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        _progressPage.ProgressBar.State = TaskDialogProgressBarState.Error;
                        ErrorDialog.ScriptNotFound(_scripts[i].Path, _progressPage.BoundDialog, RunThrow, null/*chaud : supprimer le script des settings*/);
                        _progressPage.ProgressBar.State = TaskDialogProgressBarState.Normal;
                    }
                }
            }
        }

        private void ScriptsRunnerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is not ReportProgressType)
                throw new ArgumentException($"{nameof(e.UserState)} must be a {nameof(ReportProgressType)}", nameof(e));

            ProgressReport @new = (ReportProgressType)e.UserState switch
            {
                ReportProgressType.ElapsedSeconds => new(((ProgressReport)_progressPage.Expander.Tag).ScriptIndex, e.ProgressPercentage),
                ReportProgressType.ScriptIndex => new(e.ProgressPercentage, ((ProgressReport)_progressPage.Expander.Tag).ElapsedSeconds),
                _ => throw new InvalidEnumArgumentException(nameof(ProgressChangedEventArgs.UserState), (int)e.UserState, typeof(ReportProgressType)),
            };
            ReportProgress(@new);
        }

        #endregion Private Methods

        #region Private Structs

        private struct ProgressReport
        {
            #region Public Constructors

            public ProgressReport(int scriptIndex, int elapsedSeconds)
            {
                ScriptIndex = scriptIndex;
                ElapsedSeconds = elapsedSeconds;
            }

            #endregion Public Constructors

            #region Public Properties

            public int ElapsedSeconds { get; set; }
            public int ScriptIndex { get; set; }

            #endregion Public Properties
        }

        #endregion Private Structs
    }
}
