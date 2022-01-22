namespace RaphaëlBardini.WinClean.Presentation.ScriptExecution;

public class WarningPage : TaskDialogPage
{
    private readonly TaskDialogButton _continue = TaskDialogButton.Continue;
    private readonly TaskDialogVerificationCheckBox _verification = new(Resources.ScriptExecutionWizard.WarningPageVerification);

    public WarningPage()
    {
        AllowCancel = AllowMinimize = SizeToContent = true;
        Buttons = new TaskDialogButtonCollection() { _continue, TaskDialogButton.Cancel };
        Caption = Application.ProductName;
        Heading = Resources.ScriptExecutionWizard.WarningPageHeading;
        Text = Resources.ScriptExecutionWizard.WarningPageText;

        Icon = TaskDialogIcon.Warning;
        Verification = _verification;


        _continue.AllowCloseDialog = _continue.Enabled = false;

        _verification.CheckedChanged += (s, e)
            => _continue.Enabled = _verification.Checked;
    }

    public event EventHandler ContinueClicked { add => _continue.Click += value; remove => _continue.Click -= value; }
}

