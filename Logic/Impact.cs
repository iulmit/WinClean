// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>
/// A system-wide impact.
/// </summary>
public class Impact : IEquatable<Impact?>
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Impact"/> class.
    /// </summary>
    public Impact()
    {
        Effect = ImpactEffect.Ergonomics;
        Level = ImpactLevel.Mixed;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Impact"/> class.
    /// </summary>
    public Impact(ImpactLevel lvl, ImpactEffect effect)
    {
        Effect = effect;
        Level = lvl;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// The actual effect on the system.
    /// </summary>
    public ImpactEffect Effect { get; set; }

    /// <summary>
    /// The level of the effect.
    /// </summary>
    public ImpactLevel Level { get; set; }

    #endregion Public Properties

    #region Public Methods

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as Impact);

    /// <inheritdoc/>
    public bool Equals(Impact? other) => other is not null && Effect.Equals(other.Effect) && Level == other.Level;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Effect, Level);

    /// <inheritdoc/>
    public override string ToString() => $"{Level} {Effect}";

    #endregion Public Methods
}