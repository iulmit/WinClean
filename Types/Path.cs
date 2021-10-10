// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using static System.IO.Path;

namespace RaphaëlBardini.WinClean
{
    /*public interface IPath : IEquatable<IPath>
    {
        public string Directory { get; }
        public string Root { get; }
    }*/

    /// <summary>Represents a standard file or folder path.</summary>
    public struct Path : IEquatable<Path>
    {
        #region Private Fields

        private readonly string _value;

        #endregion Private Fields

        #region Public Properties

        /// <inheritdoc cref="GetDirectoryName(string?)" path="/summary"/>
        public string Directory => GetDirectoryName(_value);

        /// <inheritdoc cref="GetExtension(string?)" path="/summary"/>
        public Extension Extension => new(GetExtension(_value));

        /// <inheritdoc cref="GetFileName(string?)" path="/summary"/>
        public string Filename => GetFileName(_value);

        /// <inheritdoc cref="GetFileNameWithoutExtension(string?)" path="/summary"/>
        public string FilenameWithoutExtension => GetFileNameWithoutExtension(_value);

        /// <inheritdoc cref="GetPathRoot(string?)" path="/summary"/>
        public string Root => GetPathRoot(_value);

        #endregion Public Properties

        #region Public Constructors

        /// <summary>Instanciates a new <see cref="Path"/> object.</summary>
        /// <param name="path">The file or folder path</param>
        /// <inheritdoc cref="GetFullPath(string)" path="/exception"/>
        public Path(string path) => _value = GetFullPath(path ?? throw new ArgumentNullException(nameof(path)));

        /// <summary>Instanciates a new <see cref="Path"/> object relative to another.</summary>
        /// <param name="path">The file or folder path</param>
        /// <inheritdoc cref="GetFullPath(string, string)" path="/exception"/>
        public Path(string path, string basePath) => _value = GetFullPath(path, basePath);

        #endregion Public Constructors

        #region Public Methods

        public static implicit operator string(Path p) => p._value;

        public static bool operator !=(Path left, Path right) => !left.Equals(right);

        public static bool operator ==(Path left, Path right) => left.Equals(right);

        /// <inheritdoc cref="object.Equals(object?)()"/>
        /// <remarks>Overriden in <see cref="Path"/>.</remarks>
        public override bool Equals(object obj) => obj is Path path && Equals(path);

        public bool Equals(Path other) => _value.Equals(other._value, StringComparison.OrdinalIgnoreCase);

        /// <inheritdoc cref="object.GetHashCode()"/>
        /// <remarks>Overriden in <see cref="Path"/>.</remarks>
        public override int GetHashCode() => HashCode.Combine(_value);

        /// <inheritdoc cref="object.ToString()"/>
        /// <remarks>Overriden in <see cref="Path"/>.</remarks>
        public override string ToString() => _value;

        #endregion Public Methods
    }
}
