// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

using static RaphaëlBardini.WinClean.Resources.ImpactEffect;

namespace RaphaëlBardini.WinClean.Logic
{
    public enum ImpactEffect
    {
        Ergonomics,
        MemoryUsage,
        NetworkUsage,
        ResponseTime,
        ShutdownTime,
        DataCollection,
        StartupTime,
        StorageCapacity,
        StorageSpeed,
        Visuals
    }

    public enum ImpactLevel
    {
        Positive,
        Negative,
        Mixed,
    }

    public static class EnumExtensions
    {
        #region Public Methods

        /// <summary>Returns the corresponding symbol, or an empty string if the value is not a valid <see cref="ImpactLevel"/>.</summary>
        public static string ToString(this ImpactLevel lvl)
            => lvl switch { ImpactLevel.Positive => "+", ImpactLevel.Negative => "-", ImpactLevel.Mixed => "•", _ => throw new InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ImpactLevel)), };

        public static string ToString(this ImpactEffect effect)
            => effect switch
            {
                ImpactEffect.Ergonomics => Ergonomics,
                ImpactEffect.MemoryUsage => MemoryUsage,
                ImpactEffect.NetworkUsage => NetworkUsage,
                ImpactEffect.ResponseTime => ResponseTime,
                ImpactEffect.ShutdownTime => ShutdownTime,
                ImpactEffect.DataCollection => DataCollection,
                ImpactEffect.StartupTime => StartupTime,
                ImpactEffect.StorageCapacity => StorageCapacity,
                ImpactEffect.StorageSpeed => StorageSpeed,
                ImpactEffect.Visuals => Visuals,
                _ => throw new InvalidEnumArgumentException(nameof(effect), (int)effect, typeof(ImpactEffect)),
            };

        #endregion Public Methods
    }

    public class Impact : IEquatable<Impact>
    {
        #region Public Constructors

        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="lvl"/> is not a valid <see cref="ImpactLevel"/> value.
        /// </exception>
        public Impact(ImpactEffect effect, ImpactLevel lvl)
        {
            Effect = Enum.IsDefined(typeof(ImpactEffect), effect) ? effect : throw new InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ImpactLevel));
            Level = Enum.IsDefined(typeof(ImpactLevel), lvl) ? lvl : throw new InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ImpactLevel));
        }

        #endregion Public Constructors

        #region Public Properties

        public ImpactEffect Effect { get; }
        public ImpactLevel Level { get; }

        #endregion Public Properties

        #region Public Methods

        public override bool Equals(object obj) => obj is Impact i && Equals(i);

        public bool Equals(Impact other) => other is not null && Level == other.Level && Effect == other.Effect;

        public override int GetHashCode() => HashCode.Combine(Level, Effect);

        public override string ToString() => $"{EnumExtensions.ToString(Level)} {EnumExtensions.ToString(Effect)}";// can't call the extension methods directly -- Effect.ToString() would call System.Enum.ToString()

        #endregion Public Methods
    }
}
