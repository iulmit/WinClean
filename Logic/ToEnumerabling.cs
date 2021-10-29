// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;

using static System.Linq.Enumerable;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Provides extension methods for converting collections to <see cref="IEnumerable{T}"/> without casting.</summary>
    public static class ToEnumerabling
    {
        #region Public Methods

        /// <inheritdoc cref="ToEnumerable(ToolStripItemCollection)"/>
        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.CheckedListViewItemCollection c) => c.OfType<ListViewItem>();

        /// <inheritdoc cref="ToEnumerable(ToolStripItemCollection)"/>
        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.ListViewItemCollection c) => c.OfType<ListViewItem>();

        /// <summary>Converts a collection object to an <see cref="IEnumerable{T}"/>.</summary>
        /// <param name="c">The collection to convert.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the elements of <paramref name="c"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="c"/> is <see langword="null"/>.</exception>
        public static IEnumerable<ToolStripItem> ToEnumerable(this ToolStripItemCollection c) => c.OfType<ToolStripItem>();

        #endregion Public Methods
    }
}
