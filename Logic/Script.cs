// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents an executable script.</summary>
    public abstract class Script : Operational.Script
    {
        #region Public Constructors

        /// <param name="impacts">The potential impacts of executing a scripts on the system.</param>
        /// <param name="filenameOrPath">The name or path of the script file located in the <see cref="Constants.ScriptsDirPath"/> folder, with the extension.</param>
        /// <exception cref="ArgumentNullException">Any of the parameters are <see langword="null"/>.</exception>
        /// <exception cref="BadFileExtensionException"><paramref name="relativePath"/>'s extension is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="relativePath"/> contains unsupported path chars.</exception>
        protected Script(string name, string description, string filenameOrPath, IEnumerable<Impact> impacts) : base(filenameOrPath)
        {
            Impacts = impacts ?? throw new ArgumentNullException(nameof(impacts));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        #endregion Public Constructors

        #region Public Properties

        public string Description { get; set; }

        /// <summary>Impacts on system performance and practicality.</summary>
        public IEnumerable<Impact> Impacts { get; }

        public string Name { get; set; }

        #endregion Public Properties

        /// <summary>The supported file extensions by the script type;</summary>
        public abstract IReadOnlyCollection<string> Extensions { get; }

        /// <summary>The user friendly name of the corresponding script host.</summary>
        public abstract string HostDisplayName { get; }

        public override bool Equals(object obj) => Equals(obj as Script);

        public bool Equals(Script other) => other != null
                                            && Description.Equals(other.Description, StringComparison.Ordinal)
                                            && Name.Equals(other.Name, StringComparison.Ordinal)
                                            && HostDisplayName.Equals(other.HostDisplayName, StringComparison.Ordinal)
                                            && Extensions.SequenceEqual(other.Extensions)
                                            && Impacts.SequenceEqual(other.Impacts)
                                            && FullPath.Equals(other.FullPath, StringComparison.Ordinal);// Explicitly call the IEquatable<Script> version.

        public override int GetHashCode() => HashCode.Combine(Description, Impacts, Name, Extensions, HostDisplayName, base.GetHashCode());

        public override string ToString() => $"[{nameof(Name)} = {Name}, {nameof(Description)} = {Description}, {nameof(HostDisplayName)} = {HostDisplayName}, {nameof(Extensions)} = {Extensions.ToMultiLineString()}, {nameof(Impacts)} = {Impacts.ToMultiLineString()}, base.ToString() = {base.ToString()}]";
    }
}
