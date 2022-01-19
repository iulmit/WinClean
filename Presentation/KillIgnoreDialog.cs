using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Presentation;

public class KillIgnoreDialog : Dialog
{
    #region Private Fields

    private static readonly TaskDialogButtonCollection s_buttons = new() { Resources.Dialog.KillScriptButton, TaskDialogButton.Ignore };

    #endregion Private Fields

    #region Protected Constructors

    protected KillIgnoreDialog() => Buttons = s_buttons;

    #endregion Protected Constructors

    #region Public Methods

    public static KillIgnoreDialog HungScript(string name, TimeSpan timeout) => new()
    {
        Icon = TaskDialogIcon.Warning,
        Text = string.Format(CultureInfo.CurrentCulture, Resources.Dialog.HungScript, name, timeout)
    };

    /// <summary>Shows the dialog.</summary>
    /// <returns>
    /// <see langword="true"/> if the users clicked on the Kill button, and <see langword="false"/> if the user clicked on the
    /// Ignore button.
    /// </returns>
    public bool ShowDialog() => this.ShowPage() == s_buttons[0];

    #endregion Public Methods
}
