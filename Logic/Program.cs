// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
                (CheckStartupPath(), ErrorMessages.WrongExecutablePath(Application.StartupPath, Constants.InstallDir)),
                (PInvokes.NativeMethods.SetProcessDPIAware(), ErrorMessages.SetProcessDpiAwareReturnedFalse)
            });
            if (validator.FalseAssertions.Any())
            {
                validator.FalseAssertions.First().Handle(Error.Level.Error);
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
            using Presentation.MainForm mainForm = new();
            using Presentation.FormConfirm formConfirm = new();

            CheckStartAble();
            (DialogResult result, IEnumerable<Script> selectedScripts) = mainForm.ShowDialog();
            if (result == DialogResult.OK && formConfirm.ShowDialog() == DialogResult.OK)
            {
                foreach (Script s in selectedScripts)
                {
                    try
                    {
                        s.Execute();
                    }
                    catch (HungScriptException e)
                    {
                        e.Handle(Error.Level.Error);
                    }
                }
            }
            "Exiting the application.".Log("Exit");
            LogManager.Dispose();
        }

        #endregion Private Methods
    }
}
