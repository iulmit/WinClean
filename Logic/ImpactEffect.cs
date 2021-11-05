// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>
/// Effect of running a script.
/// </summary>
public class ImpactEffect
{
    #region Private Fields

    private static readonly IEnumerable<string?> _validValues = Resources.ImpactEffect.ResourceManager.GetRessources<string>();

    private readonly string? _value;

    #endregion Private Fields

    #region Private Constructors

    private ImpactEffect(string? value) => _value = value;

    #endregion Private Constructors

    #region Public Properties

    /// <summary>
    /// System praticality.
    /// </summary>
    public static ImpactEffect Ergonomics => new(Resources.ImpactEffect.Ergonomics);

    /// <summary>
    /// Free storage space.
    /// </summary>
    public static ImpactEffect FreeStorageSpace => new(Resources.ImpactEffect.FreeStorageSpace);

    /// <summary>
    /// Idle system memory usage.
    /// </summary>
    public static ImpactEffect MemoryUsage => new(Resources.ImpactEffect.MemoryUsage);

    /// <summary>
    /// Idle system network usage.
    /// </summary>
    public static ImpactEffect NetworkUsage => new(Resources.ImpactEffect.NetworkUsage);

    /// <summary>
    /// System privacy invasion and spying.
    /// </summary>
    public static ImpactEffect Privacy => new(Resources.ImpactEffect.Privacy);

    /// <summary>
    /// System rapidity of executing commands.
    /// </summary>
    public static ImpactEffect ResponseTime => new(Resources.ImpactEffect.ResponseTime);

    /// <summary>
    /// System shutdown time.
    /// </summary>
    public static ImpactEffect ShutdownTime => new(Resources.ImpactEffect.ShutdownTime);

    /// <summary>
    /// System startup time.
    /// </summary>
    public static ImpactEffect StartupTime => new(Resources.ImpactEffect.StartupTime);

    /// <summary>
    /// Storage read-write speed.
    /// </summary>
    public static ImpactEffect StorageSpeed => new(Resources.ImpactEffect.StorageSpeed);

    /// <summary>
    /// Undefined effect. It should be.
    /// </summary>
    public static ImpactEffect Undefined => new(Resources.ImpactEffect.Undefined);

    /// <summary>
    /// Gets all the valid values.
    /// </summary>
    public static IEnumerable<ImpactEffect> Values => _validValues.Select((str) => new ImpactEffect(str));

    /// <summary>
    /// System visuals.
    /// </summary>
    public static ImpactEffect Visuals => new(Resources.ImpactEffect.Visuals);

    #endregion Public Properties

    #region Public Methods

    /// <inheritdoc cref="ToString"/>
    public static implicit operator string(ImpactEffect impactEffect) => impactEffect?.ToString()!;

    /// <summary>
    /// Gets the <see cref="ImpactEffect"/> matching the specified string.
    /// </summary>
    /// <returns>A new <see cref="ImpactEffect"/> object.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="value"/> does not match to any <see cref="ImpactEffect"/> value.
    /// </exception>
    public static ImpactEffect Parse(string? value)
        => _validValues.Contains(value)
            ? (new(value))
            : throw new ArgumentException($"Not a supported {nameof(ImpactEffect)} value", nameof(value));

    // ! : a cast from null returns null.

    /// <inheritdoc/>
    public override string? ToString() => _value;

    #endregion Public Methods
}