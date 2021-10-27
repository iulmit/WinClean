﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace RaphaëlBardini.WinClean.Presentation
{
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
            this.components = new System.ComponentModel.Container();
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
            this.buttonAddScripts = new System.Windows.Forms.Button();
            this.MainMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectNothing = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectDebloat = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewScripts = new System.Windows.Forms.ListView();
            this.scriptHeaderName = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripScripts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGridScript = new System.Windows.Forms.PropertyGrid();
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
            this.contextMenuStripScripts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelAll
            // 
            resources.ApplyResources(tableLayoutPanelAll, "tableLayoutPanelAll");
            tableLayoutPanelAll.CausesValidation = false;
            tableLayoutPanelAll.Controls.Add(this.listViewScripts, 0, 0);
            tableLayoutPanelAll.Controls.Add(this.propertyGridScript, 1, 1);
            tableLayoutPanelAll.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
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
            tableLayoutPanelButtons.Controls.Add(this.buttonAddScripts, 1, 0);
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
            // buttonAddScripts
            // 
            resources.ApplyResources(this.buttonAddScripts, "buttonAddScripts");
            this.buttonAddScripts.CausesValidation = false;
            this.buttonAddScripts.Name = "buttonAddScripts";
            this.buttonAddScripts.UseMnemonic = false;
            this.buttonAddScripts.UseVisualStyleBackColor = true;
            this.buttonAddScripts.Click += new System.EventHandler(this.ButtonAddScripts_Click);
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
            resources.ApplyResources(MainMenuSelect, "MainMenuSelect");
            MainMenuSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuSelectAll,
            this.MainMenuSelectNothing,
            this.MainMenuSelectMaintenance,
            this.MainMenuSelectDebloat});
            MainMenuSelect.Name = "MainMenuSelect";
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
            this.listViewScripts.ContextMenuStrip = this.contextMenuStripScripts;
            this.listViewScripts.FullRowSelect = true;
            this.listViewScripts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewScripts.HideSelection = false;
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            this.listViewScripts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewScripts_ItemChecked);
            this.listViewScripts.SelectedIndexChanged += new System.EventHandler(this.ListViewScripts_SelectedIndexChanged);
            this.listViewScripts.Resize += new System.EventHandler(this.ListViewScripts_Resize);
            // 
            // scriptHeaderName
            // 
            resources.ApplyResources(this.scriptHeaderName, "scriptHeaderName");
            // 
            // contextMenuStripScripts
            // 
            this.contextMenuStripScripts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuDelete,
            this.ContextMenuRename,
            this.ContextMenuExecute,
            this.ContextMenuNew});
            this.contextMenuStripScripts.Name = "contextMenuStripScripts";
            this.contextMenuStripScripts.ShowImageMargin = false;
            resources.ApplyResources(this.contextMenuStripScripts, "contextMenuStripScripts");
            this.contextMenuStripScripts.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuScripts_Opening);
            // 
            // ContextMenuDelete
            // 
            this.ContextMenuDelete.Name = "ContextMenuDelete";
            resources.ApplyResources(this.ContextMenuDelete, "ContextMenuDelete");
            this.ContextMenuDelete.Click += new System.EventHandler(this.ContextMenuDelete_Click);
            // 
            // ContextMenuRename
            // 
            this.ContextMenuRename.Name = "ContextMenuRename";
            resources.ApplyResources(this.ContextMenuRename, "ContextMenuRename");
            this.ContextMenuRename.Click += new System.EventHandler(this.ContextMenuRename_Click);
            // 
            // ContextMenuExecute
            // 
            this.ContextMenuExecute.Name = "ContextMenuExecute";
            resources.ApplyResources(this.ContextMenuExecute, "ContextMenuExecute");
            this.ContextMenuExecute.Click += new System.EventHandler(this.ContextMenuExecute_Click);
            // 
            // ContextMenuNew
            // 
            this.ContextMenuNew.Name = "ContextMenuNew";
            resources.ApplyResources(this.ContextMenuNew, "ContextMenuNew");
            this.ContextMenuNew.Click += new System.EventHandler(this.ContextMenuNew_Click);
            // 
            // propertyGridScript
            // 
            resources.ApplyResources(this.propertyGridScript, "propertyGridScript");
            this.propertyGridScript.CausesValidation = false;
            this.propertyGridScript.Name = "propertyGridScript";
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
            this.contextMenuStripScripts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonExecuteScripts;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.ListView listViewScripts;
        private System.Windows.Forms.ToolStripMenuItem MainMenuAbout;
        private System.Windows.Forms.Button buttonAddScripts;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelectNothing;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelectMaintenance;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelectDebloat;
        private System.Windows.Forms.ColumnHeader scriptHeaderName;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRename;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuExecute;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripScripts;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuNew;
        private System.Windows.Forms.PropertyGrid propertyGridScript;
        private System.Windows.Forms.OpenFileDialog openFileDialogScripts;
    }
}
