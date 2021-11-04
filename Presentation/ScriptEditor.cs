﻿using RaphaëlBardini.WinClean.Logic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

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
            _selectedScript = value;

            Enabled = value is not null;

            if (value is not null)
            {
                textBoxName.Text = value.Name;
                textBoxDescription.Text = value.Description;
                comboBoxAdvised.SelectedItem = Resources.ScriptAdvised.ResourceManager.GetString(value.Advised.ToString(), CultureInfo.CurrentUICulture);
                comboBoxGroup.SelectedItem = value.Group;
                textBoxCode.Text = value.Code;
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
        if (SelectedScript is not null)
        {
            SelectedScript.Name = textBoxName.Text;
        }
    }

    private void TextBoxDescription_TextChanged(object _, EventArgs __)
    {
        if (SelectedScript is not null)
        {
            SelectedScript.Description = textBoxDescription.Text;
        }
    }

    private void ComboBoxAdvised_SelectedIndexChanged(object _, EventArgs __)
    {
        if (SelectedScript is not null)
        {
            SelectedScript.Advised = Enum.Parse<ScriptAdvised>((string)comboBoxAdvised.SelectedItem);
        }
    }

    private void ComboBoxGroup_SelectedIndexChanged(object _, EventArgs __)
    {
        if (SelectedScript is not null)
        {
            SelectedScript.Group = (ListViewGroup)comboBoxGroup.SelectedItem;
        }
    }

    private void TextBoxCode_TextChanged(object _, EventArgs __)
    {
        if (SelectedScript is not null)
        {
            SelectedScript.Code = textBoxCode.Text;
        }
    }

    private void ButtonExecute_Click(object _, EventArgs __)
    {
        if (SelectedScript is not null)
        {
            ScriptExecutor executor = new(SelectedScript);
            executor.ExecuteNoUI();
        }
    }

    private void ButtonDelete_Click(object _, EventArgs __)
    {
        if (SelectedScript is not null)
        {
            if (ErrorDialog.ConfirmScriptDeletion())
            {
                SelectedScript.Delete();
            }
        }
    }
    private void ScriptEditor_SizeChanged(object _, EventArgs __)
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

        ResumeLayout();
    }
    private void ScriptEditor_Leave(object _, EventArgs __) => SelectedScript?.Save();

    private static void ChangeWidth(Control c, int newWitdth)
        => c.Width = newWitdth > c.MinimumSize.Width ? newWitdth : c.MinimumSize.Width;
}
