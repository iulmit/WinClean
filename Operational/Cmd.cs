namespace RaphaëlBardini.WinClean.Operational;

/// <summary>
/// The Windows Command Line interpreter (cmd.exe) script host.
/// </summary>
public class Cmd : ScriptHost
{
    #region Public Properties

    public override ExtensionGroup SupportedExtensions { get; } = new(".cmd", ".bat");

    #endregion Public Properties

    #region Protected Properties

    protected override IncompleteArguments Arguments { get; } = new("/d /c \"\"{0}\"\"");

    protected override FileInfo Executable { get; } = new(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine)!);// ! : comspecs exists natively on windows

    #endregion Protected Properties
}