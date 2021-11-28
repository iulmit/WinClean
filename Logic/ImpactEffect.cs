
namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Effect of running a script.</summary>
public class ImpactEffect : IEquatable<ImpactEffect?>
{
    #region Private Constructors

    private ImpactEffect(string name, string? localizedName)
    {
        LocalizedName = localizedName;
        Name = name;
    }

    #endregion Private Constructors

    #region Public Properties

    /// <summary>System praticality.</summary>
    public static ImpactEffect Ergonomics { get; } = new(nameof(Ergonomics), Resources.ImpactEffect.Ergonomics);

    /// <summary>Free storage space.</summary>
    public static ImpactEffect FreeStorageSpace { get; } = new(nameof(FreeStorageSpace), Resources.ImpactEffect.FreeStorageSpace);

    /// <summary>Idle system memory usage.</summary>
    public static ImpactEffect MemoryUsage { get; } = new(nameof(MemoryUsage), Resources.ImpactEffect.MemoryUsage);

    /// <summary>Idle system network usage.</summary>
    public static ImpactEffect NetworkUsage { get; } = new(nameof(NetworkUsage), Resources.ImpactEffect.NetworkUsage);

    /// <summary>System privacy invasion and spying.</summary>
    public static ImpactEffect Privacy { get; } = new(nameof(Privacy), Resources.ImpactEffect.Privacy);

    /// <summary>System rapidity of executing commands.</summary>
    public static ImpactEffect ResponseTime { get; } = new(nameof(ResponseTime), Resources.ImpactEffect.ResponseTime);

    /// <summary>System shutdown time.</summary>
    public static ImpactEffect ShutdownTime { get; } = new(nameof(ShutdownTime), Resources.ImpactEffect.ShutdownTime);

    /// <summary>System startup time.</summary>
    public static ImpactEffect StartupTime { get; } = new(nameof(StartupTime), Resources.ImpactEffect.StartupTime);

    /// <summary>Storage read-write speed.</summary>
    public static ImpactEffect StorageSpeed { get; } = new(nameof(StorageSpeed), Resources.ImpactEffect.StorageSpeed);

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
    public static ImpactEffect Visuals { get; } = new(nameof(Visuals), Resources.ImpactEffect.Visuals);

    public string? LocalizedName { get; }

    public string Name { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="ImpactEffect"/> matching the specified localized name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="localizedName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="localizedName"/> does not match to any <see cref="ImpactEffect"/> localizedName.
    /// </exception>
    public static ImpactEffect ParseLocalizedName(string localizedName)
        => localizedName is null
            ? throw new ArgumentNullException(nameof(localizedName))
            : Values.FirstOrDefault(validValue => validValue.LocalizedName == localizedName)
                ?? throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.DevException.InvalidTypeProp, nameof(ImpactEffect), nameof(LocalizedName)), nameof(localizedName));

    /// <summary>Gets the <see cref="ImpactEffect"/> matching the specified name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> does not match to any <see cref="ImpactEffect"/> name.</exception>
    public static ImpactEffect ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue.Name == name)
                ?? throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.DevException.InvalidTypeProp, nameof(ImpactEffect), nameof(Name)), nameof(name));

    public override bool Equals(object? obj) => Equals(obj as ImpactEffect);

    public bool Equals(ImpactEffect? other) => other is not null && Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(Name);

    public override string ToString() => Name;

    #endregion Public Methods
}
