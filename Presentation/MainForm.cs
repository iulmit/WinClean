// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Operational;

using WinCopies.Collections;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>
/// This is the application's main form. It regroups several features, including the main commit buttons, script selection, and
/// provides UI acess to other forms.
/// </summary>
public partial class MainForm : Form
{
    #region Public Constructors

    public MainForm()
    {
        InitializeComponent();

        Icon = Resources.Icons.Main;
        openFileDialogScript.MakeFilter(new Cmd().SupportedExtensions, new PowerShell().SupportedExtensions, new Regedit().SupportedExtensions, new(".*"));
        Text = $"{Application.ProductName} {Application.ProductVersion}";

        ScriptsDir.Instance.LoadScripts(listViewScripts);

        MainMenuAbout.Text = string.Format(CurrentCulture, Resources.FormattableStrings.About, Application.ProductName);
    }

    #endregion Public Constructors

    #region Private Methods

    #region Event Handlers

    #region MainForm

    // This is to prevent scroll bar flickering during resize
    private void MainForm_ResizeBegin(object _, EventArgs __) => listViewScripts.Scrollable = scriptEditor.AutoScroll = false;

    private void MainForm_ResizeEnd(object _, EventArgs __) => listViewScripts.Scrollable = scriptEditor.AutoScroll = true;

    #endregion MainForm

    #region Buttons

    private void ButtonAddScript_Click(object _, EventArgs __)
    {
        if (openFileDialogScript.ShowDialog(this) == DialogResult.OK)
        {
            FileInfo file = new(openFileDialogScript.FileName);
            ListViewGroup group = new(file.Directory!.Name); // ! : file will never be a root directory
            _ = listViewScripts.Groups.Add(group);
            _ = listViewScripts.Items.Add(new Script(file.Name, string.Empty, ScriptAdvised.No, new(), group, file));
        }
    }

    private void ButtonExecuteScripts_Click(object _, EventArgs __) => ScriptExecutor.ConfirmAndExecute(listViewScripts.CheckedItems.Cast<IScript>().ToList());

    private void ButtonQuit_Click(object _, EventArgs __) => Program.Exit();

    #endregion Buttons

    #region mainMenuStrip

    private void MainMenuQuit_Click(object _, EventArgs __) => Program.Exit();

    private void MainMenuSelectAll_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items, true);

    private void MainMenuSelectDebloat_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items, true);// placeholder

    private void MainMenuSelectMaintenance_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items, true);// placeholder

    private void MainMenuSelectNothing_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items, false);

    private void MainMenuStripAbout_Click(object _, EventArgs __)
    {
        using AboutBox about = new();
        _ = about.ShowDialog(this);
    }

    private void MainMenuStripClearLogs_Click(object _, EventArgs __) => LogManager.ClearLogsFolderAsync();

    private void MainMenuStripSettings_Click(object _, EventArgs __)
    {
        using Settings settings = new();
        _ = settings.ShowDialog(this);
    }

    private void MainMenuStripShowHelp_Click(object _, EventArgs __)
    {
    }

    #endregion mainMenuStrip

    #region listViewScripts

    private void ListViewScripts_ItemChecked(object _, ItemCheckedEventArgs __) => buttonExecuteScripts.Enabled = listViewScripts.CheckedItems.Count > 0;

    /// <summary>
    /// Resizes <see cref="listViewScripts"/>'s main and only column, <see cref="scriptHeaderName"/>, to match <see
    /// cref="listViewScripts"/>'s new size.
    /// </summary>
    private void ListViewScripts_Resize(object _, EventArgs __) => scriptHeaderName.Width = listViewScripts.Size.Width - listViewScripts.Margin.Horizontal;

    private void ListViewScripts_SelectedIndexChanged(object _, EventArgs __)
        => scriptEditor.Selected = listViewScripts.SelectedItems.Cast<IScript>().FirstOrDefault();

    #endregion listViewScripts

    #endregion Event Handlers

    private static void SetAllChecked(ListView.ListViewItemCollection items, bool @checked)
    {
        foreach (ListViewItem lvi in items)
        {
            lvi.Checked = @checked;
        }
    }

    #endregion Private Methods
}
