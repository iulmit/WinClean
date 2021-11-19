// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Button = System.Windows.Forms.TaskDialogButton;

namespace RaphaëlBardini.WinClean;

public class ConfirmationDialog : Dialog
{
    #region Public Constructors

    public ConfirmationDialog()
    {
        Buttons = new() { Button.Yes, Button.No };
        Icon = TaskDialogIcon.Warning;
    }

    #endregion Public Constructors

    #region Public Properties

    public static ConfirmationDialog AbortOperation => new()
    {
        Heading = "Abandonner l'opération ?",
        Text = "Abandonner l'opération risque de rendre le système instable. Voulez-vous vraiment continuer ?",
    };

    public static ConfirmationDialog ProgramExit => new()
    {
        Heading = $"Quitter {Application.ProductName} ?",
    };

    public static ConfirmationDialog ScriptDeletion => new()
    {
        Heading = "Supprimer le script ?",
        Text = $"Êtes-vous sûr de vouloir supprimer le script ? Cette action est irréversible."
    };

    #endregion Public Properties

    #region Public Methods

    public bool ShowDialog() => this.ShowPageInForegroundWindow() == Button.Yes;

    public void ShowDialog(Action? yes, Action? no)
    {
        if (ShowDialog())
        {
            yes?.Invoke();
        }
        else
        {
            no?.Invoke();
        }
    }

    #endregion Public Methods
}
