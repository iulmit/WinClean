// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace RaphaëlBardini.WinClean.Presentation.Forms;

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
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            tableLayoutPanel.Controls.Add(this.labelDescription, 1, 2);
            tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            tableLayoutPanel.Controls.Add(this.linkLabelRepoURL, 1, 4);
            tableLayoutPanel.Location = new System.Drawing.Point(11, 11);
            tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new System.Drawing.Size(362, 153);
            tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            logoPictureBox.Image = global::RaphaëlBardini.WinClean.Resources.Images.Splash;
            logoPictureBox.Location = new System.Drawing.Point(0, 0);
            logoPictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 11, 0);
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 5);
            logoPictureBox.Size = new System.Drawing.Size(117, 153);
            logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 12;
            logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProductName.AutoEllipsis = true;
            this.labelProductName.CausesValidation = false;
            this.labelProductName.Location = new System.Drawing.Point(128, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(234, 30);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelProductName.UseMnemonic = false;
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoEllipsis = true;
            this.labelVersion.CausesValidation = false;
            this.labelVersion.Location = new System.Drawing.Point(128, 30);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(234, 30);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelVersion.UseMnemonic = false;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.AutoEllipsis = true;
            this.labelDescription.CausesValidation = false;
            this.labelDescription.Location = new System.Drawing.Point(128, 60);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(234, 30);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDescription.UseMnemonic = false;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCompanyName.AutoEllipsis = true;
            this.labelCompanyName.CausesValidation = false;
            this.labelCompanyName.Location = new System.Drawing.Point(128, 90);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(0);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(234, 30);
            this.labelCompanyName.TabIndex = 0;
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCompanyName.UseMnemonic = false;
            // 
            // linkLabelRepoURL
            // 
            this.linkLabelRepoURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelRepoURL.AutoEllipsis = true;
            this.linkLabelRepoURL.CausesValidation = false;
            this.linkLabelRepoURL.Location = new System.Drawing.Point(128, 120);
            this.linkLabelRepoURL.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabelRepoURL.Name = "linkLabelRepoURL";
            this.linkLabelRepoURL.Size = new System.Drawing.Size(234, 33);
            this.linkLabelRepoURL.TabIndex = 0;
            this.linkLabelRepoURL.TabStop = true;
            this.linkLabelRepoURL.Text = "GitHub";
            this.linkLabelRepoURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelRepoURL.UseMnemonic = false;
            this.linkLabelRepoURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelRepoURL_LinkClicked);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.CausesValidation = false;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(298, 175);
            this.okButton.Margin = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoEllipsis = true;
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.CausesValidation = false;
            this.labelCopyright.Location = new System.Drawing.Point(11, 175);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.labelCopyright.MinimumSize = new System.Drawing.Size(0, 23);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(0, 23);
            this.labelCopyright.TabIndex = 0;
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCopyright.UseMnemonic = false;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(384, 208);
            this.Controls.Add(this.okButton);
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(this.labelCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Opacity = 0.96D;
            this.Padding = new System.Windows.Forms.Padding(11);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
