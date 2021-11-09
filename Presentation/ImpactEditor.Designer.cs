namespace RaphaëlBardini.WinClean.Presentation;

partial class ImpactEditor
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
            this.imagedComboBoxLevel = new RaphaëlBardini.WinClean.Presentation.ImagedComboBox();
            this.comboBoxEffect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // imagedComboBoxLevel
            // 
            this.imagedComboBoxLevel.CausesValidation = false;
            this.imagedComboBoxLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imagedComboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imagedComboBoxLevel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.imagedComboBoxLevel.Location = new System.Drawing.Point(0, 0);
            this.imagedComboBoxLevel.Margin = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.imagedComboBoxLevel.Name = "imagedComboBoxLevel";
            this.imagedComboBoxLevel.Size = new System.Drawing.Size(39, 23);
            this.imagedComboBoxLevel.TabIndex = 0;
            this.imagedComboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.ImagedComboBoxLevel_SelectedIndexChanged);
            // 
            // comboBoxEffect
            // 
            this.comboBoxEffect.CausesValidation = false;
            this.comboBoxEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEffect.Location = new System.Drawing.Point(50, 0);
            this.comboBoxEffect.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxEffect.Name = "comboBoxEffect";
            this.comboBoxEffect.Size = new System.Drawing.Size(121, 23);
            this.comboBoxEffect.TabIndex = 1;
            this.comboBoxEffect.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEffect_SelectedIndexChanged);
            // 
            // ImpactEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxEffect);
            this.Controls.Add(this.imagedComboBoxLevel);
            this.Name = "ImpactEditor";
            this.Size = new System.Drawing.Size(171, 23);
            this.Resize += new System.EventHandler(this.ImpactEditor_Resize);
            this.ResumeLayout(false);

    }

    #endregion

    private ImagedComboBox imagedComboBoxLevel;
    private System.Windows.Forms.ComboBox comboBoxEffect;
}
