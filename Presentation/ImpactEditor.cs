using RaphaëlBardini.WinClean.Logic;

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation;

public partial class ImpactEditor : UserControl
{
    private Impact? _selected;
    private readonly List<ImagedComboBoxItem> levelItems = new();
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

    public Impact? Selected
    {
        get => _selected;
        set
        {
            _selected = value;

            Enabled = value is not null;
            if (value is not null)
            {
                imagedComboBoxLevel.SelectedItem = levelItems.Find((icbitem) => Equals(icbitem.Tag, value.Level));
                comboBoxEffect.SelectedItem = value.Effect;
            }
        }
    }

    private void ImagedComboBoxLevel_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selected is not null && imagedComboBoxLevel.SelectedItem is not null)
        {
            _selected.Level = (ImpactLevel)((ImagedComboBoxItem)imagedComboBoxLevel.SelectedItem).Tag.FailIfNull();
        }
    }

    private void ComboBoxEffect_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selected is not null && comboBoxEffect.SelectedItem is not null)
        {
            _selected.Effect = ImpactEffect.ParseLocalizedName((string)comboBoxEffect.SelectedItem);
        }
    }

    private void ImpactEditor_Resize(object sender, EventArgs e)
        => comboBoxEffect.Width = Width - imagedComboBoxLevel.Width - imagedComboBoxLevel.Margin.Horizontal;
}
