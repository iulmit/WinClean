// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Globalization;

using static RaphaëlBardini.WinClean.Resources.ImpactEffect;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A system-wide effect of running a script.</summary>
    public readonly struct Impact : IEquatable<Impact>
    {
        #region Public Constructors

        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="lvl"/> is not a valid <see cref="ImpactLevel"/> value.
        /// </exception>
        public Impact(ImpactLevel lvl, ImpactEffect effect)
        {
            Effect = Enum.IsDefined(typeof(ImpactEffect), effect) ? effect : throw new InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ImpactLevel));
            Level = Enum.IsDefined(typeof(ImpactLevel), lvl) ? lvl : throw new InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ImpactLevel));
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>The actual effect of running a script.</summary>
        public ImpactEffect Effect { get; }

        /// <summary>The level of the effect.</summary>
        public ImpactLevel Level { get; }

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is Impact i && Equals(i);

        /// <inheritdoc/>
        public bool Equals(Impact other) => Level == other.Level && Effect == other.Effect;

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(Level, Effect);

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"{Level} {Effect}";

        #endregion Public Methods

        /// <summary>Indicates wether the object is different from another object of the same type.</summary>
        /// <returns>
        /// <see langword="true"/> if <paramref name="left"/> is different from <paramref name="right"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(Impact left, Impact right) => !(left == right);

        /// <summary>Indicates <paramref name="left"/> is equal to right <paramref name="right"/>.</summary>
        /// <returns>
        /// <see langword="true"/> if <paramref name="left"/> is equal to <paramref name="right"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(Impact left, Impact right) => left.Equals(right);
    }

    /// <summary>Provides extension methods for the <see cref="ImpactEffect"/> enum;</summary>
    public static class ImpactEffectExtensions
    {
        #region Public Methods

        /// <summary>Gets the localized string corresponding the <paramref name="effect"/>'s value.</summary>
        /// <exception cref="InvalidEnumArgumentException">
        /// <paramref name="effect"/> is not a defined <see cref="ImpactEffect"/> constant.
        /// </exception>
        public static string GetLocalizedString(this ImpactEffect effect, CultureInfo? cultureInfo = null)
            => ResourceManager.GetString(effect.ToString(), cultureInfo ?? CultureInfo.CurrentUICulture)
                ?? throw new InvalidEnumArgumentException(nameof(effect), (int)effect, typeof(ImpactEffect));

        #endregion Public Methods
    }
}
