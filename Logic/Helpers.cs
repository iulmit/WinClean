// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Provides a set of extension methods that fulfill a relatively generic role.</summary>
    internal static class Helpers
    {
        #region Private Fields

        /// <summary>
        /// MAX_PATH ( <c>260</c>) minus the null terminator ( <c>'\0'</c>), the drive letter, it's colon and slash and a
        /// trailing slash.
        /// </summary>
        private const int MaxFilename = byte.MaxValue;

        #endregion Private Fields

        #region Public Methods

        /// <summary>Checks if an exception is of a type that .NET Core's filesystem methods can throw.</summary>
        /// <returns>
        /// <para><see langword="true"/> if <paramref name="e"/> is of any of the following types :</para>
        /// <br><see cref="IOException"/> (including all derived exceptions)</br><br><see
        /// cref="UnauthorizedAccessException"/></br><br><see cref="NotSupportedException"/></br><br><see cref="System.Security.SecurityException"/></br>
        /// <para>Otherwise; <see langword="false"/>.</para>
        /// </returns>
        /// <remarks>Note that unrelated methods may throw any of these exceptions.</remarks>
        public static bool FileSystem(this Exception e) => e is IOException or UnauthorizedAccessException or NotSupportedException or System.Security.SecurityException;

        /// <summary>Checks if a string is a valid Windows filename.</summary>
        /// <param name="filenameCandidate">The filename candidate.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="filenameCandidate"/> can be a filename, otherwise; <see
        /// langword="false"/>. This method returns <see langword="false"/> if <paramref name="filenameCandidate"/> is <see langword="null"/>.
        /// </returns>
        public static bool IsFilename(this string filenameCandidate)
            => !string.IsNullOrWhiteSpace(filenameCandidate)
               && filenameCandidate.Length <= MaxFilename
               && filenameCandidate.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;

        /// <summary>Creates a file extension filter for an <see cref="OpenFileDialog"/> control.</summary>
        /// <param name="ofd">The <see cref="OpenFileDialog"/> control to make a filter for.</param>
        /// <param name="exts">The extension to put into the filter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ofd"/> is <see langword="null"/>.</exception>
        public static void MakeFilter(this OpenFileDialog ofd, IEnumerable<ExtensionGroup> exts)
            => (ofd ?? throw new ArgumentNullException(nameof(ofd))).Filter = new StringBuilder().AppendJoin('|', exts.SelectMany(group => new string[]
                                                                                   {
                                                                                       $"{group.Name} ({string.Join(';', group.Select(ext => $"*{ext}"))})",
                                                                                       string.Join(';', group.Select(ext => $"*{ext}"))
                                                                                   }
                                                                               )
                                                          ).ToString();

        /// <inheritdoc cref="MakeFilter(OpenFileDialog, IEnumerable{ExtensionGroup})"/>
        public static void MakeFilter(this OpenFileDialog ofd, params ExtensionGroup[] exts) => MakeFilter(ofd, (IEnumerable<ExtensionGroup>)exts);

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

        /// <summary>Creates a valid Windows filename from a string.</summary>
        /// <param name="filenameCandidate">The filename candidate.</param>
        /// <param name="replaceInvalidCharsWith">
        /// What to replace invalid filename chars in <paramref name="filenameCandidate"/> with.
        /// </param>
        /// <returns><paramref name="filenameCandidate"/>, modified to be a valid Windows filename if it wasn't already.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="filenameCandidate"/> or <paramref name="replaceInvalidCharsWith"/> are <see langword="null"/>, or
        /// <paramref name="replaceInvalidCharsWith"/> contains invalid filename chars.
        /// </exception>
        public static string ToFilename(this string filenameCandidate, string replaceInvalidCharsWith = "_")
            => string.IsNullOrWhiteSpace(filenameCandidate)
                ? throw new ArgumentException("Can't be null or whitespace", nameof(filenameCandidate))
                : string.IsNullOrWhiteSpace(replaceInvalidCharsWith)
                    ? throw new ArgumentException("Can't be null or whitespace", nameof(replaceInvalidCharsWith))
                    : replaceInvalidCharsWith.IndexOfAny(Path.GetInvalidFileNameChars()) != -1
                        ? throw new ArgumentException("Contains invalid filename chars", nameof(replaceInvalidCharsWith))
                        : (new(Regex.Replace(filenameCandidate, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
                                             replaceInvalidCharsWith, RegexOptions.Compiled | RegexOptions.CultureInvariant)
                               .Take(MaxFilename).ToArray()));

        #endregion Public Methods
    }
}
