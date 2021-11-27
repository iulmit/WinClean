
namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>Represents an item of an <see cref="ImagedComboBox"/></summary>
public record class ImagedComboBoxItem
{
    #region Public Constructors

    public ImagedComboBoxItem(Image? image = null, object? tag = null, string? text = null)
    {
        Image = image;
        Text = text;
        Tag = tag;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>Gets or sets the index of the image to display.</summary>
    public Image? Image { get; set; }

    /// <summary>Additional informations about the control</summary>
    public object? Tag { get; set; }

    /// <summary>Text associated with this instance.</summary>
    public string? Text { get; set; }

    #endregion Public Properties
}
