using RaphaëlBardini.WinClean.Logic;
namespace RaphaëlBardini.WinClean.Operational;

/// <summary>The Windows PowerShell script host.</summary>
internal class PowerShell : ScriptHost
{
    private static readonly string _path = Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe");

    /// <inheritdoc/>
    public override ExtensionGroup SupportedExtensions => new(".ps1");

    /// <inheritdoc/>
    public override void Execute(IScript script)
        => ExecuteCode($"Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process\r\n{script.Code}", script.Name, script.Extension);

    /// <inheritdoc/>
    protected override IncompleteArguments Arguments => new("-WindowStyle Hidden -NoLogo -NoProfile -NonInteractive -File & \"{0}\"");

    /// <inheritdoc/>
    protected override FileInfo Executable => new(_path);
}
