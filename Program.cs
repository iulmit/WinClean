﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Presentation;

using System.Collections.Generic;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean;

/// <summary>
/// Holds the <see cref="Main"/> method and application-wide data.
/// </summary>
public static class Program
{
    #region Public Fields

    // chaud : a lire de puis le registre entree installation. Besoin d'un installeur pour faire ça.
    /// <summary>
    /// Application install directory.
    /// </summary>
    public static readonly DirectoryInfo InstallDir = new(Application.StartupPath);

    #endregion Public Fields

    #region Public Methods

    /// <summary>
    /// Runs the specified scripts.
    /// </summary>
    /// <remarks>If there is more than 1 script to run, shows a GUI.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public static void ConfirmAndExecuteScripts(IList<IScript> scripts)
    {
        ScriptExecutor executor = new(scripts ?? throw new ArgumentNullException(nameof(scripts)));
        if (scripts.Count > 1)
        {
            executor.ExecuteUI();
        }
        else
        {
            executor.ExecuteNoUI();
        }
    }

    /// <summary>
    /// Exits the program.
    /// </summary>
    /// <remarks>Doesn't return.</remarks>
    public static void Exit()
    {
        "Exiting the application.".Log("Exit");
        Application.Exit();
        "Application failed to exit ! Exiting from the environment.".Log("Exit");
        Environment.Exit(0);
    }

    /// <summary>
    /// Displays the <see cref="AboutBox"/> form.
    /// </summary>
    public static void ShowAboutBox()
    {
        using AboutBox about = new();
        _ = about.ShowDialog(Form.ActiveForm); // Use showdialog so the windows dosen't disappear immediately
    }

    /// <summary>
    /// Displays the <see cref="Settings"/> form.
    /// </summary>
    public static void ShowSettings()
    {
        using Settings settings = new();
        _ = settings.ShowDialog(Form.ActiveForm);
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
            ErrorDialog.SingleInstanceOnly(EnsureSingleInstance, Exit);
            singleInstanceEnforcer.Dispose();
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
