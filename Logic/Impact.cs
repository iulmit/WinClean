﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic
{
    public enum ImpactLevel
    {
        Positive,
        Negative,
        Mixed,
    }

    public static class ImpactExtensions
    {
        #region Public Methods

        /// <summary>Returns the corresponding symbol, or an empty string if the value is not a valid <see cref="ImpactLevel"/>.</summary>
        public static string ToString(this ImpactLevel lvl) => $"{lvl switch { ImpactLevel.Positive => '+', ImpactLevel.Negative => '-', ImpactLevel.Mixed => '•', _ => string.Empty, }}";

        #endregion Public Methods
    }

    public class Impact : IEquatable<Impact>
    {
        #region Public Constructors

        /// <exception cref="ArgumentOutOfRangeException"><paramref name="lvl"/> is not avalid <see cref="ImpactLevel"/> value.</exception>
        public Impact(string type, ImpactLevel lvl)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"Cannot be null or whitespace.", nameof(type));
            }

            Type = type;
            Level = Enum.IsDefined(typeof(ImpactLevel), lvl) ? lvl : throw new ArgumentOutOfRangeException(nameof(type), type, "Undefined enum value.");
        }

        #endregion Public Constructors

        #region Public Properties

        public ImpactLevel Level { get; }
        public string Type { get; }

        #endregion Public Properties

        #region Public Methods

        public override bool Equals(object obj) => obj is Impact i && Equals(i);

        public bool Equals(Impact other) => other is not null && Level == other.Level && Type.Equals(other.Type, StringComparison.Ordinal);

        public override int GetHashCode() => HashCode.Combine(Level, Type);

        public override string ToString() => $"{ImpactExtensions.ToString(Level)} {Type}";

        #endregion Public Methods
    }
}
