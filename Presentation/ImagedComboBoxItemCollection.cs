using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>
    /// A collection of <see cref="ImagedComboBoxItem"/> objects.
    /// </summary>
    /// <seealso href="https://www.codeproject.com/Articles/106467/How-to-Display-Images-in-ComboBox-in-5-Minutes"/>
    public class ImagedComboBoxItemCollection : IList<ImagedComboBoxItem>
    {
        /// <summary>
        /// Event triggered when items are added or removed.
        /// </summary>
        public event EventHandler? UpdateItems;

        private readonly IList<ImagedComboBoxItem> _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagedComboBoxItemCollection"/> class with the specified items.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
        public ImagedComboBoxItemCollection(IList<ImagedComboBoxItem> items)
            => _items = items ?? throw new ArgumentNullException(nameof(items));
        /// <summary>
        /// Initialies a new instance of the <see cref="ImagedComboBoxItemCollection"/> containing no items.
        /// </summary>
        public ImagedComboBoxItemCollection()
            => _items = new List<ImagedComboBoxItem>();

        /// <inheritdoc cref="ImagedComboBoxItemCollection(IList{ImagedComboBoxItem})"/>
        public ImagedComboBoxItemCollection(System.Windows.Forms.ComboBox.ObjectCollection items) : this(items.OfType<object>().Select((obj) => new ImagedComboBoxItem(obj)).ToList())
        {
        }

        /// <inheritdoc/>
        public ImagedComboBoxItem this[int index] { get => _items[index]; set => _items[index] = value; }

        /// <inheritdoc/>
        public int Count => _items.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => _items.IsReadOnly;

        /// <inheritdoc/>
        public void Add(ImagedComboBoxItem item)
        {
            _items.Add(item);
            UpdateItems?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc/>
        public void Clear() => _items.Clear();

        /// <inheritdoc/>
        public bool Contains(ImagedComboBoxItem item) => _items.Contains(item);

        /// <inheritdoc/>
        public void CopyTo(ImagedComboBoxItem[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public IEnumerator<ImagedComboBoxItem> GetEnumerator() => _items.GetEnumerator();

        /// <inheritdoc/>
        public int IndexOf(ImagedComboBoxItem item) => _items.IndexOf(item);

        /// <inheritdoc/>
        public void Insert(int index, ImagedComboBoxItem item)
        {
            _items.Insert(index, item);
            UpdateItems?.Invoke(this, EventArgs.Empty);
        }


        /// <inheritdoc/>
        public bool Remove(ImagedComboBoxItem item)
        {
            UpdateItems?.Invoke(this, EventArgs.Empty);
            return _items.Remove(item);
        }


        /// <inheritdoc/>
        public void RemoveAt(int index)
        {
            UpdateItems?.Invoke(this, EventArgs.Empty);
            _items.RemoveAt(index);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_items).GetEnumerator();
    }
}
