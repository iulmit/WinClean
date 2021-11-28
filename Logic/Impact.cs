namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Effect of running a script.</summary>
public class Impact : IEquatable<Impact?>
{
    #region Private Fields

    private readonly string _name;

    #endregion Private Fields

    #region Private Constructors

    private Impact(string name, string? localizedName)
    {
        LocalizedName = localizedName;
        _name = name;
    }

    #endregion Private Constructors

    #region Public Properties

    /// <summary>System praticality.</summary>
    public static Impact Ergonomics { get; } = new(nameof(Ergonomics), Resources.ImpactEffect.Ergonomics);

    /// <summary>Free storage space.</summary>
    public static Impact FreeStorageSpace { get; } = new(nameof(FreeStorageSpace), Resources.ImpactEffect.FreeStorageSpace);

    /// <summary>Idle system memory usage.</summary>
    public static Impact MemoryUsage { get; } = new(nameof(MemoryUsage), Resources.ImpactEffect.MemoryUsage);

    /// <summary>Idle system network usage.</summary>
    public static Impact NetworkUsage { get; } = new(nameof(NetworkUsage), Resources.ImpactEffect.NetworkUsage);

    /// <summary>System privacy invasion and spying.</summary>
    public static Impact Privacy { get; } = new(nameof(Privacy), Resources.ImpactEffect.Privacy);

    /// <summary>System rapidity of executing commands.</summary>
    public static Impact ResponseTime { get; } = new(nameof(ResponseTime), Resources.ImpactEffect.ResponseTime);

    /// <summary>System shutdown time.</summary>
    public static Impact ShutdownTime { get; } = new(nameof(ShutdownTime), Resources.ImpactEffect.ShutdownTime);

    /// <summary>System startup time.</summary>
    public static Impact StartupTime { get; } = new(nameof(StartupTime), Resources.ImpactEffect.StartupTime);

    /// <summary>Storage read-write speed.</summary>
    public static Impact StorageSpeed { get; } = new(nameof(StorageSpeed), Resources.ImpactEffect.StorageSpeed);

    /// <summary>Gets all the values.</summary>
    public static IEnumerable<Impact> Values => new[]
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
    public static Impact Visuals { get; } = new(nameof(Visuals), Resources.ImpactEffect.Visuals);

    public string? LocalizedName { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="Impact"/> matching the specified localized name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="localizedName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="localizedName"/> does not match to any <see cref="Impact"/> localizedName.
    /// </exception>
    public static Impact ParseLocalizedName(string localizedName)
        => localizedName is null
            ? throw new ArgumentNullException(nameof(localizedName))
            : Values.FirstOrDefault(validValue => validValue.LocalizedName == localizedName)
                ?? throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.DevException.InvalidTypeProp, nameof(Impact), nameof(LocalizedName)), nameof(localizedName));

    /// <summary>Gets the <see cref="Impact"/> matching the specified name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> does not match to any <see cref="Impact"/> name.</exception>
    public static Impact ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue._name == name)
                ?? throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.DevException.InvalidTypeProp, nameof(Impact), nameof(_name)), nameof(name));

    public override bool Equals(object? obj) => Equals(obj as Impact);

    public bool Equals(Impact? other) => other is not null && _name == other._name;

    public override int GetHashCode() => HashCode.Combine(_name);

    public override string ToString() => _name;

    #endregion Public Methods
}
