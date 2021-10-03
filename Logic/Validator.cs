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
        /// <param name="errors">The possible errors.</param>
        /// <exception cref="ArgumentNullException"><paramref name="errors"/> is <see langword="null"/>.</exception>
        public Validator(IReadOnlyDictionary<UserFriendlyError, bool> errors) => Errors = errors ?? throw new ArgumentNullException(nameof(errors));

        public Validator(UserFriendlyError errorDisplay, bool assert)
            : this(new Dictionary<UserFriendlyError, bool>(new KeyValuePair<UserFriendlyError, bool>[1] { new KeyValuePair<UserFriendlyError, bool>(errorDisplay, assert) }))
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Asserts every error. If the assert statemenet is <see langword="false"/>, it's an active error.</summary>
        public IEnumerable<UserFriendlyError> ActiveErrors => Errors.Where((e) => !e.Value).Select((e) => e.Key);

        /// <summary>Every error, even those that are not active.</summary>
        public IReadOnlyDictionary<UserFriendlyError, bool> Errors { get; }

        #endregion Public Properties

        #region Public Methods

        public override bool Equals(object obj) => obj is Validator validator && Errors.Equals(validator.Errors);

        public override int GetHashCode() => HashCode.Combine(Errors);

        #endregion Public Methods
    }
}
