// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

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

    /// <summary>The group the script is assigned to.</summary>
    ListViewGroup Group { get; set; }

    /// <summary>System impact of running this script.</summary>
    Impact Impact { get; }

    /// <summary>A brief infinitive sentence that describes the functionnality of this script.</summary>
    string Name { get; set; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Deletes a script from the scripts dir.</summary>
    void Delete();

    /// <summary>Executes the script in a new process.</summary>
    /// <inheritdoc cref="Operational.ScriptHost.Execute(IScript)" path="/exception"/>
    void Execute();

    /// <summary>Saves this script to the disk.</summary>
    void Save();

    #endregion Public Methods
}
