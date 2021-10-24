// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Presentation;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Holds the <see cref="Main"/> method and application-wide data.</summary>
    public static class Program
    {
        // chaud : a lire de puis le registre entree installation. Besoin d'un installeur pour faire ça.
        /// <summary>Application install directory.</summary>
        public static readonly DirectoryInfo InstallDir = new(Application.StartupPath);

        #region Public Methods

        /// <summary>Runs the specified scripts.</summary>
        /// <remarks>If there is more than 1 script to run, shows a GUI.</remarks>
        /// <param name="scripts"></param>
        /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
        public static void ConfirmAndExecuteScripts(IEnumerable<IScript> scripts)
        {
            if (scripts is null)
            {
                throw new ArgumentNullException(nameof(scripts));
            }

            if (scripts.Count() > 1)
            {
                if (Confirm())
                {
                    using ScriptExecutorGUI executor = new(scripts);
                    executor.ExecuteAll();
                }
            }
            else if (scripts.Count() == 1)
            {
                scripts.ElementAt(0).Execute();
            }
        }

        /// <summary>Disposes of ressources and exits the program.</summary>
        public static void Exit()
        {
            "Exiting the application".Log("Exit");
            Application.Exit();
        }

        /// <summary>Displays the <see cref="AboutBox"/> form.</summary>
        public static void ShowAboutBox()
        {
            using AboutBox about = new();
            _ = about.ShowDialog(Form.ActiveForm); // Use showdialog so the windows dosen't disappear immediately
        }

        /// <summary>Displays the <see cref="Presentation.Settings"/> form.</summary>
        public static void ShowSettings()
        {
            using Presentation.Settings settings = new();
            _ = settings.ShowDialog(Form.ActiveForm);
        }

        #endregion Public Methods

        #region Private Methods

        private static bool Confirm()
        {
            using FormConfirm fc = new();
            return fc.ShowDialog(Form.ActiveForm) == DialogResult.OK;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000", Justification = "If the mutex is disposed, it won't work.")]
        private static void EnsureSingleInstance()
        {
            System.Threading.Mutex singleInstanceEnforcer = new(true, $"Global\\{Application.ProductName}", out bool firstInstance);
            if (firstInstance)
            {
                GC.KeepAlive(singleInstanceEnforcer);
            }
            else
            {
                ErrorDialog.SingleInstanceOnly(EnsureSingleInstance, Exit);
                singleInstanceEnforcer.Close();
            }
        }

        private static void EnsureStartupPath()
        {
            if (!Application.StartupPath.Equals(InstallDir.FullName, StringComparison.OrdinalIgnoreCase))
            {
                ErrorDialog.WrongStartupPath(EnsureStartupPath, Exit);
            }
        }

        [STAThread]
        private static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

            EnsureSingleInstance();
            EnsureStartupPath();

            using MainForm mainForm = new();
            Application.Run(mainForm);

            Exit();
        }

        #endregion Private Methods
    }
}
