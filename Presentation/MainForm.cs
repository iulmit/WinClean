// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

/*Todo :
Tester documentelement.value
 */

using System.Linq;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>
    /// This is the application's main form. It regroups several features, including the main commit buttons, script selection,
    /// and provides UI acess to other forms.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Private Methods

        private static void SetAllChecked(ListView.ListViewItemCollection items, bool @checked) => items.ToEnumerable().ForEach((i) => i.Checked = @checked);

        #endregion Private Methods

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="MainForm"/> class.</summary>
        public MainForm()
        {
            InitializeComponent();
            Text = $"{Application.ProductName} {Application.ProductVersion}";
            MainMenuAbout.Text = Resources.FormattableStrings.About(Application.ProductName);
            _ = listViewScripts.Groups.Add("TestGroup1", "Groupe test 1");
            _ = listViewScripts.Groups.Add("TestGroup2", "Groupe test 2");
            listViewScripts.Groups.OfType<ListViewGroup>().ForEach((g) => g.CollapsedState = ListViewGroupCollapsedState.Expanded);
            listViewScripts.Items.AddRange(new[]
            {
                new Script(new Cmd(), "foo.cmd")
                {
                    Name = "CmdFoo",
                    Description = "Foo description 0",
                    Impacts = new[] { new Impact(ImpactEffect.Visuals, ImpactLevel.Positive) },
                    Group = listViewScripts.Groups[0],
                    Advised = ScriptAdvised.Yes,
                },
                new Script(new Regedit(), "dummy.reg")
                {
                    Name = "RegDummy",
                    Description = "Dummy description 1",
                    Impacts = new[] { new Impact(ImpactEffect.ShutdownTime, ImpactLevel.Negative) },
                    Group = listViewScripts.Groups[1],
                    Advised = ScriptAdvised.Limited,
                },
                new Script(new PowerShell(), "ps1script.ps1")
                {
                    Name = "PowerShellSensass",
                    Description = "PowShe desc 3",
                    Impacts = new[] { new Impact(ImpactEffect.ResponseTime, ImpactLevel.Positive) },
                    Group = listViewScripts.Groups[1],
                    Advised = ScriptAdvised.No,
                }
            });

            // This local function will be useful if we ever want to add shell icons to controls.
            //static System.Drawing.Bitmap BitmapShellIcon(StockIcon id) => NativeMethods.GetShellIcon(id, ShellIcon.Small).ToBitmap();
        }

        #endregion Public Constructors

        #region Private Methods

        #region Event Handlers

        #region Buttons

        private void ButtonNewScript_Click(object sender = null, EventArgs e = null)
        {
        }

        private void ButtonNext_Click(object sender = null, EventArgs e = null) => Program.ConfirmAndExecuteScripts(listViewScripts.CheckedItems.Cast<Script>());

        private void ButtonQuit_Click(object sender = null, EventArgs e = null) => Program.Exit();

        #endregion Buttons

        #region mainMenuStrip

        private void MainMenuQuit_Click(object sender = null, EventArgs e = null) => Program.Exit();

        private void MainMenuSelectAll_Click(object sender = null, EventArgs e = null) => SetAllChecked(listViewScripts.Items, true);

        private void MainMenuSelectDebloat_Click(object sender = null, EventArgs e = null) => SetAllChecked(listViewScripts.Items, true);// placeholder

        private void MainMenuSelectMaintenance_Click(object sender = null, EventArgs e = null) => SetAllChecked(listViewScripts.Items, true);// placeholder

        private void MainMenuSelectNothing_Click(object sender = null, EventArgs e = null) => SetAllChecked(listViewScripts.Items, false);

        private void MainMenuStripAbout_Click(object sender = null, EventArgs e = null) => Program.ShowAboutBox();

        private void MainMenuStripClearLogs_Click(object sender = null, EventArgs e = null) => LogManager.ClearLogsFolder();

        private void MainMenuStripSettings_Click(object sender = null, EventArgs e = null) => Program.ShowSettings();

        private void MainMenuStripShowHelp_Click(object sender = null, EventArgs e = null)
        {
        }

        #endregion mainMenuStrip

        #region contextMenuStripScripts

        private void ContextMenuDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in listViewScripts.SelectedItems)
            {
                selectedItem.Remove();
            }
        }

        private void ContextMenuEdit_Click(object sender, EventArgs e)
        {
            listViewScripts.LabelEdit = true;
            listViewScripts.SelectedItems[0].BeginEdit();
            listViewScripts.AfterLabelEdit += (sender, e) =>
            {
                //e.Label : new name
                //listViewScripts.Items[e.Item].Text : old name
                if (!(e.CancelEdit = string.IsNullOrWhiteSpace(e.Label)))
                {
                    ((Script)listViewScripts.Items[e.Item]).Name = e.Label;
                }
                RefreshPreview();
            };
        }

        private void ContextMenuExecute_Click(object sender = null, EventArgs e = null) => Program.ConfirmAndExecuteScripts(listViewScripts.SelectedItems.Cast<Script>());

        private void ContextMenuNew_Click(object sender, EventArgs e)
        {
        }

        private void ContextMenuScripts_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ContextMenuDelete.Enabled = ContextMenuExecute.Enabled = listViewScripts.SelectedItems.Count > 0;
            ContextMenuEdit.Enabled = listViewScripts.SelectedItems.Count == 1;
        }

        #endregion contextMenuStripScripts

        #region listViewScripts

        /// <summary>
        /// Resizes <see cref="listViewScripts"/>'s main and only column, <see cref="scriptHeaderName"/>, to match <see
        /// cref="listViewScripts"/>'s new size.
        /// </summary>
        private void ListViewScripts_Resize(object sender = null, EventArgs e = null) => scriptHeaderName.Width = listViewScripts.Size.Width;

        private void RefreshPreview(object sender = null, EventArgs e = null)
        {
            if (listViewScripts.SelectedItems.Count == 1)
            {
                propertyGridScript.SelectedObject = (IScript)listViewScripts.SelectedItems[0];
            }
            else
            {
                propertyGridScript.SelectedObjects = listViewScripts.SelectedItems.Cast<IScript>().ToArray();
            }
        }

        #endregion listViewScripts

        #endregion Event Handlers

        #endregion Private Methods
    }
}
