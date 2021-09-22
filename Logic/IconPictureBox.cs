// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System.Drawing;

namespace RaphaëlBardini.WinClean.Presentation
{
    public class IconPictureBox : System.Windows.Forms.PictureBox
    {
        private Icon _icon;
        public new Icon Image
        {
            get => _icon;
            set
            {
                _icon = value;
                base.Image = value.ToBitmap();
            }
        }
    }
}
