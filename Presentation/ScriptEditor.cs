using RaphaëlBardini.WinClean.Logic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WinCopies.Collections;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>
/// Control used to display and edit a script.
/// </summary>
public partial class ScriptEditor : UserControl
{
    private IScript? _selectedScript;

    /// <summary>The script the user is currently able to see and edit.</summary>
    public IScript? SelectedScript
    {
        get => _selectedScript;
        set
        {
            flowImpacts.Controls.Clear();

            _selectedScript?.Save();
            _selectedScript = value;

            Enabled = value is not null;

            if (value is not null)
            {
                textBoxName.Text = value.Name;
                textBoxDescription.Text = value.Description;
                comboBoxAdvised.SelectedItem = Resources.ScriptAdvised.ResourceManager.GetString(value.Advised.ToString(), CultureInfo.CurrentUICulture);
                comboBoxGroup.SelectedItem = value.Group;
                textBoxCode.Text = value.Code;
                flowImpacts.Controls.AddRange(value.Impacts.Select((impact) =>
                {
                    return new ImpactEditor()
                    {
                        SelectedImpact = impact,
                        Margin = new(0, 0, 0, 7),
                        Width = this.Width
                    };
                }));
            }
        }
    }



    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptEditor"/> class.
    /// </summary>
    public ScriptEditor()
    {
        InitializeComponent();
        comboBoxAdvised.DataSource = Resources.ScriptAdvised.ResourceManager.GetRessources<string>().ToList();
        //comboBoxGroup.DataSource =
    }

    private void TextBoxName_TextChanged(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            _selectedScript.Name = textBoxName.Text;
        }
    }

    private void TextBoxDescription_TextChanged(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            _selectedScript.Description = textBoxDescription.Text;
        }
    }

    private void ComboBoxAdvised_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            _selectedScript.Advised = Enum.Parse<ScriptAdvised>((string)comboBoxAdvised.SelectedItem);
        }
    }

    private void ComboBoxGroup_SelectedIndexChanged(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            _selectedScript.Group = (ListViewGroup)comboBoxGroup.SelectedItem;
        }
    }

    private void TextBoxCode_TextChanged(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            _selectedScript.Code = textBoxCode.Text;
        }
    }

    private void ButtonExecute_Click(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            ScriptExecutor executor = new(_selectedScript);
            executor.ExecuteNoUI();
        }
    }

    private void ButtonDelete_Click(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            if (ErrorDialog.ConfirmScriptDeletion())
            {
                _selectedScript.Delete();
            }
        }
    }

    private void ScriptEditor_Leave(object _, EventArgs __) => _selectedScript?.Save();

    private static void ChangeWidth(Control c, int newWitdth)
        => c.Width = newWitdth > c.MinimumSize.Width ? newWitdth : c.MinimumSize.Width;

    private void ScriptEditor_Resize(object _, EventArgs __)
    {
        SuspendLayout();

        // TextBoxes
        ChangeWidth(textBoxName, Width);
        ChangeWidth(textBoxDescription, Width);
        ChangeWidth(textBoxCode, Width);

        // ComboBoxes
        const int ComboBoxSpacing = 11;
        int cBoxWidth = (int)((Width / 2D) - (ComboBoxSpacing / 2D));
        ChangeWidth(comboBoxGroup, cBoxWidth);
        ChangeWidth(comboBoxAdvised, cBoxWidth);
        comboBoxAdvised.Location = new(Width - cBoxWidth, comboBoxAdvised.Location.Y);

        // Buttons
        const int ButtonSpacing = 7;
        buttonExecute.Location = new((int)((Width / 2D) - (ButtonSpacing / 2D) - buttonExecute.Width), buttonExecute.Location.Y);
        buttonDelete.Location = new((int)((Width / 2D) + (ButtonSpacing / 2D)), buttonDelete.Location.Y);

        // FlowLayoutPanels
        ChangeWidth(flowImpacts, Width);
        foreach (Control c in flowImpacts.Controls)
        {
            ChangeWidth(c, Width);
        }

        ResumeLayout();
    }
}
