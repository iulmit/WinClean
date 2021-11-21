// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using Button = System.Windows.Forms.TaskDialogButton;

namespace RaphaëlBardini.WinClean.ErrorHandling;

public class Dialog : TaskDialogPage
{
    #region Public Constructors

    public Dialog()
    {
        Caption = Application.ProductName;
        SizeToContent = true;
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>Hung script error.</summary>
    /// <param name="name">The hung script's name.</param>
    /// <inheritdoc cref="RestartKillIgnore(Action?, Action?, Action?)"/>
    public static void HungScript(string name, Action? restart = null, Action? kill = null, Action? ignore = null) => new Dialog()
    {
        Icon = TaskDialogIcon.Warning,
        Text = string.Format(CurrentCulture, Resources.Dialog.HungScript, name, Program.Settings.ScriptTimeout),
    }.RestartKillIgnore(restart, kill, ignore);

    /// <summary>Single instance only error.</summary>
    /// <inheritdoc cref="RetryExit(Action?, Action?)"/>
    public static void SingleInstanceOnly(Action? retry = null) => new Dialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = Resources.Dialog.SingleInstanceOnly,
    }.RetryExit(retry);

    /// <summary>Wrong startup path error.</summary>
    /// <inheritdoc cref="RetryExit(Action?, Action?)"/>
    public static void WrongStartupPath(Action? retry = null) => new Dialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = string.Format(CurrentCulture, Resources.Dialog.WrongStartupPath, Program.AppDir.Info)
    }.RetryExit(retry);

    #endregion Public Methods

    #region Protected Methods

    /// <param name="restart">Invoked when the Restart Script of the dialog button is clicked.</param>
    /// <param name="kill">Invoked when the Kill Script button of the dialog is clicked.</param>
    /// <param name="ignore">Invoked when the Ignore button of the dialog is clicked.</param>
    protected void RestartKillIgnore(Action? restart, Action? kill, Action? ignore)
    {
        Button killScript = new(Resources.Dialog.KillScriptButton);
        Button restartScript = new(Resources.Dialog.RestartScriptButton);
        Buttons = new() { Button.Ignore, killScript, restartScript };

        Button result = this.ShowPageInForegroundWindow();

        if (result == restartScript)
        {
            restart?.Invoke();
        }
        else if (result == killScript)
        {
            kill?.Invoke();
        }
        else
        {
            ignore?.Invoke();
        }
    }

    /// <param name="retry">Invoked when the Retry button of the dialog is clicked.</param>
    /// <remarks>Exits the program wh en Exit button clicked.</remarks>
    protected void RetryExit(Action? retry)
    {
        Button exit = new(Resources.Dialog.ExitButton);
        exit.Click += (_, _) => exit.AllowCloseDialog = ConfirmationDialog.ProgramExit.ShowDialog();

        Buttons = new() { exit, Button.Retry };
        if (this.ShowPageInForegroundWindow() == exit)
        {
            Program.Exit();
        }
        else
        {
            retry?.Invoke();
        }
    }

    #endregion Protected Methods
}
