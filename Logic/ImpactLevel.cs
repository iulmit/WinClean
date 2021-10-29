// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents the level of an <see cref="ImpactEffect"/>.</summary>
    public enum ImpactLevel
    {
        /// <summary>Improvement.</summary>
        Positive,

        /// <summary>Worsening.</summary>
        Negative,

        /// <summary>Variable, uncertain.</summary>
        Mixed,
    }
}
