namespace RaphaëlBardini.WinClean.Presentation;

partial class ScriptEditor
{
    /// <summary> 
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Code généré par le Concepteur de composants

    /// <summary> 
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.comboBoxAdvised = new System.Windows.Forms.ComboBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.impactEditor = new RaphaëlBardini.WinClean.Presentation.ImpactEditor();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxCode
            // 
            this.textBoxCode.AcceptsReturn = true;
            this.textBoxCode.AcceptsTab = true;
            this.textBoxCode.CausesValidation = false;
            this.textBoxCode.Location = new System.Drawing.Point(0, 159);
            this.textBoxCode.Margin = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.textBoxCode.MinimumSize = new System.Drawing.Size(171, 0);
            this.textBoxCode.Multiline = true;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.PlaceholderText = "Code";
            this.textBoxCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCode.Size = new System.Drawing.Size(211, 130);
            this.textBoxCode.TabIndex = 6;
            this.textBoxCode.WordWrap = false;
            this.textBoxCode.TextChanged += new System.EventHandler(this.TextBoxCode_TextChanged);
            // 
            // buttonExecute
            // 
            this.buttonExecute.CausesValidation = false;
            this.buttonExecute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonExecute.Location = new System.Drawing.Point(27, 300);
            this.buttonExecute.Margin = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.buttonExecute.MinimumSize = new System.Drawing.Size(75, 0);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonExecute.Size = new System.Drawing.Size(75, 25);
            this.buttonExecute.TabIndex = 7;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.ButtonExecute_Click);
            // 
            // comboBoxAdvised
            // 
            this.comboBoxAdvised.CausesValidation = false;
            this.comboBoxAdvised.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdvised.FormattingEnabled = true;
            this.comboBoxAdvised.Location = new System.Drawing.Point(111, 91);
            this.comboBoxAdvised.Margin = new System.Windows.Forms.Padding(11, 11, 0, 0);
            this.comboBoxAdvised.MinimumSize = new System.Drawing.Size(80, 0);
            this.comboBoxAdvised.Name = "comboBoxAdvised";
            this.comboBoxAdvised.Size = new System.Drawing.Size(100, 23);
            this.comboBoxAdvised.TabIndex = 4;
            this.comboBoxAdvised.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAdvised_SelectedIndexChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.CausesValidation = false;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 34);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.textBoxDescription.MinimumSize = new System.Drawing.Size(171, 0);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.PlaceholderText = "Description";
            this.textBoxDescription.Size = new System.Drawing.Size(211, 46);
            this.textBoxDescription.TabIndex = 2;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.TextBoxDescription_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.AcceptsReturn = true;
            this.textBoxName.CausesValidation = false;
            this.textBoxName.Location = new System.Drawing.Point(0, 0);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxName.MinimumSize = new System.Drawing.Size(171, 0);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.PlaceholderText = "Name";
            this.textBoxName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxName.Size = new System.Drawing.Size(211, 23);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.CausesValidation = false;
            this.buttonDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonDelete.Location = new System.Drawing.Point(109, 300);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(7, 11, 0, 0);
            this.buttonDelete.MinimumSize = new System.Drawing.Size(75, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonDelete.Size = new System.Drawing.Size(75, 25);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // impactEditor
            // 
            this.impactEditor.Location = new System.Drawing.Point(0, 125);
            this.impactEditor.Margin = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.impactEditor.Name = "impactEditor";
            this.impactEditor.Selected = null;
            this.impactEditor.Size = new System.Drawing.Size(211, 23);
            this.impactEditor.TabIndex = 9;
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxGroup.Location = new System.Drawing.Point(0, 91);
            this.textBoxGroup.Margin = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.PlaceholderText = "Group";
            this.textBoxGroup.Size = new System.Drawing.Size(100, 23);
            this.textBoxGroup.TabIndex = 10;
            this.textBoxGroup.TextChanged += new System.EventHandler(this.TextBoxGroup_TextChanged);
            // 
            // ScriptEditor
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.textBoxGroup);
            this.Controls.Add(this.impactEditor);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.comboBoxAdvised);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonDelete);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(0, 325);
            this.Name = "ScriptEditor";
            this.Size = new System.Drawing.Size(211, 325);
            this.Leave += new System.EventHandler(this.ScriptEditor_Leave);
            this.Resize += new System.EventHandler(this.ScriptEditor_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxCode;
    private System.Windows.Forms.Button buttonExecute;
    private System.Windows.Forms.ComboBox comboBoxAdvised;
    private System.Windows.Forms.TextBox textBoxDescription;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Button buttonDelete;
    private ImpactEditor impactEditor;
    private System.Windows.Forms.TextBox textBoxGroup;
}
