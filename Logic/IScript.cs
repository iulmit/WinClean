using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>
/// Represents an executable script associated to a script host program.
/// </summary>
public interface IScript
{
    #region Public Properties

    /// <summary>
    /// Wether running this script would be advised in general purpose.
    /// </summary>
    ScriptAdvised Advised { get; set; }

    /// <summary>
    /// The actual code making the script.
    /// </summary>
    string Code { get; set; }

    /// <summary>
    /// Details on how this scripts work and what the effects of executing it would be.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// The file extension representing the script's type.
    /// </summary>
    string Extension { get; }

    /// <summary>
    /// The name of the script group this script is part of.
    /// </summary>
    string Group { get; set; }

    /// <summary>
    /// System impact of running this script.
    /// </summary>
    Impact Impact { get; set; }

    /// <summary>
    /// A brief infinitive sentence that describes the functionnality of this script.
    /// </summary>
    string Name { get; set; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Executes the script.</summary>
    /// <param name="timeout">How long to wait for the script to end before throwing an <see cref="HungScriptException"/>.</param>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="IOException">The disk is read-only. -or- An I/O error occured.</exception>
    /// <exception cref="HungScriptException">The script is still running after <paramref name="timeout"/> has elapsed and is probably hung.</exception>
    public void Execute(TimeSpan timeout) => ScriptHostFactory.FromFileExtension(Extension).Execute(this, timeout);

    #endregion Public Methods
}