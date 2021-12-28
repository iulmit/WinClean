namespace RaphaëlBardini.WinClean.Presentation;

public class AppDir
{
    #region Public Properties

    public static AppDir Instance { get; } = new();

    public static ScriptsDir ScriptsDir => ScriptsDir.Instance;

    // chaud : read install dir from registry program entry. Needs an installer.
    public DirectoryInfo Info { get; } = new(Application.StartupPath);

    #endregion Public Properties
}