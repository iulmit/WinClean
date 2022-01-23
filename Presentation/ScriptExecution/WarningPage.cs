namespace RaphaëlBardini.WinClean.Presentation.ScriptExecution;

public class WarningPage : TaskDialogPage
{
    #region Private Fields

    private readonly TaskDialogButton _continue = TaskDialogButton.Continue;
    private readonly TaskDialogVerificationCheckBox _verification = new(Resources.ScriptExecutionWizard.WarningPageVerification);

    #endregion Private Fields

    #region Public Constructors

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

    #endregion Public Constructors

    #region Public Events

    public event EventHandler ContinueClicked { add => _continue.Click += value; remove => _continue.Click -= value; }

    #endregion Public Events
}
