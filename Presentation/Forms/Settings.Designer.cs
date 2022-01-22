// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace RaphaëlBardini.WinClean.Presentation.Forms;

partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            System.Windows.Forms.Label labelLogLevel;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
            this.comboBoxLogLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxScriptTimeout = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            labelScriptTimeout = new System.Windows.Forms.Label();
            labelLogLevel = new System.Windows.Forms.Label();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel.SuspendLayout();
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
            // tableLayoutPanel
            // 
            resources.ApplyResources(tableLayoutPanel, "tableLayoutPanel");
            tableLayoutPanel.Controls.Add(this.comboBoxLogLevel, 1, 1);
            tableLayoutPanel.Controls.Add(labelScriptTimeout, 0, 0);
            tableLayoutPanel.Controls.Add(labelLogLevel, 0, 1);
            tableLayoutPanel.Controls.Add(this.comboBoxScriptTimeout, 1, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // comboBoxLogLevel
            // 
            this.comboBoxLogLevel.CausesValidation = false;
            resources.ApplyResources(this.comboBoxLogLevel, "comboBoxLogLevel");
            this.comboBoxLogLevel.Name = "comboBoxLogLevel";
            // 
            // comboBoxScriptTimeout
            // 
            this.comboBoxScriptTimeout.CausesValidation = false;
            resources.ApplyResources(this.comboBoxScriptTimeout, "comboBoxScriptTimeout");
            this.comboBoxScriptTimeout.Name = "comboBoxScriptTimeout";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.CausesValidation = false;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.buttonCancel;
            this.CausesValidation = false;
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Opacity = 0.96D;
            tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ComboBox comboBoxLogLevel;
    private ComboBox comboBoxScriptTimeout;
    private Button buttonCancel;
    private Button buttonOK;
}
