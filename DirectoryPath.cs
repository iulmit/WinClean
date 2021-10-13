// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using static System.IO.Path;

namespace RaphaëlBardini.WinClean
{
    /// <summary>Represents a standard NTFS directory path.</summary>
    public struct DirectoryPath : IEquatable<DirectoryPath>
    {
        #region Private Fields

        private readonly string _value;

        #endregion Private Fields

        #region Public Properties

        /// <inheritdoc cref="GetExtension(string?)" path="/summary"/>
        public Extension Extension => new(GetExtension(_value));

        /// <inheritdoc cref="GetFileName(string?)" path="/summary"/>
        public string Filename => GetFileName(_value);

        /// <inheritdoc cref="GetFileNameWithoutExtension(string?)" path="/summary"/>
        public string FilenameWithoutExtension => GetFileNameWithoutExtension(_value);

        /// <inheritdoc cref="GetDirectoryName(string?)" path="/summary"/>
        public DirectoryPath Parent => new(GetDirectoryName(_value));

        /// <inheritdoc cref="GetPathRoot(string?)" path="/summary"/>
        public DirectoryPath Root => new(GetPathRoot(_value));

        #endregion Public Properties

        #region Public Constructors

        /// <summary>Instanciates a new <see cref="DirectoryPath"/> object.</summary>
        /// <param name="relativePath">The folder path.</param>
        /// <inheritdoc cref="GetFullPath(string)" path="/exception"/>
        public DirectoryPath(string relativePath)
            => _value = GetFullPath(relativePath ?? throw new ArgumentNullException(nameof(relativePath)));

        /// <summary>Instanciates a new <see cref="DirectoryPath"/> object relative to another.</summary>
        /// <param name="relativePath">The folder path.</param>
        /// <inheritdoc cref="GetFullPath(string, string)" path="/exception"/>
        public DirectoryPath(string relativePath, DirectoryPath basePath)
            => _value = GetFullPath(relativePath ?? throw new ArgumentNullException(nameof(relativePath)), basePath);

        #endregion Public Constructors

        #region Public Methods

        public static implicit operator string(DirectoryPath p) => p._value;

        public static bool operator !=(DirectoryPath left, DirectoryPath right) => !left.Equals(right);

        public static bool operator ==(DirectoryPath left, DirectoryPath right) => left.Equals(right);

        public override bool Equals(object obj) => obj is DirectoryPath path && Equals(path);

        public bool Equals(DirectoryPath other) => _value.Equals(other._value, StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode() => HashCode.Combine(_value);

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString() => _value;

        #endregion Public Methods
    }
}
