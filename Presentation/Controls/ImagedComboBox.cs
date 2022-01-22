namespace RaphaëlBardini.WinClean.Presentation.Controls;

/// <summary>Represents a combo box with images instad of text for elements.</summary>
public class ImagedComboBox : ComboBox
{
    #region Public Constructors

    public ImagedComboBox() => DrawMode = DrawMode.OwnerDrawFixed;

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        _ = e ?? throw new ArgumentNullException(nameof(e));

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
                    e.Graphics.DrawImage(icbitem.Image, Center(icbitem.Image.Size, e.Bounds).Location);
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
                e.Graphics.DrawString(text, e.Font ?? Font, eForeBrush, e.Bounds.Left, e.Bounds.Top);
            }
        }
    }

    private static RectangleF Center(SizeF child, RectangleF parent) => new(parent.Location + parent.Size / 2 - child / 2, child);

    private static Rectangle Center(Size child, Rectangle parent)
    {
        RectangleF rF = Center(child, (RectangleF)parent);
        return new Rectangle(Convert.ToInt32(rF.X),
                             Convert.ToInt32(rF.Y),
                             Convert.ToInt32(rF.Height),
                             Convert.ToInt32(rF.Width));
    }

    #endregion Protected Methods
}
