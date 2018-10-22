﻿namespace GameSaveSwapper {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ProfileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SavePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.swapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveExistingSaveHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProfileDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGameDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.game_input = new System.Windows.Forms.TextBox();
            this.game_choose = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.game_add = new System.Windows.Forms.Button();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Here you can setup any type of game and its save directories.";
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProfileName,
            this.SavePath});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(12, 25);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(637, 546);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // ProfileName
            // 
            this.ProfileName.Text = "Profile Name";
            this.ProfileName.Width = 149;
            // 
            // SavePath
            // 
            this.SavePath.Text = "Profile Save Path";
            this.SavePath.Width = 475;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem1,
            this.swapToolStripMenuItem,
            this.toolStripSeparator1,
            this.renameToolStripMenuItem,
            this.moveExistingSaveHereToolStripMenuItem,
            this.openProfileDirectoryToolStripMenuItem,
            this.openGameDirectoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 170);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // playToolStripMenuItem1
            // 
            this.playToolStripMenuItem1.Name = "playToolStripMenuItem1";
            this.playToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.playToolStripMenuItem1.Text = "Play";
            this.playToolStripMenuItem1.Click += new System.EventHandler(this.playToolStripMenuItem1_Click);
            // 
            // swapToolStripMenuItem
            // 
            this.swapToolStripMenuItem.Name = "swapToolStripMenuItem";
            this.swapToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.swapToolStripMenuItem.Text = "Swap";
            this.swapToolStripMenuItem.Click += new System.EventHandler(this.swapToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // moveExistingSaveHereToolStripMenuItem
            // 
            this.moveExistingSaveHereToolStripMenuItem.Enabled = false;
            this.moveExistingSaveHereToolStripMenuItem.Name = "moveExistingSaveHereToolStripMenuItem";
            this.moveExistingSaveHereToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.moveExistingSaveHereToolStripMenuItem.Text = "Move Existing Save Here";
            this.moveExistingSaveHereToolStripMenuItem.Click += new System.EventHandler(this.moveExistingSaveHereToolStripMenuItem_Click);
            // 
            // openProfileDirectoryToolStripMenuItem
            // 
            this.openProfileDirectoryToolStripMenuItem.Name = "openProfileDirectoryToolStripMenuItem";
            this.openProfileDirectoryToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openProfileDirectoryToolStripMenuItem.Text = "Open Profile Directory";
            this.openProfileDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openProfileDirectoryToolStripMenuItem_Click);
            // 
            // openGameDirectoryToolStripMenuItem
            // 
            this.openGameDirectoryToolStripMenuItem.Name = "openGameDirectoryToolStripMenuItem";
            this.openGameDirectoryToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openGameDirectoryToolStripMenuItem.Text = "Open Game Directory";
            this.openGameDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openGameDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // game_input
            // 
            this.game_input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.game_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.game_input.Location = new System.Drawing.Point(12, 575);
            this.game_input.Name = "game_input";
            this.game_input.Size = new System.Drawing.Size(229, 20);
            this.game_input.TabIndex = 10;
            this.game_input.TextChanged += new System.EventHandler(this.game_input_TextChanged);
            // 
            // game_choose
            // 
            this.game_choose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.game_choose.FormattingEnabled = true;
            this.game_choose.Location = new System.Drawing.Point(247, 575);
            this.game_choose.Name = "game_choose";
            this.game_choose.Size = new System.Drawing.Size(134, 21);
            this.game_choose.TabIndex = 12;
            this.game_choose.SelectedIndexChanged += new System.EventHandler(this.game_choose_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 598);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Profile Name";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 598);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Game";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameSetupToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.reloadProfilesToolStripMenuItem,
            this.testToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // reloadProfilesToolStripMenuItem
            // 
            this.reloadProfilesToolStripMenuItem.Name = "reloadProfilesToolStripMenuItem";
            this.reloadProfilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reloadProfilesToolStripMenuItem.Text = "Reload";
            this.reloadProfilesToolStripMenuItem.Click += new System.EventHandler(this.reloadProfilesToolStripMenuItem_Click);
            // 
            // gameSetupToolStripMenuItem
            // 
            this.gameSetupToolStripMenuItem.Name = "gameSetupToolStripMenuItem";
            this.gameSetupToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.gameSetupToolStripMenuItem.Text = "Game Manager";
            this.gameSetupToolStripMenuItem.Click += new System.EventHandler(this.gameSetupToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::GameSaveSwapper.Properties.Resources.Settings_16x;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.reportIssueToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.openLogToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::GameSaveSwapper.Properties.Resources.Question_16x;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // reportIssueToolStripMenuItem
            // 
            this.reportIssueToolStripMenuItem.Name = "reportIssueToolStripMenuItem";
            this.reportIssueToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.reportIssueToolStripMenuItem.Text = "Report Issue";
            this.reportIssueToolStripMenuItem.Click += new System.EventHandler(this.reportIssueToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openLogToolStripMenuItem.Text = "Open Logs";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(321, 599);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(60, 13);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "New Game";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // game_add
            // 
            this.game_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.game_add.BackColor = System.Drawing.Color.White;
            this.game_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.game_add.Image = ((System.Drawing.Image)(resources.GetObject("game_add.Image")));
            this.game_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.game_add.Location = new System.Drawing.Point(387, 575);
            this.game_add.Name = "game_add";
            this.game_add.Size = new System.Drawing.Size(104, 21);
            this.game_add.TabIndex = 13;
            this.game_add.Text = "Add Profile";
            this.game_add.UseVisualStyleBackColor = false;
            this.game_add.Click += new System.EventHandler(this.button2_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(661, 620);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.game_add);
            this.Controls.Add(this.game_choose);
            this.Controls.Add(this.game_input);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(676, 659);
            this.Name = "Main";
            this.Text = "Profiles - Game Save Swapper";
            this.Load += new System.EventHandler(this.Setup_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ProfileName;
        private System.Windows.Forms.ColumnHeader SavePath;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox game_input;
        private System.Windows.Forms.ComboBox game_choose;
        private System.Windows.Forms.Button game_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem swapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveExistingSaveHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProfileDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripMenuItem openGameDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}