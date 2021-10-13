// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using static System.IO.Path;

namespace RaphaëlBardini.WinClean
{
    /// <summary>Represents a standard NTFS file path.</summary>
    public struct FilePath : IEquatable<FilePath>
    {
        #region Private Fields

        private readonly string _value;

        #endregion Private Fields

        #region Public Properties

        /// <inheritdoc cref="GetDirectoryName(string?)" path="/summary"/>
        public DirectoryPath Directory => new(GetDirectoryName(_value));

        /// <inheritdoc cref="GetExtension(string?)" path="/summary"/>
        public Extension Extension => new(GetExtension(_value));

        /// <inheritdoc cref="GetFileName(string?)" path="/summary"/>
        public string Filename => GetFileName(_value);

        /// <inheritdoc cref="GetFileNameWithoutExtension(string?)" path="/summary"/>
        public string FilenameWithoutExtension => GetFileNameWithoutExtension(_value);

        /// <inheritdoc cref="GetPathRoot(string?)" path="/summary"/>
        public DirectoryPath Root => new(GetPathRoot(_value));

        #endregion Public Properties

        #region Public Constructors

        /// <summary>Instanciates a new <see cref="FilePath"/> object.</summary>
        /// <param name="relativePath">The file path.</param>
        /// <inheritdoc cref="GetFullPath(string)" path="/exception"/>
        public FilePath(string relativePath)
            => _value = GetFullPath(relativePath ?? throw new ArgumentNullException(nameof(relativePath)));

        /// <summary>Instanciates a new <see cref="FilePath"/> object relative a directory.</summary>
        /// <param name="relativePath">The file path.</param>
        /// <inheritdoc cref="GetFullPath(string, string)" path="/exception"/>
        public FilePath(string relativePath, DirectoryPath baseDir)
            => _value = GetFullPath(relativePath ?? throw new ArgumentNullException(nameof(relativePath)), baseDir);

        #endregion Public Constructors

        #region Public Methods

        public static implicit operator string(FilePath p) => p._value;

        public static bool operator !=(FilePath left, FilePath right) => !left.Equals(right);

        public static bool operator ==(FilePath left, FilePath right) => left.Equals(right);

        public override bool Equals(object obj) => obj is FilePath path && Equals(path);

        public bool Equals(FilePath other) => _value.Equals(other._value, StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode() => HashCode.Combine(_value);

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString() => _value;

        #endregion Public Methods
    }
}
