// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Presentation;

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

        /// <summary>Ensures that this is the first instance of the program</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000", Justification = "If the mutex is disposed, it won't work.")]
        private static void EnsureSingleInstance()
        {
            System.Threading.Mutex singleInstanceEnforcer = new(true, $"Global\\{Application.ProductName}", out bool firstInstance);
            if (firstInstance)
                GC.KeepAlive(singleInstanceEnforcer);
            else
            {
                DisplayError.SingleInstanceOnly(Exit, EnsureSingleInstance);
                singleInstanceEnforcer.Close();
            }
        }

        /// <summary>Ensures that the path of the executable of the current instance of the program is in the correct location.</summary>
        private static void EnsureStartupPath()
        {
            if (Helpers.PathEquals(Application.StartupPath, Constants.InstallDir))
                DisplayError.WrongStartupPath(Exit, EnsureStartupPath);
        }

        /// <summary>The application's entry point</summary>
        [STAThread]
        private static void Main()
        {
            EnsureSingleInstance();
            EnsureStartupPath();

            using MainForm mainForm = new();
            using FormConfirm formConfirm = new();

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
            catch (System.IO.FileNotFoundException)
            {
                DisplayError.ScriptNotFound(script.FullPath, null/*chaud : supprimer le script des settings*/, () => { Run(script); });
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
            "test".Log("t0");
            "Exiting the application".Log("Exit");
            LogManager.Dispose();
            Environment.Exit(0);
        }
        #endregion Public Methods
    }
}
