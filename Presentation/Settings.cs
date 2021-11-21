// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>Form to acess and modify application settings.</summary>
public partial class Settings : Form
{
    #region Public Constructors

    public Settings()
    {
        InitializeComponent();

        comboBoxScriptTimeout.DataSource = ScriptTimeoutPreset.Values.Select((val) => val.LocalizedName).ToList();
        comboBoxScriptTimeout.SelectedItem = ScriptTimeoutPreset.ParseTimeout(Program.Settings.ScriptTimeout).LocalizedName;

        comboBoxLogLevel.DataSource = Enum.GetValues<LogLevel>();
        comboBoxLogLevel.SelectedItem = (LogLevel)Program.Settings.LogLevel;
    }

    #endregion Public Constructors

    #region Private Methods

    private void ButtonCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

    private void ButtonOK_Click(object sender, EventArgs e)
    {
        Program.Settings.ScriptTimeout = ScriptTimeoutPreset.ParseLocalizedName((string)comboBoxScriptTimeout.SelectedItem).Duration;
        Program.Settings.LogLevel = (int)comboBoxLogLevel.SelectedItem;
        DialogResult = DialogResult.OK;
    }

    #endregion Private Methods
}
