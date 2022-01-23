namespace RaphaëlBardini.WinClean.Presentation.Dialogs;

public class ContinueRetryAbortDialog : Dialog
{
    #region Private Fields

    private static readonly TaskDialogButtonCollection s_buttons = new() { TaskDialogButton.Continue, TaskDialogButton.Retry, TaskDialogButton.Abort };

    #endregion Private Fields

    #region Protected Constructors

    protected ContinueRetryAbortDialog() => Buttons = s_buttons;

    #endregion Protected Constructors

    #region Public Properties

    public static ContinueRetryAbortDialog SystemRestoreDisabled => new()
    {
        Icon = TaskDialogIcon.Error,
        Heading = Resources.Dialog.SystemProtectionDisabledHeading,
        Expander = new(Resources.Dialog.SystemProtectionDisabledExpander)
        {
            CollapsedButtonText = Resources.Dialog.SystemProtectionDisabledExpanderCollapsedButton,
            ExpandedButtonText = Resources.Dialog.SystemProtectionDisabledExpanderExpandedButton
        }
    };

    #endregion Public Properties
}
