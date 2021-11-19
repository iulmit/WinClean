// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Wether a script is advised for general purpose</summary>
// chaud : faire ça correctement avec les couleurs
public class ScriptAdvised : IEquatable<ScriptAdvised?>
{
    #region Private Constructors

    private ScriptAdvised(string name, Color color, string localizedName)
    {
        Color = color;
        Name = name;
        LocalizedName = localizedName;
    }

    #endregion Private Constructors

    #region Public Properties

    /// <summary>
    /// The script only advised for users who want advanced optimisation. It may hinder useful system features. It should be
    /// selected individually by the user.
    /// </summary>
    public static ScriptAdvised Limited => new(nameof(Limited), Color.Orange, Resources.ScriptAdvised.Limited);

    /// <summary>
    /// The script must be selected only by users who know what they are doing. It will almost certainly hinder useful system
    /// features. It should be selected by the user, only if specifically needed.
    /// </summary>
    public static ScriptAdvised No => new(nameof(No), Color.Red, Resources.ScriptAdvised.No);

    public static IEnumerable<ScriptAdvised> Values => new[] { Yes, Limited, No };

    /// <summary>
    /// The script is advised for any user. It has almost no side effects and won't hinder features the said user might want to
    /// use. It can be selected automatically.
    /// </summary>
    public static ScriptAdvised Yes { get; } = new(nameof(Yes), Color.Green, Resources.ScriptAdvised.Yes);

    public Color Color { get; }

    public string LocalizedName { get; }
    public string Name { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Gets the <see cref="ScriptAdvised"/> matching the specified localized name.</summary>
    /// <returns>A new <see cref="ScriptAdvised"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="localizedName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="localizedName"/> does not match to any <see cref="ScriptAdvised"/> localized name.
    /// </exception>
    public static ScriptAdvised ParseLocalizedName(string localizedName)
        => localizedName is null
            ? throw new ArgumentNullException(nameof(localizedName))
            : Values.FirstOrDefault(validValue => validValue.LocalizedName == localizedName)
                ?? throw new ArgumentException($"Not a valid {nameof(ScriptAdvised)} localized name.", nameof(localizedName));

    /// <summary>Gets the <see cref="ScriptAdvised"/> matching the specified name.</summary>
    /// <returns>A new <see cref="ScriptAdvised"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> does not match to any <see cref="ScriptAdvised"/> name.</exception>
    public static ScriptAdvised ParseName(string name)
        => name is null
            ? throw new ArgumentNullException(nameof(name))
            : Values.FirstOrDefault(validValue => validValue.Name == name)
                ?? throw new ArgumentException($"Not a valid {nameof(ScriptAdvised)} name.", nameof(name));

    public override bool Equals(object? obj) => Equals(obj as ScriptAdvised);

    public bool Equals(ScriptAdvised? other) => other is not null && Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(Name);

    public override string ToString() => Name;

    #endregion Public Methods
}
