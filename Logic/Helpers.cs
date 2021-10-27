// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.Win32;

using static System.Diagnostics.Debug;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Provides a set of extension methods that fulfill a relatively generic role.</summary>
    internal static class Helpers
    {
        #region Public Methods

        /// <summary>Creates a file extension filter for an <see cref="OpenFileDialog"/> control.</summary>
        /// <param name="exts">The extension to put into the filter.</param>
        public static string MakeOpenFileDialogFilter(IEnumerable<ExtensionGroup> exts)
            => new StringBuilder().AppendJoin('|', exts.SelectMany(group => new string[]
                                                                                    {
                                                                                        $"{group.Name} ({group.Select(ext => $"*{ext}").Separate(';')})",
                                                                                        group.Select(ext => $"*{ext}").Separate(';')
                                                                                    }
                                                                       )
                                             ).ToString();

        public static string MakeOpenFileDialogFilter(params ExtensionGroup[] exts) => MakeOpenFileDialogFilter(exts: (IEnumerable<ExtensionGroup>)exts);

        public static string ReplaceInvalidFilenameChars(this string maybeInvalidFilename, string replaceInvalidCharsWith = "_")
                    => Regex.Replace(maybeInvalidFilename, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
                             replaceInvalidCharsWith, RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public static string Separate<T>(this IEnumerable<T> ts, char separator) => new StringBuilder().AppendJoin(separator, ts).ToString();

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
            Assert(info is not null);
            using FileStream _ = info.Open(FileMode.Open, access);
        }

        /// <inheritdoc cref="ThrowIfUnacessible(FileInfo, FileAccess)" path="/summary"/>
        /// <exception cref="DirectoryNotFoundException">
        /// The path encapsulated in the System.IO.DirectoryInfo object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
        public static void ThrowIfUnacessible(this DirectoryInfo info)
        {
            Assert(info is not null);
            _ = info.EnumerateDirectories("Trying not to find files, to improve performance. We're just here for the exception that this method may throw.");
        }

        #endregion Public Methods
    }
}
