// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace RaphaëlBardini.WinClean.Presentation.Forms;

partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainerAll = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanelAll = new System.Windows.Forms.TableLayoutPanel();
            this.listViewScripts = new System.Windows.Forms.ListView();
            this.scriptHeaderName = new System.Windows.Forms.ColumnHeader();
            this.scriptEditor = new RaphaëlBardini.WinClean.Presentation.Controls.ScriptEditor();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExecuteScripts = new System.Windows.Forms.Button();
            this.buttonAddScript = new System.Windows.Forms.Button();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.MainMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuClearLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectAllAdvised = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectNothing = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectDebloat = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogScript = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainerAll.ContentPanel.SuspendLayout();
            this.toolStripContainerAll.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerAll.SuspendLayout();
            this.tableLayoutPanelAll.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainerAll
            // 
            // 
            // toolStripContainerAll.BottomToolStripPanel
            // 
            this.toolStripContainerAll.BottomToolStripPanel.CausesValidation = false;
            resources.ApplyResources(this.toolStripContainerAll.BottomToolStripPanel, "toolStripContainerAll.BottomToolStripPanel");
            this.toolStripContainerAll.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainerAll.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainerAll.ContentPanel, "toolStripContainerAll.ContentPanel");
            this.toolStripContainerAll.ContentPanel.Controls.Add(this.tableLayoutPanelAll);
            this.toolStripContainerAll.ContentPanel.Controls.Add(this.tableLayoutPanelButtons);
            resources.ApplyResources(this.toolStripContainerAll, "toolStripContainerAll");
            // 
            // toolStripContainerAll.LeftToolStripPanel
            // 
            this.toolStripContainerAll.LeftToolStripPanel.CausesValidation = false;
            resources.ApplyResources(this.toolStripContainerAll.LeftToolStripPanel, "toolStripContainerAll.LeftToolStripPanel");
            this.toolStripContainerAll.LeftToolStripPanelVisible = false;
            this.toolStripContainerAll.Name = "toolStripContainerAll";
            // 
            // toolStripContainerAll.RightToolStripPanel
            // 
            this.toolStripContainerAll.RightToolStripPanel.CausesValidation = false;
            resources.ApplyResources(this.toolStripContainerAll.RightToolStripPanel, "toolStripContainerAll.RightToolStripPanel");
            this.toolStripContainerAll.RightToolStripPanelVisible = false;
            this.toolStripContainerAll.TabStop = false;
            // 
            // toolStripContainerAll.TopToolStripPanel
            // 
            this.toolStripContainerAll.TopToolStripPanel.CausesValidation = false;
            this.toolStripContainerAll.TopToolStripPanel.Controls.Add(this.mainMenuStrip);
            // 
            // tableLayoutPanelAll
            // 
            resources.ApplyResources(this.tableLayoutPanelAll, "tableLayoutPanelAll");
            this.tableLayoutPanelAll.CausesValidation = false;
            this.tableLayoutPanelAll.Controls.Add(this.listViewScripts, 0, 0);
            this.tableLayoutPanelAll.Controls.Add(this.scriptEditor, 1, 0);
            this.tableLayoutPanelAll.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelAll.Name = "tableLayoutPanelAll";
            // 
            // listViewScripts
            // 
            resources.ApplyResources(this.listViewScripts, "listViewScripts");
            this.listViewScripts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewScripts.CausesValidation = false;
            this.listViewScripts.CheckBoxes = true;
            this.listViewScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.scriptHeaderName});
            this.listViewScripts.FullRowSelect = true;
            this.listViewScripts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            this.listViewScripts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewScripts_ItemChecked);
            this.listViewScripts.SelectedIndexChanged += new System.EventHandler(this.ListViewScripts_SelectedIndexChanged);
            this.listViewScripts.Resize += new System.EventHandler(this.ListViewScripts_Resize);
            // 
            // scriptHeaderName
            // 
            resources.ApplyResources(this.scriptHeaderName, "scriptHeaderName");
            // 
            // scriptEditor
            // 
            resources.ApplyResources(this.scriptEditor, "scriptEditor");
            this.scriptEditor.CausesValidation = false;
            this.scriptEditor.Name = "scriptEditor";
            this.scriptEditor.Selected = null;
            // 
            // tableLayoutPanelButtons
            // 
            resources.ApplyResources(this.tableLayoutPanelButtons, "tableLayoutPanelButtons");
            this.tableLayoutPanelButtons.CausesValidation = false;
            this.tableLayoutPanelButtons.Controls.Add(this.buttonExecuteScripts, 2, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.buttonAddScript, 0, 0);
            this.tableLayoutPanelButtons.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            // 
            // buttonExecuteScripts
            // 
            resources.ApplyResources(this.buttonExecuteScripts, "buttonExecuteScripts");
            this.buttonExecuteScripts.CausesValidation = false;
            this.buttonExecuteScripts.Name = "buttonExecuteScripts";
            this.buttonExecuteScripts.UseMnemonic = false;
            this.buttonExecuteScripts.UseVisualStyleBackColor = true;
            this.buttonExecuteScripts.Click += new System.EventHandler(this.ButtonExecuteScripts_Click);
            // 
            // buttonAddScript
            // 
            resources.ApplyResources(this.buttonAddScript, "buttonAddScript");
            this.buttonAddScript.CausesValidation = false;
            this.buttonAddScript.Name = "buttonAddScript";
            this.buttonAddScript.UseMnemonic = false;
            this.buttonAddScript.UseVisualStyleBackColor = true;
            this.buttonAddScript.Click += new System.EventHandler(this.ButtonAddScript_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.AllowMerge = false;
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.mainMenuStrip, "mainMenuStrip");
            this.mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(2);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuFile,
            this.MainMenuSelect,
            this.MainMenuSettings,
            this.MainMenuHelp});
            this.mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainMenuStrip.Name = "mainMenuStrip";
            // 
            // MainMenuFile
            // 
            resources.ApplyResources(this.MainMenuFile, "MainMenuFile");
            this.MainMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuClearLogs,
            this.MainMenuQuit});
            this.MainMenuFile.Name = "MainMenuFile";
            // 
            // MainMenuClearLogs
            // 
            resources.ApplyResources(this.MainMenuClearLogs, "MainMenuClearLogs");
            this.MainMenuClearLogs.Name = "MainMenuClearLogs";
            this.MainMenuClearLogs.Click += new System.EventHandler(this.MainMenuStripClearLogs_Click);
            // 
            // MainMenuQuit
            // 
            this.MainMenuQuit.Name = "MainMenuQuit";
            resources.ApplyResources(this.MainMenuQuit, "MainMenuQuit");
            this.MainMenuQuit.Click += new System.EventHandler(this.MainMenuQuit_Click);
            // 
            // MainMenuSelect
            // 
            this.MainMenuSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuSelectAllAdvised,
            this.MainMenuSelectAll,
            this.MainMenuSelectNothing,
            this.MainMenuSelectMaintenance,
            this.MainMenuSelectDebloat});
            this.MainMenuSelect.Name = "MainMenuSelect";
            resources.ApplyResources(this.MainMenuSelect, "MainMenuSelect");
            // 
            // MainMenuSelectAllAdvised
            // 
            this.MainMenuSelectAllAdvised.Name = "MainMenuSelectAllAdvised";
            resources.ApplyResources(this.MainMenuSelectAllAdvised, "MainMenuSelectAllAdvised");
            this.MainMenuSelectAllAdvised.Click += new System.EventHandler(this.MainMenuSelectAllAdvised_Click);
            // 
            // MainMenuSelectAll
            // 
            this.MainMenuSelectAll.Name = "MainMenuSelectAll";
            resources.ApplyResources(this.MainMenuSelectAll, "MainMenuSelectAll");
            this.MainMenuSelectAll.Click += new System.EventHandler(this.MainMenuSelectAll_Click);
            // 
            // MainMenuSelectNothing
            // 
            this.MainMenuSelectNothing.Name = "MainMenuSelectNothing";
            resources.ApplyResources(this.MainMenuSelectNothing, "MainMenuSelectNothing");
            this.MainMenuSelectNothing.Click += new System.EventHandler(this.MainMenuSelectNothing_Click);
            // 
            // MainMenuSelectMaintenance
            // 
            this.MainMenuSelectMaintenance.Name = "MainMenuSelectMaintenance";
            resources.ApplyResources(this.MainMenuSelectMaintenance, "MainMenuSelectMaintenance");
            this.MainMenuSelectMaintenance.Click += new System.EventHandler(this.MainMenuSelectMaintenance_Click);
            // 
            // MainMenuSelectDebloat
            // 
            this.MainMenuSelectDebloat.Name = "MainMenuSelectDebloat";
            resources.ApplyResources(this.MainMenuSelectDebloat, "MainMenuSelectDebloat");
            this.MainMenuSelectDebloat.Click += new System.EventHandler(this.MainMenuSelectDebloat_Click);
            // 
            // MainMenuSettings
            // 
            resources.ApplyResources(this.MainMenuSettings, "MainMenuSettings");
            this.MainMenuSettings.Name = "MainMenuSettings";
            this.MainMenuSettings.Click += new System.EventHandler(this.MainMenuStripSettings_Click);
            // 
            // MainMenuHelp
            // 
            resources.ApplyResources(this.MainMenuHelp, "MainMenuHelp");
            this.MainMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuShowHelp,
            this.MainMenuAbout});
            this.MainMenuHelp.Name = "MainMenuHelp";
            // 
            // MainMenuShowHelp
            // 
            resources.ApplyResources(this.MainMenuShowHelp, "MainMenuShowHelp");
            this.MainMenuShowHelp.Name = "MainMenuShowHelp";
            this.MainMenuShowHelp.Click += new System.EventHandler(this.MainMenuStripShowHelp_Click);
            // 
            // MainMenuAbout
            // 
            this.MainMenuAbout.Name = "MainMenuAbout";
            resources.ApplyResources(this.MainMenuAbout, "MainMenuAbout");
            this.MainMenuAbout.Click += new System.EventHandler(this.MainMenuStripAbout_Click);
            // 
            // openFileDialogScript
            // 
            resources.ApplyResources(this.openFileDialogScript, "openFileDialogScript");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.Controls.Add(this.toolStripContainerAll);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Opacity = 0.96D;
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.toolStripContainerAll.ContentPanel.ResumeLayout(false);
            this.toolStripContainerAll.ContentPanel.PerformLayout();
            this.toolStripContainerAll.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerAll.TopToolStripPanel.PerformLayout();
            this.toolStripContainerAll.ResumeLayout(false);
            this.toolStripContainerAll.PerformLayout();
            this.tableLayoutPanelAll.ResumeLayout(false);
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.tableLayoutPanelButtons.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ListView listViewScripts;
    private System.Windows.Forms.ToolStripMenuItem MainMenuAbout;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelectAllAdvised;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelectNothing;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelectMaintenance;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelectDebloat;
    private System.Windows.Forms.ColumnHeader scriptHeaderName;
    private System.Windows.Forms.OpenFileDialog openFileDialogScript;
    private Controls.ScriptEditor scriptEditor;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAll;
    private System.Windows.Forms.ToolStripContainer toolStripContainerAll;
    private System.Windows.Forms.MenuStrip mainMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem MainMenuFile;
    private System.Windows.Forms.ToolStripMenuItem MainMenuClearLogs;
    private System.Windows.Forms.ToolStripMenuItem MainMenuQuit;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelect;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSettings;
    private System.Windows.Forms.ToolStripMenuItem MainMenuHelp;
    private System.Windows.Forms.ToolStripMenuItem MainMenuShowHelp;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
    private System.Windows.Forms.Button buttonExecuteScripts;
    private System.Windows.Forms.Button buttonAddScript;
    private ToolStripMenuItem MainMenuSelectAll;
}
