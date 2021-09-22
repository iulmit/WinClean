// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class FormConfirm : Form
    {
        public FormConfirm()
        {

            InitializeComponent();
            iconPictureBox.Image = new Microsoft.WindowsAPICodePack.Shell.StockIcons(Microsoft.WindowsAPICodePack.Win32Native.Shell.StockIconSize.Large, false, false).Error.Icon;
        }
    }
}
