namespace RaphaëlBardini.WinClean.ErrorHandling;

public class KillScriptEditCodeIgnoreDialog : Dialog
{
    private static readonly TaskDialogButtonCollection s_buttons = new() { new(Resources.Dialog.KillScriptButton), new(Resources.Dialog.EditCodeButton), TaskDialogButton.Ignore };

    protected KillScriptEditCodeIgnoreDialog() => Buttons = s_buttons;

    public Result ShowDialog()
    {
        TaskDialogButton result = this.ShowPage();
        return result == s_buttons[0]
                 ? Result.KillScript
                 : result == s_buttons[1]
                     ? Result.EditCode
                     : Result.Ignore;
    }

    public enum Result
    {
        KillScript,
        EditCode,
        Ignore
    }

    public static KillScriptEditCodeIgnoreDialog HungScript(string name) => new()
    {
        Icon = TaskDialogIcon.Warning,
        Text = string.Format(CurrentCulture, Resources.Dialog.HungScript, name, Program.Settings.ScriptTimeout)
    };
}
