// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.ErrorHandling;

public class RetryExitDialog : Dialog
{
    private static readonly TaskDialogButtonCollection s_buttons = new() { TaskDialogButton.Retry, Resources.Dialog.ExitButton };

    public RetryExitDialog()
    {
        s_buttons[1].Click += (_, _) => s_buttons[1].AllowCloseDialog = YesNoDialog.ProgramExit.ShowDialog();
        Buttons = s_buttons;
    }

    public void ShowDialog(Action? retry)
    {
        if (this.ShowPage() == TaskDialogButton.Retry)
        {
            retry?.Invoke();
        }
        else
        {
            Program.Exit();
        }
    }

    public static RetryExitDialog WrongStartupPath => new()
    {
        Icon = TaskDialogIcon.Error,
        Text = string.Format(CurrentCulture, Resources.Dialog.WrongStartupPath, Program.AppDir.Info)
    };

    public static RetryExitDialog SingleInstanceOnly => new()
    {
        Icon = TaskDialogIcon.Error,
        Text = Resources.Dialog.SingleInstanceOnly
    };

}
