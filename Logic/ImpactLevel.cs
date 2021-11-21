// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Represents the level of an <see cref="ImpactEffect"/>.</summary>
public class ImpactLevel : IEquatable<ImpactLevel?>
{
    #region Private Constructors

    private ImpactLevel(string name, Image image)
    {
        Image = image;
        Name = name;
    }

    #endregion Private Constructors

    #region Public Properties

    /// <summary>Variable, uncertain.</summary>
    public static ImpactLevel Mixed { get; } = new(nameof(Mixed), Resources.Images.Mixed);

    /// <summary>Worsening.</summary>
    public static ImpactLevel Negative { get; } = new(nameof(Negative), Resources.Images.Negative);

    /// <summary>Improvement.</summary>
    public static ImpactLevel Positive { get; } = new(nameof(Positive), Resources.Images.Positive);

    public static IEnumerable<ImpactLevel> Values => new[] { Positive, Negative, Mixed };
    public Image Image { get; }
    public string Name { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="ImpactLevel"/> matching the specified name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> does not match to any <see cref="ImpactLevel"/> name.</exception>
    public static ImpactLevel ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue.Name == name)
                ?? throw new ArgumentException(string.Format(InvariantCulture, Resources.DevException.InvalidTypeProp, nameof(ImpactLevel), nameof(Name)), nameof(name));

    public override bool Equals(object? obj) => Equals(obj as ImpactLevel);

    public bool Equals(ImpactLevel? other) => other is not null && Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(Name);

    public override string ToString() => Name;

    #endregion Public Methods
}
