using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>Represents an executable script associated to a script host program.</summary>
public interface IScript
{
    #region Public Properties

    /// <summary>Wether running this script would be advised in general purpose.</summary>
    ScriptAdvised Advised { get; set; }

    /// <summary>The actual code making the script.</summary>
    string Code { get; set; }

    /// <summary>Details on how this scripts work and what the effects of executing it would be.</summary>
    string Description { get; set; }

    /// <summary>The file extension representing the script's type.</summary>
    string Extension { get; }

    /// <summary>The name of the script group this script is part of.</summary>
    string Group { get; set; }

    /// <summary>System impact of running this script.</summary>
    Impact Impact { get; set; }

    /// <summary>URL that leads to a webpage that gives more information on this script's behavior.</summary>
    Uri? MoreInfoUrl { get; set; }

    /// <summary>A brief infinitive sentence that describes the functionnality of this script.</summary>
    string Name { get; set; }

    /// <summary>The name of the file this script could be saved to / could have been loaded from. Does not include the extension.</summary>
    string FileName { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Executes the script.</summary>
    /// <inheritdoc cref="ScriptHost.ExecuteCode(string, string, TimeSpan, Func{string, bool}, Func{Exception, FileSystemInfo, FSVerb, bool}, int)" path="/param"/>
    /// <inheritdoc cref="ScriptHost.ExecuteCode(string, string, TimeSpan, Func{string, bool}, Func{Exception, FileSystemInfo, FSVerb, bool}, int)" path="/exception"/>
    public void Execute(TimeSpan timeout, Func<string, bool> promptKillOnHung, Func<Exception, FileSystemInfo, FSVerb, bool> promptRetryOnFSError, int promptLimit)
        => ScriptHostFactory.FromFileExtension(Extension).ExecuteCode(Code, Name, timeout, promptKillOnHung, promptRetryOnFSError, promptLimit);

    #endregion Public Methods
}
