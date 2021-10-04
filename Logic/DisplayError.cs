// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using System.Windows.Forms;

using WinCopies.Util;

using static System.IO.Path;

using Button = System.Windows.Forms.TaskDialogButton;
using Buttons = System.Windows.Forms.TaskDialogButtonCollection;

/* Template for each error :
   public static ErrorNameAction ErrorName(type param, Action highestImpact = null, Action lowestImpact = null, IWin32Window owner = null)
   {
       TaskDialogButton result = new TaskDialogPage()
       {
           Caption = Application.ProductName,
           Icon = TaskDialogIcon.,
           Buttons =
           Heading =,
           Text =,
       }.ShowDialog(owner);
       if (result == )
           highestImpact?.Invoke();
       else
           lowestImpact?.Invoke();
   }
 */

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Provides method for displaying a predefined warning or error.</summary>
    /// <remarks>The dialog is modal and subordinate to the currently active form. If no form is active, the dialog is modeless.</remarks>
    public static class DisplayError
    {
        #region Private Fields

        private static readonly Buttons s_ignoreKillRestart = new() { Button.Ignore, new Button("Forcer l'arrêt du script"), new Button("Redémarrer le script") };
        private static readonly Buttons s_ignoreRetryDeleteScript = new() { Button.Ignore, Button.TryAgain, new Button("Supprimer le script") };

        #endregion Private Fields

        #region Private Methods

        /// <summary>Retrieves the active form.</summary>
        /// <returns>The active form, or <see langword="null"/> if no forms are active.</returns>
        private static Form GetFocusedForm() => Application.OpenForms.ToEnumerable().FirstOrDefault((form) => form.Focused);
        /// <inheritdoc cref="TaskDialog.ShowDialog(TaskDialogPage, TaskDialogStartupLocation)"/>
        private static Button ShowDialog(this TaskDialogPage page)
        {
            IWin32Window owner = GetFocusedForm();
            return owner is null ? TaskDialog.ShowDialog(page) : TaskDialog.ShowDialog(owner, page);
        }

        #endregion Private Methods

        #region Public Methods

        #region TaskDialogs

        /// <summary>Displays a <see cref="TaskDialog"/> for the hung script error.</summary>
        /// <param name="path">The path of the script file.</param>
        /// <param name="onRestart">What to do when the user clicks on the Restart button.</param>
        /// <param name="onKill">What to do when the user clicks on the Kill button.</param>
        /// <param name="onIgnore">What to do when the user clicks on the Ignore button.</param>
        public static void HungScript(string path, Action onRestart = null, Action onKill = null, Action onIgnore = null)
        {
            Button result = new TaskDialogPage()
            {
                Caption = Application.ProductName,
                Icon = TaskDialogIcon.Warning,
                Buttons = s_ignoreKillRestart,
                Heading = "Un script est bloqué",
                Text = $"Le script (\"{GetFileName(path)}\") est en cours d'exécution depuis {TimeSpan.FromMilliseconds(Constants.ScriptTimeoutMilliseconds)} et peut ne jamais s'arrêter.",
            }.ShowDialog();
            if (result == s_ignoreKillRestart[2])
                onRestart?.Invoke();
            if (result == s_ignoreKillRestart[1])
                onKill?.Invoke();
            else
                onIgnore?.Invoke();
        }

        /// <summary>Displays a <see cref="TaskDialog"/> for the script not found error.</summary>
        /// <param name="fullPath">The full path of the script file that could not be found.</param>
        /// <param name="onDelete">What to do when the user clicks on the Delete button.</param>
        /// <param name="onRetry">What to do when the user clicks on the Retry button.</param>
        /// <param name="onIgnore">What to do when the user clicks on the Ignore button.</param>
        public static void ScriptNotFound(string fullPath, Action onDelete = null, Action onRetry = null, Action onIgnore = null)
        {
            Button result = new TaskDialogPage()
            {
                Caption = Application.ProductName,
                Icon = TaskDialogIcon.Error,
                Buttons = s_ignoreRetryDeleteScript,
                Heading = "Fichier de script introuvable",
                Text = $"Le fichier \"{GetFileName(fullPath)}\" est introuvable dans le répertoire \"{GetDirectoryName(fullPath)}.\""
            }.ShowDialog();
            if (result == s_ignoreRetryDeleteScript[2])
                onDelete?.Invoke();
            else if (result == s_ignoreRetryDeleteScript[1])
                onRetry?.Invoke();
            else
                onIgnore?.Invoke();
        }

        #endregion TaskDialogs

        #region MessageBoxes

        /// <summary>Displays a <see cref="MessageBox"/> for the can't create log dir error.</summary>
        /// <param name="dirPath">The path of the dir that couldn't be created.</param>
        /// <param name="details">Addinitonal information on the error.</param>
        /// <param name="onCancel">What to do when the user clicks on the Cancle button.</param>
        /// <param name="onRetry">What to do when the user clicks on the Retry button.</param>
        public static void CantCreateLogDir(string dirPath, string details, Action onCancel = null, Action onRetry = null)
        {
            switch (MessageBox.Show(GetFocusedForm(), $"Impossible de créer le dossier des logs (\"{dirPath}\"), {details}", Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
            {
                case DialogResult.Retry:
                    onRetry?.Invoke();
                    break;
                default:
                    onCancel?.Invoke();
                    break;
            }
        }

        /// <summary>Displays a <see cref="MessageBox"/> for the can't delete log file error.</summary>
        /// <param name="fullPath">The full path of the file couldn't be deleted.</param>
        /// <param name="details">Additional information on the error.</param>
        /// <param name="onRetry">What to do when the user clicks on the Retry button.</param>
        /// <param name="onCancel">What to do when the user clicks on the Cancel button.</param>
        public static void CantDeleteLogFile(string fullPath, string details, Action onRetry = null, Action onCancel = null)
        {
            switch (MessageBox.Show(GetFocusedForm(), $"Impossible de supprimer le fichier journal \"{GetFileName(fullPath)}\", {details}", Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
            {
                case DialogResult.Retry:
                    onRetry?.Invoke();
                    break;
                default:
                    onCancel?.Invoke();
                    break;
            }
        }

        /// <summary>Displays a <see cref="MessageBox"/> for the single instance only error.</summary>
        /// <param name="onCancel">What to do when the user clicks on the Cancel button.</param>
        /// <param name="onRetry">What to do when the user clicks on the Retry button.</param>
        public static void SingleInstanceOnly(Action onCancel = null, Action onRetry = null)
        {
            switch (MessageBox.Show(GetFocusedForm(), "L'application est déjà en cours d'exécution.", Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
            {
                case DialogResult.Retry:
                    onRetry?.Invoke();
                    break;
                default:
                    onCancel?.Invoke();
                    break;
            }
        }

        /// <summary>Displays a <see cref="MessageBox"/> for the wrong application startup path error.</summary>
        /// <param name="onCancel">What to do when the user clicks on the Cancel button.</param>
        /// <param name="onRetry">What to do when the user clicks on the Retry button.</param>
        public static void WrongStartupPath(Action onCancel = null, Action onRetry = null)
        {
            switch (MessageBox.Show(GetFocusedForm(), $"L'exécutable de l'application se trouve dans un répertoire incorrect. Déplacez le fichier dans \"{Constants.InstallDir}\".", Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
            {
                case DialogResult.Retry:
                    onRetry?.Invoke();
                    break;
                default:
                    onCancel?.Invoke();
                    break;
            }
        }

        #endregion MessageBoxes

        #endregion Public Methods
    }
}
