using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>
/// This is a special ComboBox that each item may conatins an image.
/// </summary>
/// <seealso href="https://www.codeproject.com/Articles/106467/How-to-Display-Images-in-ComboBox-in-5-Minutes"/>
public class ImagedComboBox : ComboBox
{
    /// <summary>
    /// The imaged ComboBox items.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new ImagedComboBoxItemCollection Items { get; private set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ImagedComboBox"/> class.
    /// </summary>
    public ImagedComboBox()
    {
        //Specifies that the list is displayed by clicking the down arrow and that the text portion is not editable. 
        //This means that the user cannot enter a new value. 
        //Only values already in the list can be selected. The list displays only if 
        DropDownStyle = ComboBoxStyle.DropDownList;
        //All the elements in the control are drawn manually and can differ in size.
        DrawMode = DrawMode.OwnerDrawVariable;
        //using DrawItem event we need to draw item
        DrawItem += ComboBoxDrawItemEvent;
        MeasureItem += ComboBox1_MeasureItem;
    }

    /// <inheritdoc/>
    protected override ControlCollection CreateControlsInstance()
    {
        Items = new(base.Items);

        Items.UpdateItems += UpdateItems;

        return base.CreateControlsInstance();
    }

    private void UpdateItems(object? _, EventArgs __)
    {
    }


    /// <summary>
    /// I have set the Draw property to DrawMode.OwnerDrawVariable, so I must caluclate the item measurement.  
    /// I will set the height and width of each item before it is drawn. 
    /// </summary>
    private void ComboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        var g = CreateGraphics();
        var maxWidth = 0;
        foreach (var width in Items.Cast<object>().Select(element => (int)g.MeasureString(element.ToString(), Font).Width).Where(width => width > maxWidth))
        {
            maxWidth = width;
        }
        DropDownWidth = maxWidth + 20;
    }



    /// <summary>
    /// Draws overrided items.
    /// </summary>
    private void ComboBoxDrawItemEvent(object sender, DrawItemEventArgs e)
    {
        //Draw backgroud of the item
        e.DrawBackground();
        if (e.Index != -1)
        {
            var comboboxItem = Items[e.Index];
            //Draw the image in combo box using its bound and ItemHeight
            if (comboboxItem.Image is not null)
            {
                e.Graphics.DrawImage(comboboxItem.Image, e.Bounds.X, e.Bounds.Y, ItemHeight, ItemHeight);
            }
            //we need to draw the item as string because we made drawmode to ownervariable
            e.Graphics.DrawString(Items[e.Index].Value.ToString(), Font, Brushes.Black,
                                  new RectangleF(e.Bounds.X + ItemHeight, e.Bounds.Y, DropDownWidth,
                                                 ItemHeight));
        }
        //draw rectangle over the item selected
        e.DrawFocusRectangle();
    }

}
