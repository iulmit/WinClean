// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.   

using System.Collections.Generic;
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
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="MainForm"/> class.</summary>
        public MainForm()
        {
            InitializeComponent();

            openFileDialogScripts.MakeFilter(ScriptHost.Cmd.SupportedExtensions, ScriptHost.PowerShell.SupportedExtensions, ScriptHost.Regedit.SupportedExtensions);

            //Todo : sauvegarder les groupes
            _ = listViewScripts.Groups.Add("TestGroup1", "Groupe test 1");
            _ = listViewScripts.Groups.Add("TestGroup2", "Groupe test 2");

            ScriptsDir.LoadAllScripts(listViewScripts);

            Text = $"{Application.ProductName} {Application.ProductVersion}";

            MainMenuAbout.Text = Resources.FormattableStrings.About(Application.ProductName);

            foreach (ListViewGroup group in listViewScripts.Groups)
            {
                group.CollapsedState = ListViewGroupCollapsedState.Expanded;
            }
        }

        #endregion Public Constructors

        #region Private Methods

        #region Event Handlers

        #region Buttons

        private void ButtonAddScript_Click(object sender = null, EventArgs e = null)
        {
            if (openFileDialogScripts.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string newScriptPath in openFileDialogScripts.FileNames)
                {
                    _ = listViewScripts.Items.Add(new Script("Nouveau script", "Entrez les détails de fonctionnement du script...", ScriptAdvised.Unspecified, new List<Impact>(), null, new(newScriptPath)));
                }
            }
        }

        private void ButtonExecuteScripts_Click(object sender = null, EventArgs e = null) => Program.ConfirmAndExecuteScripts(listViewScripts.CheckedItems.Cast<IScript>());

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

        private void ContextMenuExecute_Click(object sender = null, EventArgs e = null) => Program.ConfirmAndExecuteScripts(listViewScripts.SelectedItems.Cast<Script>());

        private void ContextMenuNew_Click(object sender, EventArgs e)
        {
        }

        private void ContextMenuRename_Click(object sender, EventArgs e)
                            => InitLabelEdit(listViewScripts.SelectedItems[0], null, (sender, e) =>
                {
                    if (!(e.CancelEdit = string.IsNullOrWhiteSpace(e.Label)))
                    {
                        ((IScript)listViewScripts.Items[e.Item]).Name = e.Label;
                    }
                    RefreshScriptPreview();
                });

        private void ContextMenuScripts_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ContextMenuDelete.Enabled = ContextMenuExecute.Enabled = listViewScripts.SelectedItems.Count > 0;
            ContextMenuRename.Enabled = listViewScripts.SelectedItems.Count == 1;
        }

        #endregion contextMenuStripScripts

        #region listViewScripts

        private void listViewScripts_ItemChecked(object sender, ItemCheckedEventArgs e) => buttonExecuteScripts.Enabled = listViewScripts.CheckedItems.Count > 0;

        /// <summary>
        /// Resizes <see cref="listViewScripts"/>'s main and only column, <see cref="scriptHeaderName"/>, to match <see
        /// cref="listViewScripts"/>'s new size.
        /// </summary>
        private void ListViewScripts_Resize(object sender = null, EventArgs e = null) => scriptHeaderName.Width = listViewScripts.Size.Width;

        private void ListViewScripts_SelectedIndexChanged(object sender = null, EventArgs e = null) => RefreshScriptPreview();

        #endregion listViewScripts

        #endregion Event Handlers

        private static void SetAllChecked(ListView.ListViewItemCollection items, bool @checked)
        {
            foreach (ListViewItem lvi in items)
            {
                lvi.Checked = @checked;
            }
        }

        private void InitLabelEdit(ListViewItem toEdit, LabelEditEventHandler beforeLabelEdit = null, LabelEditEventHandler afterLabelEdit = null)
        {
            ListView lv = toEdit.ListView;

            // beware the mandatory temporal couplings

            bool oldLabelEdit = lv.LabelEdit;

            lv.LabelEdit = true;
            toEdit.BeginEdit();

            lv.BeforeLabelEdit += beforeLabelEdit;
            lv.AfterLabelEdit += afterLabelEdit;
            lv.AfterLabelEdit += Cleanup;

            void Cleanup(object sender = null, LabelEditEventArgs e = null)
            {
                lv.BeforeLabelEdit -= beforeLabelEdit;
                lv.AfterLabelEdit -= afterLabelEdit;
                lv.AfterLabelEdit -= Cleanup;
                lv.LabelEdit = oldLabelEdit;
            }
        }

        private static void RefreshScriptPreview()
        {
            /*propertyGridScript.SelectedObject = propertyGridScript.SelectedObjects = null;

            if (listViewScripts.SelectedItems.Count == 1)
            {
                propertyGridScript.SelectedObject = (IScript)listViewScripts.SelectedItems[0];
            }
            else
            {
                propertyGridScript.SelectedObjects = listViewScripts.SelectedItems.Cast<IScript>().ToArray();
            }*/
        }

        #endregion Private Methods
    }
}
