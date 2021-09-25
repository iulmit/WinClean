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
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfo;
            System.Windows.Forms.ContextMenuStrip contextMenuStripPresets;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
            System.Windows.Forms.MenuStrip mainMenuStrip;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearLogs;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettings;
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
            System.Windows.Forms.ToolStripMenuItem afficherLaideToolStripMenuItem;
            System.Windows.Forms.ToolStripContainer toolStripContainerAll;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listViewScripts = new System.Windows.Forms.ListView();
            this.columnFileName = new System.Windows.Forms.ColumnHeader();
            this.labelTitleScriptCount = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.DeletePreset = new System.Windows.Forms.ToolStripMenuItem();
            this.RenamePreset = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLoadPreset = new System.Windows.Forms.Button();
            this.buttonSavePreset = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonAddScripts = new System.Windows.Forms.Button();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanelAll = new System.Windows.Forms.TableLayoutPanel();
            columnScriptName = new System.Windows.Forms.ColumnHeader();
            columnHost = new System.Windows.Forms.ColumnHeader();
            labelTitleInfo = new System.Windows.Forms.Label();
            flowLayoutPanelInfo = new System.Windows.Forms.FlowLayoutPanel();
            contextMenuStripPresets = new System.Windows.Forms.ContextMenuStrip(this.components);
            tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemClearLogs = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            afficherLaideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripContainerAll = new System.Windows.Forms.ToolStripContainer();
            tableLayoutPanelAll.SuspendLayout();
            flowLayoutPanelInfo.SuspendLayout();
            contextMenuStripPresets.SuspendLayout();
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
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            tableLayoutPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tableLayoutPanelAll.Controls.Add(this.listViewScripts, 0, 1);
            tableLayoutPanelAll.Controls.Add(labelTitleInfo, 1, 0);
            tableLayoutPanelAll.Controls.Add(this.labelTitleScriptCount, 0, 0);
            tableLayoutPanelAll.Controls.Add(flowLayoutPanelInfo, 1, 1);
            tableLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelAll.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelAll.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelAll.Name = "tableLayoutPanelAll";
            tableLayoutPanelAll.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            tableLayoutPanelAll.RowCount = 2;
            tableLayoutPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAll.Size = new System.Drawing.Size(824, 394);
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
            this.listViewScripts.Location = new System.Drawing.Point(13, 19);
            this.listViewScripts.Margin = new System.Windows.Forms.Padding(0);
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.ShowGroups = false;
            this.listViewScripts.Size = new System.Drawing.Size(477, 373);
            this.listViewScripts.TabIndex = 7;
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            // 
            // columnScriptName
            // 
            columnScriptName.Text = "Nom";
            columnScriptName.Width = 90;
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "Nom du fichier";
            this.columnFileName.Width = 90;
            // 
            // columnHost
            // 
            columnHost.Text = "Hôte";
            columnHost.Width = 180;
            // 
            // labelTitleInfo
            // 
            labelTitleInfo.AccessibleDescription = "";
            labelTitleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelTitleInfo.BackColor = System.Drawing.SystemColors.Control;
            labelTitleInfo.CausesValidation = false;
            labelTitleInfo.Location = new System.Drawing.Point(495, 2);
            labelTitleInfo.Name = "labelTitleInfo";
            labelTitleInfo.Size = new System.Drawing.Size(313, 15);
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
            this.labelTitleScriptCount.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.labelTitleScriptCount.Location = new System.Drawing.Point(16, 2);
            this.labelTitleScriptCount.Name = "labelTitleScriptCount";
            this.labelTitleScriptCount.Size = new System.Drawing.Size(471, 15);
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
            flowLayoutPanelInfo.Location = new System.Drawing.Point(492, 19);
            flowLayoutPanelInfo.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanelInfo.Name = "flowLayoutPanelInfo";
            flowLayoutPanelInfo.Size = new System.Drawing.Size(319, 373);
            flowLayoutPanelInfo.TabIndex = 8;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.CausesValidation = false;
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
            this.labelInfo.Location = new System.Drawing.Point(3, 60);
            this.labelInfo.MinimumSize = new System.Drawing.Size(0, 30);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(84, 30);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.Text = "Informations : ";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInfo.UseMnemonic = false;
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
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tableLayoutPanelButtons.CausesValidation = false;
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
            tableLayoutPanelButtons.Controls.Add(this.buttonQuit, 7, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonAddScripts, 3, 0);
            tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            tableLayoutPanelButtons.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new System.Drawing.Point(0, 394);
            tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.Padding = new System.Windows.Forms.Padding(11);
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelButtons.Size = new System.Drawing.Size(824, 47);
            tableLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonLoadPreset
            // 
            this.buttonLoadPreset.AccessibleDescription = "Cliquez pour charger la présélection sélectionnée.";
            this.buttonLoadPreset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLoadPreset.AutoSize = true;
            this.buttonLoadPreset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLoadPreset.CausesValidation = false;
            this.buttonLoadPreset.Enabled = false;
            this.buttonLoadPreset.Location = new System.Drawing.Point(130, 11);
            this.buttonLoadPreset.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
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
            this.buttonSavePreset.AutoSize = true;
            this.buttonSavePreset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSavePreset.CausesValidation = false;
            this.buttonSavePreset.Location = new System.Drawing.Point(11, 11);
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
            this.buttonNext.AutoSize = true;
            this.buttonNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNext.CausesValidation = false;
            this.buttonNext.Location = new System.Drawing.Point(695, 11);
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
            this.buttonQuit.Location = new System.Drawing.Point(758, 11);
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
            this.buttonAddScripts.Location = new System.Drawing.Point(426, 11);
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
            mainMenuStrip.BackColor = System.Drawing.SystemColors.Window;
            mainMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(5, 2, 2, 2);
            mainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ToolStripMenuItemFile,
            ToolStripMenuItemSettings,
            ToolStripMenuItemHelp});
            mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            mainMenuStrip.Size = new System.Drawing.Size(824, 24);
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
            toolStripContainerAll.ContentPanel.Size = new System.Drawing.Size(824, 441);
            toolStripContainerAll.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainerAll.LeftToolStripPanel
            // 
            toolStripContainerAll.LeftToolStripPanel.CausesValidation = false;
            toolStripContainerAll.LeftToolStripPanel.Enabled = false;
            toolStripContainerAll.LeftToolStripPanelVisible = false;
            toolStripContainerAll.Location = new System.Drawing.Point(0, 0);
            toolStripContainerAll.Margin = new System.Windows.Forms.Padding(0);
            toolStripContainerAll.Name = "toolStripContainerAll";
            // 
            // toolStripContainerAll.RightToolStripPanel
            // 
            toolStripContainerAll.RightToolStripPanel.CausesValidation = false;
            toolStripContainerAll.RightToolStripPanel.Enabled = false;
            toolStripContainerAll.RightToolStripPanelVisible = false;
            toolStripContainerAll.Size = new System.Drawing.Size(824, 465);
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
            this.ClientSize = new System.Drawing.Size(824, 465);
            this.Controls.Add(toolStripContainerAll);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(560, 336);
            this.Name = "MainForm";
            this.Opacity = 0.96D;
            tableLayoutPanelAll.ResumeLayout(false);
            flowLayoutPanelInfo.ResumeLayout(false);
            flowLayoutPanelInfo.PerformLayout();
            contextMenuStripPresets.ResumeLayout(false);
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

        private System.Windows.Forms.Button buttonAddScripts;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonLoadPreset;
        private System.Windows.Forms.Button buttonSavePreset;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelTitleScriptCount;
        private System.Windows.Forms.ListView listViewScripts;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearLogs;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
#pragma warning disable 0649
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPresets;
#pragma warning restore 0649
        private System.Windows.Forms.ToolStripMenuItem DeletePreset;
        private System.Windows.Forms.ToolStripMenuItem RenamePreset;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem CopyPreset;
        private System.Windows.Forms.ToolStripMenuItem LoadPreset;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelInfo;
    }
}
