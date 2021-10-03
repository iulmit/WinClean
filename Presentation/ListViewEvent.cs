// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>A <see cref="ListView"/> control, but with an additionnal event triggered when an item is added.</summary>
    public class ListViewEvent : ListView
    {
        #region Public Constructors

        public ListViewEvent() => Items = new ListViewItemCollection(this);

        #endregion Public Constructors

        #region Public Properties

        public new ListViewItemCollection Items { get; }

        #endregion Public Properties

        #region Public Classes

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1010", Justification = "Not needed")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034", Justification = "Base class override")]
        public new class ListViewItemCollection : ListView.ListViewItemCollection
        {
            #region Public Constructors

            public ListViewItemCollection(ListView owner) : base(owner)
            {
            }

            #endregion Public Constructors

            #region Public Events

            public event EventHandler ItemAdded = null;

            #endregion Public Events

            #region Public Methods

            /// <inheritdoc cref="ListView.ListViewItemCollection.Add(ListViewItem)"/>
            public override ListViewItem Add(ListViewItem value) => OnItemAdded(base.Add(value));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Add(string, string, int)"/>
            public override ListViewItem Add(string key, string text, int imageIndex) => OnItemAdded(base.Add(key, text, imageIndex));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Add(string, string, string)"/>
            public override ListViewItem Add(string key, string text, string imageKey) => OnItemAdded(base.Add(key, text, imageKey));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Add(string)"/>
            public override ListViewItem Add(string text) => OnItemAdded(base.Add(text));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Add(string, int)"/>
            public override ListViewItem Add(string text, int imageIndex) => OnItemAdded(base.Add(text, imageIndex));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Add(string, string)"/>
            public override ListViewItem Add(string text, string imageKey) => OnItemAdded(base.Add(text, imageKey));

            /// <inheritdoc cref="ListView.ListViewItemCollection.AddRange(ListViewItem[])"/>
            public new void AddRange(ListViewItem[] values)
            {
                foreach (ListViewItem item in values ?? throw new ArgumentNullException(nameof(values)))
                    _ = OnItemAdded(item);
                base.AddRange(values);
            }

            /// <inheritdoc cref="ListView.ListViewItemCollection.Insert(int, string, int)"/>
            public new ListViewItem Insert(int index, string text, int imageIndex) => OnItemAdded(base.Insert(index, text, imageIndex));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Insert(int, string, string)"/>
            public new ListViewItem Insert(int index, string text, string imageKey) => OnItemAdded(base.Insert(index, text, imageKey));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Insert(int, string, string, int)"/>
            public override ListViewItem Insert(int index, string key, string text, int imageIndex) => OnItemAdded(base.Insert(index, key, text, imageIndex));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Insert(int, string, string, string)"/>
            public override ListViewItem Insert(int index, string key, string text, string imageKey) => OnItemAdded(base.Insert(index, key, text, imageKey));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Insert(int, ListViewItem)"/>
            public new ListViewItem Insert(int index, ListViewItem item) => OnItemAdded(base.Insert(index, item));

            /// <inheritdoc cref="ListView.ListViewItemCollection.Insert(int, string)"/>
            public new ListViewItem Insert(int index, string text) => OnItemAdded(base.Insert(index, text));

            #endregion Public Methods

            #region Private Methods

            /// <summary>Triggers the <see cref="ItemAdded"/> event.</summary>
            /// <param name="sender">The sender of the event that is triggered.</param>
            /// <returns><paramref name="sender"/></returns>
            private ListViewItem OnItemAdded(ListViewItem sender)
            {
                ItemAdded?.Invoke(sender, EventArgs.Empty);
                return sender;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}
