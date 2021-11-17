// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Button = System.Windows.Forms.TaskDialogButton;

namespace RaphaëlBardini.WinClean;

/// <summary>A standardised error message, implementing Microsoft's error messages design reccomendations.</summary>
public class ErrorDialog : TaskDialogPage
{
    #region Public Constructors

    public ErrorDialog()
    {
        Caption = Application.ProductName;
        SizeToContent = true;
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>File inacessible error.</summary>
    /// <param name="path">The path of the inacessible file.</param>
    /// <param name="e">The exception that caused the error.</param>
    /// <inheritdoc cref="DeleteRetryIgnore(Action?, Action?, Action?)"/>
    public static void CantAcessFile(Exception e, string path, Action? retry = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Heading = "Fichier inacessible",
        Text = $"Le fichier \"{path}\" est inacessible. {e?.Message}"
    }.RetryExit(retry);

    /// <summary>Can't create directory error.</summary>
    /// <param name="e">The exception that caused the error.</param>
    /// <param name="path">The path of the directory that couldn't be created.</param>
    /// <inheritdoc cref="RetryExit(Action?, Action?)"/>
    public static void CantCreateDirectory(Exception e, string path, Action? retry = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de créer le dossier \"{path}\". {e?.Message}"
    }.RetryExit(retry);

    /// <summary>Can't create file error.</summary>
    /// <param name="e">The exception that caused the error.</param>
    /// <param name="path">The path of the file that couldn't be created.</param>
    /// <inheritdoc cref="RetryExit(Action?, Action?)"/>
    public static void CantCreateFile(Exception e, string path, Action? retry = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de créer le fichier \"{path}\". {e?.Message}"
    }.RetryExit(retry);

    /// <summary>Can't create log file error.</summary>
    /// <param name="e">The exception that caused the error.</param>
    /// <param name="path">The path of the file that couldn't be deleted.</param>
    /// <inheritdoc cref="RetryIgnore(Action?, Action?)"/>
    public static void CantDeleteFile(Exception e, string path, Action? retry = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de supprimer le fichier \"{path}\". {e?.Message}"
    }.RetryExit(retry);

    /// <summary>Asks the users for confirmation before exiting the application and risking data loss.</summary>
    /// <inheritdoc cref="YesNo()"/>
    public static bool ConfirmAbortOperation() => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Warning,
        Heading = "Abandonner l'opération ?",
        Text = "Abandonner l'opération risque de rendre le système instable. Voulez-vous vraiment continuer ?",
    }.YesNo();

    public static bool ConfirmProgramExit() => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Warning,
        Text = $"Êtes-vous sûr de vouloir quitter {Application.ProductName} ?",
    }.YesNo();

    /// <summary>Asks the user for confirmation before deleting a script</summary>
    /// <inheritdoc cref="YesNo()"/>
    public static bool ConfirmScriptDeletion() => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Warning,
        Heading = "Remplacer le script ?",
        Text = $"Êtes-vous sûr de vouloir supprimer ce script ? Cette action est irréversible."
    }.YesNo();

    /// <summary>Hung script error.</summary>
    /// <param name="filename">The hung script's filename.</param>
    /// <inheritdoc cref="RestartKillIgnore(Action?, Action?, Action?)"/>
    public static void HungScript(string filename, Action? restart = null, Action? kill = null, Action? ignore = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Warning,
        Heading = "Un script est bloqué",
        Text = $"Le script (\"{filename}\") est en cours d'exécution depuis {Properties.Settings.Default.ScriptTimeout} et ne s'arrêtera probablement jamais.",
    }.RestartKillIgnore(restart, kill, ignore);

    /// <summary>Single instance only error.</summary>
    /// <inheritdoc cref="RetryExit(Action?, Action?)"/>
    public static void SingleInstanceOnly(Action? retry = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = "L'application est déjà en cours d'exécution."
    }.RetryExit(retry);

    /// <summary>Wrong startup path error.</summary>
    /// <inheritdoc cref="RetryExit(Action?, Action?)"/>
    public static void WrongStartupPath(Action? retry = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"L'exécutable de l'application se trouve dans un répertoire incorrect. Déplacez-le dans \"{Program.AppDir}\"."
    }.RetryExit(retry);

    #endregion Public Methods

    #region Private Methods

    /// <param name="retry">Invoked when the Retry button of the dialog is clicked.</param>
    /// <param name="ignore">Invoked when the Ignore button of the dialog is clicked.</param>
    /// <param name="delete">Invoked when the Delete Script button of the dialog is clicked.</param>
    private void DeleteRetryIgnore(Action? delete, Action? retry, Action? ignore)
    {
        Button deleteScript = new("Supprimer le script");
        Buttons = new() { Button.Ignore, Button.Retry, deleteScript };
        Button result = this.ShowDialog();
        if (result == deleteScript)
        {
            delete?.Invoke();
        }
        else if (result == Button.Retry)
        {
            retry?.Invoke();
        }
        else
        {
            ignore?.Invoke();
        }
    }

    /// <param name="restart">Invoked when the Restart Script of the dialog button is clicked.</param>
    /// <param name="kill">Invoked when the Kill Script button of the dialog is clicked.</param>
    /// <param name="ignore">Invoked when the Ignore button of the dialog is clicked.</param>
    private void RestartKillIgnore(Action? restart, Action? kill, Action? ignore)
    {
        Button killScript = new("Forcer l'arrêt du script");
        Button restartScript = new("Redémarrer le script");
        Buttons = new() { Button.Ignore, killScript, restartScript };

        Button result = this.ShowDialog();

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
    private void RetryExit(Action? retry)
    {
        Button exit = new("Quitter");
        exit.Click += (_, _) => exit.AllowCloseDialog = ConfirmProgramExit();

        Buttons = new() { exit, Button.Retry };
        if (this.ShowDialog() == exit)
        {
            Program.Exit();
        }
        else
        {
            retry?.Invoke();
        }
    }

    /// <param name="retry">Invoked when the Retry button of the dialog is clicked.</param>
    /// <param name="ignore">Invoked when the Ignore button of the dialog is clicked.</param>
    private void RetryIgnore(Action? retry, Action? ignore)
    {
        Buttons = new() { Button.Ignore, Button.Retry };
        if (this.ShowDialog() == Button.Retry)
        {
            retry?.Invoke();
        }
        else
        {
            ignore?.Invoke();
        }
    }

    /// <returns><see langword="true"/> if the Yes button was clicked, otherwise; <see langword="false"/>.</returns>
    private bool YesNo()
    {
        Buttons = new() { Button.Yes, Button.No };
        return this.ShowDialog() == Button.Yes;
    }

    #endregion Private Methods
}
