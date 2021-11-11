// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Effect of running a script.</summary>
public class ImpactEffect
{
    #region Private Fields

    private readonly string _name;

    #endregion Private Fields

    #region Public Properties

    public string? LocalizedName { get; }

    #endregion Public Properties

    #region Private Constructors

    private ImpactEffect(string name, string? localizedName)
    {
        LocalizedName = localizedName;
        _name = name;
    }

    #endregion Private Constructors



    #region Public Properties

    /// <summary>System praticality.</summary>
    public static ImpactEffect Ergonomics => new(nameof(Ergonomics), Resources.ImpactEffect.Ergonomics);

    /// <summary>Free storage space.</summary>
    public static ImpactEffect FreeStorageSpace => new(nameof(FreeStorageSpace), Resources.ImpactEffect.FreeStorageSpace);

    /// <summary>Idle system memory usage.</summary>
    public static ImpactEffect MemoryUsage => new(nameof(MemoryUsage), Resources.ImpactEffect.MemoryUsage);

    /// <summary>Idle system network usage.</summary>
    public static ImpactEffect NetworkUsage => new(nameof(NetworkUsage), Resources.ImpactEffect.NetworkUsage);

    /// <summary>System privacy invasion and spying.</summary>
    public static ImpactEffect Privacy => new(nameof(Privacy), Resources.ImpactEffect.Privacy);

    /// <summary>System rapidity of executing commands.</summary>
    public static ImpactEffect ResponseTime => new(nameof(ResponseTime), Resources.ImpactEffect.ResponseTime);

    /// <summary>System shutdown time.</summary>
    public static ImpactEffect ShutdownTime => new(nameof(ShutdownTime), Resources.ImpactEffect.ShutdownTime);

    /// <summary>System startup time.</summary>
    public static ImpactEffect StartupTime => new(nameof(StartupTime), Resources.ImpactEffect.StartupTime);

    /// <summary>Storage read-write speed.</summary>
    public static ImpactEffect StorageSpeed => new(nameof(StorageSpeed), Resources.ImpactEffect.StorageSpeed);

    /// <summary>Gets all the values.</summary>
    public static IEnumerable<ImpactEffect> Values => new[]
    {
        Ergonomics,
        FreeStorageSpace,
        MemoryUsage,
        NetworkUsage,
        Privacy,
        ResponseTime,
        ShutdownTime,
        StartupTime,
        StorageSpeed,
        Visuals
    };

    /// <summary>System visuals.</summary>
    public static ImpactEffect Visuals => new(nameof(Visuals), Resources.ImpactEffect.Visuals);

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="ImpactEffect"/> matching the specified localized name.</summary>
    /// <returns>A new <see cref="ImpactEffect"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="localizedName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="localizedName"/> does not match to any <see cref="ImpactEffect"/> localizedName.
    /// </exception>
    public static ImpactEffect ParseLocalizedName(string localizedName)
        => localizedName is null
            ? throw new ArgumentNullException(nameof(localizedName))
            : Values.FirstOrDefault(validValue => validValue.LocalizedName == localizedName)
                ?? throw new ArgumentException($"Not a valid {nameof(ImpactEffect)} localized name.", nameof(localizedName));

    /// <summary>Gets the <see cref="ImpactEffect"/> matching the specified name.</summary>
    /// <returns>A new <see cref="ImpactEffect"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> does not match to any <see cref="ImpactEffect"/> name.</exception>
    public static ImpactEffect ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue._name == name)
                ?? throw new ArgumentException($"Not a valid {nameof(ImpactEffect)} name.", nameof(name));

    /// <inheritdoc/>
    public override string ToString() => _name;

    #endregion Public Methods
}
