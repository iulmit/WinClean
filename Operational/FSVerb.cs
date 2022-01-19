namespace RaphaëlBardini.WinClean.Operational;

public class FSVerb : IEquatable<FSVerb?>
{
    #region Private Constructors

    private FSVerb(string name, string localizedVerb)
    {
        Name = name;
        LocalizedVerb = localizedVerb;
    }

    #endregion Private Constructors

    #region Public Properties

    /// <summary>Access of a file system element.</summary>
    public static FSVerb Acess { get; } = new(nameof(Acess), Resources.FileSystemVerbs.Acess);

    /// <summary>Creation of a file system element.</summary>
    public static FSVerb Create { get; } = new(nameof(Create), Resources.FileSystemVerbs.Create);

    /// <summary>Deletion of a file system element.</summary>
    public static FSVerb Delete { get; } = new(nameof(Delete), Resources.FileSystemVerbs.Delete);

    /// <summary>Move of a file system element.</summary>
    public static FSVerb Move { get; } = new(nameof(Move), Resources.FileSystemVerbs.Move);

    public static IEnumerable<FSVerb> Values => new[] { Create, Delete, Move, Acess };
    public string LocalizedVerb { get; }
    public string Name { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="FSVerb"/> matching the specified name.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> does not match to any <see cref="FSVerb"/> name.</exception>
    public static FSVerb ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue.Name == name)
                ?? throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.DevException.InvalidTypeProp, nameof(FSVerb), nameof(Name)), nameof(name));

    public override bool Equals(object? obj) => Equals(obj as FSVerb);

    public bool Equals(FSVerb? other) => other is not null && Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(Name, LocalizedVerb);

    public override string ToString() => Name;

    #endregion Public Methods
}
