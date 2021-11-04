using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Linq;

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class ImpactEditor : UserControl
    {
        private Impact? _selectedImpact;

        /// <summary>
        /// Gets or sets the selected impact that the user is able to see and edit
        /// </summary>
        public Impact? SelectedImpact
        {
            get => _selectedImpact;
            set
            {
                Enabled = value is not null;
                _selectedImpact = value;
                comboBoxEffect.SelectedItem = value?.Effect;
                comboBoxLevel.SelectedItem = value?.Level;

                pictureBoxLevelIcon.Image = (value is null) ? null : Resources.Images.ResourceManager.GetObject(value.Level.ToString(), CultureInfo.CurrentUICulture) as Image;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImpactEditor"/> class.
        /// </summary>
        public ImpactEditor()
        {
            InitializeComponent();
            comboBoxEffect.DataSource = ImpactEffect.Values.ToList();
            comboBoxLevel.DataSource = Enum.GetValues<ImpactLevel>();
        }

        private void ComboBoxLevel_SelectedIndexChanged(object _, EventArgs __)
        {
            if (_selectedImpact is not null)
            {
                _selectedImpact.Level = (ImpactLevel)comboBoxLevel.SelectedItem;
                pictureBoxLevelIcon.Image = Resources.Images.ResourceManager.GetObject(((ImpactLevel)comboBoxLevel.SelectedItem).ToString(), CultureInfo.CurrentUICulture) as Image;
            }
        }

        private void ComboBoxEffect_SelectedIndexChanged(object _, EventArgs __)
        {
            if (_selectedImpact is not null)
            {
                _selectedImpact.Effect = (ImpactEffect)comboBoxEffect.SelectedItem;
            }
        }
    }
}
