namespace RaphaëlBardini.WinClean.Presentation.Forms;

/// <summary>Form to acess and modify application settings.</summary>
public partial class Settings : Form
{
    #region Public Constructors

    public Settings()
    {
        InitializeComponent();

        numericUpDownScriptTimeoutHours.Value = Convert.ToInt32(Program.Settings.ScriptTimeout.TotalHours);

        comboBoxLogLevel.DataSource = Enum.GetValues<LogLevel>();
        comboBoxLogLevel.SelectedItem = (LogLevel)Program.Settings.LogLevel;

        checkBoxAllowScriptCodeEdit.Checked = Program.Settings.AllowScriptCodeEdit;

        numericUpDownPrompts.Value = Program.Settings.MaxPrompts;
    }

    #endregion Public Constructors

    #region Private Methods

    private void ButtonCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

    private void ButtonOK_Click(object sender, EventArgs e)
    {
        Program.Settings.ScriptTimeout = TimeSpan.FromHours((int)numericUpDownScriptTimeoutHours.Value);
        Program.Settings.LogLevel = (int)comboBoxLogLevel.SelectedItem;
        Program.Settings.MaxPrompts = Convert.ToInt32(numericUpDownPrompts.Value);
        Program.Settings.AllowScriptCodeEdit = checkBoxAllowScriptCodeEdit.Checked;
        DialogResult = DialogResult.OK;
    }

    #endregion Private Methods
}
