// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Presentation;

using System.Windows.Forms;

namespace RaphaëlBardini.WinClean;

/// <summary>Holds the <see cref="Main"/> method and application-wide data.</summary>
public static class Program
{
    #region Public Properties

    // chaud : read install dir from registry program entry. Needs an installer.
    /// <summary>Application install directory.</summary>
    public static DirectoryInfo AppDir => new(Application.StartupPath);

    #endregion Public Properties

    #region Public Methods

    /// <summary>Exits the program.</summary>
    /// <remarks>Doesn't return.</remarks>
    public static void Exit()
    {
        "Exiting the application.".Log("Exit");
        Application.Exit();
        // If we didnt exit at this stage, we must be out of the message loop. Exit from the environment.
        Environment.Exit(0);
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
            ErrorDialog.SingleInstanceOnly(EnsureSingleInstance);
            singleInstanceEnforcer.Dispose();
        }
    }

    private static void EnsureStartupPath()
    {
        if (!Helpers.PathEquals(Application.StartupPath, AppDir.FullName))
        {
            ErrorDialog.WrongStartupPath(EnsureStartupPath);
        }
    }

    [STAThread]
    private static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();

        EnsureSingleInstance();
        EnsureStartupPath();

        using MainForm mainForm = new();
        Application.Run(mainForm);
    }

    #endregion Private Methods
}
