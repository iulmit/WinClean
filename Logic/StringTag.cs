// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean
{
    /// <summary>A tag used for searching a substring in another.</summary>
    public struct StringTag : IEquatable<StringTag>
    {
        #region Public Constructors

        /// <exception cref="ArgumentNullException"><paramref name="end"/> or <paramref name="start"/> are <see langword="null"/>.</exception>
        public StringTag(string start, string end, bool ignoreCase)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            End = end ?? throw new ArgumentNullException(nameof(end));
            IgnoreCase = ignoreCase;
        }

        #endregion Public Constructors

        #region Public Properties

        public string End { get; set; }
        public bool IgnoreCase { get; set; }
        public string Start { get; set; }

        public override bool Equals(object obj) => obj is StringTag tag && Equals(tag);

        public bool Equals(StringTag other) => End.Equals(other.End, StringComparison.Ordinal) && IgnoreCase == other.IgnoreCase && Start.Equals(other.Start, StringComparison.Ordinal);

        public override int GetHashCode() => HashCode.Combine(End, IgnoreCase, Start);

        #endregion Public Properties

        #region Public Methods

        public static bool operator !=(StringTag left, StringTag right)
        {
            return !(left == right);
        }

        public static bool operator ==(StringTag left, StringTag right)
        {
            return left.Equals(right);
        }

        public override string ToString() => $"Start = \"{Start}\", End = \"{End}\", IgnoreCase = {IgnoreCase}";

        #endregion Public Methods
    }
}
