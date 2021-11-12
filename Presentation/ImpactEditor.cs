using RaphaëlBardini.WinClean.Logic;

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation;

public partial class ImpactEditor : UserControl
{
    #region Private Fields

    private readonly List<ImagedComboBoxItem> levelItems = new();
    private Impact? _selected;

    #endregion Private Fields

    #region Public Constructors

    public ImpactEditor()
    {
        InitializeComponent();
        foreach (ImpactLevel level in ImpactLevel.Values)
        {
            ImagedComboBoxItem @new = new(level.Image, level);
            levelItems.Add(@new);
            _ = imagedComboBoxLevel.Items.Add(@new);
        }
        comboBoxEffect.DataSource = ImpactEffect.Values.Select((val) => val.LocalizedName).ToList();
    }

    #endregion Public Constructors

    #region Public Properties

    public Impact? Selected
    {
        get => _selected;
        set
        {
            _selected = value;

            Enabled = value is not null;
            imagedComboBoxLevel.SelectedItem = (value is null) ? null : levelItems.Find((icbitem) => Equals(icbitem.Tag, value.Level));
            comboBoxEffect.SelectedItem = value?.Effect;
        }
    }

    #endregion Public Properties

    #region Private Methods

    private void ComboBoxEffect_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selected is not null && comboBoxEffect.SelectedItem is not null)
        {
            _selected.Effect = ImpactEffect.ParseLocalizedName((string)comboBoxEffect.SelectedItem);
        }
    }

    private void ImagedComboBoxLevel_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selected is not null && imagedComboBoxLevel.SelectedItem is not null)
        {
            _selected.Level = (ImpactLevel)((ImagedComboBoxItem)imagedComboBoxLevel.SelectedItem).Tag.FailNull();
        }
    }

    private void ImpactEditor_Resize(object sender, EventArgs e)
        => comboBoxEffect.Width = Width - imagedComboBoxLevel.Width - imagedComboBoxLevel.Margin.Horizontal;

    #endregion Private Methods
}
