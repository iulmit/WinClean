// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Text.RegularExpressions;

namespace RaphaëlBardini.WinClean
{
    public struct Extension : IEquatable<Extension>
    {
        #region Private Fields

        private readonly string _value;

        #endregion Private Fields

        #region Public Constructors

        /// <param name="dotExt">The file extension starting with a dot, for instance, <c>".txt"</c>.</param>
        public Extension(string dotExt)
        {
            if (dotExt is null)
                throw new ArgumentNullException(nameof(dotExt));
            if (!Regex.Match(dotExt, "^\\.[^.]+$").Success)
                throw new ArgumentException("Not a file extension", nameof(dotExt));

            _value = dotExt;
        }

        #endregion Public Constructors

        #region Public Methods

        public static implicit operator string(Extension ext) => ext._value;

        public static bool operator !=(Extension left, Extension right) => !left.Equals(right);

        public static bool operator ==(Extension left, Extension right) => left.Equals(right);

        public override bool Equals(object obj) => obj is Extension ext && Equals(ext);

        public bool Equals(Extension other) => _value.Equals(other._value, StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode() => _value.GetHashCode(StringComparison.Ordinal);

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString() => _value;

        #endregion Public Methods
    }
}
