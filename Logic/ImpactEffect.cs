// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Effect of running a script.</summary>
public class ImpactEffect
{
    private readonly string _value;
    /// <summary>
    /// Initializes a new instance of the <see cref="ImpactEffect"/> class.
    /// </summary>
    public ImpactEffect(string value)
        => _value = Values.Contains(value) ? value : throw new ArgumentException($"{value} is not supported.");

    /// <summary>
    /// Gets all the valid values.
    /// </summary>
    public static IEnumerable<string?> Values => Resources.ImpactEffect.ResourceManager.GetRessources<string>();

    /// <summary>System praticality.</summary>
    public static ImpactEffect Ergonomics => new(Resources.ImpactEffect.Ergonomics);

    /// <summary>Idle system memory usage.</summary>
    public static ImpactEffect MemoryUsage => new(Resources.ImpactEffect.MemoryUsage);

    /// <summary>Idle system network usage.</summary>
    public static ImpactEffect NetworkUsage => new(Resources.ImpactEffect.NetworkUsage);

    /// <summary>System rapidity of executing commands.</summary>
    public static ImpactEffect ResponseTime => new(Resources.ImpactEffect.ResponseTime);

    /// <summary>System shutdown time.</summary>
    public static ImpactEffect ShutdownTime => new(Resources.ImpactEffect.ShutdownTime);

    /// <summary>System privacy invasion and spying.</summary>
    public static ImpactEffect Privacy => new(Resources.ImpactEffect.Privacy);

    /// <summary>System startup time.</summary>
    public static ImpactEffect StartupTime => new(Resources.ImpactEffect.StartupTime);

    /// <summary>Free storage space.</summary>
    public static ImpactEffect FreeStorageSpace => new(Resources.ImpactEffect.FreeStorageSpace);

    /// <summary>Storage read-write speed.</summary>
    public static ImpactEffect StorageSpeed => new(Resources.ImpactEffect.StorageSpeed);

    /// <summary>System visuals.</summary>
    public static ImpactEffect Visuals => new(Resources.ImpactEffect.Visuals);

    /// <inheritdoc cref="ToString"/>
    public static implicit operator string(ImpactEffect impactEffect) => impactEffect?.ToString()!;// ! : a cast from null returns null.

    /// <inheritdoc/>
    public override string ToString() => _value;
}
