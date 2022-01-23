global using System.Globalization;

using RaphaëlBardini.WinClean.Presentation.Dialogs;

namespace RaphaëlBardini.WinClean.Presentation;

public static class Program
{
    #region Public Properties

    public static Properties.Settings Settings => Properties.Settings.Default;

    #endregion Public Properties

    #region Public Methods

    /// <summary>Exits the program.</summary>
    public static void Exit()
    {
        "Exiting the application.".Log("Exit");

        Settings.Save();

        Application.Exit();
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
        if (!PathEquals(Application.StartupPath, AppDir.Instance.Info.FullName))
        {
            RetryExitDialog.WrongStartupPath.ShowDialog(EnsureStartupPathCorrect);
        }
    }

    [STAThread]
    private static void Main()
    {
        "The application started.".Log("Start", LogLevel.Info);

        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();

        "Ensuring single instance...".Log("Single instance");
        EnsureSingleInstance();
        "Single instance OK.".Log("Single instance");

        "Ensuring startup path correct...".Log("Startup path");
        EnsureStartupPathCorrect();
        "Startup path OK.".Log("Startup path");

        using Forms.MainForm mainForm = new();
        Application.Run(mainForm);

        Exit();
    }

    private static bool PathEquals(string left, string right) => string.Equals(left, right, StringComparison.OrdinalIgnoreCase);

    #endregion Private Methods
}
