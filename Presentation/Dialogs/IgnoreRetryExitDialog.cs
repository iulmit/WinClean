using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Presentation.Dialogs;

public class IgnoreRetryExitDialog : Dialog
{
    #region Private Fields

    private static readonly TaskDialogButtonCollection s_buttons = new() { TaskDialogButton.Ignore, TaskDialogButton.Retry, Resources.Dialog.ExitButton };

    #endregion Private Fields

    #region Public Constructors

    public IgnoreRetryExitDialog()
    {
        s_buttons[2].Click += (_, _) => s_buttons[2].AllowCloseDialog = YesNoDialog.ProgramExit.ShowDialog();
        Buttons = s_buttons;
    }

    #endregion Public Constructors

    #region Public Methods

    public DialogResult ShowDialog()
    {
        TaskDialogButton result = this.ShowPage();

        if (result == s_buttons[1])
        {
            return DialogResult.Ignore;
        }
        else if (result == s_buttons[2])
        {
            return DialogResult.Retry;
        }
        else
        {
            Program.Exit();
            return DialogResult.None;
        }
    }

    #endregion Public Methods
}
