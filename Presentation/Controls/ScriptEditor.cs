using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Presentation.ScriptExecution;

using WinCopies.Collections;

namespace RaphaëlBardini.WinClean.Presentation.Controls;

/// <summary>Control used to display and edit a script.</summary>
public partial class ScriptEditor : UserControl
{
    #region Private Fields

    private ScriptListViewItem? _selected;
    #endregion Private Fields

    #region Public Constructors

    public ScriptEditor()
    {
        InitializeComponent();
        comboBoxAdvised.DataSource = ScriptAdvised.Values.Select((val) => val.LocalizedName).ToList();
        comboBoxImpact.DataSource = Impact.Values.Select(val => val.LocalizedName).ToList();
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>The script the user is currently able to see and edit.</summary>
    public ScriptListViewItem? Selected
    {
        get => _selected;
        set
        {
            PrepareForAnother();

            _selected = value;

            Enabled = value is not null;

            textBoxName.Text = value?.Name;
            textBoxDescription.Text = value?.Description;

            linkLabelMoreInfo.Enabled = value?.MoreInfoUrl is not null;
            toolTip.SetToolTip(linkLabelMoreInfo, value?.MoreInfoUrl?.AbsoluteUri);

            comboBoxAdvised.SelectedItem = value?.Advised.LocalizedName;

            textBoxGroup.AutoCompleteCustomSource.AddRange(ScriptsDir.Instance.Groups.Select(group => group.Info.Name).ToArray());
            textBoxGroup.Text = value?.Group;

            textBoxCode.Text = value?.Code;
            // If the user changes the setting, the propery will change after a script change.
            textBoxCode.ReadOnly = !Program.Settings.AllowScriptCodeEdit;

            comboBoxImpact.SelectedItem = value?.Impact.LocalizedName;
        }
    }

    #endregion Public Properties

    #region Private Methods

    #region Event Handlers

    private void ButtonDelete_Click(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            _selected.Delete();
        }
    }

    private void ButtonExecute_Click(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            ScriptExecutionWizard executor = new(_selected);
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

    private void ComboBoxImpact_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selected is not null)
        {
            _selected.Impact = Impact.ParseLocalizedName((string)comboBoxImpact.SelectedItem);
        }
    }
    private void LinkLabelMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (_selected?.MoreInfoUrl is not null)
        {
            linkLabelMoreInfo.LinkVisited = true;
            _ = Windows.System.Launcher.LaunchUriAsync(_selected.MoreInfoUrl);
        }
    }

    private void ScriptEditor_Leave(object _, EventArgs __) => PrepareForAnother();

    private void ScriptEditor_Resize(object _, EventArgs __)
    {
        SuspendLayout();

        // Fullwidth controls
        ChangeWidth(textBoxName, Width);
        ChangeWidth(textBoxDescription, Width);
        ChangeWidth(linkLabelMoreInfo, Width);
        ChangeWidth(textBoxCode, Width);
        ChangeWidth(comboBoxImpact, Width);

        // Advised and group
        const int ComboBoxSpacing = 11;
        int cBoxWidth = (int)(Width / 2D - ComboBoxSpacing / 2D);
        ChangeWidth(textBoxGroup, cBoxWidth);
        ChangeWidth(comboBoxAdvised, cBoxWidth);
        comboBoxAdvised.Location = new(Width - cBoxWidth, comboBoxAdvised.Location.Y);

        // Buttons
        const int ButtonSpacing = 7;
        buttonExecute.Location = new(Convert.ToInt32(Width / 2D - ButtonSpacing / 2D - buttonExecute.Width), buttonExecute.Location.Y);
        buttonDelete.Location = new(Convert.ToInt32(Width / 2D + ButtonSpacing / 2D), buttonDelete.Location.Y);

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

    private void TextBoxGroup_TextChanged(object _, EventArgs __)
    {
        if (_selected is not null && textBoxGroup.Text.IsValidFilename() && !textBoxGroup.Text.Contains('.', StringComparison.Ordinal))
        {
            _selected.Group = textBoxGroup.Text.Trim();
        }
    }

    private void TextBoxName_TextChanged(object _, EventArgs __)
    {
        if (_selected is not null && _selected.Name != textBoxName.Text)
        {
            _selected.Name = textBoxName.Text;
        }
    }

    #endregion Event Handlers

    private static void ChangeWidth(Control c, int newWitdth)
        => c.Width = newWitdth > c.MinimumSize.Width ? newWitdth : c.MinimumSize.Width;

    private void PrepareForAnother()
    {
        if (_selected is not null)
        {
            new ScriptXmlSerializer(ScriptsDir.Instance.Info).Serialize(_selected);
        }
    }

    #endregion Private Methods
}
