using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>
/// The Windows PowerShell script host.
/// </summary>
internal class PowerShell : ScriptHost
{
    #region Private Fields

    private static readonly string _path = Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe");

    #endregion Private Fields

    #region Public Properties

    /// <inheritdoc/>
    public override ExtensionGroup SupportedExtensions => new(".ps1");

    #endregion Public Properties

    #region Protected Properties

    /// <inheritdoc/>
    protected override IncompleteArguments Arguments => new("-WindowStyle Hidden -NoLogo -NoProfile -NonInteractive -File & \"{0}\"");

    /// <inheritdoc/>
    protected override FileInfo Executable => new(_path);

    #endregion Protected Properties

    #region Public Methods

    /// <inheritdoc/>
    public override void Execute(IScript script)
        => ExecuteCode($"Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process\r\n{script.Code}", script.Name, script.Extension);

    #endregion Public Methods
}