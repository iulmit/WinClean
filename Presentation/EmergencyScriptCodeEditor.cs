// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation;
public partial class EmergencyScriptCodeEditor : Form
{
    private IScript? _selected;

    public IScript? Selected
    {
        get => _selected;
        set
        {
            textBoxCode.Text = _selected?.Code;
            _selected = value;
        }
    }
    public EmergencyScriptCodeEditor() => InitializeComponent();

    public EmergencyScriptCodeEditor(IScript? selected) : this() => Selected = selected;
    private void ButtonOk_Click(object sender, EventArgs e)
    {
        if (_selected is not null)
        {
            _selected.Code = textBoxCode.Text;
        }
        DialogResult = DialogResult.OK;
    }

    private void ButtonCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
}
