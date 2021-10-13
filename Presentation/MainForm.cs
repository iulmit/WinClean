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
    public partial class MainForm : Form
    {
        #region Public Constructors

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
                new Script(new Cmd(), new Path("foo.cmd", Constants.ScriptsDir))
                {
                    Name = "CmdFoo",
                    Description = "Foo description 0",
                    Impacts = new[] { new Impact(ImpactEffect.Visuals, ImpactLevel.Positive) },
                    Group = listViewScripts.Groups[0]
                },
                new Script(new Regedit(), new Path("dummy.reg", Constants.ScriptsDir))
                {
                    Name = "RegDummy",
                    Description = "Dummy description 1",
                    Impacts = new[] { new Impact(ImpactEffect.ShutdownTime, ImpactLevel.Negative) },
                    Group = listViewScripts.Groups[1]
                },
                new Script(new PowerShell(), new Path("ps1script.ps1", Constants.ScriptsDir))
                {
                    Name = "PowerShellSensass",
                    Description = "PowShe desc 3",
                    Impacts = new[] { new Impact(ImpactEffect.ResponseTime, ImpactLevel.Positive) },
                    Group = listViewScripts.Groups[1],
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

        private void ButtonNext_Click(object sender = null, EventArgs e = null) => Program.ConfirmAndExecuteScripts(listViewScripts.CheckedItems.Cast<Script>(), this);

        private void ButtonQuit_Click(object sender = null, EventArgs e = null) => Program.Exit();

        #endregion Buttons

        #region mainMenuStrip

        private void MainMenuSelectAll_Click(object sender = null, EventArgs e = null) => listViewScripts.Items.SetAllChecked(true);

        private void MainMenuSelectDebloat_Click(object sender = null, EventArgs e = null) => listViewScripts.Items.SetAllChecked(true);// placeholder

        private void MainMenuSelectMaintenance_Click(object sender = null, EventArgs e = null) => listViewScripts.Items.SetAllChecked(true);// placeholder

        private void MainMenuSelectNothing_Click(object sender = null, EventArgs e = null) => listViewScripts.Items.SetAllChecked(false);

        private void MainMenuStripAbout_Click(object sender = null, EventArgs e = null) => Program.ShowAboutBox(this);

        private void MainMenuStripClearLogs_Click(object sender = null, EventArgs e = null) => LogManager.ClearLogsFolder();

        private void MainMenuQuit_Click(object sender = null, EventArgs e = null) => Program.Exit();

        private void MainMenuStripSettings_Click(object sender = null, EventArgs e = null)
        {
        }

        private void MainMenuStripShowHelp_Click(object sender = null, EventArgs e = null)
        {
        }

        #endregion mainMenuStrip

        #region contextMenuStripScripts

        private void ContextMenuScriptsDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in listViewScripts.SelectedItems)
                selectedItem.Remove();
        }

        private void ContextMenuScriptsExecute_Click(object sender = null, EventArgs e = null) => Program.ConfirmAndExecuteScripts(listViewScripts.SelectedItems.Cast<Script>(), this);

        private void ContextMenuScriptsRename_Click(object sender, EventArgs e)
        {
            listViewScripts.LabelEdit = true;
            listViewScripts.AfterLabelEdit += (sender, e) =>
            {
                //e.Label : new name
                //listViewScripts.Items[e.Item].Text : old name
                e.CancelEdit = string.IsNullOrWhiteSpace(e.Label);
            };
            listViewScripts.SelectedItems[0].BeginEdit();
        }

        private void ContextMenuScripts_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStripScripts.Items.ToEnumerable().ForEach((item) => item.Enabled = true);

            ContextMenuScriptsDelete.Enabled =
            ContextMenuScriptsExecute.Enabled = listViewScripts.SelectedItems.Count > 0;
            ContextMenuScriptsRename.Enabled = listViewScripts.SelectedItems.Count == 1;
        }

        private void ContextMenuScriptsNew_Click(object sender, EventArgs e)
        {
        }

        #endregion contextMenuStripScripts

        #region listViewScripts

        /// <summary>Resizes <see cref="listViewScripts"/>'s main and only column, <see cref="scriptHeaderName"/>, to match <see cref="listViewScripts"/>'s new size.</summary>
        private void ListViewScripts_Resize(object sender = null, EventArgs e = null) => scriptHeaderName.Width = listViewScripts.Size.Width;

        private void ListViewScripts_SelectedIndexChanged(object sender = null, EventArgs e = null)
        {
            if (listViewScripts.SelectedItems.Count == 0)
            {
                labelName.Text =
                labelDescription.Text =
                labelInfo.Text = string.Empty;
            }
            else
            {
                labelName.Text = ((Script)listViewScripts.SelectedItems[0]).Name;
                labelDescription.Text = ((Script)listViewScripts.SelectedItems[0]).Description;
                labelInfo.Text = ((Script)listViewScripts.SelectedItems[0]).Impacts.ToMultilineString();
            }
        }

        #endregion listViewScripts

        #endregion Event Handlers

        #endregion Private Methods

    }
}
