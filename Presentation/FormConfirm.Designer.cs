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
            System.Windows.Forms.Label labelSave;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfirm));
            System.Windows.Forms.Label labelPrograms;
            System.Windows.Forms.Label labelPlug;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelAll;
            System.Windows.Forms.Label labelTitle;
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.checkBoxPlug = new System.Windows.Forms.CheckBox();
            this.checkBoxPrograms = new System.Windows.Forms.CheckBox();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            labelSave = new System.Windows.Forms.Label();
            labelPrograms = new System.Windows.Forms.Label();
            labelPlug = new System.Windows.Forms.Label();
            tableLayoutPanelAll = new System.Windows.Forms.TableLayoutPanel();
            labelTitle = new System.Windows.Forms.Label();
            tableLayoutPanelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            // tableLayoutPanelAll
            // 
            tableLayoutPanelAll.BackColor = System.Drawing.SystemColors.Window;
            tableLayoutPanelAll.CausesValidation = false;
            resources.ApplyResources(tableLayoutPanelAll, "tableLayoutPanelAll");
            tableLayoutPanelAll.Controls.Add(this.pictureBox, 0, 0);
            tableLayoutPanelAll.Controls.Add(labelTitle, 1, 0);
            tableLayoutPanelAll.Controls.Add(this.checkBoxPlug, 1, 1);
            tableLayoutPanelAll.Controls.Add(labelPlug, 1, 2);
            tableLayoutPanelAll.Controls.Add(this.checkBoxPrograms, 1, 5);
            tableLayoutPanelAll.Controls.Add(this.checkBoxSave, 1, 3);
            tableLayoutPanelAll.Controls.Add(labelPrograms, 1, 6);
            tableLayoutPanelAll.Controls.Add(labelSave, 1, 4);
            tableLayoutPanelAll.Name = "tableLayoutPanelAll";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // labelTitle
            // 
            resources.ApplyResources(labelTitle, "labelTitle");
            labelTitle.CausesValidation = false;
            labelTitle.Name = "labelTitle";
            // 
            // checkBoxPlug
            // 
            resources.ApplyResources(this.checkBoxPlug, "checkBoxPlug");
            this.checkBoxPlug.CausesValidation = false;
            this.checkBoxPlug.Name = "checkBoxPlug";
            this.checkBoxPlug.UseVisualStyleBackColor = true;
            this.checkBoxPlug.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxPrograms
            // 
            resources.ApplyResources(this.checkBoxPrograms, "checkBoxPrograms");
            this.checkBoxPrograms.Name = "checkBoxPrograms";
            this.checkBoxPrograms.UseVisualStyleBackColor = true;
            this.checkBoxPrograms.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxSave
            // 
            resources.ApplyResources(this.checkBoxSave, "checkBoxSave");
            this.checkBoxSave.CausesValidation = false;
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            this.checkBoxSave.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // buttonContinue
            // 
            this.buttonContinue.CausesValidation = false;
            resources.ApplyResources(this.buttonContinue, "buttonContinue");
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
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.CausesValidation = false;
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonContinue);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // FormConfirm
            // 
            this.AcceptButton = this.buttonContinue;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.buttonCancel;
            this.CausesValidation = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(tableLayoutPanelAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfirm";
            this.Opacity = 0.96D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            tableLayoutPanelAll.ResumeLayout(false);
            tableLayoutPanelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.CheckBox checkBoxPrograms;
        private System.Windows.Forms.CheckBox checkBoxPlug;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
