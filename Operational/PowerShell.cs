namespace RaphaëlBardini.WinClean.Operational;

/// <summary>The Windows PowerShell script host.</summary>
public class PowerShell : ScriptHost
{
    #region Private Fields

    private static readonly string _path = Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe");

    #endregion Private Fields

    #region Public Properties

    public override ExtensionGroup SupportedExtensions { get; } = new(".ps1");

    #endregion Public Properties

    #region Protected Properties

    protected override IncompleteArguments Arguments { get; } = new("-WindowStyle Hidden -NoLogo -NoProfile -NonInteractive -File & \"{0}\"");

    protected override FileInfo Executable { get; } = new(_path);

    #endregion Protected Properties

    #region Public Methods

    public override void ExecuteCode(string code, string scriptName, TimeSpan timeout, Func<string, bool> promptKillOnHung, Func<Exception, FileSystemInfo, FSVerb, bool> promptRetryOnFSError, int promptLimit)
        => base.ExecuteCode($"Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process\r\n{code}", scriptName, timeout, promptKillOnHung, promptRetryOnFSError, promptLimit);

    #endregion Public Methods
}
