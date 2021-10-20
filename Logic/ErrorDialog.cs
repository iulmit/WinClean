// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Button = System.Windows.Forms.TaskDialogButton;

namespace RaphaëlBardini.WinClean.Logic
{
    public class ErrorDialog : TaskDialogPage
    {
        #region Public Properties

        public static new string Caption => Application.ProductName;

        public static new bool SizeToContent => true;

        #endregion Public Properties

        #region Public Methods

        /// <summary>Can't create log directory error.</summary>
        /// <param name="dir">The path of the directory that couldn't be created.</param>
        /// <param name="message">More details on the error.</param>
        public static void CantCreateLogDir(string message, Action retry = null, Action close = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = $"Impossible de créer le dossier des logs. {message}"
        }.RetryClose(retry, close);

        /// <summary>Can't create log file error.</summary>
        /// <param name="dir">The path of the file that couldn't be deleted.</param>
        /// <param name="message">More details on the error.</param>
        public static void CantDeleteLogFile(string message, Action retry = null, Action ignore = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = $"Impossible de supprimer le fichier de logs. {message}"
        }.RetryIgnore(retry, ignore);

        /// <summary>Asks the users for confirmation on exiting the application and potentially loosing data.</summary>
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
        public static void HungScript(FilePath script, Action restart = null, Action kill = null, Action ignore = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Warning,
            Heading = "Un script est bloqué",
            Text = $"Le script (\"{script.Filename}\") est en cours d'exécution depuis {Operational.IScriptHost.Timeout} et ne s'arrêtera probablement jamais.",
        }.RestartKillIgnore(restart, kill, ignore);

        /// <summary>Script not found error.</summary>
        /// <param name="script">The hung script's path.</param>
        public static void ScriptNotFound(FilePath script, Action retry = null, Action delete = null, Action ignore = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Heading = "Script introuvable",
            Text = $"Le fichier \"{script.Filename}\" est introuvable dans le répertoire \"{script.Directory}.\""
        }.DeleteRetryIgnore(delete, retry, ignore);

        /// <summary>Single instance only error.</summary>
        public static void SingleInstanceOnly(Action retry = null, Action close = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = "L'application est déjà en cours d'exécution."
        }.RetryClose(retry, close);

        /// <summary>Wrong startup path error.</summary>
        public static void WrongStartupPath(Action retry = null, Action close = null) => new ErrorDialog()
        {
            Icon = TaskDialogIcon.Error,
            Text = $"L'exécutable de l'application se trouve dans un répertoire incorrect. Déplacez-le dans \"{Constants.AppInstallDir}\"."
        }.RetryClose(retry, close);

        #endregion Public Methods

        #region Private Methods

        private void DeleteRetryIgnore(Action delete, Action retry, Action ignore)
        {
            Button deleteScript = new("Supprimer le script");
            Buttons = new() { Button.Ignore, Button.Retry, deleteScript };
            Button result = Show();
            if (result == deleteScript)
                delete?.Invoke();
            else if (result == Button.Retry)
                retry?.Invoke();
            else
                ignore?.Invoke();
        }

        private void RestartKillIgnore(Action restart, Action kill, Action ignore)
        {
            Button killScript = new("Forcer l'arrêt du script");
            Button restartScript = new("Redémarrer le script");
            Buttons = new() { Button.Ignore, killScript, restartScript };

            Button result = Show();

            if (result == restartScript)
                restart?.Invoke();
            else if (result == killScript)
                kill?.Invoke();
            else
                ignore?.Invoke();
        }

        private void RetryClose(Action retry, Action close)
        {
            Buttons = new() { Button.Close, Button.Retry };
            if (Show() == Button.Retry)
                retry?.Invoke();
            else
                close?.Invoke();
        }

        private void RetryIgnore(Action retry, Action ignore)
        {
            Buttons = new() { Button.Ignore, Button.Retry };
            if (Show() == Button.Retry)
                retry?.Invoke();
            else
                ignore?.Invoke();
        }

        private Button Show() => Form.ActiveForm is null ? TaskDialog.ShowDialog(this) : TaskDialog.ShowDialog(Form.ActiveForm, this);

        private void YesNo(Action yes, Action no)
        {
            Buttons = new() { Button.Yes, Button.No };
            if (Show() == Button.Yes)
                yes?.Invoke();
            else
                no?.Invoke();
        }

        #endregion Private Methods
    }
}
