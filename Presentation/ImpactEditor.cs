using RaphaëlBardini.WinClean.Logic;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class ImpactEditor : UserControl
    {
        #region Private Fields

        private Impact? _selectedImpact;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImpactEditor"/> class.
        /// </summary>
        public ImpactEditor(Impact? selected = null)
        {
            InitializeComponent();

            IList<ImpactEffect> impactEffectValues = ImpactEffect.Values.ToList();
            comboBoxEffect.MaxDropDownItems = impactEffectValues.Count;
            comboBoxEffect.DataSource = impactEffectValues;

            ImpactLevel[] levels = Enum.GetValues<ImpactLevel>();
            for (int i = 0; i < levels.Length; ++i)
            {
                imagedComboBoxLevel.ImageList.Images.Add(levels[i].ToString(), GetImage(levels[i].ToString()));
                _ = imagedComboBoxLevel.Items.Add(new ImagedComboBoxItem() { ImageIndex = i, Tag = levels[i] });
            }
            SelectedImpact = selected;
        }

        #endregion Public Constructors

        #region Public Properties

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

                if (value is not null)
                {
                    comboBoxEffect.SelectedItem = value.Effect;
                    imagedComboBoxLevel.SelectedItem = imagedComboBoxLevel.Items.OfType<ImagedComboBoxItem>().First((item) => item.Tag.Equals(value.Level));
                }
            }
        }

        #endregion Public Properties

        #region Private Methods

        private static Image GetImage(string levelName)
            => (Image)Resources.Images.ResourceManager.GetObject(levelName, CultureInfo.CurrentUICulture).FailIfNull();

        private void ComboBoxEffect_SelectedIndexChanged(object _, EventArgs __)
        {
            if (_selectedImpact is not null && comboBoxEffect.SelectedItem is not null)
            {
                _selectedImpact.Effect = (ImpactEffect)comboBoxEffect.SelectedItem;
            }
        }

        private void ComboBoxLevel_SelectedIndexChanged(object _, EventArgs __)
        {
            if (_selectedImpact is not null && imagedComboBoxLevel.SelectedItem.HasValue)
            {
                _selectedImpact.Level = (ImpactLevel)imagedComboBoxLevel.SelectedItem.Value.Tag;
            }
        }

        #endregion Private Methods
    }
}