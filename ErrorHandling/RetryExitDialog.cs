// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.ErrorHandling;

public class RetryExitDialog : Dialog
{
    private static readonly TaskDialogButtonCollection s_buttons = new() { TaskDialogButton.Retry, Resources.Dialog.ExitButton };

    static RetryExitDialog()
        => s_buttons[0].Click += (_, _) => s_buttons[0].AllowCloseDialog = YesNoDialog.ProgramExit.ShowDialog();

    /// <summary>
    /// Shows the dialog and exits the program if the users clicks on the Exit button.
    /// </summary>
    public void ShowDialogAssertExit()
    {
        if (this.ShowPage() == s_buttons[1])
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
