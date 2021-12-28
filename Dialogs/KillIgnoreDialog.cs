﻿using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Dialogs;

public class KillIgnoreDialog : Dialog
{
    #region Private Fields

    private static readonly TaskDialogButtonCollection s_buttons = new() { Resources.Dialog.KillScriptButton, TaskDialogButton.Ignore };

    #endregion Private Fields

    #region Protected Constructors

    protected KillIgnoreDialog() => Buttons = s_buttons;

    #endregion Protected Constructors

    #region Public Methods

    public static KillIgnoreDialog HungScript(string name, TimeSpan timeout) => new()
    {
        Icon = TaskDialogIcon.Warning,
        Text = string.Format(CultureInfo.CurrentCulture, Resources.Dialog.HungScript, name, timeout)
    };

    public void ShowDialog(Action? killScript, Action? ignore)
    {
        if (this.ShowPage() == s_buttons[0])
        {
            killScript?.Invoke();
        }
        else
        {
            ignore?.Invoke();
        }
    }

    #endregion Public Methods
}