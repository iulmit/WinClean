// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/*Todo :
Tester documentelement.value
 */

using System.Collections.Generic;
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
                new CmdScript("Foo", "foo description 0", listViewScripts.Groups[0], "foo.cmd", new Impact[] { new Impact(Resources.ImpactType.Visuals, ImpactLevel.Positive) }),
                new WScript("Bar","bar description 1", listViewScripts.Groups[0],"bar.vbs",  new Impact[] { new Impact(Resources.ImpactType.Ergonomics, ImpactLevel.Mixed) }),
                new RegScript("Dummy", "dummy description 2", listViewScripts.Groups[1], "dummy.reg", new Impact[] { new Impact(Resources.ImpactType.StartupTime, ImpactLevel.Negative) }),
                new Ps1Script("Ps1", "hello world description 3", listViewScripts.Groups[1], "ps1script.ps1", new Impact[] { new Impact(Resources.ImpactType.ResponseTime, ImpactLevel.Positive) })
            }.ToListViewItems().ToArray());

            ContextMenuScriptsExecute.Image = Operational.SystemIcons.GetIcon(PInvokes.SHSTOCKICONID.SIID_SHIELD, PInvokes.SHGSI.SHGSI_SMALLICON).ToBitmap();
        }

        #endregion Public Constructors

        #region Private Methods

        #region Event Handlers

        #region Buttons

        private void ButtonNewScript_Click(object sender = null, EventArgs e = null)
        {
        }

        private void ButtonNext_Click(object sender = null, EventArgs e = null) => DialogResult = DialogResult.OK;

        private void ButtonQuit_Click(object sender = null, EventArgs e = null) => DialogResult = DialogResult.Cancel;

        #endregion Buttons

        #region mainMenuStrip

        private void MainMenuSelectAll_Click(object sender = null, EventArgs e = null) => listViewScripts.Items.SetAllChecked(true);

        private void MainMenuSelectDebloat_Click(object sender = null, EventArgs e = null)
        {
            listViewScripts.Items.SetAllChecked(true);// placeholder
        }

        private void MainMenuSelectMaintenance_Click(object sender = null, EventArgs e = null)
        {
            listViewScripts.Items.SetAllChecked(true);// placeholder
        }

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
        private void ContextMenuScriptsDelete_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenuScriptsRename_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenuScriptsExecute_Click(object sender, EventArgs e)
            => listViewScripts.SelectedItems.ToEnumerable().Select((item) => Script.Retrieve(item)).RunAll();
        private void NouveauxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion contextMenuStripScripts

        #endregion Event Handlers

        #endregion Private Methods

        #region Public Methods

        /// <inheritdoc cref="Form.ShowDialog()" path="/summary"/>
        /// <returns>The dialog result and the scripts the users has selected.</returns>
        /// <inheritdoc cref="Form.ShowDialog()" path="/exception"/>
        public new(DialogResult result, IEnumerable<Script> selectedScripts) ShowDialog()
            => (base.ShowDialog(), listViewScripts.CheckedItems.ToEnumerable().Select((item) => Script.Retrieve(item)));

        #endregion Public Methods

        private void ListViewScripts_Resize(object sender = null, EventArgs e = null) => scriptHeaderName.Width = listViewScripts.Size.Width;
    }
}
