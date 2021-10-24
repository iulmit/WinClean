// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>A confirmation modal dialog box ensuring that the user knows what he's doing when about to execute scripts.</summary>
    public partial class FormConfirm : Form
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="FormConfirm"/> class.</summary>
        public FormConfirm()
        {
            InitializeComponent();

            buttonContinue.Width += SystemInformation.SmallIconSize.Width;
            buttonContinue.Location = new(buttonContinue.Location.X - SystemInformation.SmallIconSize.Width, buttonContinue.Location.Y);

            using StockIcon warning = new(StockIconIdentifier.Warning);
            pictureBox.Image = warning.Bitmap;

            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
            {
                checkBoxPlug.Checked = true;
            }
        }

        #endregion Public Constructors

        #region Private Methods

        private void ButtonCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void ButtonContinue_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        #endregion Private Methods

        private void CheckBox_CheckedChanged(object sender, EventArgs e) => buttonContinue.Enabled = checkBoxPlug.Checked && checkBoxPrograms.Checked && checkBoxSave.Checked;
    }
}
