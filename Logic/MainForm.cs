// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/*Todo :
 * Tester documentelement.value
 * Tester listView.Items quand la listView est null
 * Gérer les presets et les scripts par defaut independemment des preferences
 * tester OSVersion.VersionString vs OSVersion.ToString()
 */

using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class MainForm : Form
    {
        #region Public Constructors

        public MainForm()
        {
            InitializeComponent();

            Text = $"{Application.ProductName} {Application.ProductVersion}";
            listViewPresets.Items.AddRange(Program.Presets.ToListViewItems().ToArray());
            listViewScripts.Items.AddRange(Program.Scripts.ToListViewItems().ToArray());
        }

        #endregion Public Constructors

        #region Private Methods

        #region Event Handlers

        #region Buttons Event Handlers

        private void ButtonLoadPreset_Click(object sender = null, EventArgs e = null) => Preset.Create(listViewPresets.SelectedItems[0]).Load(listViewScripts);

        private void ButtonNewScript_Click(object sender = null, EventArgs e = null)
        {
        }

        private void ButtonNext_Click(object sender = null, EventArgs e = null)
        {
        }

        private void ButtonQuit_Click(object sender = null, EventArgs e = null) => Helpers.Exit();

        private void ButtonSavePreset_Click(object sender = null, EventArgs e = null)
        {
            Preset @new = Preset.CreateFromScripts(listViewScripts);
            Program.Presets.Add(@new);
            listViewPresets.LabelEdit = true;
            listViewPresets.Items.Add(@new.ToListViewItem()).StartRename();
        }

        #endregion Buttons Event Handlers

        #region _mainMenuStrip Event Handlers

        private void MainMenuStripAbout_Click(object sender = null, EventArgs e = null)
        {
        }

        private void MainMenuStripClearLogs_Click(object sender = null, EventArgs e = null) => LogManager.ClearLogsFolder();

        private void MainMenuStripSettings_Click(object sender = null, EventArgs e = null)
        {
        }

        private void MainMenuStripShowHelp_Click(object sender = null, EventArgs e = null)
        {
        }

        #endregion _mainMenuStrip Event Handlers

        #region _contextMenuStripPresets Event Handlers

        private void ContextMenuStripPresets_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetAllItemsEnabled(contextMenuStripPresets, true);
            if (listViewPresets.SelectedItems.Count == 1)
            {
                if (Program.DefaultPresets.Contains(Preset.Create(listViewPresets.SelectedItems[0])))
                    DisableMenuItemsForDefaultPreset();
            }
            else if (listViewPresets.SelectedItems.Count > 1)
            {
                if (listViewPresets.SelectedItems.ToEnumerable().Any((item) => Program.DefaultPresets.Contains(Preset.Create(item))))
                    DisableMenuItemsForMultipleDefaultSelection();
                else
                    DisableMenuItemsForMultipleSelection();
            }
            else
                DisableMenuItemsForNothingSelected();
        }

        private void ContextMenuStripPresetsCopy_Click(object sender = null, EventArgs e = null)
        {
        }

        private void ContextMenuStripPresetsDelete_Click(object sender = null, EventArgs e = null)
        {
        }

        private void ContextMenuStripPresetsNew_Click(object sender = null, EventArgs e = null)
        {
        }

        private void ContextMenuStripPresetsRename_Click(object sender = null, EventArgs e = null)
        {
            listViewPresets.LabelEdit = true;
            listViewPresets.SelectedItems[0].BeginEdit();
        }

        #endregion _contextMenuStripPresets Event Handlers

        #region Control Specific Event Handlers

        private void ListViewPresets_DoubleClick(object sender = null, EventArgs e = null) => ButtonLoadPreset_Click();

        private void ListViewPresets_SelectedIndexChanged(object sender = null, EventArgs e = null) =>
            buttonLoadPreset.Enabled = listViewPresets.SelectedItems.Count == 1;

        #endregion Control Specific Event Handlers

        #endregion Event Handlers

        private void DisableMenuItemsForDefaultPreset() =>
            RenamePreset.Enabled =
            DeletePreset.Enabled = false;

        private void DisableMenuItemsForNothingSelected() =>
            RenamePreset.Enabled =
            CopyPreset.Enabled =
            DeletePreset.Enabled =
            LoadPreset.Enabled = false;
        private void DisableMenuItemsForMultipleSelection() =>
            LoadPreset.Enabled =
            RenamePreset.Enabled = false;
        private void DisableMenuItemsForMultipleDefaultSelection() =>
            LoadPreset.Enabled =
            RenamePreset.Enabled =
            DeletePreset.Enabled = false;
        private static void SetAllItemsEnabled(ToolStrip menu, bool value)
        {
            foreach (ToolStripItem item in menu.Items)
                item.Enabled = value;
        }
        #endregion Private Methods
    }
}
