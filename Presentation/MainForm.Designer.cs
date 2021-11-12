// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace RaphaëlBardini.WinClean.Presentation;

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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelAll;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripContainer toolStripContainerAll;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
            System.Windows.Forms.MenuStrip mainMenuStrip;
            System.Windows.Forms.ToolStripMenuItem MainMenuFile;
            System.Windows.Forms.ToolStripMenuItem MainMenuClearLogs;
            System.Windows.Forms.ToolStripMenuItem MainMenuQuit;
            System.Windows.Forms.ToolStripMenuItem MainMenuSelect;
            System.Windows.Forms.ToolStripMenuItem MainMenuSettings;
            System.Windows.Forms.ToolStripMenuItem MainMenuHelp;
            System.Windows.Forms.ToolStripMenuItem MainMenuShowHelp;
            this.buttonExecuteScripts = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonAddScript = new System.Windows.Forms.Button();
            this.MainMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectNothing = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectDebloat = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewScripts = new System.Windows.Forms.ListView();
            this.scriptHeaderName = new System.Windows.Forms.ColumnHeader();
            this.scriptEditor = new RaphaëlBardini.WinClean.Presentation.ScriptEditor();
            this.openFileDialogScripts = new System.Windows.Forms.OpenFileDialog();
            tableLayoutPanelAll = new System.Windows.Forms.TableLayoutPanel();
            toolStripContainerAll = new System.Windows.Forms.ToolStripContainer();
            tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            MainMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuClearLogs = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuSelect = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanelAll.SuspendLayout();
            toolStripContainerAll.ContentPanel.SuspendLayout();
            toolStripContainerAll.TopToolStripPanel.SuspendLayout();
            toolStripContainerAll.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelAll
            // 
            resources.ApplyResources(tableLayoutPanelAll, "tableLayoutPanelAll");
            tableLayoutPanelAll.CausesValidation = false;
            tableLayoutPanelAll.Controls.Add(this.listViewScripts, 0, 0);
            tableLayoutPanelAll.Controls.Add(this.scriptEditor, 1, 0);
            tableLayoutPanelAll.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelAll.Name = "tableLayoutPanelAll";
            // 
            // toolStripContainerAll
            // 
            // 
            // toolStripContainerAll.BottomToolStripPanel
            // 
            toolStripContainerAll.BottomToolStripPanel.CausesValidation = false;
            resources.ApplyResources(toolStripContainerAll.BottomToolStripPanel, "toolStripContainerAll.BottomToolStripPanel");
            toolStripContainerAll.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainerAll.ContentPanel
            // 
            resources.ApplyResources(toolStripContainerAll.ContentPanel, "toolStripContainerAll.ContentPanel");
            toolStripContainerAll.ContentPanel.Controls.Add(tableLayoutPanelAll);
            toolStripContainerAll.ContentPanel.Controls.Add(tableLayoutPanelButtons);
            resources.ApplyResources(toolStripContainerAll, "toolStripContainerAll");
            // 
            // toolStripContainerAll.LeftToolStripPanel
            // 
            toolStripContainerAll.LeftToolStripPanel.CausesValidation = false;
            resources.ApplyResources(toolStripContainerAll.LeftToolStripPanel, "toolStripContainerAll.LeftToolStripPanel");
            toolStripContainerAll.LeftToolStripPanelVisible = false;
            toolStripContainerAll.Name = "toolStripContainerAll";
            // 
            // toolStripContainerAll.RightToolStripPanel
            // 
            toolStripContainerAll.RightToolStripPanel.CausesValidation = false;
            resources.ApplyResources(toolStripContainerAll.RightToolStripPanel, "toolStripContainerAll.RightToolStripPanel");
            toolStripContainerAll.RightToolStripPanelVisible = false;
            toolStripContainerAll.TabStop = false;
            // 
            // toolStripContainerAll.TopToolStripPanel
            // 
            toolStripContainerAll.TopToolStripPanel.CausesValidation = false;
            toolStripContainerAll.TopToolStripPanel.Controls.Add(mainMenuStrip);
            // 
            // tableLayoutPanelButtons
            // 
            resources.ApplyResources(tableLayoutPanelButtons, "tableLayoutPanelButtons");
            tableLayoutPanelButtons.CausesValidation = false;
            tableLayoutPanelButtons.Controls.Add(this.buttonExecuteScripts, 3, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonQuit, 4, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonAddScript, 1, 0);
            tableLayoutPanelButtons.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
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
            // buttonQuit
            // 
            resources.ApplyResources(this.buttonQuit, "buttonQuit");
            this.buttonQuit.CausesValidation = false;
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.UseMnemonic = false;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
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
            mainMenuStrip.AllowMerge = false;
            mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(mainMenuStrip, "mainMenuStrip");
            mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(2);
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainMenuFile,
            MainMenuSelect,
            MainMenuSettings,
            MainMenuHelp});
            mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            mainMenuStrip.Name = "mainMenuStrip";
            // 
            // MainMenuFile
            // 
            resources.ApplyResources(MainMenuFile, "MainMenuFile");
            MainMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainMenuClearLogs,
            MainMenuQuit});
            MainMenuFile.Name = "MainMenuFile";
            // 
            // MainMenuClearLogs
            // 
            resources.ApplyResources(MainMenuClearLogs, "MainMenuClearLogs");
            MainMenuClearLogs.Name = "MainMenuClearLogs";
            MainMenuClearLogs.Click += new System.EventHandler(this.MainMenuStripClearLogs_Click);
            // 
            // MainMenuQuit
            // 
            MainMenuQuit.Name = "MainMenuQuit";
            resources.ApplyResources(MainMenuQuit, "MainMenuQuit");
            MainMenuQuit.Click += new System.EventHandler(this.MainMenuQuit_Click);
            // 
            // MainMenuSelect
            // 
            MainMenuSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuSelectAll,
            this.MainMenuSelectNothing,
            this.MainMenuSelectMaintenance,
            this.MainMenuSelectDebloat});
            MainMenuSelect.Name = "MainMenuSelect";
            resources.ApplyResources(MainMenuSelect, "MainMenuSelect");
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
            resources.ApplyResources(MainMenuSettings, "MainMenuSettings");
            MainMenuSettings.Name = "MainMenuSettings";
            MainMenuSettings.Click += new System.EventHandler(this.MainMenuStripSettings_Click);
            // 
            // MainMenuHelp
            // 
            resources.ApplyResources(MainMenuHelp, "MainMenuHelp");
            MainMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainMenuShowHelp,
            this.MainMenuAbout});
            MainMenuHelp.Name = "MainMenuHelp";
            // 
            // MainMenuShowHelp
            // 
            resources.ApplyResources(MainMenuShowHelp, "MainMenuShowHelp");
            MainMenuShowHelp.Name = "MainMenuShowHelp";
            MainMenuShowHelp.Click += new System.EventHandler(this.MainMenuStripShowHelp_Click);
            // 
            // MainMenuAbout
            // 
            this.MainMenuAbout.Name = "MainMenuAbout";
            resources.ApplyResources(this.MainMenuAbout, "MainMenuAbout");
            this.MainMenuAbout.Click += new System.EventHandler(this.MainMenuStripAbout_Click);
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
            this.listViewScripts.HideSelection = false;
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            this.listViewScripts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewScripts_ItemChecked);
            this.listViewScripts.SelectedIndexChanged += new System.EventHandler(this.ListViewScripts_SelectedIndexChanged);
            this.listViewScripts.Leave += new System.EventHandler(this.ListViewScripts_Leave);
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
            // openFileDialogScripts
            // 
            this.openFileDialogScripts.Multiselect = true;
            resources.ApplyResources(this.openFileDialogScripts, "openFileDialogScripts");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.Controls.Add(toolStripContainerAll);
            this.DoubleBuffered = true;
            this.MainMenuStrip = mainMenuStrip;
            this.Name = "MainForm";
            this.Opacity = 0.96D;
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            tableLayoutPanelAll.ResumeLayout(false);
            toolStripContainerAll.ContentPanel.ResumeLayout(false);
            toolStripContainerAll.ContentPanel.PerformLayout();
            toolStripContainerAll.TopToolStripPanel.ResumeLayout(false);
            toolStripContainerAll.TopToolStripPanel.PerformLayout();
            toolStripContainerAll.ResumeLayout(false);
            toolStripContainerAll.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button buttonExecuteScripts;
    private System.Windows.Forms.Button buttonQuit;
    private System.Windows.Forms.ListView listViewScripts;
    private System.Windows.Forms.ToolStripMenuItem MainMenuAbout;
    private System.Windows.Forms.Button buttonAddScript;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelectAll;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelectNothing;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelectMaintenance;
    private System.Windows.Forms.ToolStripMenuItem MainMenuSelectDebloat;
    private System.Windows.Forms.ColumnHeader scriptHeaderName;
    private System.Windows.Forms.OpenFileDialog openFileDialogScripts;
    private ScriptEditor scriptEditor;
}
