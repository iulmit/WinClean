// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.ErrorHandling;

public class KillEditIgnoreDialog : Dialog
{
    private static readonly TaskDialogButtonCollection s_buttons = new() { new(Resources.Dialog.KillScriptButton), new(Resources.Dialog.EditCodeButton), TaskDialogButton.Ignore };

    protected KillEditIgnoreDialog() => Buttons = s_buttons;

    public void ShowDialog(Action? killScript, Action? editCode, Action? ignore)
    {
        TaskDialogButton result = this.ShowPage();
        if (result == s_buttons[0])
        {
            killScript?.Invoke();
        }
        else if (result == s_buttons[1])
        {
            editCode?.Invoke();
        }
        else
        {
            ignore?.Invoke();
        }
    }

    public static KillEditIgnoreDialog HungScript(string name, TimeSpan timeout) => new()
    {
        Icon = TaskDialogIcon.Warning,
        Text = string.Format(CurrentCulture, Resources.Dialog.HungScript, name, timeout)
    };
}
