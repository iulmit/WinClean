// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Presentation;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean;

/// <summary>Holds the <see cref="Main"/> method and application-wide data.</summary>
public static class Program
{
    #region Public Fields

    // chaud : a lire de puis le registre entree installation. Besoin d'un installeur pour faire ça.
    /// <summary>Application install directory.</summary>
    public static readonly DirectoryInfo InstallDir = new(Application.StartupPath);

    #endregion Public Fields

    #region Public Methods

    /// <summary>Runs the specified scripts.</summary>
    /// <remarks>If there is more than 1 script to run, shows a GUI.</remarks>
    /// <param name="scripts"></param>
    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public static void ConfirmAndExecuteScripts(IList<IScript> scripts)
    {
        if (scripts is null)
        {
            throw new ArgumentNullException(nameof(scripts));
        }
        ScriptExecutor executor = new(scripts);
        if (scripts.Count > 1)
        {
            executor.ExecuteUI();
        }
        else
        {
            executor.ExecuteNoUI();
        }

    }

    /// <summary>Exits the program.</summary>
    /// <remarks>Doesn't return.</remarks>
    public static void Exit()
    {
        "Exiting the application.".Log("Exit");
        Application.Exit();
        "Application failed to exit ! Exiting from the environment.".Log("Exit");
        Environment.Exit(0);
    }

    /// <summary>Displays the <see cref="AboutBox"/> form.</summary>
    public static void ShowAboutBox()
    {
        using AboutBox about = new();
        _ = about.ShowDialog(Form.ActiveForm); // Use showdialog so the windows dosen't disappear immediately
    }

    /// <summary>Displays the <see cref="Settings"/> form.</summary>
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
