// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic;

public class ScriptTimeoutPreset : IEquatable<ScriptTimeoutPreset?>
{
    #region Private Constructors

    private ScriptTimeoutPreset(string name, string localizedName, TimeSpan duration)
    {
        Name = name;
        LocalizedName = localizedName;
        Duration = duration;
    }

    #endregion Private Constructors

    #region Public Properties

    public static ScriptTimeoutPreset LongTimeout { get; } = new(nameof(LongTimeout), Resources.ScriptTimeoutPreset.LongTimeout, TimeSpan.FromMinutes(90));
    public static ScriptTimeoutPreset MediumTimeout { get; } = new(nameof(MediumTimeout), Resources.ScriptTimeoutPreset.MediumTimeout, TimeSpan.FromMinutes(60));
    public static ScriptTimeoutPreset ShortTimeout { get; } = new(nameof(ShortTimeout), Resources.ScriptTimeoutPreset.ShortTimeout, TimeSpan.FromMinutes(30));
    public static IEnumerable<ScriptTimeoutPreset> Values { get; } = new[] { LongTimeout, MediumTimeout, ShortTimeout };
    public TimeSpan Duration { get; }
    public string LocalizedName { get; }
    public string Name { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="ScriptTimeoutPreset"/> matching the specified localized name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="localizedName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="localizedName"/> does not match to any <see cref="ScriptTimeoutPreset"/> localized name.
    /// </exception>
    public static ScriptTimeoutPreset ParseLocalizedName(string localizedName)
        => localizedName is null
            ? throw new ArgumentNullException(nameof(localizedName))
            : Values.FirstOrDefault(validValue => validValue.LocalizedName == localizedName)
                ?? throw new ArgumentException($"Not a valid {nameof(ScriptTimeoutPreset)} localized name.", nameof(localizedName));

    /// <summary>Gets the <see cref="ScriptTimeoutPreset"/> matching the specified name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="name"/> does not match to any <see cref="ScriptTimeoutPreset"/> name.
    /// </exception>
    public static ScriptTimeoutPreset ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue.Name == name)
                ?? throw new ArgumentException($"Not a valid {nameof(ScriptTimeoutPreset)} name.", nameof(name));

    /// <summary>Gets the <see cref="ScriptTimeoutPreset"/> matching the specified name.</summary>
    /// <exception cref="ArgumentException">
    /// <paramref name="duration"/> does not match to any <see cref="ScriptTimeoutPreset"/> duration.
    /// </exception>
    public static ScriptTimeoutPreset ParseTimeout(TimeSpan duration)
        => Values.FirstOrDefault(validValue => validValue.Duration == duration)
             ?? throw new ArgumentException($"Not a valid {nameof(ScriptTimeoutPreset)} duration.", nameof(duration));

    public override bool Equals(Object? obj) => Equals(obj as ScriptTimeoutPreset);

    public bool Equals(ScriptTimeoutPreset? other) => other is not null && Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(Duration, LocalizedName, Name);

    public override string ToString() => Name;

    #endregion Public Methods
}
