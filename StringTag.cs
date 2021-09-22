// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean
{
    /// <summary>A tag used for searching a substring in another.</summary>
    public struct StringTag
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

        #endregion Public Properties

        #region Public Methods

        public override string ToString() => $"Start = \"{Start}\", End = \"{End}\", IgnoreCase = {IgnoreCase}";

        #endregion Public Methods
    }
}