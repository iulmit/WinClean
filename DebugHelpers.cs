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
        public static void m(this object o) => MessageBox.Show($"{o?.GetType()}{Environment.NewLine}{o}", "Debug");

        /// <summary>Displays a collection in a message box.</summary>
        /// <typeparam name="T">The collection item type.</typeparam>
        /// <param name="enumerable">The collection to display.</param>
        /// <remarks>Debug only.</remarks>
        public static void mEach<T>(this IEnumerable<T> enumerable)
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

        /// <summary>Displays data in a message box, waits for it's dismiss, and returns that data.</summary>
        /// <typeparam name="T">The type of the data passed.</typeparam>
        /// <param name="o">The data passed.</param>
        /// <returns><paramref name="o"/>.</returns>
        /// <remarks>Debug only.</remarks>
        public static T mReturn<T>(this T o)
        {
            o.m();
            return o;
        }

        #endregion Public Methods
    }
}

#endif
