// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

global using static System.Globalization.CultureInfo;

using RaphaëlBardini.WinClean.Presentation;
using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.ErrorHandling;

namespace RaphaëlBardini.WinClean;

/// <summary>Holds the <see cref="Main"/> method and application-wide data.</summary>
public static class Program
{
    #region Public Properties

    public static AppDir AppDir => AppDir.Instance;
    public static Properties.Settings Settings => Properties.Settings.Default;

    #endregion Public Properties

    #region Public Methods

    /// <summary>Exits the program.</summary>
    [System.Diagnostics.CodeAnalysis.DoesNotReturn()]
    public static void Exit()
    {
        "Exiting the application.".Log("Exit");

        Settings.Save();

        Application.Exit();
        // If we didnt exit at this stage, we must be out of the message loop. Exit from the environment.
        Environment.Exit(0);
    }

    public static void ShowEmergencyScriptCodeEditor(IWin32Window? owner, IScript script)
    {
        using EmergencyScriptCodeEditor emergencyScriptCodeEditor = new();
        emergencyScriptCodeEditor.Selected = script;
        _ = emergencyScriptCodeEditor.ShowDialog(owner);
    }

    #endregion Public Methods

    #region Private Methods

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
            RetryExitDialog.SingleInstanceOnly.ShowDialog(EnsureSingleInstance);
            singleInstanceEnforcer.Dispose();
        }
    }

    private static void EnsureStartupPathCorrect()
    {
        if (!PathEquals(Application.StartupPath, AppDir.Info.FullName))
        {
            RetryExitDialog.WrongStartupPath.ShowDialog(EnsureStartupPathCorrect);
        }
    }

    [STAThread]
    private static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();

        EnsureSingleInstance();
        EnsureStartupPathCorrect();

        using MainForm mainForm = new();
        Application.Run(mainForm);
    }

    private static bool PathEquals(string left, string right) => string.Equals(left, right, StringComparison.OrdinalIgnoreCase);

    #endregion Private Methods
}
