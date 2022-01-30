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
            System.Windows.Forms.Label labelScriptTimeoutHours;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            System.Windows.Forms.Label labelLogLevel;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
            System.Windows.Forms.Label labelPrompts;
            System.Windows.Forms.Label label1;
            this.comboBoxLogLevel = new System.Windows.Forms.ComboBox();
            this.numericUpDownPrompts = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAllowScriptCodeEdit = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.numericUpDownScriptTimeoutHours = new System.Windows.Forms.NumericUpDown();
            labelScriptTimeoutHours = new System.Windows.Forms.Label();
            labelLogLevel = new System.Windows.Forms.Label();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            labelPrompts = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrompts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScriptTimeoutHours)).BeginInit();
            this.SuspendLayout();
            // 
            // labelScriptTimeoutHours
            // 
            resources.ApplyResources(labelScriptTimeoutHours, "labelScriptTimeoutHours");
            labelScriptTimeoutHours.CausesValidation = false;
            labelScriptTimeoutHours.Name = "labelScriptTimeoutHours";
            // 
            // labelLogLevel
            // 
            resources.ApplyResources(labelLogLevel, "labelLogLevel");
            labelLogLevel.CausesValidation = false;
            labelLogLevel.Name = "labelLogLevel";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.CausesValidation = false;
            resources.ApplyResources(tableLayoutPanel, "tableLayoutPanel");
            tableLayoutPanel.Controls.Add(this.numericUpDownScriptTimeoutHours, 1, 0);
            tableLayoutPanel.Controls.Add(this.comboBoxLogLevel, 1, 1);
            tableLayoutPanel.Controls.Add(labelScriptTimeoutHours, 0, 0);
            tableLayoutPanel.Controls.Add(labelLogLevel, 0, 1);
            tableLayoutPanel.Controls.Add(labelPrompts, 0, 2);
            tableLayoutPanel.Controls.Add(this.numericUpDownPrompts, 1, 2);
            tableLayoutPanel.Controls.Add(this.checkBoxAllowScriptCodeEdit, 1, 3);
            tableLayoutPanel.Controls.Add(label1, 0, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // comboBoxLogLevel
            // 
            this.comboBoxLogLevel.CausesValidation = false;
            resources.ApplyResources(this.comboBoxLogLevel, "comboBoxLogLevel");
            this.comboBoxLogLevel.Name = "comboBoxLogLevel";
            // 
            // labelPrompts
            // 
            resources.ApplyResources(labelPrompts, "labelPrompts");
            labelPrompts.CausesValidation = false;
            labelPrompts.Name = "labelPrompts";
            // 
            // numericUpDownPrompts
            // 
            this.numericUpDownPrompts.CausesValidation = false;
            resources.ApplyResources(this.numericUpDownPrompts, "numericUpDownPrompts");
            this.numericUpDownPrompts.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPrompts.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPrompts.Name = "numericUpDownPrompts";
            this.numericUpDownPrompts.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // checkBoxAllowScriptCodeEdit
            // 
            resources.ApplyResources(this.checkBoxAllowScriptCodeEdit, "checkBoxAllowScriptCodeEdit");
            this.checkBoxAllowScriptCodeEdit.CausesValidation = false;
            this.checkBoxAllowScriptCodeEdit.Name = "checkBoxAllowScriptCodeEdit";
            this.checkBoxAllowScriptCodeEdit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.CausesValidation = false;
            label1.Name = "label1";
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
            // numericUpDownScriptTimeoutHours
            // 
            this.numericUpDownScriptTimeoutHours.CausesValidation = false;
            resources.ApplyResources(this.numericUpDownScriptTimeoutHours, "numericUpDownScriptTimeoutHours");
            this.numericUpDownScriptTimeoutHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScriptTimeoutHours.Name = "numericUpDownScriptTimeoutHours";
            this.numericUpDownScriptTimeoutHours.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrompts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScriptTimeoutHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ComboBox comboBoxLogLevel;
    private Button buttonCancel;
    private Button buttonOK;
    private NumericUpDown numericUpDownPrompts;
    private CheckBox checkBoxAllowScriptCodeEdit;
    private NumericUpDown numericUpDownScriptTimeoutHours;
}
