namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>
    /// Allows the user to see and edit a collection of <see cref="Logic.Impact"/> objects.
    /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpactEditor));
            this.pictureBoxLevelIcon = new System.Windows.Forms.PictureBox();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxEffect = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevelIcon)).BeginInit();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxLevelIcon
            // 
            resources.ApplyResources(this.pictureBoxLevelIcon, "pictureBoxLevelIcon");
            this.pictureBoxLevelIcon.Name = "pictureBoxLevelIcon";
            this.pictureBoxLevelIcon.TabStop = false;
            // 
            // table
            // 
            this.table.CausesValidation = false;
            resources.ApplyResources(this.table, "table");
            this.table.Controls.Add(this.pictureBoxLevelIcon, 0, 0);
            this.table.Controls.Add(this.comboBoxLevel, 1, 0);
            this.table.Controls.Add(this.comboBoxEffect, 2, 0);
            this.table.Name = "table";
            // 
            // comboBoxLevel
            // 
            resources.ApplyResources(this.comboBoxLevel, "comboBoxLevel");
            this.comboBoxLevel.CausesValidation = false;
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLevel_SelectedIndexChanged);
            // 
            // comboBoxEffect
            // 
            resources.ApplyResources(this.comboBoxEffect, "comboBoxEffect");
            this.comboBoxEffect.CausesValidation = false;
            this.comboBoxEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEffect.FormattingEnabled = true;
            this.comboBoxEffect.Name = "comboBoxEffect";
            this.comboBoxEffect.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEffect_SelectedIndexChanged);
            // 
            // ImpactEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.DoubleBuffered = true;
            this.Name = "ImpactEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevelIcon)).EndInit();
            this.table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLevelIcon;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.ComboBox comboBoxEffect;
    }
}
