// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>
    /// Manages a set of errors reperesented by boolean expressions.
    /// </summary>
    public class Validator
    {
        #region Public Constructors
        /// <summary>Creates a new instance of the <see cref="Validator"/> class wtih the specified errors.</summary>
        /// <param name="errors">The possible errors.</param>
        /// <exception cref="ArgumentNullException"><paramref name="errors"/> is <see langword="null"/>.</exception>
        public Validator(IEnumerable<(string text, bool condition)> errors) => PossibleErrors = errors ?? throw new ArgumentNullException(nameof(errors));

        public Validator(string text, bool condition) : this(new (string, bool)[1] { (text, condition) })
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public IEnumerable<(string text, bool condition)> PossibleErrors { get; }

        /// <summary>Errors that have their condition <see langword="true"/>.</summary>
        public IEnumerable<(string text, bool condition)> ActiveErrors => PossibleErrors.Where((e) => e.condition);
        #endregion Public Properties

        #region Public Methods

        public override bool Equals(object obj) => obj is Validator validator && PossibleErrors.Equals(validator.PossibleErrors);

        public override int GetHashCode() => HashCode.Combine(PossibleErrors);

        #endregion Public Methods
    }
}
