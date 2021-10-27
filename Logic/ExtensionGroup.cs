// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Win32;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A group of extensions</summary>
    public readonly struct ExtensionGroup : IEquatable<ExtensionGroup>, IReadOnlyCollection<string>
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ExtensionGroup"/> structure.</summary>
        /// <param name="extensions">The extensions in the group.</param>
        public ExtensionGroup(IEnumerable<string> extensions)
        {
            Assert(extensions is not null);
            _extensions = extensions.ToList();
        }

        /// <inheritdoc cref="ExtensionGroup(IEnumerable{string})"/>
        public ExtensionGroup(params string[] extensionsParam) : this(extensions: extensionsParam)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>File extensions included in the group.</summary>
        private readonly IReadOnlyCollection<string> _extensions;

        /// <inheritdoc/>
        public int Count => _extensions.Count;

        /// <summary>Name of the group.</summary>
        public string Name => GetFileTypeDisplayName(_extensions.First());

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc/>
        public static bool operator !=(ExtensionGroup left, ExtensionGroup right) => !(left == right);

        /// <inheritdoc/>
        public static bool operator ==(ExtensionGroup left, ExtensionGroup right) => left.Equals(right);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ExtensionGroup group && Equals(group);

        /// <inheritdoc/>
        public bool Equals(ExtensionGroup other) => _extensions.SequenceEqual(other._extensions) && Name == other.Name;

        /// <inheritdoc/>
        public IEnumerator<string> GetEnumerator() => _extensions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_extensions).GetEnumerator();

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(_extensions, Name);

        #endregion Public Methods

        #region Private Methods

        private static string GetFileTypeDisplayName(string extension)
        {
            Assert(extension is not null);
            try
            {
                using RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey((Registry.ClassesRoot.OpenSubKey(extension).GetValue(null) as string) ?? string.Empty);
                if (registryKey == null)
                {
                    return string.Empty;
                }

                object fileDescriptionObject = registryKey.GetValue(null);
                if (fileDescriptionObject is not string)
                {
                    return string.Empty;
                }

                string fileDescription = (string)fileDescriptionObject;
                return fileDescription;
            }
            catch (Exception e) when (e is System.Security.SecurityException or ObjectDisposedException or UnauthorizedAccessException)
            {
                return string.Empty;
            }
        }

        #endregion Private Methods
    }
}
