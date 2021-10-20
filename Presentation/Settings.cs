// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Flobbster.Windows.Forms;

using RaphaëlBardini.WinClean.Properties;

namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class SettingsForm : Form
    {
        #region Public Constructors

        public SettingsForm()
        {
            InitializeComponent();
            comboBoxLogLevel.DataSource = Enum.GetValues<LogLevel>();
            comboBoxLogLevel.SelectedItem = Settings.Default.LogLevel;
            numericUpDownScriptTimeout.Value = Convert.ToInt32(Settings.Default.ScriptTimeout.TotalMinutes);
            propertyGrid.SelectedObject = new PropertyBag();
        }

        #endregion Public Constructors

        #region Private Methods

        private void buttonCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Settings.Default.LogLevel = (int)comboBoxLogLevel.SelectedItem;
            Settings.Default.ScriptTimeout = TimeSpan.FromMinutes((double)numericUpDownScriptTimeout.Value);
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        #endregion Private Methods
    }
}
