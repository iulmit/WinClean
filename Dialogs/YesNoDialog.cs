using RaphaëlBardini.WinClean.Operational;
using Button = System.Windows.Forms.TaskDialogButton;

namespace RaphaëlBardini.WinClean.Dialogs;

public class YesNoDialog : Dialog
{
    #region Protected Constructors

    protected YesNoDialog() => Buttons = new() { Button.Yes, Button.No };

    #endregion Protected Constructors

    #region Public Properties

    public static YesNoDialog AbortOperation => new()
    {
        Icon = TaskDialogIcon.Warning,
        Text = Resources.Dialog.ConfirmAbortOperation
    };

    public static YesNoDialog ProgramExit => new()
    {
        Icon = TaskDialogIcon.Warning,
        Text = string.Format(CultureInfo.CurrentCulture, Resources.Dialog.ConfirmProgramExit, Application.ProductName)
    };

    public static YesNoDialog ScriptDeletion => new()
    {
        Icon = TaskDialogIcon.Warning,
        Text = Resources.Dialog.ConfirmScriptDeletion
    };

    public static YesNoDialog SystemRestorePoint => new()
    {
        Icon = TaskDialogIcon.Warning,
        Text = Resources.Dialog.SystemRestorePoint
    };

    #endregion Public Properties

    #region Public Methods

    public bool ShowDialog() => this.ShowPage() == Button.Yes;

    #endregion Public Methods
}