// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A preset as seen in the <see cref="Logic"/> layer.</summary>
    public abstract class Preset : IEquatable<Preset>
    {
        /// <summary>Generates a new instance of the <see cref="Preset"/> class with a name, a description, and a script collection.</summary>
        /// <exception cref="ArgumentNullException">Any of the parameters are <see langword="null"/>.</exception>
        public Preset(string name, string description, IEnumerable<Script> scripts) : base()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Scripts = scripts ?? throw new ArgumentNullException(nameof(scripts));
        }

        #region Public Properties

        public string Description { get; set; }
        public string Name { get; set; }
        public IEnumerable<Script> Scripts { get; }
        public bool Equals(Preset other) => other != null && Name.Equals(other.Name) && Description.Equals(other.Description) && Scripts.SequenceEqual(other.Scripts);

        #endregion Public Properties
    }
}
