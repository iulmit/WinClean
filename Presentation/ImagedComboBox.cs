using RaphaëlBardini.WinClean.Logic;
using System.Drawing;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>
/// Represents a combo box with images instad of text for elements.
/// </summary>
public class ImagedComboBox : ComboBox
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ImagedComboBox"/> class.
    /// </summary>
    public ImagedComboBox() => DrawMode = DrawMode.OwnerDrawFixed;

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets the collection of images avaible to the items.
    /// </summary>
    public ImageList ImageList { get; set; } = new();

    /// <inheritdoc cref="ComboBox.SelectedItem"/>
    public new ImagedComboBoxItem? SelectedItem { get => (ImagedComboBoxItem?)base.SelectedItem; set => base.SelectedItem = value; }

    #endregion Public Properties

    #region Protected Methods

    /// <inheritdoc/>
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
                if (icbitem.ImageIndex != -1)
                {
                    ImageList.Draw(e.Graphics, ImageList.Images[icbitem.ImageIndex].Size.CenterIn(e.Bounds).Location, icbitem.ImageIndex);
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
                e.Graphics.DrawString(text, e.Font, eForeBrush, e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
            }
        }
    }

    #endregion Protected Methods
}