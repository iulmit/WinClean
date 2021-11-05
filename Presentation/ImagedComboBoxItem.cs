using System.Collections.Generic;
using System.Drawing;


namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>
    /// Represents an item of an <see cref="ImagedComboBox"/>
    /// </summary>
    public struct ImagedComboBoxItem : IEquatable<ImagedComboBoxItem>
    {
        /// <summary>
        /// Gets or sets the index of the image to display.
        /// </summary>
        public int ImageIndex { get; set; }

        /// <summary>
        /// Additional informations about the control
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Text associated with this instance.
        /// </summary>
        public string Text { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is ImagedComboBoxItem item && Equals(item);

        /// <inheritdoc/>
        public bool Equals(ImagedComboBoxItem other) => ImageIndex == other.ImageIndex && Tag.Equals(other.Tag) && Text == other.Text;

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(ImageIndex, Tag, Text);
        /// <summary>
        /// Compares two <see cref="ImagedComboBoxItem"/> objects.
        /// </summary>
        /// <returns>Wether <paramref name="left"/> and <paramref name="right"/> can be considered equal.</returns>
        public static bool operator ==(ImagedComboBoxItem left, ImagedComboBoxItem right) => left.Equals(right);
        /// <summary>
        /// Compares two <see cref="ImagedComboBoxItem"/> objects.
        /// </summary>
        /// <returns>Wether <paramref name="left"/> and <paramref name="right"/> can be considered different.</returns>
        public static bool operator !=(ImagedComboBoxItem left, ImagedComboBoxItem right) => !(left == right);
    }
}
