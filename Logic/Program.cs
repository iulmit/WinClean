// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Presentation;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Holds the <see cref="Main"/> method and application-wide data.</summary>
    public static class Program
    {
        #region Private Fields

        private static readonly MainForm s_mainForm = new();

        #endregion Private Fields

        #region Public Properties

        public static IWin32Window MainForm => s_mainForm.Visible ? s_mainForm : null;

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Asks for confirmation and runs the script.
        /// </summary>
        /// <remarks>If there is more than 1 script to run, show a GUI</remarks>
        /// <param name="scripts"></param>
        /// <param name="owner"></param>
        public static void ConfirmAndExecuteScripts(IEnumerable<Script> scripts, IWin32Window owner = null)
        {
            if (scripts.Count() > 1)
            {
                if (Confirm(owner))
                    ExecuteScriptsGUI(scripts.ToArray(), owner);
            }
            else if (scripts.Count() == 1)
                ExecuteScriptNoGUI(scripts.First(), owner);
        }
        /// <summary>
        /// Disposes of ressources and exits the program.
        /// </summary>
        public static void Exit()
        {
            "Exiting the application".Log("Exit");
            LogManager.Dispose();
            Application.Exit();
        }

        /// <summary>Shows the traditional about dialog box with the program's metadata.</summary>
        /// <inheritdoc cref="Form.Show(IWin32Window)" path="/param"/>
        public static void ShowAboutBox(IWin32Window owner)
        {
            using AboutBox about = new();
            _ = about.ShowDialog(owner); // Use showdialog so the windows dosen't disappear immediately
        }

        #endregion Public Methods

        #region Private Methods
        private static bool Confirm(IWin32Window owner)
        {
            using FormConfirm fc = new();
            return fc.ShowDialog(owner) == DialogResult.OK;
        }

        /// <summary>Ensures that this is the first instance of the program</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000", Justification = "If the mutex is disposed, it won't work.")]
        private static void EnsureSingleInstance()
        {
            System.Threading.Mutex singleInstanceEnforcer = new(true, $"Global\\{Application.ProductName}", out bool firstInstance);
            if (firstInstance)
                GC.KeepAlive(singleInstanceEnforcer);
            else
            {
                ErrorDialog.SingleInstanceOnly().ShowCloseRetry(Exit, EnsureSingleInstance);
                singleInstanceEnforcer.Close();
            }
        }

        /// <summary>Ensures that the path of the executable of the current instance of the program is in the correct location.</summary>
        private static void EnsureStartupPath()
        {
            if (Application.StartupPath != Constants.InstallDir)
                ErrorDialog.WrongStartupPath().ShowCloseRetry(Exit, EnsureStartupPath);
        }

        /// <summary>
        /// Executes a script without displaying a progress dialog.
        /// </summary>
        /// <param name="script">The script to execute.</param>
        private static void ExecuteScriptNoGUI(Script script, IWin32Window owner = null)
        {
            try
            {
                script.Execute();
            }
            catch (System.IO.FileNotFoundException)
            {
                ErrorDialog.ScriptNotFound(script.Path).ShowIgnoreRetryDelete(null, () => ExecuteScriptNoGUI(script, owner), null/*chaud : delete script from settings*/, owner);
            }
        }

        /// <summary>Executes all the scripts in an <see cref="IEnumerable{Operational.Script}"/> and displays a dialog tracking the progress.</summary>
        /// <param name="scripts">The scripts to execute.</param>
        private static void ExecuteScriptsGUI(Script[] scripts, IWin32Window owner = null)
        {
            TaskDialogPage page = new()
            {
                AllowMinimize = true,
                Buttons = { TaskDialogButton.Close },
                Caption = "0% terminé",
                Expander = new("Script actuel :\nTemps écoulé :"),
                Icon = new TaskDialogIcon(NativeMethods.GetShellIcon(StockIcon.Software)),
                ProgressBar = new() { Maximum = scripts.Length },
                Text = "Nettoyage en cours. Cette opération peut jusqu'à une heure, selon les performances de votre ordinateur.",
                Footnote = new("L'ordinateur redémarrera automatiquement à la fin de l'opération.") { Icon = TaskDialogIcon.Information },
            };
            page.Buttons[0].Enabled = false;

            page.Created += (sender, args) =>
            {
                System.Diagnostics.Stopwatch chrono = new();
                chrono.Start();

                for (int i = 0; i < scripts.Length; i++)
                {
                    RunThrow();
                    page.Caption = $"{Convert.ToInt32((double)i / scripts.Length):p} terminé";
                    page.ProgressBar.Value = i + 1;
                    page.Expander.Text = $"Script actuel : {scripts[i].Path.Filename}\nTemps écoulé : {TimeSpan.FromSeconds(Convert.ToInt32(chrono.Elapsed.TotalSeconds)):g}";

                    void RunThrow()
                    {
                        try
                        {
                            scripts[i].Execute();
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            page.ProgressBar.State = TaskDialogProgressBarState.Paused;
                            ErrorDialog.ScriptNotFound(scripts[i].Path).ShowIgnoreRetryDelete(null, () => { RunThrow(); }, null/*chaud : supprimer le script des settings*/, page.BoundDialog);
                            page.ProgressBar.State = TaskDialogProgressBarState.Normal;
                        }
                    }
                }
                page.Buttons[0].Enabled = true;

                chrono.Stop();
            };

            if (owner is null)
                _ = TaskDialog.ShowDialog(page);
            else
                _ = TaskDialog.ShowDialog(owner, page);
        }

        /// <summary>The application's entry point</summary>
        [STAThread]
        private static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            EnsureSingleInstance();
            EnsureStartupPath();
            Application.Run(s_mainForm);
        }

        #endregion Private Methods
    }
}
