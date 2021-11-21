// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using Button = System.Windows.Forms.TaskDialogButton;

namespace RaphaëlBardini.WinClean.ErrorHandling;

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

    public static ConfirmationDialog AbortOperation { get; } = new()
    {
        Text = Resources.Dialog.ConfirmAbortOperation
    };

    public static ConfirmationDialog ProgramExit { get; } = new()
    {
        Text = string.Format(CurrentCulture, Resources.Dialog.ConfirmProgramExit, Application.ProductName)
    };

    public static ConfirmationDialog ScriptDeletion { get; } = new()
    {
        Text = Resources.Dialog.ConfirmScriptDeletion
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
