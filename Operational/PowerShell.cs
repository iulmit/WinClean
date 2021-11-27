
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

    public override void Execute(Logic.IScript script, TimeSpan timeout)
    {
        _ = script ?? throw new ArgumentNullException(nameof(script));
        ExecuteCode($"Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process\r\n{script.Code}", script.Name, script.Extension, timeout);
    }

    #endregion Public Methods
}
