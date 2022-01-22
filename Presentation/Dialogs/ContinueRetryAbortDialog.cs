namespace RaphaëlBardini.WinClean.Presentation.Dialogs;
public class ContinueRetryAbortDialog : Dialog
{
    private static readonly TaskDialogButtonCollection s_buttons = new() { TaskDialogButton.Continue, TaskDialogButton.Retry, TaskDialogButton.Abort };

    protected ContinueRetryAbortDialog() => Buttons = s_buttons;

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
}
