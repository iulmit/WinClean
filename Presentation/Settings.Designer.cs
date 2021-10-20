// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace RaphaëlBardini.WinClean.Presentation
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label labelScriptTimeout;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            System.Windows.Forms.Label labelLogLevel;
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.numericUpDownScriptTimeout = new System.Windows.Forms.NumericUpDown();
            this.comboBoxLogLevel = new System.Windows.Forms.ComboBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            labelScriptTimeout = new System.Windows.Forms.Label();
            labelLogLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScriptTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // labelScriptTimeout
            // 
            resources.ApplyResources(labelScriptTimeout, "labelScriptTimeout");
            labelScriptTimeout.CausesValidation = false;
            labelScriptTimeout.Name = "labelScriptTimeout";
            // 
            // labelLogLevel
            // 
            resources.ApplyResources(labelLogLevel, "labelLogLevel");
            labelLogLevel.CausesValidation = false;
            labelLogLevel.Name = "labelLogLevel";
            // 
            // buttonCancel
            // 
            this.buttonCancel.CausesValidation = false;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseMnemonic = false;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.CausesValidation = false;
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseMnemonic = false;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // numericUpDownScriptTimeout
            // 
            this.numericUpDownScriptTimeout.CausesValidation = false;
            resources.ApplyResources(this.numericUpDownScriptTimeout, "numericUpDownScriptTimeout");
            this.numericUpDownScriptTimeout.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDownScriptTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScriptTimeout.Name = "numericUpDownScriptTimeout";
            this.numericUpDownScriptTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxLogLevel
            // 
            this.comboBoxLogLevel.CausesValidation = false;
            resources.ApplyResources(this.comboBoxLogLevel, "comboBoxLogLevel");
            this.comboBoxLogLevel.Name = "comboBoxLogLevel";
            // 
            // propertyGrid
            // 
            this.propertyGrid.CausesValidation = false;
            resources.ApplyResources(this.propertyGrid, "propertyGrid");
            this.propertyGrid.Name = "propertyGrid";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.buttonCancel;
            this.CausesValidation = false;
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.comboBoxLogLevel);
            this.Controls.Add(labelLogLevel);
            this.Controls.Add(this.numericUpDownScriptTimeout);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(labelScriptTimeout);
            this.Controls.Add(this.buttonCancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Opacity = 0.96D;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScriptTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelScriptTimeout;
        private System.Windows.Forms.NumericUpDown numericUpDownScriptTimeout;
        private System.Windows.Forms.Label labelLogLevel;
        private System.Windows.Forms.ComboBox comboBoxLogLevel;
        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}
