using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>A script that can be executed from a script host program.</summary>
public class Script : IScript
{
    #region Public Constructors

    /// <summary>Initializes a new instance of the <see cref="Script"/> class with the specified data.</summary>
    /// <exception cref="ArgumentNullException">One or more parameters are <see langword="null"/>.</exception>
    public Script(string name, string description, ScriptAdvised advised, Impact impact, string group, string extension, string code)
    {
        Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
        Description = description?.Trim() ?? throw new ArgumentNullException(nameof(description));
        Advised = advised;
        Impact = impact ?? throw new ArgumentNullException(nameof(impact));
        Group = group;
        Extension = extension;
        Code = code;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">The property was set to <see langword="null"/>.</exception>
    public ScriptAdvised Advised { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

    public string Extension { get; }

    public Impact Impact { get; set; }

    public string Name { get; set; }

    public string Group { get; set; }

    #endregion Public Properties

    #region Public Methods

    public void Execute(TimeSpan timeout) => ScriptHostFactory.FromFileExtension(Extension).Execute(this, timeout);

    #endregion Public Methods
}
