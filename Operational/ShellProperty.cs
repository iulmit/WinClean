// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>Provides static methods for manipulation file and folder shell properties.</summary>
    public static class ShellProperty
    {
        #region Public Methods

        /// <summary>Gets the shell attribute labeled "File Description" of a file.</summary>
        /// <param name="path">The file to get the file description from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is <see langword="null"/>.</exception>
        /// <returns>The file description, or <see cref="string.Empty"/> if there is none.</returns>
        public static string GetFileDescription(System.IO.FileInfo path)
        {
            const string descriptionPropertyGuid = "0CEF7D53-FA64-11D1-A203-0000F81FEDEE";
            const int descriptionPropertyIndex = 3;
            using ShellFile sh = new((path ?? throw new ArgumentNullException(nameof(path))).FullName);
            return sh.Properties.GetProperty<string>(new PropertyKey(descriptionPropertyGuid, descriptionPropertyIndex)).Value;
        }

        #endregion Public Methods
    }
}
