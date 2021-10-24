// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Button = System.Windows.Forms.TaskDialogButton;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A standardised error message, implementing Microsoft's error messages design reccomendations.</summary>
    internal class ErrorDialog : TaskDialogPage
    {
        #region Public Properties

        /// <summary>Text displayed in the dialog's title bar.</summary>
        public static new string Caption => Application.ProductName;

        /// <inheritdoc cref="TaskDialogPage.SizeToContent" path="/summary"/>
        public static new bool SizeToContent => true;

        #endregion Public Properties

        #region Public Methods

#pragma warning disable CS1573

        /// <summary>Can't create log directory error.</summary>
        /// <param name="e">The exception that caused the error.</param>
        /// <inheritdoc cref="RetryClose(Action, Action)" path="/param"/>
        public static void CantCreateLogDir(Exception e, Action retry = null, Action close = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = $"Impossible de créer le dossier de journalisation. {e.Message}"
        }.RetryClose(retry, close);

        /// <summary>Can't create scripts directory error.</summary>
        /// <param name="e">The exception that caused the error.</param>
        /// <inheritdoc cref="RetryClose(Action, Action)" path="/param"/>
        public static void CantCreateScriptsDir(Exception e, Action retry = null, Action close = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = $"Impossible de créer le dossier des scripts. {e.Message}"
        }.RetryClose(retry, close);

        /// <summary>Can't create scripts directory error.</summary>
        /// <param name="e">The exception that caused the error.</param>
        /// <inheritdoc cref="RetryClose(Action, Action)" path="/param"/>
        public static void ScriptFileInacessible(Exception e, Action retry = null, Action close = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = $"Impossible de créer le fichier de script. {e.Message}"
        }.RetryClose(retry, close);

        /// <summary>Can't create log file error.</summary>
        /// <param name="e">The exception that caused the error.</param>
        /// <inheritdoc cref="RetryIgnore(Action, Action)" path="/param"/>
        public static void CantDeleteLogFile(Exception e, Action retry = null, Action ignore = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = $"Impossible de supprimer le fichier de logs. {e.Message}"
        }.RetryIgnore(retry, ignore);

        /// <summary>Asks the users for confirmation on exiting the application and potentially loosing data.</summary>
        /// <inheritdoc cref="YesNo(Action, Action)" path="/param"/>
        public static void ConfirmAbortOperation(Action yes = null, Action no = null)
        {
            ErrorDialog dialog = new()
            {
                Icon = TaskDialogIcon.Warning,
                Heading = "Abandonner l'opération ?",
                Text = "Abandonner l'opération risque de rendre le système instable. Voulez-vous vraiment continuer ?",
            };
            dialog.YesNo(yes, no);
        }

        /// <summary>Hung script error.</summary>
        /// <param name="script">The hung script's path.</param>
        /// <inheritdoc cref="RestartKillIgnore(Action, Action, Action)" path="/param"/>
        public static void HungScript(FileInfo script, Action restart = null, Action kill = null, Action ignore = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Warning,
            Heading = "Un script est bloqué",
            Text = $"Le script (\"{script.Name}\") est en cours d'exécution depuis {Operational.IScriptHost.Timeout} et ne s'arrêtera probablement jamais.",
        }.RestartKillIgnore(restart, kill, ignore);

        /// <summary>Script not found error.</summary>
        /// <param name="script">The hung script's path.</param>
        /// <inheritdoc cref="DeleteRetryIgnore(Action, Action, Action)" path="/param"/>
        public static void ScriptNotFound(FileInfo script, Action retry = null, Action delete = null, Action ignore = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Heading = "Script introuvable",
            Text = $"Le fichier \"{script.Name}\" est introuvable dans le répertoire \"{script.Directory}.\""
        }.DeleteRetryIgnore(delete, retry, ignore);

        /// <summary>Script not found error.</summary>
        /// <param name="script">The hung script's path.</param>
        /// <inheritdoc cref="DeleteRetryIgnore(Action, Action, Action)" path="/param"/>
        /// <param name="e">The exception that caused the error.</param>
        public static void ScriptInacessible(FileInfo script, Exception e, Action retry = null, Action delete = null, Action ignore = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Heading = "Script inacessible",
            Text = $"Le fichier \"{script.FullName}\" est inacessible, {e.Message}\""
        }.DeleteRetryIgnore(delete, retry, ignore);

        /// <summary>Single instance only error.</summary>
        /// <inheritdoc cref="RetryClose(Action, Action)" path="/param"/>
        public static void SingleInstanceOnly(Action retry = null, Action close = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = "L'application est déjà en cours d'exécution."
        }.RetryClose(retry, close);

        /// <summary>Wrong startup path error.</summary>
        /// <inheritdoc cref="RetryClose(Action, Action)" path="/param"/>
        public static void WrongStartupPath(Action retry = null, Action close = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = $"L'exécutable de l'application se trouve dans un répertoire incorrect. Déplacez-le dans \"{Program.InstallDir}\"."
        }.RetryClose(retry, close);

#pragma warning restore CS1573

        #endregion Public Methods

        #region Private Methods

        /// <param name="retry">Invoked when the Retry button is clicked.</param>
        /// <param name="ignore">Invoked when the Ignore button is clicked.</param>
        /// <param name="delete">Invoked when the Delete Script button is clicked.</param>
        private void DeleteRetryIgnore(Action delete, Action retry, Action ignore)
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

        /// <param name="restart">Invoked when the Restart Script button is clicked.</param>
        /// <param name="kill">Invoked when the Kill Script button is clicked.</param>
        /// <param name="ignore">Invoked when the Ignore button is clicked.</param>
        private void RestartKillIgnore(Action restart, Action kill, Action ignore)
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

        /// <param name="retry">Invoked when the Retry button is clicked.</param>
        /// <param name="close">Invoked when the Close button is clicked.</param>
        private void RetryClose(Action retry, Action close)
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

        /// <param name="retry">Invoked when the Retry button is clicked.</param>
        /// <param name="ignore">Invoked when the Ignore button is clicked.</param>
        private void RetryIgnore(Action retry, Action ignore)
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

        /// <param name="yes">Invoked when the Yes button is clicked.</param>
        /// <param name="no">Invoked when the No button is clicked.</param>
        private void YesNo(Action yes, Action no)
        {
            Buttons = new() { Button.Yes, Button.No };
            if (Show() == Button.Yes)
            {
                yes?.Invoke();
            }
            else
            {
                no?.Invoke();
            }
        }

        #endregion Private Methods
    }
}
