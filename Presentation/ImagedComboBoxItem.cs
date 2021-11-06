namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>
    /// Represents an item of an <see cref="ImagedComboBox"/>
    /// </summary>
    public struct ImagedComboBoxItem : IEquatable<ImagedComboBoxItem>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagedComboBoxItem"/> structure with the
        /// specified image index and text.
        /// </summary>
        public ImagedComboBoxItem(int imageIndex = -1, string? text = null, object? tag = null)
        {
            ImageIndex = imageIndex;
            Text = text ?? string.Empty;
            Tag = tag;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the index of the image to display.
        /// </summary>
        public int ImageIndex { get; set; }

        /// <summary>
        /// Additional informations about the control
        /// </summary>
        public object? Tag { get; set; }

        /// <summary>
        /// Text associated with this instance.
        /// </summary>
        public string Text { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Compares two <see cref="ImagedComboBoxItem"/> objects.
        /// </summary>
        /// <returns>
        /// Wether <paramref name="left"/> and <paramref name="right"/> can be considered different.
        /// </returns>
        public static bool operator !=(ImagedComboBoxItem left, ImagedComboBoxItem right) => !(left == right);

        /// <summary>
        /// Compares two <see cref="ImagedComboBoxItem"/> objects.
        /// </summary>
        /// <returns>
        /// Wether <paramref name="left"/> and <paramref name="right"/> can be considered equal.
        /// </returns>
        public static bool operator ==(ImagedComboBoxItem left, ImagedComboBoxItem right) => left.Equals(right);

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is ImagedComboBoxItem item && Equals(item);

        /// <inheritdoc/>
        public bool Equals(ImagedComboBoxItem other) => ImageIndex == other.ImageIndex && Equals(Tag, other.Tag) && Text == other.Text;

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(ImageIndex, Tag, Text);

        #endregion Public Methods
    }
}