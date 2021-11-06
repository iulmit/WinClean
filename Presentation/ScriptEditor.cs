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
    #region Protected Properties

    /// <inheritdoc/>
    /// <remarks>Reduced flickering on child control paint.</remarks>
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
            return cp;
        }
    }

    #endregion Protected Properties

    #region Private Fields

    private IScript? _selectedScript;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptEditor"/> class.
    /// </summary>
    public ScriptEditor()
    {
        InitializeComponent();
        comboBoxAdvised.DataSource = Resources.ScriptAdvised.ResourceManager.GetRessources<string>().ToList();
        //comboBoxGroup.DataSource =
    }

    #endregion Public Constructors

    #region Public Properties

    /// <inheritdoc/>
    public override bool AutoScroll
    {
        get => base.AutoScroll;
        set => base.AutoScroll = impactCollectionEditor.AutoScroll = value;
    }

    /// <summary>
    /// The script the user is currently able to see and edit.
    /// </summary>
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
                impactCollectionEditor.AddRange(value.Impacts);
            }
        }
    }

    #endregion Public Properties

    #region Private Methods

    #region Event Handlers

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

    private void ButtonExecute_Click(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            ScriptExecutor executor = new(_selectedScript);
            executor.ExecuteNoUI();
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

    private void ScriptEditor_Leave(object _, EventArgs __) => PrepareForAnother();

    private void ScriptEditor_Resize(object _, EventArgs __)
    {
        SuspendLayout();

        int newWidth = Width;
        if (Height < buttonExecute.Location.Y + buttonExecute.Height)
        {
            newWidth -= SystemInformation.VerticalScrollBarWidth;
        }

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

        ResumeLayout();
    }

    private void TextBoxCode_TextChanged(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            _selectedScript.Code = textBoxCode.Text;
        }
    }

    private void TextBoxDescription_TextChanged(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            _selectedScript.Description = textBoxDescription.Text;
        }
    }

    private void TextBoxName_TextChanged(object _, EventArgs __)
    {
        if (_selectedScript is not null)
        {
            _selectedScript.Name = textBoxName.Text;
        }
    }

    #endregion Event Handlers

    private static void ChangeWidth(Control c, int newWitdth)
        => c.Width = newWitdth > c.MinimumSize.Width ? newWitdth : c.MinimumSize.Width;

    private void PrepareForAnother()
    {
        _selectedScript?.Save();
        impactCollectionEditor.Clear();
    }

    #endregion Private Methods
}