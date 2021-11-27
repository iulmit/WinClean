
namespace RaphaëlBardini.WinClean.Logic;

/// <summary>A system-wide impact.</summary>
public class Impact : IEquatable<Impact?>
{
    #region Public Constructors

    public Impact()
    {
        Effect = ImpactEffect.Ergonomics;
        Level = ImpactLevel.Mixed;
    }

    public Impact(ImpactLevel lvl, ImpactEffect effect)
    {
        Effect = effect;
        Level = lvl;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>The actual effect on the system.</summary>
    public ImpactEffect Effect { get; set; }

    /// <summary>The level of the effect.</summary>
    public ImpactLevel Level { get; set; }

    #endregion Public Properties

    #region Public Methods

    public override bool Equals(object? obj) => Equals(obj as Impact);

    public bool Equals(Impact? other) => other is not null && Effect.Equals(other.Effect) && Level == other.Level;

    public override int GetHashCode() => HashCode.Combine(Effect, Level);

    public override string ToString() => $"{Level} {Effect}";

    #endregion Public Methods
}
