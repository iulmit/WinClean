// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Presentation;
using RaphaëlBardini.WinClean.Resources;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Holds the <see cref="Main"/> method and application-wide data.</summary>
    public static class Program
    {
        #region Public Constructors

        static Program()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>Checks that this is the first instance of the program. If not, throws an <see cref="ApplicationException"/>.</summary>
        /// <exception cref="ApplicationException"/>
        /// <returns><see langword="true"/> if this is the first instance, <see langword="false"/> else.</returns>
        private static bool CheckSingleInstance()
        {
            using System.Threading.Mutex singleInstanceEnforcer = new(true, $"Global\\{Application.ProductName}", out bool firstInstance);
            if (firstInstance)
                GC.KeepAlive(singleInstanceEnforcer);
            return firstInstance;
        }

        private static void CheckStartAble()
        {
            Validator validator = new(new (bool, string)[]
            {
                (CheckSingleInstance(), ErrorMessages.AppAlreadyRunning),
                (CheckStartupPath(), FormattableErrorMessages.WrongExecutablePath(Application.StartupPath, Constants.InstallDir)),
                (Application.SetHighDpiMode(HighDpiMode.PerMonitorV2), ErrorMessages.SetProcessDpiAwareReturnedFalse)
            });
            if (validator.ActiveErrors.Any())
            {
                new UserFriendlyError()
                {
                    Level = ErrorLevel.Error,
                    MainInstruction = validator.ActiveErrors.First(),
                    
                }
            }
        }

        /// <summary>Checks that the path of the executable of the current instance of the program is in the correct location. If not, throws an <see cref="ApplicationException"/>.</summary>
        /// <exception cref="ApplicationException"/>
        /// <returns><see langword="true"/> if the startup path is correct, <see langword="false"/> else.</returns>
        private static bool CheckStartupPath() => Constants.InstallDir.Equals(Application.StartupPath, StringComparison.Ordinal);

        /// <summary>The application's entry point</summary>
        [STAThread]
        private static void Main()
        {
            using MainForm mainForm = new();
            using FormConfirm formConfirm = new();

            CheckStartAble();
            (DialogResult result, IEnumerable<Script> selectedScripts) = mainForm.ShowDialog();
            if (result == DialogResult.OK && formConfirm.ShowDialog() == DialogResult.OK)
            {
                selectedScripts.RunAll();
            }
            Exit();
        }

        private static void Run(Operational.Script script)
        {
            try
            {
                script.Run();
            }
            catch (System.IO.FileNotFoundException e)
            {
                TaskDialogButton deleteScript = new("Supprimer le script");
                TaskDialogButton result = new UserFriendlyError(new TaskDialogPage
                {
                    Icon = TaskDialogIcon.Error,
                    Heading = "Fichier de script introuvable",
                    Caption = Application.ProductName,
                    Text = FormattableErrorMessages.ScriptFileNotFound(s.FullPath),
                    Buttons =
                        {
                            TaskDialogButton.Ignore,
                            TaskDialogButton.Retry,
                            deleteScript
                        },


                }).Show()
                 if (result == deleteScript)
                    ;// supprimer le script dans les paramètre de l'application chaud
                else if (result == TaskDialogButton.Retry)
                    Run(script);
            }
        }
        #endregion Private Methods

        #region Public Methods

        /// <summary>Shows the traditional about dialog box with the program's metadata.</summary>
        /// <inheritdoc cref="Form.Show(IWin32Window)" path="/param"/>
        public static void ShowAboutBox(IWin32Window owner)
        {
            using AboutBox about = new();
            _ = about.ShowDialog(owner); // Use showdialog so the windows dosen't disappear immediately
        }
        /// <summary>Executes all the scripts in an <see cref="IEnumerable{Operational.Script}"/>.</summary>
        /// <param name="scripts">The scripts to execute.</param>
        /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
        public static void RunAll(this IEnumerable<Operational.Script> scripts)
        {
            scripts.ForEach((script) => Run(script));
        }
        public static void Exit()
        {
            "Exiting the application".Log("Exit");
            LogManager.Dispose();
            Application.Exit();
        }
        #endregion Public Methods
    }
}
