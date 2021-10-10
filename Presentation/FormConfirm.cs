// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class FormConfirm : Form
    {
        #region Public Constructors

        public FormConfirm()
        {
            InitializeComponent();
            buttonContinue.Width += SystemInformation.SmallIconSize.Width;
            buttonContinue.Location = new(buttonContinue.Location.X - SystemInformation.SmallIconSize.Width, buttonContinue.Location.Y);
            pictureBox.Image = NativeMethods.GetShellIcon(StockIcon.Warning).ToBitmap();
            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
                checkBoxPlug.Checked = true;
        }

        #endregion Public Constructors

        #region Private Methods

        private void ButtonCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void ButtonContinue_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        #endregion Private Methods

        private void CheckBox_CheckedChanged(object sender, EventArgs e) => buttonContinue.Enabled = checkBoxPlug.Checked && checkBoxPrograms.Checked && checkBoxSave.Checked;
    }
}
