// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Button = System.Windows.Forms.TaskDialogButton;
using Buttons = System.Windows.Forms.TaskDialogButtonCollection;

namespace RaphaëlBardini.WinClean.Logic
{
    public class ErrorDialog : TaskDialogPage
    {
        #region Public Properties

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static new string Caption => Application.ProductName;

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static new bool SizeToContent => true;

        #endregion Public Properties

        #region Private Fields

        #region Custom Buttons

        private static readonly Button s_deleteScript = new("Supprimer le script");
        private static readonly Button s_kilLScript = new("Forcer l'arrêt du script");
        private static readonly Button s_restartScript = new("Redémarrer le script");

        #endregion Custom Buttons

        private static readonly Buttons s_closeRetry = new() { Button.Close, Button.Retry };
        private static readonly Buttons s_ignoreKillRestart = new() { Button.Ignore, s_kilLScript, s_restartScript };
        private static readonly Buttons s_ignoreRetry = new() { Button.Ignore, Button.Retry };
        private static readonly Buttons s_ignoreRetryDelete = new() { Button.Ignore, Button.Retry, s_deleteScript };

        #endregion Private Fields

        #region Public Methods

        public void ShowCloseRetry(Action onClose = null, Action onRetry = null, IWin32Window owner = null)
        {
            Buttons = s_closeRetry;
            if (ShowDialog(owner) == s_closeRetry[1])
                onRetry?.Invoke();
            else
                onClose?.Invoke();
        }

        public Button ShowDialog(IWin32Window owner = null) => owner is null ? TaskDialog.ShowDialog(this) : TaskDialog.ShowDialog(owner, this);

        public void ShowIgnoreKillRestart(Action onIgnore = null, Action onKill = null, Action onRestart = null, IWin32Window owner = null)
        {
            Buttons = s_ignoreKillRestart;
            Button result = ShowDialog(owner);
            if (result == s_ignoreKillRestart[2])
                onRestart?.Invoke();
            else if (result == s_ignoreKillRestart[1])
                onKill?.Invoke();
            else
                onIgnore?.Invoke();
        }

        public void ShowIgnoreRetry(Action onIgnore = null, Action onRetry = null, IWin32Window owner = null)
        {
            Buttons = s_ignoreRetry;
            if (ShowDialog(owner) == s_ignoreRetry[1])
                onRetry?.Invoke();
            else
                onIgnore?.Invoke();
        }

        public void ShowIgnoreRetryDelete(Action onIgnore = null, Action onRetry = null, Action onDelete = null, IWin32Window owner = null)
        {
            Buttons = s_ignoreRetryDelete;
            Button result = ShowDialog(owner);
            if (result == s_ignoreRetryDelete[2])
                onDelete?.Invoke();
            else if (result == s_ignoreRetryDelete[1])
                onRetry?.Invoke();
            else
                onIgnore?.Invoke();
        }

        #endregion Public Methods

        #region Public Methods

        /// <summary>Can't create log directory error.</summary>
        /// <param name="dir">The path of the directory that couldn't be created.</param>
        /// <param name="message">More details on the error.</param>
        /// <remarks>Close and Retry buttons.</remarks>
        /// <returns>The corresponding <see cref="ErrorDialog"/>.</returns>
        public static ErrorDialog CantCreateLogDir(string message) => new()
        {
            Icon = TaskDialogIcon.Error,
            Buttons = s_closeRetry,
            Text = $"Impossible de créer le dossier des logs, {message.ParseForSentence()}."
        };

        /// <summary>Can't create log file error.</summary>
        /// <param name="dir">The path of the file that couldn't be deleted.</param>
        /// <param name="message">More details on the error.</param>
        /// <remarks>Ignore and Retry buttons.</remarks>
        /// <returns>The corresponding <see cref="ErrorDialog"/>.</returns>
        public static ErrorDialog CantDeleteLogFile(string message) => new()
        {
            Icon = TaskDialogIcon.Error,
            Buttons = s_ignoreRetry,
            Text = $"Impossible de supprimer le fichier de logs, {message.ParseForSentence()}"
        };

        /// <summary>Hung script error.</summary>
        /// <param name="script">The hung script's path.</param>
        /// <remarks>Ignore, Kill Script and Restart Script buttons.</remarks>
        /// <returns>The corresponding <see cref="ErrorDialog"/>.</returns>
        public static ErrorDialog HungScript(Path script) => new()
        {
            Icon = TaskDialogIcon.Warning,
            Buttons = s_ignoreKillRestart,
            Heading = "Un script est bloqué",
            Text = $"Le script (\"{script.Filename}\") est en cours d'exécution depuis {TimeSpan.FromMilliseconds(Constants.ScriptTimeoutMilliseconds)} et ne s'arrêtera probablement jamais.",
        };

        /// <summary>Script not found error.</summary>
        /// <param name="script">The hung script's path.</param>
        /// <remarks>Ignore, Retry and Delete Script buttons.</remarks>
        /// <returns>The corresponding <see cref="ErrorDialog"/>.</returns>
        public static ErrorDialog ScriptNotFound(Path script) => new()
        {
            Icon = TaskDialogIcon.Error,
            Buttons = s_ignoreRetryDelete,
            Heading = "Script introuvable",
            Text = $"Le fichier \"{script.Filename}\" est introuvable dans le répertoire \"{script.Directory}.\""
        };

        /// <summary>Single instance only error.</summary>
        /// <remarks>Retry, Close buttons.</remarks>
        /// <returns>The corresponding <see cref="ErrorDialog"/>.</returns>
        public static ErrorDialog SingleInstanceOnly() => new()
        {
            Icon = TaskDialogIcon.Error,
            Buttons = s_closeRetry,
            Text = "L'application est déjà en cours d'exécution."
        };

        /// <summary>Wrong startup path error.</summary>
        /// <remarks>Retry, Close buttons.</remarks>
        /// <returns>The corresponding <see cref="ErrorDialog"/>.</returns>
        public static ErrorDialog WrongStartupPath() => new()
        {
            Icon = TaskDialogIcon.Error,
            Buttons = s_closeRetry,
            Text = $"L'exécutable de l'application se trouve dans un répertoire incorrect. Déplacez-le dans \"{Constants.InstallDir}\"."
        };

        #endregion Public Methods
    }
}
