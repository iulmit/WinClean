namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Wether a script is advised for general purpose</summary>
public class ScriptAdvised : IEquatable<ScriptAdvised?>
{
    #region Private Fields

    private readonly string _name;

    #endregion Private Fields

    #region Private Constructors

    private ScriptAdvised(string name, string localizedName, Color color)
    {
        Color = color;
        _name = name;
        LocalizedName = localizedName;
    }

    #endregion Private Constructors

    #region Public Properties

    /// <summary>
    /// The script is generally safe, but it may hinder features that are useful for a minority of users.
    /// </summary>
    public static ScriptAdvised Limited { get; } = new(nameof(Limited), Resources.ScriptAdvised.Limited, Color.Yellow);

    /// <summary>
    /// The script is only advised to a minority of users who want advanced optimization. It will almost certainly hinder useful system
    /// features. It should be selected by the user, only if specifically needed.
    /// </summary>
    public static ScriptAdvised No { get; } = new(nameof(No), Resources.ScriptAdvised.No, Color.Red);

    public static IEnumerable<ScriptAdvised> Values => new ScriptAdvised[] { Yes, Limited, No };

    /// <summary>
    /// The script is advised for any user. It has almost no side effects and won't hinder features the said user might want to
    /// use. It can be selected automatically.
    /// </summary>
    public static ScriptAdvised Yes { get; } = new(nameof(Yes), Resources.ScriptAdvised.Yes, Color.Green);

    public Color Color { get; }

    public string LocalizedName { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="ScriptAdvised"/> matching the specified localized name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="localizedName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="localizedName"/> does not match to any <see cref="ScriptAdvised"/> localized name.
    /// </exception>
    public static ScriptAdvised ParseLocalizedName(string localizedName)
        => localizedName is null
            ? throw new ArgumentNullException(nameof(localizedName))
            : Values.FirstOrDefault(validValue => validValue.LocalizedName == localizedName)
                ?? throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.DevException.InvalidTypeProp, nameof(ScriptAdvised), nameof(LocalizedName)), nameof(localizedName));

    /// <summary>Gets the <see cref="ScriptAdvised"/> matching the specified name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> does not match to any <see cref="ScriptAdvised"/> name.</exception>
    public static ScriptAdvised ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue._name == name)
                ?? throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.DevException.InvalidTypeProp, nameof(ScriptAdvised), nameof(_name)), nameof(name));

    public override bool Equals(object? obj) => Equals(obj as ScriptAdvised);

    public bool Equals(ScriptAdvised? other) => other is not null && _name == other._name;

    public override int GetHashCode() => HashCode.Combine(_name);

    public override string ToString() => _name;

    #endregion Public Methods
}
