using RaphaëlBardini.WinClean.Logic;

using System.Linq;
using System.Windows.Forms;

using WinCopies.Collections;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>Control used to display and edit a script.</summary>
public partial class ScriptEditor : UserControl
{
    #region Private Fields

    private IScript? _selected;

    #endregion Private Fields

    #region Public Constructors

    public ScriptEditor()
    {
        InitializeComponent();
        comboBoxAdvised.DataSource = ScriptAdvised.Values.Select((val) => val.LocalizedName).ToList();
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>The script the user is currently able to see and edit.</summary>
    public IScript? Selected
    {
        get => _selected;
        set
        {
            PrepareForAnother();

            _selected = value;

            Enabled = value is not null;

            textBoxName.Text = value?.Name;
            textBoxDescription.Text = value?.Description;
            comboBoxAdvised.SelectedItem = value?.Advised.LocalizedName;

            comboBoxGroup.DataSource = AppDir.GroupsFile.Instance.Groups;
            comboBoxGroup.SelectedItem = value?.Group;

            textBoxCode.Text = value?.Code;
            impactEditor.Selected = value?.Impact;
        }
    }

    #endregion Public Properties

    #region Private Methods

    #region Event Handlers

    private void ButtonDelete_Click(object _, EventArgs __)
    {
        if (_selected is not null && ErrorDialog.ConfirmScriptDeletion())
        {
            _selected.Delete();
        }
    }

    private void ButtonExecute_Click(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            ScriptExecutor executor = new(_selected);
            executor.ExecuteNoUI();
        }
    }

    private void ComboBoxAdvised_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            _selected.Advised = ScriptAdvised.ParseLocalizedName((string)comboBoxAdvised.SelectedItem);
        }
    }

    private void ComboBoxGroup_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            _selected.Group = (ListViewGroup)comboBoxGroup.SelectedItem;
        }
    }

    private void ScriptEditor_Leave(object _, EventArgs __) => PrepareForAnother();

    private void ScriptEditor_Resize(object _, EventArgs __)
    {
        SuspendLayout();

        // TextBoxes
        ChangeWidth(textBoxName, Width);
        ChangeWidth(textBoxDescription, Width);
        ChangeWidth(textBoxCode, Width);

        // ComboBoxes
        const int ComboBoxSpacing = 11;
        int cBoxWidth = (int)(Width / 2D - ComboBoxSpacing / 2D);
        ChangeWidth(comboBoxGroup, cBoxWidth);
        ChangeWidth(comboBoxAdvised, cBoxWidth);
        comboBoxAdvised.Location = new(Width - cBoxWidth, comboBoxAdvised.Location.Y);

        // Buttons
        const int ButtonSpacing = 7;
        buttonExecute.Location = new((int)(Width / 2D - ButtonSpacing / 2D - buttonExecute.Width), buttonExecute.Location.Y);
        buttonDelete.Location = new((int)(Width / 2D + ButtonSpacing / 2D), buttonDelete.Location.Y);

        // Impact Editor
        impactEditor.Width = Width;

        ResumeLayout();
    }

    private void TextBoxCode_TextChanged(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            _selected.Code = textBoxCode.Text;
        }
    }

    private void TextBoxDescription_TextChanged(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            _selected.Description = textBoxDescription.Text;
        }
    }

    private void TextBoxName_TextChanged(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            _selected.Name = textBoxName.Text;
        }
    }

    #endregion Event Handlers

    private static void ChangeWidth(Control c, int newWitdth)
        => c.Width = newWitdth > c.MinimumSize.Width ? newWitdth : c.MinimumSize.Width;

    private void PrepareForAnother() => _selected?.Save();

    #endregion Private Methods
}
