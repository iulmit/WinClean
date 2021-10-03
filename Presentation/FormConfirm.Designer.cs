// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace RaphaëlBardini.WinClean.Presentation
{
    partial class FormConfirm
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
            System.Windows.Forms.Label labelTitle;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfirm));
            System.Windows.Forms.Label labelSave;
            System.Windows.Forms.Label labelPrograms;
            System.Windows.Forms.Label labelPlug;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAll;
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.checkBoxPrograms = new System.Windows.Forms.CheckBox();
            this.checkBoxPlug = new System.Windows.Forms.CheckBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            labelTitle = new System.Windows.Forms.Label();
            labelSave = new System.Windows.Forms.Label();
            labelPrograms = new System.Windows.Forms.Label();
            labelPlug = new System.Windows.Forms.Label();
            flowLayoutPanelAll = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(labelTitle, "labelTitle");
            labelTitle.CausesValidation = false;
            labelTitle.Name = "labelTitle";
            // 
            // labelSave
            // 
            resources.ApplyResources(labelSave, "labelSave");
            labelSave.CausesValidation = false;
            labelSave.Name = "labelSave";
            // 
            // labelPrograms
            // 
            resources.ApplyResources(labelPrograms, "labelPrograms");
            labelPrograms.CausesValidation = false;
            labelPrograms.Name = "labelPrograms";
            // 
            // labelPlug
            // 
            resources.ApplyResources(labelPlug, "labelPlug");
            labelPlug.CausesValidation = false;
            labelPlug.Name = "labelPlug";
            // 
            // flowLayoutPanelAll
            // 
            flowLayoutPanelAll.CausesValidation = false;
            flowLayoutPanelAll.Controls.Add(labelTitle);
            flowLayoutPanelAll.Controls.Add(labelSave);
            flowLayoutPanelAll.Controls.Add(this.checkBoxSave);
            flowLayoutPanelAll.Controls.Add(labelPrograms);
            flowLayoutPanelAll.Controls.Add(this.checkBoxPrograms);
            flowLayoutPanelAll.Controls.Add(labelPlug);
            flowLayoutPanelAll.Controls.Add(this.checkBoxPlug);
            resources.ApplyResources(flowLayoutPanelAll, "flowLayoutPanelAll");
            flowLayoutPanelAll.Name = "flowLayoutPanelAll";
            // 
            // checkBoxSave
            // 
            resources.ApplyResources(this.checkBoxSave, "checkBoxSave");
            this.checkBoxSave.CausesValidation = false;
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            this.checkBoxSave.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxPrograms
            // 
            resources.ApplyResources(this.checkBoxPrograms, "checkBoxPrograms");
            this.checkBoxPrograms.Name = "checkBoxPrograms";
            this.checkBoxPrograms.UseVisualStyleBackColor = true;
            this.checkBoxPrograms.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxPlug
            // 
            resources.ApplyResources(this.checkBoxPlug, "checkBoxPlug");
            this.checkBoxPlug.Name = "checkBoxPlug";
            this.checkBoxPlug.UseVisualStyleBackColor = true;
            this.checkBoxPlug.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // buttonContinue
            // 
            resources.ApplyResources(this.buttonContinue, "buttonContinue");
            this.buttonContinue.CausesValidation = false;
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormConfirm
            // 
            this.AcceptButton = this.buttonContinue;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonCancel;
            this.CausesValidation = false;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(flowLayoutPanelAll);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfirm";
            this.Opacity = 0.96D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            flowLayoutPanelAll.ResumeLayout(false);
            flowLayoutPanelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelSave;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.Label labelPrograms;
        private System.Windows.Forms.CheckBox checkBoxPrograms;
        private System.Windows.Forms.CheckBox checkBoxPlug;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonContinue;
    }
}
