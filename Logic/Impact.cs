// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

using static RaphaëlBardini.WinClean.Resources.ImpactEffect;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Effect of running a script.</summary>
    public enum ImpactEffect
    {
        /// <summary>System praticality.</summary>
        Ergonomics,

        /// <summary>System non user-related memory usage.</summary>
        MemoryUsage,

        /// <summary>System non user-related network usage.</summary>
        NetworkUsage,

        /// <summary>System rapidity of running commands.</summary>
        ResponseTime,

        /// <summary>System shutdown time.</summary>
        ShutdownTime,

        /// <summary>System privacy invasion and spying.</summary>
        DataCollection,

        /// <summary>System startup time.</summary>
        StartupTime,

        /// <summary>Free storage space.</summary>
        StorageCapacity,

        /// <summary>Storage read-write speed.</summary>
        StorageSpeed,

        /// <summary>System visuals.</summary>
        Visuals
    }

    /// <summary>Represents the level of an <see cref="ImpactEffect"/>.</summary>
    public enum ImpactLevel
    {
        /// <summary>Improvement.</summary>
        Positive,

        /// <summary>Worsening.</summary>
        Negative,

        /// <summary>Variable, uncertain.</summary>
        Mixed,
    }

    /// <summary>A system-wide effect of running a script.</summary>
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

        /// <summary>The actual effect of running a script.</summary>
        public ImpactEffect Effect { get; }

        /// <summary>The level of the effect.</summary>
        public ImpactLevel Level { get; }

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is Impact i && Equals(i);

        /// <inheritdoc/>
        public bool Equals(Impact other) => other is not null && Level == other.Level && Effect == other.Effect;

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(Level, Effect);

        /// <inheritdoc/>
        public override string ToString() => $"{ToString(Level)} {ToString(Effect)}";// can't call the extension methods directly -- Effect.ToString() would call System.Enum.ToString()

        #endregion Public Methods

        /// <summary>Returns the corresponding symbol, or an empty string if the value is not a valid <see cref="ImpactLevel"/>.</summary>
        /// <exception cref="InvalidEnumArgumentException">
        /// <paramref name="lvl"/> is not a defined <see cref="ImpactLevel"/> constant.
        /// </exception>
        public static string ToString(ImpactLevel lvl)
            => lvl switch
            {
                ImpactLevel.Positive => "+",
                ImpactLevel.Negative => "-",
                ImpactLevel.Mixed => "•",
                _ => throw new InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ImpactLevel))
            };

        /// <exception cref="InvalidEnumArgumentException">
        /// <paramref name="effect"/> is not a defined <see cref="ImpactEffect"/> constant.
        /// </exception>
        private static string ToString(ImpactEffect effect) => effect switch
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
    }
}
