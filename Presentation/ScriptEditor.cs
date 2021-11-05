using RaphaëlBardini.WinClean.Logic;
using System.Collections.Generic;
using System.Drawing;
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
    private void AddImpactTableRow(Impact impact)
    {
        ++tableImpacts.RowCount;

        tableImpactRows.Add(new Control[3]
        {
            new ImpactEditor(impact)
            {
                Margin = new(0, 0, 0, 7),
                Width = this.Width,
                Anchor = AnchorStyles.None,
            },
            NewAddImpactButton,
            NewRemoveImpactButton
        });

        tableImpacts.Controls.Add(tableImpactRows.Last()[0], 0, tableImpacts.RowCount);
        tableImpacts.Controls.Add(tableImpactRows.Last()[1], 1, tableImpacts.RowCount);
        tableImpacts.Controls.Add(tableImpactRows.Last()[2], 2, tableImpacts.RowCount);
    }
    private void RemoveImpactTableLastRow()
    {
        foreach (Control lastRowControl in tableImpactRows.Last())
        {
            tableImpacts.Controls.Remove(lastRowControl);
        }
        tableImpactRows.RemoveAt(--tableImpacts.RowCount);
    }
    private readonly List<Control[]> tableImpactRows = new();
    private Button NewAddImpactButton
    {
        get
        {
            Button b = CreateTableLayoutPanelButton(Resources.Images.Positive);
            b.Click += (s, e) =>
            {
                if (_selectedScript is not null)
                {
                    Impact @new = new();
                    _selectedScript.Impacts.Add(@new);
                    AddImpactTableRow(@new);
                }
            };
            return b;
        }
    }

    private Button NewRemoveImpactButton
    {
        get
        {
            Button b = CreateTableLayoutPanelButton(tableImpactRows.Count > 0 ? Resources.Images.Negative : Resources.Images.NegativeDisabled);
            b.Enabled = tableImpactRows.Count > 0;
            b.Click += (s, e) =>
            {
                RemoveImpactTableLastRow();
            };
            return b;
        }
    }

    private Button CreateTableLayoutPanelButton(Image backImg) => new()
    {
        BackgroundImage = backImg,
        BackgroundImageLayout = ImageLayout.Center,
        UseMnemonic = false,
        UseVisualStyleBackColor = true,
        TabIndex = buttonDelete.TabIndex + tableImpacts.RowCount,
        Anchor = AnchorStyles.None,
        Margin = new(5, 0, 0, 0),
        Size = new(20, 20),
        CausesValidation = false,
    };

    /// <inheritdoc/>
    public override bool AutoScroll
    {
        get => base.AutoScroll;
        set => base.AutoScroll = tableImpacts.AutoScroll = value;
    }

    private IScript? _selectedScript;

    /// <summary>The script the user is currently able to see and edit.</summary>
    public IScript? SelectedScript
    {
        get => _selectedScript;
        set
        {
            PrepareForAnother();

            _selectedScript = value;

            Enabled = value is not null;

            if (value is not null)
            {
                textBoxName.Text = value.Name;
                textBoxDescription.Text = value.Description;
                comboBoxAdvised.SelectedItem = Resources.ScriptAdvised.ResourceManager.GetString(value.Advised.ToString(), CultureInfo.CurrentUICulture).FailIfNull();
                comboBoxGroup.SelectedItem = value.Group;
                textBoxCode.Text = value.Code;

                foreach (Impact impact in value.Impacts)
                {
                    AddImpactTableRow(impact);
                }
            }
        }
    }

    private void PrepareForAnother()
    {
        tableImpactRows.Clear();
        tableImpacts.RowCount = 0;

        _selectedScript?.Save();
        tableImpacts.Controls.Clear();
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

    private void ScriptEditor_Leave(object _, EventArgs __) => PrepareForAnother();

    private void ChangeWidth(Control c, int newWitdth)
    {
        c.Width = newWitdth > c.MinimumSize.Width ? newWitdth : c.MinimumSize.Width;
    }

    private void ScriptEditor_Resize(object _, EventArgs __)
    {
        SuspendLayout();
        tableImpacts.SuspendLayout();

        int newWidth = Width;
        newWidth -= SystemInformation.VerticalScrollBarWidth;

        // TextBoxes
        ChangeWidth(textBoxName, newWidth);
        ChangeWidth(textBoxDescription, newWidth);
        ChangeWidth(textBoxCode, newWidth);

        // ComboBoxes
        const int ComboBoxSpacing = 11;
        int cBoxWidth = (int)((newWidth / 2D) - (ComboBoxSpacing / 2D));
        ChangeWidth(comboBoxGroup, cBoxWidth);
        ChangeWidth(comboBoxAdvised, cBoxWidth);
        comboBoxAdvised.Location = new(newWidth - cBoxWidth, comboBoxAdvised.Location.Y);

        // Buttons
        const int ButtonSpacing = 7;
        buttonExecute.Location = new((int)((newWidth / 2D) - (ButtonSpacing / 2D) - buttonExecute.Width), buttonExecute.Location.Y);
        buttonDelete.Location = new((int)((newWidth / 2D) + (ButtonSpacing / 2D)), buttonDelete.Location.Y);

        // FlowLayoutPanels
        ChangeWidth(tableImpacts, newWidth);
        foreach (Control c in tableImpacts.Controls)
        {
            ChangeWidth(c, newWidth);
        }

        tableImpacts.ResumeLayout();
        ResumeLayout();
    }
}
