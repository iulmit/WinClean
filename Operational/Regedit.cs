using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>
/// Windows Registry Editor
/// </summary>
public class Regedit : ScriptHost
{
    /// <inheritdoc/>
    public override ExtensionGroup SupportedExtensions => new(".reg");

    /// <inheritdoc/>
    protected override IncompleteArguments Arguments => new("/s {0}");

    /// <inheritdoc/>
    protected override FileInfo Executable => new(Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe"));
}
