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
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxEffect = new System.Windows.Forms.ComboBox();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.CausesValidation = false;
            resources.ApplyResources(this.table, "table");
            this.table.Controls.Add(this.comboBoxLevel, 0, 0);
            this.table.Controls.Add(this.comboBoxEffect, 1, 0);
            this.table.Name = "table";
            // 
            // comboBoxEffect
            // 
            resources.ApplyResources(this.comboBoxEffect, "comboBoxEffect");
            this.comboBoxEffect.CausesValidation = false;
            this.comboBoxEffect.FormattingEnabled = true;
            this.comboBoxEffect.Name = "comboBoxEffect";
            this.comboBoxEffect.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEffect_SelectedIndexChanged);
            // 
            // comboBoxLevel
            // 
            resources.ApplyResources(this.comboBoxLevel, "comboBoxLevel");
            this.comboBoxLevel.CausesValidation = false;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLevel_SelectedIndexChanged);
            // 
            // ImpactEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.table);
            this.DoubleBuffered = true;
            this.Name = "ImpactEditor";
            this.table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.ComboBox comboBoxEffect;
        private System.Windows.Forms.ComboBox comboBoxLevel;
    }
}
