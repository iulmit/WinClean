// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>
/// Form to acess and modify application settings.
/// </summary>
public partial class Settings : Form
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Settings"/> class.
    /// </summary>
    public Settings()
    {
        InitializeComponent();
        Logic.Impact impact = new(Logic.ImpactLevel.Positive, Logic.ImpactEffect.Visuals);
        impactEditor1.SelectedImpact = impact;
    }

    #endregion Public Constructors
}