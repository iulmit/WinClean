﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents an executable script associated to a script host program.</summary>
    public interface IScript
    {
        #region Public Properties

        /// <summary>If running this script is advised in general purpose.</summary>
        ScriptAdvised Advised { get; set; }

        /// <summary>The actual code making the script.</summary>
        string Code { get; }

        /// <summary>Details on how this scripts work and what the effects of executing it would be.</summary>
        string Description { get; set; }

        /// <summary>System impacts of running this script.</summary>
        ICollection<Impact> Impacts { get; }

        /// <summary>A brief infinitive sentence that describes the functionnality of this script.</summary>
        string Name { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Deletes a script from the scripts dir.</summary>
        void Delete();

        /// <summary>Executes the script in a new process.</summary>
        /// <inheritdoc cref="Operational.IScriptHost.Execute(IScript)" path="/exception"/>
        void Execute();

        /// <summary>Saves this script to the scripts dir.</summary>
        void Save();

        #endregion Public Methods
    }
}
