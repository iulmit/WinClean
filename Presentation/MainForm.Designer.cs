// Licensed to the .NET Foundation under one or more agreements.
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
            System.Windows.Forms.Label labelTitleInfo;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfo;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
            System.Windows.Forms.MenuStrip mainMenuStrip;
            System.Windows.Forms.ToolStripMenuItem MainMenuFile;
            System.Windows.Forms.ToolStripMenuItem MainMenuClearLogs;
            System.Windows.Forms.ToolStripMenuItem MainMenuSelect;
            System.Windows.Forms.ToolStripMenuItem MainMenuSettings;
            System.Windows.Forms.ToolStripMenuItem MainMenuHelp;
            System.Windows.Forms.ToolStripMenuItem MainMenuShowHelp;
            System.Windows.Forms.ToolStripContainer toolStripContainerAll;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listViewScripts = new RaphaëlBardini.WinClean.Presentation.ListViewEvent();
            this.scriptHeaderName = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripScripts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuScriptsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuScriptsRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuScriptsExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuScriptsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTitleScriptCount = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonAddScripts = new System.Windows.Forms.Button();
            this.MainMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectNothing = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSelectDebloat = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanelAll = new System.Windows.Forms.TableLayoutPanel();
            labelTitleInfo = new System.Windows.Forms.Label();
            flowLayoutPanelInfo = new System.Windows.Forms.FlowLayoutPanel();
            tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            MainMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuClearLogs = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuSelect = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            MainMenuShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            toolStripContainerAll = new System.Windows.Forms.ToolStripContainer();
            tableLayoutPanelAll.SuspendLayout();
            this.contextMenuStripScripts.SuspendLayout();
            flowLayoutPanelInfo.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            toolStripContainerAll.ContentPanel.SuspendLayout();
            toolStripContainerAll.TopToolStripPanel.SuspendLayout();
            toolStripContainerAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelAll
            // 
            tableLayoutPanelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tableLayoutPanelAll.CausesValidation = false;
            tableLayoutPanelAll.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanelAll.ColumnCount = 2;
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            tableLayoutPanelAll.Controls.Add(this.listViewScripts, 0, 1);
            tableLayoutPanelAll.Controls.Add(labelTitleInfo, 1, 0);
            tableLayoutPanelAll.Controls.Add(this.labelTitleScriptCount, 0, 0);
            tableLayoutPanelAll.Controls.Add(flowLayoutPanelInfo, 1, 1);
            tableLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelAll.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelAll.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelAll.Name = "tableLayoutPanelAll";
            tableLayoutPanelAll.RowCount = 2;
            tableLayoutPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAll.Size = new System.Drawing.Size(762, 384);
            tableLayoutPanelAll.TabIndex = 0;
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
            this.listViewScripts.ContextMenuStrip = this.contextMenuStripScripts;
            this.listViewScripts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewScripts.HideSelection = false;
            this.listViewScripts.Location = new System.Drawing.Point(2, 19);
            this.listViewScripts.Margin = new System.Windows.Forms.Padding(0);
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.Scrollable = false;
            this.listViewScripts.Size = new System.Drawing.Size(412, 363);
            this.listViewScripts.TabIndex = 7;
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            this.listViewScripts.Resize += new System.EventHandler(this.ListViewScripts_Resize);
            // 
            // scriptHeaderName
            // 
            this.scriptHeaderName.Width = 433;
            // 
            // contextMenuStripScripts
            // 
            this.contextMenuStripScripts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuScriptsDelete,
            this.ContextMenuScriptsRename,
            this.ContextMenuScriptsExecute,
            this.ContextMenuScriptsNew});
            this.contextMenuStripScripts.Name = "contextMenuStripScripts";
            this.contextMenuStripScripts.Size = new System.Drawing.Size(137, 92);
            this.contextMenuStripScripts.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripScripts_Opening);
            // 
            // ContextMenuScriptsDelete
            // 
            this.ContextMenuScriptsDelete.Name = "ContextMenuScriptsDelete";
            this.ContextMenuScriptsDelete.Size = new System.Drawing.Size(136, 22);
            this.ContextMenuScriptsDelete.Text = "Supprimer";
            this.ContextMenuScriptsDelete.Click += new System.EventHandler(this.ContextMenuScriptsDelete_Click);
            // 
            // ContextMenuScriptsRename
            // 
            this.ContextMenuScriptsRename.Name = "ContextMenuScriptsRename";
            this.ContextMenuScriptsRename.Size = new System.Drawing.Size(136, 22);
            this.ContextMenuScriptsRename.Text = "Renommer";
            this.ContextMenuScriptsRename.Click += new System.EventHandler(this.ContextMenuScriptsRename_Click);
            // 
            // ContextMenuScriptsExecute
            // 
            this.ContextMenuScriptsExecute.Name = "ContextMenuScriptsExecute";
            this.ContextMenuScriptsExecute.Size = new System.Drawing.Size(136, 22);
            this.ContextMenuScriptsExecute.Text = "Exécuter";
            this.ContextMenuScriptsExecute.Click += new System.EventHandler(this.ContextMenuScriptsExecute_Click);
            // 
            // ContextMenuScriptsNew
            // 
            this.ContextMenuScriptsNew.Name = "ContextMenuScriptsNew";
            this.ContextMenuScriptsNew.Size = new System.Drawing.Size(136, 22);
            this.ContextMenuScriptsNew.Text = "Nouveau(x)";
            this.ContextMenuScriptsNew.Click += new System.EventHandler(this.NouveauxToolStripMenuItem_Click);
            // 
            // labelTitleInfo
            // 
            labelTitleInfo.AccessibleDescription = "";
            labelTitleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelTitleInfo.BackColor = System.Drawing.SystemColors.Control;
            labelTitleInfo.CausesValidation = false;
            labelTitleInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            labelTitleInfo.Location = new System.Drawing.Point(419, 2);
            labelTitleInfo.Name = "labelTitleInfo";
            labelTitleInfo.Size = new System.Drawing.Size(338, 15);
            labelTitleInfo.TabIndex = 2;
            labelTitleInfo.Text = "Informations";
            labelTitleInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelTitleInfo.UseMnemonic = false;
            // 
            // labelTitleScriptCount
            // 
            this.labelTitleScriptCount.AccessibleDescription = "Indique le nombre de scripts disponibles.";
            this.labelTitleScriptCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitleScriptCount.BackColor = System.Drawing.SystemColors.Control;
            this.labelTitleScriptCount.CausesValidation = false;
            this.labelTitleScriptCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitleScriptCount.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.labelTitleScriptCount.Location = new System.Drawing.Point(5, 2);
            this.labelTitleScriptCount.Name = "labelTitleScriptCount";
            this.labelTitleScriptCount.Size = new System.Drawing.Size(406, 15);
            this.labelTitleScriptCount.TabIndex = 1;
            this.labelTitleScriptCount.Text = "Scripts";
            this.labelTitleScriptCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitleScriptCount.UseMnemonic = false;
            // 
            // flowLayoutPanelInfo
            // 
            flowLayoutPanelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanelInfo.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanelInfo.CausesValidation = false;
            flowLayoutPanelInfo.Controls.Add(this.labelName);
            flowLayoutPanelInfo.Controls.Add(this.labelDescription);
            flowLayoutPanelInfo.Controls.Add(this.labelInfo);
            flowLayoutPanelInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanelInfo.Location = new System.Drawing.Point(416, 19);
            flowLayoutPanelInfo.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanelInfo.Name = "flowLayoutPanelInfo";
            flowLayoutPanelInfo.Size = new System.Drawing.Size(344, 363);
            flowLayoutPanelInfo.TabIndex = 8;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.CausesValidation = false;
            this.labelName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.MinimumSize = new System.Drawing.Size(0, 30);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(43, 30);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Nom : ";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName.UseMnemonic = false;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.CausesValidation = false;
            this.labelDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDescription.Location = new System.Drawing.Point(3, 30);
            this.labelDescription.MinimumSize = new System.Drawing.Size(0, 30);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(76, 30);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description : ";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDescription.UseMnemonic = false;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.CausesValidation = false;
            this.labelInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelInfo.Location = new System.Drawing.Point(3, 60);
            this.labelInfo.MinimumSize = new System.Drawing.Size(0, 30);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(84, 30);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.Text = "Informations : ";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInfo.UseMnemonic = false;
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
            tableLayoutPanelButtons.Controls.Add(this.buttonNext, 3, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonQuit, 4, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonAddScripts, 1, 0);
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
            // buttonNext
            // 
            this.buttonNext.AccessibleDescription = "Cliquez pour valider les paramètres et passer à l\'étape suivante.";
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNext.AutoSize = true;
            this.buttonNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNext.CausesValidation = false;
            this.buttonNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonNext.Location = new System.Drawing.Point(644, 11);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(56, 25);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Suivant";
            this.buttonNext.UseMnemonic = false;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.AccessibleName = "Cliquez pour valider les paramètres et passer à l\'étape suivante.";
            this.buttonQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonQuit.AutoSize = true;
            this.buttonQuit.CausesValidation = false;
            this.buttonQuit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonQuit.Location = new System.Drawing.Point(707, 11);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(54, 25);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "Quitter";
            this.buttonQuit.UseMnemonic = false;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // buttonAddScripts
            // 
            this.buttonAddScripts.AccessibleDescription = "Cliquez pour ajouter un ou plusieurs scripts. Un script est représentée par une c" +
    "ase à cocher sous la colonne \"Scripts\".";
            this.buttonAddScripts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddScripts.AutoSize = true;
            this.buttonAddScripts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddScripts.CausesValidation = false;
            this.buttonAddScripts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAddScripts.Location = new System.Drawing.Point(160, 11);
            this.buttonAddScripts.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddScripts.Name = "buttonAddScripts";
            this.buttonAddScripts.Size = new System.Drawing.Size(110, 25);
            this.buttonAddScripts.TabIndex = 3;
            this.buttonAddScripts.Text = "Ajouter script(s)...";
            this.buttonAddScripts.UseMnemonic = false;
            this.buttonAddScripts.UseVisualStyleBackColor = true;
            this.buttonAddScripts.Click += new System.EventHandler(this.ButtonNewScript_Click);
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.AllowMerge = false;
            mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            mainMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(5, 2, 2, 2);
            mainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainMenuFile,
            MainMenuSelect,
            MainMenuSettings,
            MainMenuHelp});
            mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            mainMenuStrip.Size = new System.Drawing.Size(762, 24);
            mainMenuStrip.TabIndex = 1;
            mainMenuStrip.Text = "menuStripAll";
            // 
            // MainMenuFile
            // 
            MainMenuFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainMenuClearLogs});
            MainMenuFile.Name = "MainMenuFile";
            MainMenuFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            MainMenuFile.Size = new System.Drawing.Size(54, 20);
            MainMenuFile.Text = "Fichier";
            // 
            // MainMenuClearLogs
            // 
            MainMenuClearLogs.AccessibleDescription = "Effacer tous les fichiers journaux de l\'application.";
            MainMenuClearLogs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuClearLogs.Name = "MainMenuClearLogs";
            MainMenuClearLogs.Size = new System.Drawing.Size(152, 22);
            MainMenuClearLogs.Text = "Effacer les logs";
            MainMenuClearLogs.Click += new System.EventHandler(this.MainMenuStripClearLogs_Click);
            // 
            // MainMenuSelect
            // 
            MainMenuSelect.AutoSize = false;
            MainMenuSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuSelectAll,
            this.MainMenuSelectNothing,
            this.MainMenuSelectMaintenance,
            this.MainMenuSelectDebloat});
            MainMenuSelect.Name = "MainMenuSelect";
            MainMenuSelect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            MainMenuSelect.Size = new System.Drawing.Size(84, 20);
            MainMenuSelect.Text = "Sélectionner";
            // 
            // MainMenuSelectAll
            // 
            this.MainMenuSelectAll.Name = "MainMenuSelectAll";
            this.MainMenuSelectAll.Size = new System.Drawing.Size(143, 22);
            this.MainMenuSelectAll.Text = "Tout";
            this.MainMenuSelectAll.Click += new System.EventHandler(this.MainMenuSelectAll_Click);
            // 
            // MainMenuSelectNothing
            // 
            this.MainMenuSelectNothing.Name = "MainMenuSelectNothing";
            this.MainMenuSelectNothing.Size = new System.Drawing.Size(143, 22);
            this.MainMenuSelectNothing.Text = "Rien";
            this.MainMenuSelectNothing.Click += new System.EventHandler(this.MainMenuSelectNothing_Click);
            // 
            // MainMenuSelectMaintenance
            // 
            this.MainMenuSelectMaintenance.Name = "MainMenuSelectMaintenance";
            this.MainMenuSelectMaintenance.Size = new System.Drawing.Size(143, 22);
            this.MainMenuSelectMaintenance.Text = "Maintenance";
            this.MainMenuSelectMaintenance.Click += new System.EventHandler(this.MainMenuSelectMaintenance_Click);
            // 
            // MainMenuSelectDebloat
            // 
            this.MainMenuSelectDebloat.Name = "MainMenuSelectDebloat";
            this.MainMenuSelectDebloat.Size = new System.Drawing.Size(143, 22);
            this.MainMenuSelectDebloat.Text = "Debloat";
            this.MainMenuSelectDebloat.Click += new System.EventHandler(this.MainMenuSelectDebloat_Click);
            // 
            // MainMenuSettings
            // 
            MainMenuSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuSettings.Name = "MainMenuSettings";
            MainMenuSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            MainMenuSettings.Size = new System.Drawing.Size(61, 20);
            MainMenuSettings.Text = "Options";
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
            MainMenuHelp.Size = new System.Drawing.Size(43, 20);
            MainMenuHelp.Text = "Aide";
            // 
            // MainMenuShowHelp
            // 
            MainMenuShowHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MainMenuShowHelp.Name = "MainMenuShowHelp";
            MainMenuShowHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            MainMenuShowHelp.Size = new System.Drawing.Size(166, 22);
            MainMenuShowHelp.Text = "Afficher l\'aide";
            MainMenuShowHelp.Click += new System.EventHandler(this.MainMenuStripShowHelp_Click);
            // 
            // MainMenuAbout
            // 
            this.MainMenuAbout.Name = "MainMenuAbout";
            this.MainMenuAbout.Size = new System.Drawing.Size(166, 22);
            this.MainMenuAbout.Click += new System.EventHandler(this.MainMenuStripAbout_Click);
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
            toolStripContainerAll.Text = "toolStripContainer1";
            // 
            // toolStripContainerAll.TopToolStripPanel
            // 
            toolStripContainerAll.TopToolStripPanel.CausesValidation = false;
            toolStripContainerAll.TopToolStripPanel.Controls.Add(mainMenuStrip);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(784, 455);
            this.Controls.Add(toolStripContainerAll);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(400, 247);
            this.Name = "MainForm";
            this.Opacity = 0.96D;
            this.Padding = new System.Windows.Forms.Padding(11, 0, 11, 11);
            tableLayoutPanelAll.ResumeLayout(false);
            this.contextMenuStripScripts.ResumeLayout(false);
            flowLayoutPanelInfo.ResumeLayout(false);
            flowLayoutPanelInfo.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            toolStripContainerAll.ContentPanel.ResumeLayout(false);
            toolStripContainerAll.ContentPanel.PerformLayout();
            toolStripContainerAll.TopToolStripPanel.ResumeLayout(false);
            toolStripContainerAll.TopToolStripPanel.PerformLayout();
            toolStripContainerAll.ResumeLayout(false);
            toolStripContainerAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelTitleScriptCount;
        private RaphaëlBardini.WinClean.Presentation.ListViewEvent listViewScripts;
        private System.Windows.Forms.ToolStripMenuItem MainMenuFile;
        private System.Windows.Forms.ToolStripMenuItem MainMenuClearLogs;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSettings;
        private System.Windows.Forms.ToolStripMenuItem MainMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowHelp;
        private System.Windows.Forms.ToolStripMenuItem MainMenuAbout;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
#pragma warning disable 0649
#pragma warning restore 0649
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonAddScripts;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelect;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelectNothing;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelectMaintenance;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSelectDebloat;
        private System.Windows.Forms.ColumnHeader scriptHeaderName;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuScriptsDelete;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuScriptsRename;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuScriptsExecute;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripScripts;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuScriptsNew;
    }
}
