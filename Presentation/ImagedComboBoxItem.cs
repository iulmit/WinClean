using System.Drawing;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>
/// This class represents an item of an <see cref="ImagedComboBox"/> control.
/// </summary>
/// <seealso href="https://www.codeproject.com/Articles/106467/How-to-Display-Images-in-ComboBox-in-5-Minutes"/>
[Serializable]
public class ImagedComboBoxItem
{
    /// <summary>
    /// ComobBox Item.
    /// </summary>
    public object Value { get; set; } = string.Empty;

    /// <summary>
    /// Item image.
    /// </summary>
    public Image? Image { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImagedComboBoxItem"/> class with the specified value.
    /// </summary>
    public ImagedComboBoxItem(object value) => Value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImagedComboBoxItem"/> class with the specifed value and image.
    /// </summary>
    public ImagedComboBoxItem(object value, Image image)
    {
        Value = value;
        Image = image;
    }

    /// <inheritdoc/>
    public override string? ToString() => Value.ToString();
}
