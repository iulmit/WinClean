// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

/*Todo :
Tester documentelement.value
 */

using System.Linq;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Logic;

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
            listViewScripts.Items.AddRange(new Script[]
            {
                new CmdScript(new Path("foo.cmd", Constants.ScriptsDir), "Foo", "foo description 0",               new Impact[] { new Impact(ImpactEffect.Visuals, ImpactLevel.Positive) },      listViewScripts.Groups[0]),
                new WshScript(new Path("bar.vbs", Constants.ScriptsDir), "Bar","bar description 1",                new Impact[] { new Impact(ImpactEffect.Ergonomics, ImpactLevel.Mixed) },      listViewScripts.Groups[0]),
                new RegScript(new Path("dummy.reg", Constants.ScriptsDir), "Dummy", "dummy description 2",         new Impact[] { new Impact(ImpactEffect.ShutdownTime, ImpactLevel.Negative) }, listViewScripts.Groups[1]),
                new Ps1Script(new Path("ps1script.ps1", Constants.ScriptsDir), "Ps1", "hello world description 3", new Impact[] { new Impact(ImpactEffect.ResponseTime, ImpactLevel.Positive) }, listViewScripts.Groups[1])
            });

            ContextMenuScriptsExecute.Image = NativeMethods.GetShellIcon(StockIcon.Shield, ShellIcon.Small).ToBitmap();
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
        }

        private void ContextMenuScriptsExecute_Click(object sender = null, EventArgs e = null) => Program.ConfirmAndExecuteScripts(listViewScripts.SelectedItems.Cast<Script>(), this);

        private void ContextMenuScriptsRename_Click(object sender, EventArgs e)
        {
        }

        private void ContextMenuStripScripts_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listViewScripts.SelectedItems.Count == 0)
            {
                ContextMenuScriptsDelete.Enabled =
                ContextMenuScriptsExecute.Enabled =
                ContextMenuScriptsRename.Enabled = false;
                ContextMenuScriptsNew.Enabled = true;
            }
            else
                contextMenuStripScripts.Items.ToEnumerable().ForEach((item) => item.Enabled = true);
        }

        private void NouveauxToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        #endregion contextMenuStripScripts

        #endregion Event Handlers

        #endregion Private Methods

        private void ListViewScripts_Resize(object sender = null, EventArgs e = null) => scriptHeaderName.Width = listViewScripts.Size.Width;
    }
}
