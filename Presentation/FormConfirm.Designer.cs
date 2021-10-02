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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            labelTitle = new System.Windows.Forms.Label();
            labelSave = new System.Windows.Forms.Label();
            labelPrograms = new System.Windows.Forms.Label();
            labelPlug = new System.Windows.Forms.Label();
            flowLayoutPanelAll = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.CausesValidation = false;
            labelTitle.Location = new System.Drawing.Point(3, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(387, 15);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Avant de commencer le nettoyage, quelques informations importantes :";
            // 
            // labelSave
            // 
            labelSave.AutoSize = true;
            labelSave.CausesValidation = false;
            labelSave.Location = new System.Drawing.Point(3, 15);
            labelSave.Name = "labelSave";
            labelSave.Size = new System.Drawing.Size(541, 15);
            labelSave.TabIndex = 2;
            labelSave.Text = "- L\'opération aboutira par le redémarrage de l\'ordinateur. Sauvegardez tout docum" +
    "ent non enregistré.\r\n";
            // 
            // labelPrograms
            // 
            labelPrograms.AutoSize = true;
            labelPrograms.CausesValidation = false;
            labelPrograms.Location = new System.Drawing.Point(3, 55);
            labelPrograms.Name = "labelPrograms";
            labelPrograms.Size = new System.Drawing.Size(350, 15);
            labelPrograms.TabIndex = 4;
            labelPrograms.Text = "- Pour éviter les conflits, quittez toute application non essentielle.\r\n";
            // 
            // labelPlug
            // 
            labelPlug.AutoSize = true;
            labelPlug.CausesValidation = false;
            labelPlug.Location = new System.Drawing.Point(3, 95);
            labelPlug.Name = "labelPlug";
            labelPlug.Size = new System.Drawing.Size(721, 15);
            labelPlug.TabIndex = 6;
            labelPlug.Text = "- L\'ordinateur doit resté branché sur secteur durant toute la durée de l\'opératio" +
    "n afin d\'éviter un échec du system à un moment critique.";
            // 
            // flowLayoutPanelAll
            // 
            flowLayoutPanelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanelAll.AutoSize = true;
            flowLayoutPanelAll.CausesValidation = false;
            flowLayoutPanelAll.Controls.Add(labelTitle);
            flowLayoutPanelAll.Controls.Add(labelSave);
            flowLayoutPanelAll.Controls.Add(this.checkBoxSave);
            flowLayoutPanelAll.Controls.Add(labelPrograms);
            flowLayoutPanelAll.Controls.Add(this.checkBoxPrograms);
            flowLayoutPanelAll.Controls.Add(labelPlug);
            flowLayoutPanelAll.Controls.Add(this.checkBoxPlug);
            this.flowLayoutPanel1.SetFlowBreak(flowLayoutPanelAll, true);
            flowLayoutPanelAll.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanelAll.Location = new System.Drawing.Point(43, 0);
            flowLayoutPanelAll.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanelAll.Name = "flowLayoutPanelAll";
            flowLayoutPanelAll.Size = new System.Drawing.Size(727, 135);
            flowLayoutPanelAll.TabIndex = 10;
            flowLayoutPanelAll.WrapContents = false;
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.CausesValidation = false;
            this.checkBoxSave.Location = new System.Drawing.Point(3, 33);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(244, 19);
            this.checkBoxSave.TabIndex = 3;
            this.checkBoxSave.Text = "J\'ai sauvegardé tout travail non enregistré";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            this.checkBoxSave.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxPrograms
            // 
            this.checkBoxPrograms.AutoSize = true;
            this.checkBoxPrograms.Location = new System.Drawing.Point(3, 73);
            this.checkBoxPrograms.Name = "checkBoxPrograms";
            this.checkBoxPrograms.Size = new System.Drawing.Size(239, 19);
            this.checkBoxPrograms.TabIndex = 5;
            this.checkBoxPrograms.Text = "J\'ai fermé tout programme non essentiel";
            this.checkBoxPrograms.UseVisualStyleBackColor = true;
            this.checkBoxPrograms.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxPlug
            // 
            this.checkBoxPlug.AutoSize = true;
            this.checkBoxPlug.Location = new System.Drawing.Point(3, 113);
            this.checkBoxPlug.Name = "checkBoxPlug";
            this.checkBoxPlug.Size = new System.Drawing.Size(214, 19);
            this.checkBoxPlug.TabIndex = 7;
            this.checkBoxPlug.Text = "L\'ordinateur est branché sur secteur";
            this.checkBoxPlug.UseVisualStyleBackColor = true;
            this.checkBoxPlug.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.AccessibleDescription = "Une icône d\'avertissement";
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // buttonContinue
            // 
            this.buttonContinue.AutoSize = true;
            this.buttonContinue.CausesValidation = false;
            this.buttonContinue.Enabled = false;
            this.buttonContinue.Location = new System.Drawing.Point(0, 135);
            this.buttonContinue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(74, 25);
            this.buttonContinue.TabIndex = 9;
            this.buttonContinue.Text = "Continuer";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.Location = new System.Drawing.Point(74, 135);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(63, 25);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.CausesValidation = false;
            this.flowLayoutPanel1.Controls.Add(this.pictureBox);
            this.flowLayoutPanel1.Controls.Add(flowLayoutPanelAll);
            this.flowLayoutPanel1.Controls.Add(this.buttonContinue);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(770, 159);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // FormConfirm
            // 
            this.AcceptButton = this.buttonContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.buttonCancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(794, 183);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfirm";
            this.Opacity = 0.96D;
            this.Padding = new System.Windows.Forms.Padding(12);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Avertissement";
            flowLayoutPanelAll.ResumeLayout(false);
            flowLayoutPanelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
