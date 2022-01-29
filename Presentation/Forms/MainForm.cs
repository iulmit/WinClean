using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Operational;
using RaphaëlBardini.WinClean.Presentation.ScriptExecution;

using static RaphaëlBardini.WinClean.Resources.LogStrings;

namespace RaphaëlBardini.WinClean.Presentation.Forms;

/// <summary>
/// This is the application's main form. It regroups several features, including the main commit buttons, script selection, and
/// provides UI acess to other forms.
/// </summary>
public partial class MainForm : Form
{
    #region Public Constructors

    public MainForm()
    {
        LoadingMainForm.Log(Resources.Happenings.MainForm);

        InitializeComponent();

        Icon = Resources.Icons.Main;
        openFileDialogScript.MakeFilter(new Cmd().SupportedExtensions, new PowerShell().SupportedExtensions, new Regedit().SupportedExtensions, new(".*"));
        Text = $"{Application.ProductName} {Application.ProductVersion}";

        ScriptsDir.Instance.LoadScripts(listViewScripts);

        MainMenuAbout.Text = string.Format(CultureInfo.CurrentCulture, Resources.FormattableStrings.About, Application.ProductName);

        MainFormLoaded.Log(Resources.Happenings.MainForm);
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
        AddScriptClicked.Log(Resources.Happenings.MainForm);
        if (openFileDialogScript.ShowDialog(this) == DialogResult.OK)
        {
            string path = openFileDialogScript.FileName;
            _ = listViewScripts.Items.Add(new ScriptListViewItem(new Script(Path.GetFileNameWithoutExtension(path),
                                                                            string.Empty,
                                                                            null,
                                                                            ScriptAdvised.No,
                                                                            Impact.Ergonomics,
                                                                            path.GetDirectoryNameOnly()!, // wont return null as path cannot be a root directory
                                                                            Path.GetExtension(path),
                                                                            File.ReadAllText(path)), listViewScripts));
        }
    }

    private void ButtonExecuteScripts_Click(object _, EventArgs __)
    {
        ExecuteScriptsClicked.Log(Resources.Happenings.MainForm);

        IList<IScript> scripts = listViewScripts.CheckedItems.Cast<IScript>().ToList();

        ScriptExecutionWizard executor = new(scripts.ToList());

        if (scripts.Count > 1)
        {
            executor.ExecuteUI();
        }
        else if (scripts.Count > 0)
        {
            executor.ExecuteNoUI();
        }
    }

    #endregion Buttons

    #region mainMenuStrip

    private void MainMenuQuit_Click(object _, EventArgs __) => Program.Exit();

    private void MainMenuSelectAll_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items, true);

    private void MainMenuSelectAllAdvised_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items.Cast<ScriptListViewItem>().Where(script => script.Advised.Equals(ScriptAdvised.Yes)), true);

    private void MainMenuSelectDebloat_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items, true);// placeholder

    private void MainMenuSelectMaintenance_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items, true);// placeholder

    private void MainMenuSelectNothing_Click(object _, EventArgs __) => SetAllChecked(listViewScripts.Items, false);

    private void MainMenuStripAbout_Click(object _, EventArgs __)
    {
        using AboutBox about = new();
        _ = about.ShowDialog(this);
    }

    private void MainMenuStripClearLogs_Click(object _, EventArgs __) => LogManager.Instance.ClearLogsFolderAsync();

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
        => scriptEditor.Selected = listViewScripts.SelectedItems.Cast<ScriptListViewItem>().FirstOrDefault();

    #endregion listViewScripts

    #endregion Event Handlers

    private static void SetAllChecked(IEnumerable<ListViewItem> items, bool @checked)
    {
        foreach (ListViewItem lvi in items)
        {
            lvi.Checked = @checked;
        }
    }

    private static void SetAllChecked(ListView.ListViewItemCollection items, bool @checked)
        => SetAllChecked(((System.Collections.IEnumerable)items).Cast<ListViewItem>(), @checked);

    #endregion Private Methods
}
