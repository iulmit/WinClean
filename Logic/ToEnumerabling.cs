// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;

using static System.Linq.Enumerable;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Provides extension method for converting collections to <see cref="IEnumerable{T}"/> without casting.</summary>
    public static class ToEnumerabling
    {
        #region Public Methods

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.CheckedListViewItemCollection c) => c.OfType<ListViewItem>();

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.ListViewItemCollection c) => c.OfType<ListViewItem>();

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.SelectedListViewItemCollection c) => c.OfType<ListViewItem>();

        public static IEnumerable<ToolStripItem> ToEnumerable(this ToolStripItemCollection c) => c.OfType<ToolStripItem>();

        public static IEnumerable<Form> ToEnumerable(this FormCollection c) => c.OfType<Form>();

        #endregion Public Methods
    }
}
