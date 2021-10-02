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
            _ = listViewScripts.Groups.Add("TestGroup1", "Groupe test 1");
            _ = listViewScripts.Groups.Add("TestGroup2", "Groupe test 2");
            listViewScripts.Groups.OfType<ListViewGroup>().ForEach((g) => g.CollapsedState = ListViewGroupCollapsedState.Expanded);
            listViewScripts.Items.AddRange(new Script[]
            {
                new CmdScript("Foo", "foo description 0", listViewScripts.Groups[0], "foo.cmd", new Logic.Impact[] { new Logic.Impact(Resources.ImpactType.Visuals, Logic.ImpactLevel.Positive) }),
                new WScript("Bar","bar description 1", listViewScripts.Groups[0],"bar.vbs",  new Logic.Impact[] { new Logic.Impact(Resources.ImpactType.Ergonomics, Logic.ImpactLevel.Mixed) }),
                new RegScript("Dummy", "dummy description 2", listViewScripts.Groups[1], "dummy.reg", new Logic.Impact[] { new Logic.Impact(Resources.ImpactType.StartupTime, Logic.ImpactLevel.Negative) }),
                new Ps1Script("Ps1", "hello world description 3", listViewScripts.Groups[1], "ps1script.ps1", new Logic.Impact[] { new Logic.Impact(Resources.ImpactType.ResponseTime, Logic.ImpactLevel.Positive) })
            }.ToListViewItems().ToArray());
        }

        #endregion Public Constructors

        #region Private Methods

        #region Event Handlers

        #region Buttons Event Handlers

        private void ButtonNewScript_Click(object sender = null, EventArgs e = null)
        {
        }

        private void ButtonNext_Click(object sender = null, EventArgs e = null) => DialogResult = DialogResult.OK;

        private void ButtonQuit_Click(object sender = null, EventArgs e = null) => DialogResult = DialogResult.Cancel;

        #endregion Buttons Event Handlers

        #region _mainMenuStrip Event Handlers

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

        private void MainMenuStripAbout_Click(object sender = null, EventArgs e = null)
        {
            using AboutBox about = new();
            about.Show();
        }

        private void MainMenuStripClearLogs_Click(object sender = null, EventArgs e = null) => LogManager.ClearLogsFolder();

        private void MainMenuStripSettings_Click(object sender = null, EventArgs e = null)
        {
        }

        private void MainMenuStripShowHelp_Click(object sender = null, EventArgs e = null)
        {
        }

        #endregion _mainMenuStrip Event Handlers

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
