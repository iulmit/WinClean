// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using RaphaëlBardini.WinClean.Presentation;
using System.Text;

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

        /// <summary>Asks for confirmation and runs the script.</summary>
        /// <remarks>If there is more than 1 script to run, show a GUI</remarks>
        /// <param name="scripts"></param>
        /// <param name="owner"></param>
        public static void ConfirmAndExecuteScripts(IEnumerable<Script> scripts, IWin32Window owner = null)
        {
            if (scripts is null)
                throw new ArgumentNullException(nameof(scripts));
            if (scripts.Count() > 1)
            {
                if (Confirm(owner))
                {
                    using ScriptExecutorGUI executor = new(scripts);
                    executor.ExecuteAll(owner);
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
                ErrorDialog.SingleInstanceOnly(null, EnsureSingleInstance, Exit);
                singleInstanceEnforcer.Close();
            }
        }

        /// <summary>Ensures that the path of the executable of the current instance of the program is in the correct location.</summary>
        private static void EnsureStartupPath()
        {
            if (Application.StartupPath != Constants.InstallDir)
                ErrorDialog.WrongStartupPath(null, EnsureStartupPath, Exit);
        }

        [STAThread]
        private static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            EnsureSingleInstance();
            EnsureStartupPath();
            Application.Run(s_mainForm);
            Exit();
        }
        private struct LogEntry
        {
            #region Public Properties

            public int Index { get; set; }
            public LogLevel Level { get; set; }
            public int CallLine { get; set; }
            public string Caller { get; set; }
            public string Happening { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
            public string CallFileFullPath { get; set; }

            #endregion Public Properties
        }
        #endregion Private Methods
    }
}
