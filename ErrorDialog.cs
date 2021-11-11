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

#pragma warning disable CS1573

    /// <summary>Can't create log directory error.</summary>
    /// <param name="e">The exception that caused the error.</param>
    /// <inheritdoc cref="RetryClose(Action?, Action?)" path="/param"/>
    public static void CantCreateLogDir(Exception e, Action? retry = null, Action? close = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de créer le dossier de journalisation. {e?.Message}"
    }.RetryClose(retry, close);

    /// <summary>Can't create script file error.</summary>
    /// <param name="e">The exception that caused the error.</param>
    /// <inheritdoc cref="RetryClose(Action?, Action?)" path="/param"/>
    public static void CantCreateScriptFileInScriptsDir(Exception e, Action? retry = null, Action? close = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de créer le fichier de script dans le répertoire des scripts. {e?.Message}"
    }.RetryClose(retry, close);

    /// <summary>Can't create scripts directory error.</summary>
    /// <param name="e">The exception that caused the error.</param>
    /// <inheritdoc cref="RetryClose(Action?, Action?)" path="/param"/>
    public static void CantCreateScriptsDir(Exception e, Action? retry = null, Action? close = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de créer le dossier des scripts. {e?.Message}"
    }.RetryClose(retry, close);

    public static void CantCreateTempFile(Exception e, Action? retry = null, Action? close = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de créer le fichier temporaire. {e?.Message}"
    }.RetryClose(retry, close);

    /// <summary>Can't create log file error.</summary>
    /// <param name="e">The exception that caused the error.</param>
    /// <inheritdoc cref="RetryIgnore(Action?, Action?)" path="/param"/>
    public static void CantDeleteLogFile(Exception e, Action? retry = null, Action? ignore = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de supprimer le fichier de logs. {e?.Message}"
    }.RetryIgnore(retry, ignore);

    /// <summary>Can't create log file error.</summary>
    /// <param name="e">The exception that caused the error.</param>
    /// <inheritdoc cref="RetryIgnore(Action?, Action?)" path="/param"/>
    public static void CantDeleteScript(Exception e, Action? retry = null, Action? ignore = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"Impossible de supprimer le script. {e?.Message}"
    }.RetryIgnore(retry, ignore);

    /// <summary>Asks the users for confirmation before exiting the application and risking data loss.</summary>
    /// <inheritdoc cref="YesNo()" path="/returns"/>
    public static bool ConfirmAbortOperation() => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Warning,
        Heading = "Abandonner l'opération ?",
        Text = "Abandonner l'opération risque de rendre le système instable. Voulez-vous vraiment continuer ?",
    }.YesNo();

    /// <summary>Asks the user for confirmation before deleting a script</summary>
    /// <inheritdoc cref="YesNo()" path="/returns"/>
    public static bool ConfirmScriptDeletion() => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Warning,
        Heading = "Remplacer le script ?",
        Text = $"Êtes-vous sûr de vouloir supprimer ce script ? Cette Action? est irréversible."
    }.YesNo();

    /// <summary>Hung script error.</summary>
    /// <param name="filename">The hung script's filename.</param>
    /// <inheritdoc cref="RestartKillIgnore(Action?, Action?, Action?)" path="/param"/>
    public static void HungScript(string filename, Action? restart = null, Action? kill = null, Action? ignore = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Warning,
        Heading = "Un script est bloqué",
        Text = $"Le script (\"{filename}\") est en cours d'exécution depuis {Properties.Settings.Default.ScriptTimeout} et ne s'arrêtera probablement jamais.",
    }.RestartKillIgnore(restart, kill, ignore);

    /// <summary>Script not found error.</summary>
    /// <param name="filename">The inacessible script's filename.</param>
    /// <inheritdoc cref="DeleteRetryIgnore(Action?, Action?, Action?)" path="/param"/>
    /// <param name="e">The exception that caused the error.</param>
    public static void ScriptInacessible(string filename, Exception e, Action? retry = null, Action? delete = null, Action? ignore = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Heading = "Script inacessible",
        Text = $"Le script \"{filename}\" est inacessible. {e?.Message}"
    }.DeleteRetryIgnore(delete, retry, ignore);

    /// <summary>Single instance only error.</summary>
    /// <inheritdoc cref="RetryClose(Action?, Action?)" path="/param"/>
    public static void SingleInstanceOnly(Action? retry = null, Action? close = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = "L'application est déjà en cours d'exécution."
    }.RetryClose(retry, close);

    /// <summary>Wrong startup path error.</summary>
    /// <inheritdoc cref="RetryClose(Action?, Action?)" path="/param"/>
    public static void WrongStartupPath(Action? retry = null, Action? close = null) => new ErrorDialog()
    {
        Icon = TaskDialogIcon.Error,
        Text = $"L'exécutable de l'application se trouve dans un répertoire incorrect. Déplacez-le dans \"{Program.InstallDir}\"."
    }.RetryClose(retry, close);

#pragma warning restore CS1573

    #endregion Public Methods

    #region Private Methods

    /// <param name="retry">Invoked when the Retry button of the dialog is clicked.</param>
    /// <param name="ignore">Invoked when the Ignore button of the dialog is clicked.</param>
    /// <param name="delete">Invoked when the Delete Script button of the dialog is clicked.</param>
    private void DeleteRetryIgnore(Action? delete, Action? retry, Action? ignore)
    {
        Button deleteScript = new("Supprimer le script");
        Buttons = new() { Button.Ignore, Button.Retry, deleteScript };
        Button result = Show();
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

        Button result = Show();

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
    /// <param name="close">Invoked when the Close button of the dialog is clicked.</param>
    private void RetryClose(Action? retry, Action? close)
    {
        Buttons = new() { Button.Close, Button.Retry };
        if (Show() == Button.Retry)
        {
            retry?.Invoke();
        }
        else
        {
            close?.Invoke();
        }
    }

    /// <param name="retry">Invoked when the Retry button of the dialog is clicked.</param>
    /// <param name="ignore">Invoked when the Ignore button of the dialog is clicked.</param>
    private void RetryIgnore(Action? retry, Action? ignore)
    {
        Buttons = new() { Button.Ignore, Button.Retry };
        if (Show() == Button.Retry)
        {
            retry?.Invoke();
        }
        else
        {
            ignore?.Invoke();
        }
    }

    private Button Show() => Form.ActiveForm is null ? TaskDialog.ShowDialog(this) : TaskDialog.ShowDialog(Form.ActiveForm, this);

    /// <returns><see langword="true"/> if the Yes button was clicked, otherwise; <see langword="false"/>.</returns>
    private bool YesNo()
    {
        Buttons = new() { Button.Yes, Button.No };
        return Show() == Button.Yes;
    }

    #endregion Private Methods
}
