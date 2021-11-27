// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation;

public partial class EmergencyScriptCodeEditor : Form
{
    #region Private Fields

    private IScript? _selected;

    #endregion Private Fields

    #region Public Constructors

    public EmergencyScriptCodeEditor() => InitializeComponent();

    public EmergencyScriptCodeEditor(IScript? selected) : this() => Selected = selected;

    #endregion Public Constructors

    #region Public Properties

    public IScript? Selected
    {
        get => _selected;
        set
        {
            textBoxCode.Text = _selected?.Code;
            _selected = value;
        }
    }

    #endregion Public Properties

    #region Private Methods

    private void ButtonCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

    private void ButtonOk_Click(object sender, EventArgs e)
    {
        if (_selected is not null)
        {
            _selected.Code = textBoxCode.Text;
        }
        DialogResult = DialogResult.OK;
    }

    #endregion Private Methods
}
