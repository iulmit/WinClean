// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class AboutBox
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            System.Windows.Forms.PictureBox logoPictureBox;
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.linkLabelRepoURL = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.labelCopyright = new System.Windows.Forms.Label();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            logoPictureBox = new System.Windows.Forms.PictureBox();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.CausesValidation = false;
            resources.ApplyResources(tableLayoutPanel, "tableLayoutPanel");
            tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            tableLayoutPanel.Controls.Add(this.labelDescription, 1, 2);
            tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            tableLayoutPanel.Controls.Add(this.linkLabelRepoURL, 1, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // logoPictureBox
            // 
            resources.ApplyResources(logoPictureBox, "logoPictureBox");
            logoPictureBox.Image = global::RaphaëlBardini.WinClean.Resources.Images.Splash;
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 5);
            logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            resources.ApplyResources(this.labelProductName, "labelProductName");
            this.labelProductName.AutoEllipsis = true;
            this.labelProductName.CausesValidation = false;
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.UseMnemonic = false;
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.AutoEllipsis = true;
            this.labelVersion.CausesValidation = false;
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.UseMnemonic = false;
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.AutoEllipsis = true;
            this.labelDescription.CausesValidation = false;
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.UseMnemonic = false;
            // 
            // labelCompanyName
            // 
            resources.ApplyResources(this.labelCompanyName, "labelCompanyName");
            this.labelCompanyName.AutoEllipsis = true;
            this.labelCompanyName.CausesValidation = false;
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.UseMnemonic = false;
            // 
            // linkLabelRepoURL
            // 
            resources.ApplyResources(this.linkLabelRepoURL, "linkLabelRepoURL");
            this.linkLabelRepoURL.AutoEllipsis = true;
            this.linkLabelRepoURL.CausesValidation = false;
            this.linkLabelRepoURL.Name = "linkLabelRepoURL";
            this.linkLabelRepoURL.TabStop = true;
            this.linkLabelRepoURL.UseMnemonic = false;
            this.linkLabelRepoURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelRepoURL_LinkClicked);
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.CausesValidation = false;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Name = "okButton";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoEllipsis = true;
            resources.ApplyResources(this.labelCopyright, "labelCopyright");
            this.labelCopyright.CausesValidation = false;
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.UseMnemonic = false;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.Controls.Add(this.okButton);
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(this.labelCopyright);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Opacity = 0.96D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.LinkLabel linkLabelRepoURL;
        private System.Windows.Forms.Label labelCopyright;
    }
}
