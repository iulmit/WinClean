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
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAll;
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox = new RaphaëlBardini.WinClean.Presentation.IconPictureBox();
            flowLayoutPanelAll = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelAll
            // 
            flowLayoutPanelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            flowLayoutPanelAll.CausesValidation = false;
            flowLayoutPanelAll.Controls.Add(this.label1);
            flowLayoutPanelAll.Controls.Add(this.iconPictureBox);
            flowLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelAll.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanelAll.Name = "flowLayoutPanelAll";
            flowLayoutPanelAll.Size = new System.Drawing.Size(800, 450);
            flowLayoutPanelAll.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Avant de commencer le nettoyage, quelques informations importantes :";
            // 
            // iconPictureBox
            //
            this.iconPictureBox.Location = new System.Drawing.Point(3, 18);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(100, 50);
            this.iconPictureBox.TabIndex = 1;
            this.iconPictureBox.TabStop = false;
            // 
            // FormConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(flowLayoutPanelAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfirm";
            this.Opacity = 0.96D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormConfirm";
            flowLayoutPanelAll.ResumeLayout(false);
            flowLayoutPanelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Presentation.IconPictureBox iconPictureBox;
    }
}
