
using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Dialogs;

public class RetryExitDialog : Dialog
{
    #region Private Fields

    private static readonly TaskDialogButtonCollection s_buttons = new() { TaskDialogButton.Retry, Resources.Dialog.ExitButton };

    #endregion Private Fields

    #region Protected Constructors

    protected RetryExitDialog()
    {
        s_buttons[1].Click += (_, _) => s_buttons[1].AllowCloseDialog = YesNoDialog.ProgramExit.ShowDialog();
        Buttons = s_buttons;
    }

    #endregion Protected Constructors

    #region Private Properties

    public static RetryExitDialog SingleInstanceOnly => new()
    {
        Icon = TaskDialogIcon.Error,
        Text = Resources.Dialog.SingleInstanceOnly
    };

    public static RetryExitDialog WrongStartupPath => new()
    {
        Icon = TaskDialogIcon.Error,
        Text = string.Format(CultureInfo.CurrentCulture, Resources.Dialog.WrongStartupPath, AppDir.Instance.Info)
    };

    #endregion Public Properties

    #region Public Methods

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

    #endregion Public Methods
}
