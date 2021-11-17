// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Operational;

using System.Linq;
using System.Windows.Forms;

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

        openFileDialogScripts.MakeFilter(new Cmd().SupportedExtensions, new PowerShell().SupportedExtensions, new Regedit().SupportedExtensions);

        /*ListViewGroup[] placeholderGroups = new[]
        {
            new ListViewGroup("TestGroup1", "Groupe test 1"),
            new ListViewGroup("TestGroup2", "Groupe test 2")
        };
        listViewScripts.Groups.AddRange(placeholderGroups);*/

        /*IScript[] placeholders = new[]
        {
                new Script
                (
                    name: "CmdFoo",
                    description: "Foo description 0",
                    impact: new(ImpactLevel.Positive, ImpactEffect.Visuals),
                    group: listViewScripts.Groups[0],
                    advised: ScriptAdvised.Yes,
                    source: new FileInfo(@"D:\Scover\Bureau\wclea\SampleScripts\foo.cmd")
                ),
                new Script
                (
                    name: "RegDummy",
                    description: "Dummy description 1",
                    impact: new(ImpactLevel.Negative, ImpactEffect.ShutdownTime),
                    group: listViewScripts.Groups[1],
                    advised: ScriptAdvised.Limited,
                    source: new FileInfo(@"D:\Scover\Bureau\wclea\SampleScripts\dummy.reg")
                ),
                new Script
                (
                    name: "PowerShellSensass",
                    description: "PowShe desc 3",
                    impact: new(ImpactLevel.Positive, ImpactEffect.ResponseTime),
                    group: listViewScripts.Groups[1],
                    advised: ScriptAdvised.No,
                    source: new FileInfo(@"D:\Scover\Bureau\wclea\SampleScripts\ps1script.ps1")
                )
            };
        foreach (IScript placeholder in placeholders)
        {
            placeholder.Save();
        }*/

        AppDir.GroupsFile.Instance.LoadGroups(listViewScripts);
        listViewScripts.Items.AddRange(AppDir.ScriptsDir.Instance.LoadAllScripts().ToArray());

        Text = $"{Application.ProductName} {Application.ProductVersion}";

        MainMenuAbout.Text = Resources.FormattableStrings.About(Application.ProductName);
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
        if (openFileDialogScripts.ShowDialog(this) == DialogResult.OK)
        {
            foreach (string newScriptPath in openFileDialogScripts.FileNames)
            {
                _ = listViewScripts.Items.Add(new Script("Nouveau script", "Entrez les détails de fonctionnement du script...", ScriptAdvised.No, new(), null, new(newScriptPath)));
            }
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

    private void ListViewScripts_Leave(object _, EventArgs __) => AppDir.GroupsFile.Instance.SaveGroups();

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
