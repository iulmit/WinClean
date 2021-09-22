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
            System.Windows.Forms.ColumnHeader columnScriptName;
            System.Windows.Forms.ColumnHeader columnHost;
            System.Windows.Forms.Label labelTitleInfo;
            System.Windows.Forms.SplitContainer splitContainerInfo;
            System.Windows.Forms.ColumnHeader columnName;
            System.Windows.Forms.ColumnHeader columnNbScripts;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
            System.Windows.Forms.MenuStrip mainMenuStrip;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearLogs;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettings;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
            System.Windows.Forms.ToolStripMenuItem afficherLaideToolStripMenuItem;
            System.Windows.Forms.ContextMenuStrip contextMenuStripPresets;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listViewScripts = new System.Windows.Forms.ListView();
            this.columnFileName = new System.Windows.Forms.ColumnHeader();
            this.labelTitleScriptCount = new System.Windows.Forms.Label();
            this.labelTitlePresetCount = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelImpacts = new System.Windows.Forms.Label();
            this.listViewPresets = new System.Windows.Forms.ListView();
            this.buttonLoadPreset = new System.Windows.Forms.Button();
            this.buttonSavePreset = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonAddScripts = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletePreset = new System.Windows.Forms.ToolStripMenuItem();
            this.RenamePreset = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            tableLayoutPanelAll = new System.Windows.Forms.TableLayoutPanel();
            columnScriptName = new System.Windows.Forms.ColumnHeader();
            columnHost = new System.Windows.Forms.ColumnHeader();
            labelTitleInfo = new System.Windows.Forms.Label();
            splitContainerInfo = new System.Windows.Forms.SplitContainer();
            columnName = new System.Windows.Forms.ColumnHeader();
            columnNbScripts = new System.Windows.Forms.ColumnHeader();
            tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemClearLogs = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            afficherLaideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStripPresets = new System.Windows.Forms.ContextMenuStrip(this.components);
            tableLayoutPanelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splitContainerInfo)).BeginInit();
            splitContainerInfo.Panel1.SuspendLayout();
            splitContainerInfo.Panel2.SuspendLayout();
            splitContainerInfo.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            contextMenuStripPresets.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelAll
            // 
            tableLayoutPanelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tableLayoutPanelAll.CausesValidation = false;
            tableLayoutPanelAll.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanelAll.ColumnCount = 3;
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanelAll.Controls.Add(this.listViewScripts, 1, 1);
            tableLayoutPanelAll.Controls.Add(labelTitleInfo, 2, 0);
            tableLayoutPanelAll.Controls.Add(this.labelTitleScriptCount, 1, 0);
            tableLayoutPanelAll.Controls.Add(this.labelTitlePresetCount, 0, 0);
            tableLayoutPanelAll.Controls.Add(splitContainerInfo, 2, 1);
            tableLayoutPanelAll.Controls.Add(this.listViewPresets, 0, 1);
            tableLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelAll.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelAll.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelAll.Name = "tableLayoutPanelAll";
            tableLayoutPanelAll.RowCount = 2;
            tableLayoutPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAll.Size = new System.Drawing.Size(784, 406);
            tableLayoutPanelAll.TabIndex = 0;
            // 
            // listViewScripts
            // 
            this.listViewScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewScripts.AutoArrange = false;
            this.listViewScripts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewScripts.CausesValidation = false;
            this.listViewScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnScriptName,
            this.columnFileName,
            columnHost});
            this.listViewScripts.GridLines = true;
            this.listViewScripts.HideSelection = false;
            this.listViewScripts.LabelWrap = false;
            this.listViewScripts.Location = new System.Drawing.Point(262, 19);
            this.listViewScripts.Margin = new System.Windows.Forms.Padding(0);
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.ShowGroups = false;
            this.listViewScripts.Size = new System.Drawing.Size(258, 385);
            this.listViewScripts.TabIndex = 7;
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            // 
            // columnScriptName
            // 
            columnScriptName.Text = "Nom";
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "Nom du fichier";
            this.columnFileName.Width = 95;
            // 
            // columnHost
            // 
            columnHost.Text = "Hôte";
            columnHost.Width = 102;
            // 
            // labelTitleInfo
            // 
            labelTitleInfo.AccessibleDescription = "";
            labelTitleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelTitleInfo.CausesValidation = false;
            labelTitleInfo.Location = new System.Drawing.Point(525, 2);
            labelTitleInfo.Name = "labelTitleInfo";
            labelTitleInfo.Size = new System.Drawing.Size(254, 15);
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
            this.labelTitleScriptCount.CausesValidation = false;
            this.labelTitleScriptCount.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.labelTitleScriptCount.Location = new System.Drawing.Point(265, 2);
            this.labelTitleScriptCount.Name = "labelTitleScriptCount";
            this.labelTitleScriptCount.Size = new System.Drawing.Size(252, 15);
            this.labelTitleScriptCount.TabIndex = 1;
            this.labelTitleScriptCount.Text = "Scripts";
            this.labelTitleScriptCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitleScriptCount.UseMnemonic = false;
            // 
            // labelTitlePresetCount
            // 
            this.labelTitlePresetCount.AccessibleDescription = "Indique le nombre de présélections disponibles.";
            this.labelTitlePresetCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitlePresetCount.CausesValidation = false;
            this.labelTitlePresetCount.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.labelTitlePresetCount.Location = new System.Drawing.Point(5, 2);
            this.labelTitlePresetCount.Name = "labelTitlePresetCount";
            this.labelTitlePresetCount.Size = new System.Drawing.Size(252, 15);
            this.labelTitlePresetCount.TabIndex = 0;
            this.labelTitlePresetCount.Text = "Présélections";
            this.labelTitlePresetCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitlePresetCount.UseMnemonic = false;
            // 
            // splitContainerInfo
            // 
            splitContainerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            splitContainerInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            splitContainerInfo.CausesValidation = false;
            splitContainerInfo.Cursor = System.Windows.Forms.Cursors.HSplit;
            splitContainerInfo.Location = new System.Drawing.Point(522, 19);
            splitContainerInfo.Margin = new System.Windows.Forms.Padding(0);
            splitContainerInfo.Name = "splitContainerInfo";
            splitContainerInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerInfo.Panel1
            // 
            splitContainerInfo.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            splitContainerInfo.Panel1.CausesValidation = false;
            splitContainerInfo.Panel1.Controls.Add(this.labelDescription);
            // 
            // splitContainerInfo.Panel2
            // 
            splitContainerInfo.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            splitContainerInfo.Panel2.CausesValidation = false;
            splitContainerInfo.Panel2.Controls.Add(this.labelImpacts);
            splitContainerInfo.Size = new System.Drawing.Size(260, 385);
            splitContainerInfo.SplitterDistance = 207;
            splitContainerInfo.TabIndex = 0;
            // 
            // labelDescription
            // 
            this.labelDescription.AccessibleDescription = "Cet encadré fournit des explications et des informations sur l\'élément actuelleme" +
    "nt survolé par le curseur de la souris.";
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.CausesValidation = false;
            this.labelDescription.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.labelDescription.Location = new System.Drawing.Point(0, 0);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(256, 203);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Cet encadré fournit des explications et des informations sur l\'élément actuelleme" +
    "nt survolé par le curseur de la souris.";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDescription.UseMnemonic = false;
            // 
            // labelImpacts
            // 
            this.labelImpacts.AccessibleDescription = "Cet encadré fournit les impacts sur le système du script sélectionné.";
            this.labelImpacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelImpacts.CausesValidation = false;
            this.labelImpacts.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.labelImpacts.Location = new System.Drawing.Point(0, 0);
            this.labelImpacts.Margin = new System.Windows.Forms.Padding(0);
            this.labelImpacts.Name = "labelImpacts";
            this.labelImpacts.Size = new System.Drawing.Size(256, 170);
            this.labelImpacts.TabIndex = 0;
            this.labelImpacts.Text = "Cet encadré fournit les impacts sur le système du script sélectionné.";
            this.labelImpacts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelImpacts.UseMnemonic = false;
            // 
            // listViewPresets
            // 
            this.listViewPresets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPresets.AutoArrange = false;
            this.listViewPresets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewPresets.CausesValidation = false;
            this.listViewPresets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnName,
            columnNbScripts});
            this.listViewPresets.ContextMenuStrip = contextMenuStripPresets;
            this.listViewPresets.GridLines = true;
            this.listViewPresets.HideSelection = false;
            this.listViewPresets.LabelWrap = false;
            this.listViewPresets.Location = new System.Drawing.Point(2, 19);
            this.listViewPresets.Margin = new System.Windows.Forms.Padding(0);
            this.listViewPresets.Name = "listViewPresets";
            this.listViewPresets.ShowGroups = false;
            this.listViewPresets.Size = new System.Drawing.Size(258, 385);
            this.listViewPresets.TabIndex = 6;
            this.listViewPresets.UseCompatibleStateImageBehavior = false;
            this.listViewPresets.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            columnName.Text = "Nom";
            // 
            // columnNbScripts
            // 
            columnNbScripts.Text = "Scripts";
            columnNbScripts.Width = 50;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tableLayoutPanelButtons.CausesValidation = false;
            tableLayoutPanelButtons.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            tableLayoutPanelButtons.ColumnCount = 8;
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelButtons.Controls.Add(this.buttonLoadPreset, 0, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonSavePreset, 0, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonNext, 6, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonAddScripts, 3, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonQuit, 7, 0);
            tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            tableLayoutPanelButtons.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new System.Drawing.Point(0, 406);
            tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelButtons.Size = new System.Drawing.Size(784, 31);
            tableLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonLoadPreset
            // 
            this.buttonLoadPreset.AccessibleDescription = "Cliquez pour charger la présélection sélectionnée.";
            this.buttonLoadPreset.Anchor = System.Windows.Forms.AnchorStyles.None;
            
            this.buttonLoadPreset.CausesValidation = false;
            this.buttonLoadPreset.Enabled = false;
            this.buttonLoadPreset.Location = new System.Drawing.Point(118, 3);
            this.buttonLoadPreset.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLoadPreset.Name = "buttonLoadPreset";
            this.buttonLoadPreset.Size = new System.Drawing.Size(137, 25);
            this.buttonLoadPreset.TabIndex = 2;
            this.buttonLoadPreset.Text = "Charger présésélection";
            this.buttonLoadPreset.UseMnemonic = false;
            this.buttonLoadPreset.UseVisualStyleBackColor = true;
            this.buttonLoadPreset.Click += new System.EventHandler(this.ButtonLoadPreset_Click);
            // 
            // buttonSavePreset
            // 
            this.buttonSavePreset.AccessibleDescription = "Cliquez pour sauvegarder une présélection selon les paramètres actuellement sélec" +
    "tionnés.";
            this.buttonSavePreset.Anchor = System.Windows.Forms.AnchorStyles.None;
            
            this.buttonSavePreset.CausesValidation = false;
            this.buttonSavePreset.Location = new System.Drawing.Point(3, 3);
            this.buttonSavePreset.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSavePreset.Name = "buttonSavePreset";
            this.buttonSavePreset.Size = new System.Drawing.Size(112, 25);
            this.buttonSavePreset.TabIndex = 1;
            this.buttonSavePreset.Text = "Sauv. présélection";
            this.buttonSavePreset.UseMnemonic = false;
            this.buttonSavePreset.UseVisualStyleBackColor = true;
            this.buttonSavePreset.Click += new System.EventHandler(this.ButtonSavePreset_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.AccessibleDescription = "Cliquez pour valider les paramètres et passer à l\'étape suivante.";
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            
            this.buttonNext.CausesValidation = false;
            this.buttonNext.Location = new System.Drawing.Point(668, 3);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(56, 25);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Suivant";
            this.buttonNext.UseMnemonic = false;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // buttonAddScripts
            // 
            this.buttonAddScripts.AccessibleDescription = "Cliquez pour ajouter un ou plusieurs scripts. Un script est représentée par une c" +
    "ase à cocher sous la colonne \"Scripts\".";
            this.buttonAddScripts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddScripts.CausesValidation = false;
            this.buttonAddScripts.Location = new System.Drawing.Point(405, 3);
            this.buttonAddScripts.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddScripts.Name = "buttonAddScripts";
            this.buttonAddScripts.Size = new System.Drawing.Size(110, 25);
            this.buttonAddScripts.TabIndex = 3;
            this.buttonAddScripts.Text = "Ajouter script(s)...";
            this.buttonAddScripts.UseMnemonic = false;
            this.buttonAddScripts.UseVisualStyleBackColor = true;
            this.buttonAddScripts.Click += new System.EventHandler(this.ButtonNewScript_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.AccessibleName = "Cliquez pour valider les paramètres et passer à l\'étape suivante.";
            this.buttonQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            
            this.buttonQuit.CausesValidation = false;
            this.buttonQuit.Location = new System.Drawing.Point(727, 3);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(54, 25);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "Quitter";
            this.buttonQuit.UseMnemonic = false;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.AllowMerge = false;
            mainMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ToolStripMenuItemFile,
            ToolStripMenuItemSettings,
            ToolStripMenuItemHelp});
            mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(784, 24);
            mainMenuStrip.TabIndex = 1;
            mainMenuStrip.Text = "menuStripAll";
            // 
            // ToolStripMenuItemFile
            // 
            ToolStripMenuItemFile.AutoSize = false;
            ToolStripMenuItemFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ToolStripMenuItemClearLogs});
            ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            ToolStripMenuItemFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            ToolStripMenuItemFile.Size = new System.Drawing.Size(54, 20);
            ToolStripMenuItemFile.Text = "Fichier";
            // 
            // ToolStripMenuItemClearLogs
            // 
            ToolStripMenuItemClearLogs.AccessibleDescription = "Effacer tous les fichiers journaux de l\'application.";
            ToolStripMenuItemClearLogs.AutoSize = false;
            ToolStripMenuItemClearLogs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ToolStripMenuItemClearLogs.Name = "ToolStripMenuItemClearLogs";
            ToolStripMenuItemClearLogs.Size = new System.Drawing.Size(180, 22);
            ToolStripMenuItemClearLogs.Text = "Effacer les logs";
            // 
            // ToolStripMenuItemSettings
            // 
            ToolStripMenuItemSettings.AutoSize = false;
            ToolStripMenuItemSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ToolStripMenuItemSettings.Name = "ToolStripMenuItemSettings";
            ToolStripMenuItemSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            ToolStripMenuItemSettings.Size = new System.Drawing.Size(61, 20);
            ToolStripMenuItemSettings.Text = "Options";
            // 
            // ToolStripMenuItemHelp
            // 
            ToolStripMenuItemHelp.AutoSize = false;
            ToolStripMenuItemHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            afficherLaideToolStripMenuItem,
            this.ToolStripMenuItemAbout});
            ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            ToolStripMenuItemHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            ToolStripMenuItemHelp.Size = new System.Drawing.Size(43, 20);
            ToolStripMenuItemHelp.Text = "Aide";
            // 
            // afficherLaideToolStripMenuItem
            // 
            afficherLaideToolStripMenuItem.AutoSize = false;
            afficherLaideToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            afficherLaideToolStripMenuItem.Name = "afficherLaideToolStripMenuItem";
            afficherLaideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            afficherLaideToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            afficherLaideToolStripMenuItem.Text = "Afficher l\'aide";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.AutoSize = false;
            
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(192, 22);
            this.ToolStripMenuItemAbout.Text = "À propos de WinClean";
            // 
            // contextMenuStripPresets
            // 
            contextMenuStripPresets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            contextMenuStripPresets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeletePreset,
            this.RenamePreset,
            this.ToolStripMenuItemNew,
            this.CopyPreset,
            this.LoadPreset});
            contextMenuStripPresets.Name = "contextMenuStripPresets";
            contextMenuStripPresets.Size = new System.Drawing.Size(166, 114);
            // 
            // DeletePreset
            // 
            this.DeletePreset.AccessibleDescription = "";
            this.DeletePreset.AutoSize = false;
            
            this.DeletePreset.Name = "DeletePreset";
            this.DeletePreset.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeletePreset.ShowShortcutKeys = false;
            this.DeletePreset.Size = new System.Drawing.Size(180, 22);
            this.DeletePreset.Text = "Supprimer";
            this.DeletePreset.ToolTipText = "Supprimer la présélection séléctionnée de la liste.";
            // 
            // RenamePreset
            // 
            this.RenamePreset.AccessibleDescription = "";
            this.RenamePreset.AutoSize = false;
            
            this.RenamePreset.Name = "RenamePreset";
            this.RenamePreset.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.RenamePreset.Size = new System.Drawing.Size(180, 22);
            this.RenamePreset.Text = "Rennomer";
            this.RenamePreset.ToolTipText = "Modifier le nom de la présélection sélectionnée.";
            // 
            // ToolStripMenuItemNew
            // 
            this.ToolStripMenuItemNew.AccessibleDescription = "";
            this.ToolStripMenuItemNew.AutoSize = false;
            
            this.ToolStripMenuItemNew.Name = "ToolStripMenuItemNew";
            this.ToolStripMenuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ToolStripMenuItemNew.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemNew.Text = "Nouveau";
            this.ToolStripMenuItemNew.ToolTipText = "Créer une nouvelle présélection à partir des scripts actuels.";
            // 
            // CopyPreset
            // 
            this.CopyPreset.AutoSize = false;
            
            this.CopyPreset.Name = "CopyPreset";
            this.CopyPreset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyPreset.Size = new System.Drawing.Size(180, 22);
            this.CopyPreset.Text = "Recréer";
            this.CopyPreset.ToolTipText = "Créer une copie de la présélection sélectionnée";
            // 
            // LoadPreset
            // 
            this.LoadPreset.AutoSize = false;
            
            this.LoadPreset.Name = "LoadPreset";
            this.LoadPreset.Size = new System.Drawing.Size(180, 22);
            this.LoadPreset.Text = "Charger";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(tableLayoutPanelAll);
            this.toolStripContainer1.ContentPanel.Controls.Add(tableLayoutPanelButtons);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(784, 437);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(784, 461);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(mainMenuStrip);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(530, 260);
            this.Name = "MainForm";
            this.Opacity = 0.96D;
            tableLayoutPanelAll.ResumeLayout(false);
            splitContainerInfo.Panel1.ResumeLayout(false);
            splitContainerInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainerInfo)).EndInit();
            splitContainerInfo.ResumeLayout(false);
            tableLayoutPanelButtons.ResumeLayout(false);
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            contextMenuStripPresets.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddScripts;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonLoadPreset;
        private System.Windows.Forms.Button buttonSavePreset;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelTitleScriptCount;
        private System.Windows.Forms.Label labelTitlePresetCount;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelImpacts;
        private System.Windows.Forms.ListView listViewScripts;
        private System.Windows.Forms.ListView listViewPresets;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearLogs;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPresets;
        private System.Windows.Forms.ToolStripMenuItem DeletePreset;
        private System.Windows.Forms.ToolStripMenuItem RenamePreset;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem CopyPreset;
        private System.Windows.Forms.ToolStripMenuItem LoadPreset;
    }
}
