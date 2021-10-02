// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Manages a set of assertions reperesented by boolean expressions coupled with text that describes the error.</summary>
    public class Validator
    {
        #region Public Constructors

        /// <summary>Creates a new instance of the <see cref="Validator"/> class wtih the specified errors.</summary>
        /// <param name="asserts">The possible errors.</param>
        /// <exception cref="ArgumentNullException"><paramref name="asserts"/> is <see langword="null"/>.</exception>
        public Validator(IEnumerable<(bool assert, string text)> asserts) => Assertions = asserts ?? throw new ArgumentNullException(nameof(asserts));

        public Validator(bool assert, string text) : this(new (bool, string)[1] { (assert, text) })
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Asserts every error. If the assert statemenet is <see langword="false"/>, it's an active error.</summary>
        public IEnumerable<string> FalseAssertions => Assertions.Where((e) => !e.assert).Select((e) => e.text);

        /// <summary>Every error, even those that are not active.</summary>
        public IEnumerable<(bool assert, string text)> Assertions { get; }

        #endregion Public Properties

        #region Public Methods

        public override bool Equals(object obj) => obj is Validator validator && Assertions.Equals(validator.Assertions);

        public override int GetHashCode() => HashCode.Combine(Assertions);

        #endregion Public Methods
    }
}
