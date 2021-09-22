// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RaphaëlBardini.WinClean.Presentation;

namespace RaphaëlBardini.WinClean
{
    /// <summary>
    /// Holds the <see cref="Main"/> method and application-wide data.
    /// </summary>
    public static class Program
    {
        #region Public Constructors

        static Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Scripts = DefaultScripts.ToList();
            Presets = DefaultPresets.ToList();
            MainForm = new MainForm();
        }

        public static IReadOnlyCollection<Preset> DefaultPresets => new Preset[]
        {
                new Preset(Resources.Presets.AllName, Resources.Presets.AllDesc, Scripts),
                new Preset(Resources.Presets.NoneName, Resources.Presets.NoneDesc),
                new Preset(Resources.Presets.MaintenanceName, Resources.Presets.MaintenanceDesc, Scripts),
                new Preset(Resources.Presets.DebloatName, Resources.Presets.DebloatDesc, Scripts)
        };

        public static IReadOnlyCollection<Script> DefaultScripts => new Script[]
        {
                new CmdScript(new Logic.Impact[] { new Logic.Impact(Resources.ImpactType.Visuals, Logic.ImpactLevel.Positive) }, "foo.cmd", "Foo", "foo description 0"),
                new WScript(new Logic.Impact[] { new Logic.Impact(Resources.ImpactType.Ergonomics, Logic.ImpactLevel.Mixed) }, "bar.vbs", "Bar", "bar description 1"),
                new RegScript(new Logic.Impact[] { new Logic.Impact(Resources.ImpactType.StartupTime, Logic.ImpactLevel.Negative) }, "dummy.reg", "Dummy", "dummy description 2"),
                new Ps1Script(new Logic.Impact[] { new Logic.Impact(Resources.ImpactType.ResponseTime, Logic.ImpactLevel.Positive) }, "hello world.ps1", "Ps1", "hello world description 3")
        };

        #endregion Public Constructors

        #region Public Properties

        public static MainForm MainForm { get; }
        public static ICollection<Preset> Presets { get; }
        public static ICollection<Script> Scripts { get; }

        #endregion Public Properties

        #region Private Methods

        /// <summary>Checks that the OS Version is correct. If not, throws an <see cref="ApplicationException"/>.</summary>
        /// <exception cref="ApplicationException"/>
        private static void CheckOSVersion()
        {
            if (Environment.OSVersion.Version.CompareTo(new Version(6, 2)) < 0)// Corresponds to
                                                                               //
                                                                               //
                                                                               //
                                                                               // 8 or superior
                throw new ApplicationException($"{Resources.ErrorMessages.BadOSVersion}{Constants.NL}{Environment.OSVersion.VersionString}");
        }

        /// <summary>Check that the call to <see cref="SetProcessDPIAware()"/> succeeded. If not, throws an <see cref="ApplicationException"/>.</summary>
        /// <exception cref="ApplicationException"/>
        private static void CheckSetDpiAware()
        {
            if (!SetProcessDPIAware())
                throw new ApplicationException(Resources.ErrorMessages.SetProcessDpiAwareReturned0);
        }

        /// <summary>Checks that this is the first instance of the program. If not, throws an <see cref="ApplicationException"/>.</summary>
        /// <exception cref="ApplicationException"/>
        private static void CheckSingleInstance()
        {
            System.Threading.Mutex singleInstanceEnforcer = new(true, $"Global\\{Application.ProductName}", out bool firstInstance);
            if (firstInstance)
                GC.KeepAlive(singleInstanceEnforcer);
            else
                throw new ApplicationException(Resources.ErrorMessages.AppAlreadyRunning);
        }

        private static void CheckStartAble()
        {
            try
            {
                CheckOSVersion();
                CheckSetDpiAware();
                CheckSingleInstance();
                CheckStartupPath();
            }
            catch (ApplicationException e)
            {
                e.Handle();
            }
        }

        /// <summary>Checks that the path of the executable of the current instance of the program is in the correct location.
        /// If not, throws an <see cref="ApplicationException"/>.</summary>
        /// <exception cref="ApplicationException"/>
        private static void CheckStartupPath()
        {
            if (!Constants.INSTALL_DIR.Equals(Application.StartupPath))
                throw new ApplicationException(Resources.ErrorMessages.WrongExecutablePath);
        }

        /// <summary>The application's entry point</summary>
        [STAThread]
        private static void Main()
        {
            CheckStartAble();
            Application.Run(MainForm);
        }

        /// <summary>Enables support for non-standard DPI displays.</summary>
        /// <returns><see langword="true"/> if the call succeeded, <see langword="false"/> if it didn't.</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        #endregion Private Methods
    }
}
