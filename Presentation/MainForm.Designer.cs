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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            tableLayoutPanelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tableLayoutPanelAll.CausesValidation = false;
            tableLayoutPanelAll.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanelAll.ColumnCount = 2;
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelAll.Controls.Add(this.listViewScripts, 0, 0);
            tableLayoutPanelAll.Controls.Add(this.scriptEditor, 1, 0);
            tableLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelAll.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelAll.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelAll.Name = "tableLayoutPanelAll";
            tableLayoutPanelAll.RowCount = 1;
            tableLayoutPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAll.Size = new System.Drawing.Size(762, 384);
            tableLayoutPanelAll.TabIndex = 0;
            // 
            // toolStripContainerAll
            // 
            // 
            // toolStripContainerAll.BottomToolStripPanel
            // 
            toolStripContainerAll.BottomToolStripPanel.CausesValidation = false;
            toolStripContainerAll.BottomToolStripPanel.Enabled = false;
            toolStripContainerAll.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainerAll.ContentPanel
            // 
            toolStripContainerAll.ContentPanel.AutoScroll = true;
            toolStripContainerAll.ContentPanel.Controls.Add(tableLayoutPanelAll);
            toolStripContainerAll.ContentPanel.Controls.Add(tableLayoutPanelButtons);
            toolStripContainerAll.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            toolStripContainerAll.ContentPanel.Size = new System.Drawing.Size(762, 420);
            toolStripContainerAll.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainerAll.LeftToolStripPanel
            // 
            toolStripContainerAll.LeftToolStripPanel.CausesValidation = false;
            toolStripContainerAll.LeftToolStripPanel.Enabled = false;
            toolStripContainerAll.LeftToolStripPanelVisible = false;
            toolStripContainerAll.Location = new System.Drawing.Point(11, 0);
            toolStripContainerAll.Margin = new System.Windows.Forms.Padding(0);
            toolStripContainerAll.Name = "toolStripContainerAll";
            // 
            // toolStripContainerAll.RightToolStripPanel
            // 
            toolStripContainerAll.RightToolStripPanel.CausesValidation = false;
            toolStripContainerAll.RightToolStripPanel.Enabled = false;
            toolStripContainerAll.RightToolStripPanelVisible = false;
            toolStripContainerAll.Size = new System.Drawing.Size(762, 444);
            toolStripContainerAll.TabIndex = 0;
            toolStripContainerAll.TabStop = false;
            // 
            // toolStripContainerAll.TopToolStripPanel
            // 
            toolStripContainerAll.TopToolStripPanel.CausesValidation = false;
            toolStripContainerAll.TopToolStripPanel.Controls.Add(mainMenuStrip);
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tableLayoutPanelButtons.CausesValidation = false;
            tableLayoutPanelButtons.ColumnCount = 5;
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.Controls.Add(this.buttonExecuteScripts, 3, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonQuit, 4, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonAddScript, 1, 0);
            tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            tableLayoutPanelButtons.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new System.Drawing.Point(0, 384);
            tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelButtons.Size = new System.Drawing.Size(762, 36);
            tableLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonExecuteScripts
            // 
            this.buttonExecuteScripts.AccessibleDescription = "Execute the selected scripts.";
            this.buttonExecuteScripts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonExecuteScripts.AutoSize = true;
            this.buttonExecuteScripts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExecuteScripts.CausesValidation = false;
            this.buttonExecuteScripts.Enabled = false;
            this.buttonExecuteScripts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonExecuteScripts.Location = new System.Drawing.Point(595, 11);
            this.buttonExecuteScripts.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.buttonExecuteScripts.Name = "buttonExecuteScripts";
            this.buttonExecuteScripts.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonExecuteScripts.Size = new System.Drawing.Size(109, 25);
            this.buttonExecuteScripts.TabIndex = 4;
            this.buttonExecuteScripts.Text = "Execute scripts";
            this.buttonExecuteScripts.UseMnemonic = false;
            this.buttonExecuteScripts.UseVisualStyleBackColor = true;
            this.buttonExecuteScripts.Click += new System.EventHandler(this.ButtonExecuteScripts_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.AccessibleName = "Exit the application.";
            this.buttonQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonQuit.AutoSize = true;
            this.buttonQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonQuit.CausesValidation = false;
            this.buttonQuit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonQuit.Location = new System.Drawing.Point(711, 11);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonQuit.Size = new System.Drawing.Size(50, 25);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "Exit";
            this.buttonQuit.UseMnemonic = false;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // buttonAddScript
            // 
            this.buttonAddScript.AccessibleDescription = "Add a new script.";
            this.buttonAddScript.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddScript.AutoSize = true;
            this.buttonAddScript.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddScript.CausesValidation = false;
            this.buttonAddScript.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAddScript.Location = new System.Drawing.Point(153, 11);
            this.buttonAddScript.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddScript.Name = "buttonAddScript";
            this.buttonAddScript.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonAddScript.Size = new System.Drawing.Size(85, 25);
            this.buttonAddScript.TabIndex = 3;
            this.buttonAddScript.Text = "Add script";
            this.buttonAddScript.UseMnemonic = false;
            this.buttonAddScript.UseVisualStyleBackColor = true;
            this.buttonAddScript.Click += new System.EventHandler(this.ButtonAddScript_Click);
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.AllowMerge = false;
            mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            mainMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(2);
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainMenuFile,
            MainMenuSelect,
            MainMenuSettings,
            MainMenuHelp});
            mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(762, 24);
            mainMenuStrip.TabIndex = 1;
            // 
            // MainMenuFile
            // 
            MainMenuFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainMenuClearLogs,
            MainMenuQuit});
            MainMenuFile.Name = "MainMenuFile";
            MainMenuFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            MainMenuFile.Size = new System.Drawing.Size(37, 20);
            MainMenuFile.Text = "&File";
            // 
            // MainMenuClearLogs
            // 
            MainMenuClearLogs.AccessibleDescription = "Erase all application log files.";
            MainMenuClearLogs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuClearLogs.Name = "MainMenuClearLogs";
            MainMenuClearLogs.Size = new System.Drawing.Size(126, 22);
            MainMenuClearLogs.Text = "&Clear logs";
            MainMenuClearLogs.Click += new System.EventHandler(this.MainMenuStripClearLogs_Click);
            // 
            // MainMenuQuit
            // 
            MainMenuQuit.Name = "MainMenuQuit";
            MainMenuQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            MainMenuQuit.ShowShortcutKeys = false;
            MainMenuQuit.Size = new System.Drawing.Size(126, 22);
            MainMenuQuit.Text = "&Exit";
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
            MainMenuSelect.Size = new System.Drawing.Size(50, 20);
            MainMenuSelect.Text = "&Select";
            // 
            // MainMenuSelectAll
            // 
            this.MainMenuSelectAll.Name = "MainMenuSelectAll";
            this.MainMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.MainMenuSelectAll.Size = new System.Drawing.Size(143, 22);
            this.MainMenuSelectAll.Text = "&All";
            this.MainMenuSelectAll.Click += new System.EventHandler(this.MainMenuSelectAll_Click);
            // 
            // MainMenuSelectNothing
            // 
            this.MainMenuSelectNothing.Name = "MainMenuSelectNothing";
            this.MainMenuSelectNothing.Size = new System.Drawing.Size(143, 22);
            this.MainMenuSelectNothing.Text = "&None";
            this.MainMenuSelectNothing.Click += new System.EventHandler(this.MainMenuSelectNothing_Click);
            // 
            // MainMenuSelectMaintenance
            // 
            this.MainMenuSelectMaintenance.Name = "MainMenuSelectMaintenance";
            this.MainMenuSelectMaintenance.Size = new System.Drawing.Size(143, 22);
            this.MainMenuSelectMaintenance.Text = "&Maintenance";
            this.MainMenuSelectMaintenance.Click += new System.EventHandler(this.MainMenuSelectMaintenance_Click);
            // 
            // MainMenuSelectDebloat
            // 
            this.MainMenuSelectDebloat.Name = "MainMenuSelectDebloat";
            this.MainMenuSelectDebloat.Size = new System.Drawing.Size(143, 22);
            this.MainMenuSelectDebloat.Text = "&Debloat";
            this.MainMenuSelectDebloat.Click += new System.EventHandler(this.MainMenuSelectDebloat_Click);
            // 
            // MainMenuSettings
            // 
            MainMenuSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuSettings.Name = "MainMenuSettings";
            MainMenuSettings.Size = new System.Drawing.Size(61, 20);
            MainMenuSettings.Text = "&Settings";
            MainMenuSettings.Click += new System.EventHandler(this.MainMenuStripSettings_Click);
            // 
            // MainMenuHelp
            // 
            MainMenuHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainMenuShowHelp,
            this.MainMenuAbout});
            MainMenuHelp.Name = "MainMenuHelp";
            MainMenuHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            MainMenuHelp.Size = new System.Drawing.Size(44, 20);
            MainMenuHelp.Text = "&Help";
            // 
            // MainMenuShowHelp
            // 
            MainMenuShowHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuShowHelp.Name = "MainMenuShowHelp";
            MainMenuShowHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            MainMenuShowHelp.Size = new System.Drawing.Size(148, 22);
            MainMenuShowHelp.Text = "Show help";
            MainMenuShowHelp.Click += new System.EventHandler(this.MainMenuStripShowHelp_Click);
            // 
            // MainMenuAbout
            // 
            this.MainMenuAbout.Name = "MainMenuAbout";
            this.MainMenuAbout.Size = new System.Drawing.Size(148, 22);
            this.MainMenuAbout.Click += new System.EventHandler(this.MainMenuStripAbout_Click);
            // 
            // listViewScripts
            // 
            this.listViewScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewScripts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewScripts.CausesValidation = false;
            this.listViewScripts.CheckBoxes = true;
            this.listViewScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.scriptHeaderName});
            this.listViewScripts.FullRowSelect = true;
            this.listViewScripts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewScripts.HideSelection = false;
            this.listViewScripts.Location = new System.Drawing.Point(5, 5);
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.Size = new System.Drawing.Size(372, 374);
            this.listViewScripts.TabIndex = 7;
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            this.listViewScripts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewScripts_ItemChecked);
            this.listViewScripts.SelectedIndexChanged += new System.EventHandler(this.ListViewScripts_SelectedIndexChanged);
            this.listViewScripts.Resize += new System.EventHandler(this.ListViewScripts_Resize);
            // 
            // scriptHeaderName
            // 
            this.scriptHeaderName.Width = 409;
            // 
            // scriptEditor
            // 
            this.scriptEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptEditor.AutoScroll = true;
            this.scriptEditor.CausesValidation = false;
            this.scriptEditor.Location = new System.Drawing.Point(385, 5);
            this.scriptEditor.MinimumSize = new System.Drawing.Size(0, 325);
            this.scriptEditor.Name = "scriptEditor";
            this.scriptEditor.Selected = null;
            this.scriptEditor.Size = new System.Drawing.Size(372, 374);
            this.scriptEditor.TabIndex = 8;
            // 
            // openFileDialogScripts
            // 
            this.openFileDialogScripts.Multiselect = true;
            this.openFileDialogScripts.Title = "Add script";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(784, 455);
            this.Controls.Add(toolStripContainerAll);
            this.DoubleBuffered = true;
            this.MainMenuStrip = mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(400, 247);
            this.Name = "MainForm";
            this.Opacity = 0.96D;
            this.Padding = new System.Windows.Forms.Padding(11, 0, 11, 11);
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
