// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Provides a set of extension methods that fulfill a relatively generic role.</summary>
    internal static class Helpers
    {
        #region Public Methods

        /// <summary>Invokes the specified action on each element of an <see cref="IEnumerable{T}"/>.</summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> and <paramref name="action"/>'s types.</typeparam>
        /// <param name="action">The action to invoke on each element of <paramref name="list"/>.</param>
        /// <param name="list">The list containing the elements that will be passed to <paramref name="action"/>.</param>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T element in list)
            {
                action?.Invoke(element);
            }
        }

        public static string ReplaceInvalidFilenameChars(string maybeInvalidFilename, string replaceInvalidCharsWith = "_")
                    => Regex.Replace(maybeInvalidFilename, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
                             replaceInvalidCharsWith, RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>Throws the appropriate exception if the filesystem element is not accessible.</summary>
        /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="info"/> was not found.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="info"/> is readonly or a directory.</exception>
        /// <exception cref="DirectoryNotFoundException">
        /// <paramref name="info"/> is invalid, such as being on an unmapped drive.
        /// </exception>
        /// <exception cref="IOException"><paramref name="info"/> is already open.</exception>
        public static void ThrowIfUnacessible(this FileInfo info, FileAccess access = FileAccess.ReadWrite)
        {
            using FileStream _ = info.Open(FileMode.Open, access);
        }

        /// <inheritdoc cref="ThrowIfUnacessible(FileInfo, FileAccess)" path="/summary"/>
        /// <inheritdoc cref="DirectoryInfo.EnumerateDirectories()" path="/exception"/>
        public static void ThrowIfUnacessible(this DirectoryInfo info)
            => _ = info.EnumerateDirectories("Trying not to find files, to improve performance. We're just here for the exception that this method may throw.");

        #endregion Public Methods
    }
}
