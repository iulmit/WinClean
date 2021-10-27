// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Flobbster.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>Form to acess and modify application settings.</summary>
    public partial class Settings : Form
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="Settings"/> class.</summary>
        public Settings()
        {
            PropertyBag bag = new();
            bag.GetValue += Bag_GetValue;
            bag.SetValue += Bag_SetValue;
            bag.GridProperties.Add(new GridProperty("Niveau de logs", typeof(LogLevel), "Général", "Niveau de journalisation global à l'application.", LogLevel.Verbose));
            bag.GridProperties.Add(new GridProperty("Temps d'exécution max.", typeof(TimeSpan), "Scripts", "Temps maximal d'exécution d'un script avant l'affichage d'un avertissement.", TimeSpan.FromMinutes(30)));
            InitializeComponent();
            propertyGrid.SelectedObject = bag;
        }

        private void Bag_GetValue(object sender, GridPropertyEventArgs e) => e.Value = e.Property.Name switch
        {
            "Niveau de logs" => Properties.Settings.Default.LogLevel,
            "Temps d'exécution max." => Properties.Settings.Default.ScriptTimeout,
            _ => throw new NotSupportedException("The property was not found in the property bag.")
        };

        private void Bag_SetValue(object sender, GridPropertyEventArgs e)
        {
            switch (e.Property.Name)
            {
                case nameof(Properties.Settings.Default.LogLevel): Properties.Settings.Default.LogLevel = (int)e.Value; break;
                case nameof(Properties.Settings.Default.ScriptTimeout): Properties.Settings.Default.ScriptTimeout = (TimeSpan)e.Value; break;
                default: throw new NotSupportedException("The property was not found in the property bag.");
            }
        }

        #endregion Public Constructors
    }
}
