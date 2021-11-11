using RaphaëlBardini.WinClean.Logic;

using System.Drawing;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>Represents a combo box with images instad of text for elements.</summary>
public class ImagedComboBox : ComboBox
{
    #region Public Constructors

    public ImagedComboBox() => DrawMode = DrawMode.OwnerDrawFixed;

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        Assert(e is not null);

        e.DrawBackground();
        e.DrawFocusRectangle();

        using SolidBrush eForeBrush = new(e.ForeColor);

        if (e.Index == -1)
        {
            DrawText(Text);
        }
        else
        {
            if (Items[e.Index] is ImagedComboBoxItem icbitem)
            {
                if (icbitem.Image is not null)
                {
                    e.Graphics.DrawImage(icbitem.Image, icbitem.Image.Size.CenterIn(e.Bounds).Location);
                }
                DrawText(icbitem.Text);
            }
            else
            {
                DrawText(Items[e.Index].ToString());
            }
        }
        base.OnDrawItem(e);

        void DrawText(string? text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                e.Graphics.DrawString(text, e.Font, eForeBrush, e.Bounds.Left, e.Bounds.Top);
            }
        }
    }

    #endregion Protected Methods
}
