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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.checkBoxPrograms = new System.Windows.Forms.CheckBox();
            this.checkBoxPlug = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            labelTitle = new System.Windows.Forms.Label();
            labelSave = new System.Windows.Forms.Label();
            labelPrograms = new System.Windows.Forms.Label();
            labelPlug = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.CausesValidation = false;
            labelTitle.Location = new System.Drawing.Point(144, 8);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(512, 16);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Avant de commencer le nettoyage, quelques informations importantes :";
            // 
            // labelSave
            // 
            labelSave.CausesValidation = false;
            labelSave.Location = new System.Drawing.Point(144, 40);
            labelSave.Name = "labelSave";
            labelSave.Size = new System.Drawing.Size(512, 32);
            labelSave.TabIndex = 2;
            labelSave.Text = "- L\'opération aboutira par le redémarrage de l\'ordinateur. Sauvegardez tout docum" +
    "ent non enregistré.\r\n";
            // 
            // labelPrograms
            // 
            labelPrograms.CausesValidation = false;
            labelPrograms.Location = new System.Drawing.Point(144, 104);
            labelPrograms.Name = "labelPrograms";
            labelPrograms.Size = new System.Drawing.Size(512, 16);
            labelPrograms.TabIndex = 4;
            labelPrograms.Text = "- Pour éviter les conflits, quittez toute application non essentielle.\r\n\r\n";
            // 
            // labelPlug
            // 
            labelPlug.CausesValidation = false;
            labelPlug.Location = new System.Drawing.Point(144, 152);
            labelPlug.Name = "labelPlug";
            labelPlug.Size = new System.Drawing.Size(512, 32);
            labelPlug.TabIndex = 6;
            labelPlug.Text = "- L\'ordinateur doit resté branché sur secteur durant toute la durée de l\'opératio" +
    "n afin d\'éviter un échec du system à un moment critique.";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(24, 56);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(96, 96);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.CausesValidation = false;
            this.checkBoxSave.Location = new System.Drawing.Point(152, 72);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(504, 24);
            this.checkBoxSave.TabIndex = 3;
            this.checkBoxSave.Text = "J\'ai sauvegardé tout travail non enregistré";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            this.checkBoxSave.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxPrograms
            // 
            this.checkBoxPrograms.Location = new System.Drawing.Point(152, 120);
            this.checkBoxPrograms.Name = "checkBoxPrograms";
            this.checkBoxPrograms.Size = new System.Drawing.Size(504, 24);
            this.checkBoxPrograms.TabIndex = 5;
            this.checkBoxPrograms.Text = "J\'ai fermé tout programme non essentiel";
            this.checkBoxPrograms.UseVisualStyleBackColor = true;
            this.checkBoxPrograms.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxPlug
            // 
            this.checkBoxPlug.Location = new System.Drawing.Point(152, 184);
            this.checkBoxPlug.Name = "checkBoxPlug";
            this.checkBoxPlug.Size = new System.Drawing.Size(504, 24);
            this.checkBoxPlug.TabIndex = 7;
            this.checkBoxPlug.Text = "L\'ordinateur est branché sur secteur";
            this.checkBoxPlug.UseVisualStyleBackColor = true;
            this.checkBoxPlug.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(552, 216);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(104, 24);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.CausesValidation = false;
            this.buttonContinue.Enabled = false;
            this.buttonContinue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonContinue.Location = new System.Drawing.Point(432, 216);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(104, 24);
            this.buttonContinue.TabIndex = 9;
            this.buttonContinue.Text = "Continuer";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // FormConfirm
            // 
            this.AcceptButton = this.buttonContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.buttonCancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(664, 249);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxPlug);
            this.Controls.Add(labelPlug);
            this.Controls.Add(this.checkBoxPrograms);
            this.Controls.Add(labelPrograms);
            this.Controls.Add(this.checkBoxSave);
            this.Controls.Add(labelTitle);
            this.Controls.Add(labelSave);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfirm";
            this.Opacity = 0.96D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormConfirm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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
    }
}
