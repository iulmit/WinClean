// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

#if DEBUG

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean
{
    internal static class DebugHelpers
    {
        #region Public Methods

        /// <summary>Shortcut to <see cref="MessageBox.Show(string)"/></summary>
        /// <remarks>Debug only</remarks>
        public static void M<T>(this T t) => MessageBox.Show($"{typeof(T)}\n{t}", "Debug");

        /// <summary>Displays a collection in a message box.</summary>
        /// <typeparam name="T">The collection item type.</typeparam>
        /// <param name="e">The collection to display.</param>
        /// <remarks>Debug only.</remarks>

        public static void ME<T>(this IEnumerable<T> e)
        {
            if (e is null)
            {
                M(string.Empty);
                return;
            }
            new StringBuilder().AppendLine(e.GetType().ToString())
                .AppendLine("{")
                .AppendJoin(Environment.NewLine, e)
                .AppendLine("}")
                .ToString()
                .M();
        }

        /// <summary>Displays data in a message box, waits for it's dismiss, and returns that data.</summary>
        /// <typeparam name="T">The type of the data passed.</typeparam>
        /// <param name="t">The data passed.</param>
        /// <returns><paramref name="t"/>.</returns>
        /// <remarks>Debug only.</remarks>
        public static T MR<T>(this T t)
        {
            t.M();
            return t;
        }

        #endregion Public Methods
    }
}

#endif
