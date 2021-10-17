// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Drawing;
using System.Text;
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
        public static void m(this object o) => MessageBox.Show($"{o?.GetType()}{Environment.NewLine}{o}", "Debug");

        public static void mEnumerable<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
            {
                m(string.Empty);
                return;
            }
            new StringBuilder().AppendLine(enumerable.GetType().ToString())
                .AppendLine("{")
                .AppendJoin(Environment.NewLine, enumerable)
                .AppendLine("}")
                .ToString()
                .m();
        }

        public static T mReturn<T>(this T o)
        {
            o.m();
            return o;
        }

#endif

        #endregion Debug

        /// <summary>Blends the specified colors together.</summary>
        /// <param name="color">Color to blend onto the background color.</param>
        /// <param name="backColor">Color to blend the other color onto.</param>
        /// <param name="amount">How much of <paramref name="color"/> to keep, “on top of” <paramref name="backColor"/>.</param>
        /// <returns>The blended colors.</returns>
        public static Color EmulateAlpha(this Color color, Color fadeInto, byte alpha)
        {
            float amount = (float)alpha / byte.MaxValue;
            byte r = (byte)(color.R * amount + fadeInto.R * (1 - amount));
            byte g = (byte)(color.G * amount + fadeInto.G * (1 - amount));
            byte b = (byte)(color.B * amount + fadeInto.B * (1 - amount));
            return Color.FromArgb(r, g, b);
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

        /// <summary>
        /// Sets the <see cref="ListViewItem.Checked"/> property to <paramref name="checked"/> for all items of the specified collection.
        /// </summary>
        /// <param name="checked">The value to set the <see cref="ListViewItem.Checked"/> property of all items to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
        public static void SetAllChecked(this ListView.ListViewItemCollection items, bool @checked) => items.ToEnumerable().ForEach((i) => i.Checked = @checked);

        public static string ToMultilineString(this IEnumerable<Impact> impacts) => new StringBuilder().AppendJoin(Environment.NewLine, impacts).ToString();

        #endregion Public Methods
    }
}
