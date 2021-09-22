// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean
{
    /// <summary>Provides a set of extension methods that fulfill a relatively generic role.</summary>
    public static class Helpers
    {
        #region Debug

#if DEBUG

        /// <summary>
        /// Debug only. Shortcut to <see cref="MessageBox.Show(string)"/>
        /// </summary>
        public static void m(this object o) => MessageBox.Show(o.ToString());

#endif

        #endregion Debug

        #region Public Methods


        public static IEnumerable<ListViewItem> ToListViewItems(this IEnumerable<Presentation.Preset> presets) => presets.Select((p) => p.ToListViewItem());
        public static IEnumerable<ListViewItem> ToListViewItems(this IEnumerable<Presentation.Script> scripts) => scripts.Select((s) => s.ToListViewItem());
        /// <summary>Makes the <see cref="ListViewItem"/> available for rename by the end-user.</summary>
        /// <remarks>When the call is done, the <see cref="ListViewItem"/> is not yet renamed. It is renamed when the <see cref="ListView.AfterLabelEdit"/> event
        /// is triggered.</remarks>
        /// <param name="item"></param>
        public static void StartRename(this ListViewItem item)
        {
            if (item.ListView is null)
                throw new InvalidOperationException($"The {nameof(ListViewItem)} must be part of a {nameof(ListView)} control.");

            item.ListView.LabelEdit = true;
            item.BeginEdit();

            item.ListView.AfterLabelEdit += AfterLabelEdit;
        }

        private static void AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item = ((ListView)sender).Items[e.Item];

            bool oldShowITT = item.ListView.ShowItemToolTips;
            bool oldLabelEdit = item.ListView.LabelEdit;
            string oldTTT = item.ToolTipText;

            Validator v = new(new (string, bool)[]
            {
                    (Resources.ErrorMessages.NameAlreadyExists, item.ListView.ChecksForItemsWithSameText(item.Text.Trim())),
                    (Resources.ErrorMessages.EmptyName, string.IsNullOrWhiteSpace(item.Text.Trim()))
            });

            if (e.CancelEdit = v.ActiveErrors.Any())
            {
                item.ListView.ShowItemToolTips = true;
                item.ToolTipText = v.ActiveErrors.ToMultiLineString();
            }
            else
            {
                item.ListView.ShowItemToolTips = oldShowITT;
                item.ListView.LabelEdit = oldLabelEdit;
                item.ToolTipText = oldTTT;
            }
        }

        public static bool ChecksForItemsWithSameText(this ListView list, string text) =>
                    list.Items.ToEnumerable().Any((item) => item.Text.Equals(text));

        /// <summary>Sets the <see cref="ListViewItem.Checked"/> property to <paramref name="checked"/> for all items of the specified collection.</summary>
        /// <param name="checked">The value to set the <see cref="ListViewItem.Checked"/> property of all items to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
        public static void SetAllChecked(this ListView.CheckedListViewItemCollection items, bool @checked)
        {
            foreach (ListViewItem item in items ?? throw new ArgumentNullException(nameof(items)))
                item.Checked = @checked;
        }

        /// <summary>Prompts the user for replacing the specified file.</summary>
        /// <returns><see langword="true"/> if the user accepted, otherwise <see langword="false"/>.</returns>
        /// <remarks>Performs no filesystem operation on it's own.</remarks>
        public static bool AskForReplace(string path)
        {
            $"{path} already exists. Prompting user for overwrite.".Log("File overwrite operation", TraceEventType.Warning);
            return MessageBox.Show($"{path}{Constants.NL}{Resources.ErrorMessages.FileReplacePrompt}", Resources.ErrorStrings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        /// <summary>Searches a <see cref="StringTag"/> in a string</summary>
        /// <returns>The substring located between the first occurences of <c>tag.a</c> and <c>tag.b</c> without including them.
        /// If <c>tag.a</c> or <c>tag.b</c> are not found, an empty string.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
        public static string Between(this string s, in StringTag tag)
        {
            int IA = s.IndexOf(tag.Start, tag.IgnoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);

            int IB = s.IndexOf(tag.End, IA, tag.IgnoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);
            return s.Substring(IA + tag.Start.Length, (IB == -1) ? s.Length : IB - IA - tag.End.Length);
        }

        /// <summary>Searches an array of <see cref="StringTag"/> in a string.</summary>
        /// <returns>The substring located between the first occurences of one of <paramref name="tags"/> elements in <paramref name="s"/> without including them.
        /// If nothing was found, an emptry string.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="s"/> is <see langword="null"/>.</exception>
        public static string Between(this string s, in StringTag[] tags)
        {
            foreach (StringTag tag in tags)
            {
                string r;
                if ((r = s.Between(tag)) != "")
                    return r;
            }
            return "";
        }

        /// <summary>Logs the exit and quits the program.</summary>
        public static void Exit()
        {
            $"Exiting the application.".Log("Exit", TraceEventType.Information);
            Application.Exit();
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

        /// <summary>Prompts the user for quitting the application after showing the exception's details and logs it.</summary>
        /// <param name="message">A complementary message to show to the user.</param>
        /// <param name="lvl">The seriousness of the exception.</param>
        public static void Handle(this Exception e, string message = "", TraceEventType lvl = TraceEventType.Error)
        {
            e.ToString().Log("Exception", lvl);
            HandleDontLog(e, message, lvl);
        }

        /// <inheritdoc cref="Handle(Exception, string, TraceEventType)"/>
        /// <remarks>Performs no log operation. Useful if a log operation failed and would fail again.</remarks>
        public static void HandleDontLog(this Exception e, string message = "", TraceEventType lvl = TraceEventType.Error)
        {
            if (PromptQuit(e, message, lvl))
                Application.Exit();
        }

        public static ListViewGroup[] ToArray(this ListViewGroupCollection c) => c.OfType<ListViewGroup>().ToArray();

        #region ToEnumerables

        /* We can't use type arguments for this one because it would require the caller to cast to IEnumerable<T>, and this would be unnecessary complicated.
        Soo... we just add these here when necessary.*/

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.CheckedListViewItemCollection c) => c.OfType<ListViewItem>();

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.ListViewItemCollection c) => c.OfType<ListViewItem>();

        public static IEnumerable<ListViewItem> ToEnumerable(this ListView.SelectedListViewItemCollection c) => c.OfType<ListViewItem>();

        #endregion ToEnumerables

        /// <summary>Generates a formatted <see cref="string"/> out of an <see cref="IEnumerable{T}"/>.</summary>
        /// <returns>A multi-line string beginning with <c>'{'</c>, each line corresponding to <see cref="object.ToString"/>.</returns>
        public static string ToMultiLineString<T>(this IEnumerable<T> enmerable)
        {
            System.Text.StringBuilder sb = new();
            _ = sb.Append("{ ");
            foreach (T val in enmerable)
            {
                _ = sb.Append(val.ToString());
                _ = sb.Append(", ");
            }
            _ = sb.Append('}');
            return sb.ToString();
        }

        #endregion Public Methods

        #region Private Methods

        private static (MessageBoxIcon icon, string title, bool quit) Parse(this TraceEventType lvl) => lvl switch
        {
            TraceEventType.Critical => (MessageBoxIcon.Error, Resources.ErrorStrings.Critical, true),
            TraceEventType.Error => (MessageBoxIcon.Error, Resources.ErrorStrings.Error, false),
            TraceEventType.Warning => (MessageBoxIcon.Warning, Resources.ErrorStrings.Warning, false),
            _ => (MessageBoxIcon.Information, Resources.ErrorStrings.Info, false)
        };

        private static bool PromptQuit(Exception e, string complementaryMessage, TraceEventType lvl)
        {
            (MessageBoxIcon icon, string title, bool quit) = lvl.Parse();
            return MessageBox.Show(
            $"{Application.ProductName} a rencontré une erreur :\n\n{e.Message}\n\n{complementaryMessage}\n\n{(quit ? Resources.ErrorMessages.ClickOKToExit : Resources.ErrorMessages.PromptContinueApp)}"
            , title, quit ? MessageBoxButtons.OK : MessageBoxButtons.YesNo, icon) != DialogResult.Yes;
        }

        #endregion Private Methods
    }
}
