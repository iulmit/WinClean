// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Globalization;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>Form to acess and modify application settings.</summary>
    public partial class Settings : Form
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="Settings"/> class.</summary>
        public Settings()
        {
            InitializeComponent();
            Controls.Add(new PropertyEditor(
                new PropertyInfo("Niveau de logs",
                                           "Niveau de journalisation global à l'application.",
                                           () => Properties.Settings.Default.LogLevel,
                                           (value) => Properties.Settings.Default.LogLevel = value.ToInt32(CultureInfo.CurrentCulture),
                                           (int)LogLevel.Verbose)
                ));
        }

        #endregion Public Constructors
    }
}
