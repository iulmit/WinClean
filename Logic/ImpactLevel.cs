﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>
/// Represents the level of an <see cref="ImpactEffect"/>.
/// </summary>
public class ImpactLevel : IEquatable<ImpactLevel?>
{
    private ImpactLevel(string name, Image image)
    {
        Image = image;
        _name = name;
    }

    private readonly string _name;

    public static IEnumerable<ImpactLevel> Values => new[]
    {
        Positive,
        Negative,
        Mixed
    };

    public Image Image { get; }

    /// <summary>
    /// Improvement.
    /// </summary>
    public static ImpactLevel Positive => new(nameof(Positive), Resources.Images.Positive);

    /// <summary>
    /// Worsening.
    /// </summary>
    public static ImpactLevel Negative => new(nameof(Negative), Resources.Images.Negative);

    /// <summary>
    /// Variable, uncertain.
    /// </summary>
    public static ImpactLevel Mixed => new(nameof(Mixed), Resources.Images.Mixed);

    public override string ToString() => _name;

    /// <summary>
    /// Gets the <see cref="ImpactLevel"/> matching the specified name.
    /// </summary>
    /// <returns>A new <see cref="ImpactLevel"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="name"/> does not match to any <see cref="ImpactLevel"/> name.
    /// </exception>
    public static ImpactLevel ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue._name == name)
                ?? throw new ArgumentException($"Not a valid {nameof(ImpactLevel)} name.", nameof(name));
    public override bool Equals(object? obj) => Equals(obj as ImpactLevel);
    public bool Equals(ImpactLevel? other) => other is not null && _name == other._name;
    public override int GetHashCode() => HashCode.Combine(_name);
}