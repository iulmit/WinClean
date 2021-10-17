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
        #region Public Methods

        /// <summary>Asks for confirmation and runs the script.</summary>
        /// <remarks>If there is more than 1 script to run, show a GUI</remarks>
        /// <param name="scripts"></param>
        public static void ConfirmAndExecuteScripts(IEnumerable<Script> scripts)
        {
            if (scripts is null)
                throw new ArgumentNullException(nameof(scripts));
            if (scripts.Count() > 1)
            {
                if (Confirm())
                {
                    using ScriptExecutorGUI executor = new(scripts);
                    executor.ExecuteAll();
                }
            }
            else if (scripts.Count() == 1)
                scripts.ElementAt(0).Execute();
        }

        /// <summary>Disposes of ressources and exits the program.</summary>
        public static void Exit()
        {
            "Exiting the application".Log("Exit");
            Application.Exit();
        }

        /// <summary>Shows the traditional about dialog box with the program's metadata.</summary>
        public static void ShowAboutBox()
        {
            using AboutBox about = new();
            _ = about.ShowDialog(Form.ActiveForm); // Use showdialog so the windows dosen't disappear immediately
        }

        public static void ShowSettings()
        {
            using SettingsForm settings = new();
            _ = settings.ShowDialog(Form.ActiveForm);
        }

        #endregion Public Methods

        #region Private Methods

        private static bool Confirm()
        {
            using FormConfirm fc = new();
            return fc.ShowDialog(Form.ActiveForm) == DialogResult.OK;
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
                ErrorDialog.SingleInstanceOnly(EnsureSingleInstance, Exit);
                singleInstanceEnforcer.Close();
            }
        }

        /// <summary>Ensures that the path of the executable of the current instance of the program is in the correct location.</summary>
        private static void EnsureStartupPath()
        {
            if (Application.StartupPath != Constants.InstallDir)
                ErrorDialog.WrongStartupPath(EnsureStartupPath, Exit);
        }

        [STAThread]
        private static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            EnsureSingleInstance();
            EnsureStartupPath();
            Settings.LoadDefaults();
            using MainForm mainForm = new();
            Application.Run(mainForm);
            Exit();
        }

        #endregion Private Methods
    }
}
