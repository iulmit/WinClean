namespace RaphaëlBardini.WinClean.Presentation.ScriptExecution;

public class CompletedPage : TaskDialogPage
{
    #region Private Fields

    private readonly TaskDialogButton _restart = new(Resources.ScriptExecutionWizard.RestartVerb);

    #endregion Private Fields

    #region Public Constructors

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

    #endregion Public Constructors

    #region Public Events

    public event EventHandler RestartClicked { add => _restart.Click += value; remove => _restart.Click -= value; }

    #endregion Public Events
}
