﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace RaphaëlBardini.WinClean.Logic;

/// <summary>A system-wide impact.</summary>
public class Impact
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Impact"/> class.
    /// </summary>
    /// <exception cref="InvalidEnumArgumentException"><paramref name="lvl"/> is not a defined <see cref="ImpactLevel"/> constant.</exception>
    public Impact(ImpactLevel lvl, ImpactEffect effect)
    {
        Effect = effect;
        Level = Enum.IsDefined<ImpactLevel>(lvl) ? lvl : throw new InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ImpactLevel));
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>The actual effect on the system.</summary>
    public ImpactEffect Effect { get; }

    /// <summary>The level of the effect.</summary>
    public ImpactLevel Level { get; }

    #endregion Public Properties
}
