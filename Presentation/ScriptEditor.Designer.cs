﻿namespace RaphaëlBardini.WinClean.Presentation
{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptEditor));
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.comboBoxAdvised = new System.Windows.Forms.ComboBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCode
            // 
            this.textBoxCode.AcceptsReturn = true;
            this.textBoxCode.AcceptsTab = true;
            resources.ApplyResources(this.textBoxCode, "textBoxCode");
            this.textBoxCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCode.CausesValidation = false;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.TextChanged += new System.EventHandler(this.TextBoxCode_TextChanged);
            // 
            // buttonExecute
            // 
            resources.ApplyResources(this.buttonExecute, "buttonExecute");
            this.buttonExecute.CausesValidation = false;
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.ButtonExecute_Click);
            // 
            // comboBoxAdvised
            // 
            resources.ApplyResources(this.comboBoxAdvised, "comboBoxAdvised");
            this.comboBoxAdvised.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxAdvised.CausesValidation = false;
            this.comboBoxAdvised.FormattingEnabled = true;
            this.comboBoxAdvised.Name = "comboBoxAdvised";
            this.comboBoxAdvised.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGroup_SelectedIndexChanged);
            // 
            // comboBoxGroup
            // 
            resources.ApplyResources(this.comboBoxGroup, "comboBoxGroup");
            this.comboBoxGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxGroup.CausesValidation = false;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAdvised_SelectedIndexChanged);
            // 
            // textBoxDescription
            // 
            resources.ApplyResources(this.textBoxDescription, "textBoxDescription");
            this.textBoxDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxDescription.CausesValidation = false;
            this.textBoxDescription.Name = "textBoxDescription";
            // 
            // textBoxName
            // 
            this.textBoxName.AcceptsReturn = true;
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxName.CausesValidation = false;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxDescription_TextChanged);
            // 
            // buttonDelete
            // 
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.CausesValidation = false;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ScriptEditor
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.comboBoxAdvised);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonDelete);
            this.Name = "ScriptEditor";
            this.SizeChanged += new System.EventHandler(this.ScriptEditor_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.ComboBox comboBoxAdvised;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonDelete;
    }
}