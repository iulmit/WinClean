// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Button = System.Windows.Forms.TaskDialogButton;

namespace RaphaëlBardini.WinClean.ErrorHandling;

public class Dialog : TaskDialogPage
{
    #region Protected Constructors

    protected Dialog()
    {
        Caption = Application.ProductName;
        SizeToContent = true;
    }

    #endregion Protected Constructors

    #region Public Methods

    /// <summary>Hung script error.</summary>
    /// <param name="filename">The hung script's filename.</param>
    /// <inheritdoc cref="RestartKillIgnore(Action?, Action?, Action?)"/>
    public static void HungScript(string filename, Action? restart = null, Action? kill = null, Action? ignore = null) => new Dialog()
    {
        Icon = TaskDialogIcon.Warning,
        Heading = "Un script est bloqué",
        Text = $"Le script (\"{filename}\") est en cours d'exécution depuis {Properties.Settings.Default.ScriptTimeout} et ne s'arrêtera probablement jamais.",
    }.RestartKillIgnore(restart, kill, ignore);

    /// <summary>Single instance only error.</summary>
    /// <inheritdoc cref="RetryExit(Action?, Action?)"/>
    public static void SingleInstanceOnly(Action? retry = null) => new Dialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = "L'application est déjà en cours d'exécution."
    }.RetryExit(retry);

    /// <summary>Wrong startup path error.</summary>
    /// <inheritdoc cref="RetryExit(Action?, Action?)"/>
    public static void WrongStartupPath(Action? retry = null) => new Dialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"L'exécutable de l'application se trouve dans un répertoire incorrect. Déplacez-le dans \"{Program.AppDir}\"."
    }.RetryExit(retry);

    #endregion Public Methods

    #region Protected Methods

    /// <param name="restart">Invoked when the Restart Script of the dialog button is clicked.</param>
    /// <param name="kill">Invoked when the Kill Script button of the dialog is clicked.</param>
    /// <param name="ignore">Invoked when the Ignore button of the dialog is clicked.</param>
    protected void RestartKillIgnore(Action? restart, Action? kill, Action? ignore)
    {
        Button killScript = new("Forcer l'arrêt du script");
        Button restartScript = new("Redémarrer le script");
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
        Button exit = new("Quitter");
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
