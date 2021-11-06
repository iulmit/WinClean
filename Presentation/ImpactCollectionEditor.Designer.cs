namespace RaphaëlBardini.WinClean.Presentation
{
    partial class ImpactCollectionEditor
    {
        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpactCollectionEditor));
            this.tableImpacts = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddImpact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableImpacts
            // 
            this.tableImpacts.CausesValidation = false;
            resources.ApplyResources(this.tableImpacts, "tableImpacts");
            this.tableImpacts.Name = "tableImpacts";
            // 
            // buttonAddImpact
            // 
            this.buttonAddImpact.BackgroundImage = global::RaphaëlBardini.WinClean.Resources.Images.Positive;
            resources.ApplyResources(this.buttonAddImpact, "buttonAddImpact");
            this.buttonAddImpact.CausesValidation = false;
            this.buttonAddImpact.Name = "buttonAddImpact";
            this.buttonAddImpact.UseMnemonic = false;
            this.buttonAddImpact.UseVisualStyleBackColor = true;
            this.buttonAddImpact.Click += new System.EventHandler(this.ButtonAddImpact_Click);
            // 
            // ImpactCollectionEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddImpact);
            this.Controls.Add(this.tableImpacts);
            this.DoubleBuffered = true;
            this.Name = "ImpactCollectionEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableImpacts;
        private System.Windows.Forms.Button buttonAddImpact;
    }
}
