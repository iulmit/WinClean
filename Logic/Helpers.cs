// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Provides a set of extension methods that fulfill a relatively generic role.</summary>
    public static class Helpers
    {
        #region Public Methods

        #region Debug

#if DEBUG

        /// <summary>Shortcut to <see cref="MessageBox.Show(string)"/></summary>
        /// <remarks>Debug only</remarks>
        public static void m(this object o) => MessageBox.Show(o?.ToString(), "Debug");

#endif

        #endregion Debug

        #region ToEnumerables

        /* can't use type arguments because it would require the caller to cast to IEnumerable<T>, and this would be unnecessary complicated.
        Soo... just add these here when necessary.*/

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.CheckedListViewItemCollection c) => c.OfType<ListViewItem>();

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.ListViewItemCollection c) => c.OfType<ListViewItem>();

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.SelectedListViewItemCollection c) => c.OfType<ListViewItem>();

        public static IEnumerable<ToolStripItem> ToEnumerable(this ToolStripItemCollection c) => c.OfType<ToolStripItem>();

        public static IEnumerable<Form> ToEnumerable(this FormCollection c) => c.OfType<Form>();

        #endregion ToEnumerables

        public static string ParseForSentence(this string s) => ParseForSentence(s, System.Globalization.CultureInfo.CurrentCulture);

        public static string ParseForSentence(this string s, System.Globalization.CultureInfo culture)
        {
            // matches a sentence
            System.Text.StringBuilder builder = new(Regex.Match(s, "\b[^.!?]*[.!?]").Value);
            if (builder.ToString().Equals(Match.Empty.Value, StringComparison.Ordinal))
                return s;
            builder[0] = char.ToLower(builder[0], culture);
            _ = builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }

        public static char FirstLetter(this string s)
            => s?.First((ch) => char.IsLetter(ch)) ?? throw new ArgumentException("No letters", nameof(s));

        /// <inheritdoc cref="TaskDialog.ShowDialog(TaskDialogPage, TaskDialogStartupLocation)"/>
        /// <remarks>The dialog is a modal dialog box to the currently active form.</remarks>
        public static TaskDialogButton ShowDialog(this TaskDialogPage page, IWin32Window owner = null)
        {
            TaskDialogButton result = owner is null ? TaskDialog.ShowDialog(page) : TaskDialog.ShowDialog(owner, page);
            return result;
        }

        /// <summary>Exécute l'action spécifiée sur chaque élément de <see cref="IEnumerable{}"/> en fournissant son index.</summary>
        /// <typeparam name="T">Le type des éléments de la <see cref="IEnumerable{}"/> et du premier paramètre de l'action.</typeparam>
        /// <param name="action">L'action à exécuter.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T, int> action)
        {
            for (int i = 0; i < (list ?? throw new ArgumentNullException(nameof(list))).Count(); ++i)
                (action ?? throw new ArgumentNullException(nameof(list))).Invoke(list.ElementAt(i), i);
        }

        /// <summary>Exécute l'action spécifiée sur chaque élément de <see cref="IEnumerable{}"/>.</summary>
        /// <typeparam name="T">Le type des éléments de la <see cref="IEnumerable{}"/> et du premier paramètre de l'action.</typeparam>
        /// <param name="action">L'action à exécuter.</param>
        /// <exception cref="ArgumentNullException">One of the parameters are <see langword="null"/>.</exception>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T element in list ?? throw new ArgumentNullException(nameof(list)))
                (action ?? throw new ArgumentNullException(nameof(list))).Invoke(element);
        }

        /// <summary>Sets the <see cref="ListViewItem.Checked"/> property to <paramref name="checked"/> for all items of the specified collection.</summary>
        /// <param name="checked">The value to set the <see cref="ListViewItem.Checked"/> property of all items to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
        public static void SetAllChecked(this ListView.ListViewItemCollection items, bool @checked) => items.ToEnumerable().ForEach((i) => i.Checked = @checked);

        public static string ToMultilineString<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));

            System.Text.StringBuilder sb = new();
            foreach (T val in enumerable)
            {
                _ = sb.AppendLine(val.ToString());
            }
            return sb.ToString();
        }

        #endregion Public Methods
    }
}
