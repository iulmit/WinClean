// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.ErrorHandling;

public class FSOperation : IEquatable<FSOperation?>
{
    #region Private Constructors

    private FSOperation(string name, string localizedVerb)
    {
        Name = name;
        LocalizedVerb = localizedVerb;
    }

    #endregion Private Constructors

    #region Public Properties

    /// <summary>Access of a file system element.</summary>
    public static FSOperation Acess => new(nameof(Acess), Resources.FileSystemVerbs.Acess);

    /// <summary>Creation of a file system element.</summary>
    public static FSOperation Create => new(nameof(Create), Resources.FileSystemVerbs.Create);

    /// <summary>Deletion of a file system element.</summary>
    public static FSOperation Delete => new(nameof(Delete), Resources.FileSystemVerbs.Delete);

    /// <summary>Move of a file system element.</summary>
    public static FSOperation Move => new(nameof(Move), Resources.FileSystemVerbs.Move);

    public static IEnumerable<FSOperation> Values => new[] { Create, Delete, Move, Acess };
    public string LocalizedVerb { get; }
    public string Name { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="FSOperation"/> matching the specified name.</summary>
    /// <returns>A new <see cref="FSOperation"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> does not match to any <see cref="FSOperation"/> name.</exception>
    public static FSOperation ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue.Name == name)
                ?? throw new ArgumentException($"Not a valid {nameof(FSOperation)} name.", nameof(name));

    public override bool Equals(object? obj) => Equals(obj as FSOperation);

    public bool Equals(FSOperation? other) => other is not null && Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(Name, LocalizedVerb);

    public override string ToString() => Name;

    #endregion Public Methods
}
