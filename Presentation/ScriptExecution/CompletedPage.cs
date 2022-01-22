namespace RaphaëlBardini.WinClean.Presentation.ScriptExecution;

public class CompletedPage : TaskDialogPage
{
    private readonly TaskDialogButton _restart = new(Resources.ScriptExecutionWizard.RestartVerb);
    public CompletedPage(int scriptsCount, TimeSpan elapsed)
    {
        AllowCancel = AllowMinimize = true;
        Buttons = new TaskDialogButtonCollection() { TaskDialogButton.Close, _restart };
        Caption = Resources.ScriptExecutionWizard.CompletedPageCaption;
        Icon = TaskDialogIcon.ShieldSuccessGreenBar;
        Expander = new(string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutionWizard.CompletedPageExpander, scriptsCount, elapsed))
        {
            Expanded = Program.Settings.ShowScriptExecutionCompletedDetails,
        };
        Heading = Resources.ScriptExecutionWizard.CompletedPageHeading;
        Text = Resources.ScriptExecutionWizard.CompletedPageText;

    }

    public event EventHandler RestartClicked { add => _restart.Click += value; remove => _restart.Click -= value; }
}
