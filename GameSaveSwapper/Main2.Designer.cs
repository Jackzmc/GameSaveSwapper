namespace GameSaveSwapper {
    partial class Main2 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main2));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.nogame_text = new System.Windows.Forms.Label();
            this.game_add = new System.Windows.Forms.Button();
            this.game_swap = new System.Windows.Forms.Button();
            this.settings_btn = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.game_profile = new System.Windows.Forms.Label();
            this.game_profileList = new System.Windows.Forms.ListView();
            this.col_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_lastPlayed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_saveLoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.profile_stats = new System.Windows.Forms.Label();
            this.game_play = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.game_picBox = new System.Windows.Forms.PictureBox();
            this.label_gameName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.legacy_btn = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.game_picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(244, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // nogame_text
            // 
            this.nogame_text.AutoSize = true;
            this.nogame_text.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nogame_text.Location = new System.Drawing.Point(209, 59);
            this.nogame_text.Name = "nogame_text";
            this.nogame_text.Size = new System.Drawing.Size(186, 30);
            this.nogame_text.TabIndex = 2;
            this.nogame_text.Text = "No Games Found!";
            // 
            // game_add
            // 
            this.game_add.Location = new System.Drawing.Point(222, 92);
            this.game_add.Name = "game_add";
            this.game_add.Size = new System.Drawing.Size(129, 23);
            this.game_add.TabIndex = 3;
            this.game_add.Text = "Add Game";
            this.game_add.UseVisualStyleBackColor = true;
            this.game_add.Click += new System.EventHandler(this.game_add_Click);
            // 
            // game_swap
            // 
            this.game_swap.Location = new System.Drawing.Point(183, 561);
            this.game_swap.Name = "game_swap";
            this.game_swap.Size = new System.Drawing.Size(188, 34);
            this.game_swap.TabIndex = 4;
            this.game_swap.Text = "Swap";
            this.game_swap.UseVisualStyleBackColor = true;
            this.game_swap.Click += new System.EventHandler(this.game_swap_Click);
            // 
            // settings_btn
            // 
            this.settings_btn.Location = new System.Drawing.Point(22, 666);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.Size = new System.Drawing.Size(83, 23);
            this.settings_btn.TabIndex = 5;
            this.settings_btn.Text = "Settings";
            this.settings_btn.UseVisualStyleBackColor = true;
            // 
            // version
            // 
            this.version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(571, 712);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(74, 13);
            this.version.TabIndex = 6;
            this.version.Text = "V1.53.562.5.2";
            this.version.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // game_profile
            // 
            this.game_profile.AutoSize = true;
            this.game_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_profile.Location = new System.Drawing.Point(173, 13);
            this.game_profile.Name = "game_profile";
            this.game_profile.Size = new System.Drawing.Size(148, 25);
            this.game_profile.TabIndex = 0;
            this.game_profile.Text = "game_profile";
            this.game_profile.Click += new System.EventHandler(this.label1_Click);
            // 
            // game_profileList
            // 
            this.game_profileList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.game_profileList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.game_profileList.AllowColumnReorder = true;
            this.game_profileList.BackColor = System.Drawing.SystemColors.Control;
            this.game_profileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_name,
            this.col_size,
            this.col_lastPlayed,
            this.col_saveLoc});
            this.game_profileList.Location = new System.Drawing.Point(22, 41);
            this.game_profileList.Name = "game_profileList";
            this.game_profileList.Size = new System.Drawing.Size(670, 648);
            this.game_profileList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.game_profileList.TabIndex = 1;
            this.game_profileList.UseCompatibleStateImageBehavior = false;
            this.game_profileList.View = System.Windows.Forms.View.Details;
            this.game_profileList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.game_profileList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.game_profileList_MouseClick);
            // 
            // col_name
            // 
            this.col_name.Text = "Name";
            this.col_name.Width = 64;
            // 
            // col_size
            // 
            this.col_size.Text = "Size";
            this.col_size.Width = 68;
            // 
            // col_lastPlayed
            // 
            this.col_lastPlayed.Text = "Last Played";
            this.col_lastPlayed.Width = 119;
            // 
            // col_saveLoc
            // 
            this.col_saveLoc.Text = "Save Location";
            this.col_saveLoc.Width = 441;
            // 
            // profile_stats
            // 
            this.profile_stats.AutoSize = true;
            this.profile_stats.Location = new System.Drawing.Point(19, 701);
            this.profile_stats.Name = "profile_stats";
            this.profile_stats.Size = new System.Drawing.Size(217, 13);
            this.profile_stats.TabIndex = 2;
            this.profile_stats.Text = "You have 5 profiles, totaling 80TB of storage";
            // 
            // game_play
            // 
            this.game_play.Location = new System.Drawing.Point(377, 561);
            this.game_play.Name = "game_play";
            this.game_play.Size = new System.Drawing.Size(35, 35);
            this.game_play.TabIndex = 7;
            this.game_play.Text = "play";
            this.game_play.UseVisualStyleBackColor = true;
            this.game_play.Click += new System.EventHandler(this.game_play_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // game_picBox
            // 
            this.game_picBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("game_picBox.InitialImage")));
            this.game_picBox.Location = new System.Drawing.Point(78, 137);
            this.game_picBox.Name = "game_picBox";
            this.game_picBox.Size = new System.Drawing.Size(463, 377);
            this.game_picBox.TabIndex = 8;
            this.game_picBox.TabStop = false;
            // 
            // label_gameName
            // 
            this.label_gameName.AutoSize = true;
            this.label_gameName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gameName.Location = new System.Drawing.Point(209, 59);
            this.label_gameName.Name = "label_gameName";
            this.label_gameName.Size = new System.Drawing.Size(310, 30);
            this.label_gameName.TabIndex = 9;
            this.label_gameName.Text = "Minecraft 2.0 Ultimate Edition";
            this.label_gameName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.game_profile);
            this.splitContainer1.Panel1.Controls.Add(this.profile_stats);
            this.splitContainer1.Panel1.Controls.Add(this.game_profileList);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.legacy_btn);
            this.splitContainer1.Panel2.Controls.Add(this.settings_btn);
            this.splitContainer1.Panel2.Controls.Add(this.version);
            this.splitContainer1.Panel2.Controls.Add(this.game_play);
            this.splitContainer1.Panel2.Controls.Add(this.label_gameName);
            this.splitContainer1.Panel2.Controls.Add(this.game_swap);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.nogame_text);
            this.splitContainer1.Panel2.Controls.Add(this.game_picBox);
            this.splitContainer1.Panel2.Controls.Add(this.game_add);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1331, 725);
            this.splitContainer1.SplitterDistance = 712;
            this.splitContainer1.TabIndex = 9;
            // 
            // legacy_btn
            // 
            this.legacy_btn.Location = new System.Drawing.Point(111, 666);
            this.legacy_btn.Name = "legacy_btn";
            this.legacy_btn.Size = new System.Drawing.Size(83, 23);
            this.legacy_btn.TabIndex = 10;
            this.legacy_btn.Text = "Legacy";
            this.legacy_btn.UseVisualStyleBackColor = true;
            this.legacy_btn.Click += new System.EventHandler(this.legacy_btn_Click);
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
            // 
            // playToolStripMenuItem1
            // 
            this.playToolStripMenuItem1.Name = "playToolStripMenuItem1";
            this.playToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.playToolStripMenuItem1.Text = "Play";
            // 
            // swapToolStripMenuItem
            // 
            this.swapToolStripMenuItem.Name = "swapToolStripMenuItem";
            this.swapToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.swapToolStripMenuItem.Text = "Swap";
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
            // 
            // moveExistingSaveHereToolStripMenuItem
            // 
            this.moveExistingSaveHereToolStripMenuItem.Enabled = false;
            this.moveExistingSaveHereToolStripMenuItem.Name = "moveExistingSaveHereToolStripMenuItem";
            this.moveExistingSaveHereToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.moveExistingSaveHereToolStripMenuItem.Text = "Move Existing Save Here";
            // 
            // openProfileDirectoryToolStripMenuItem
            // 
            this.openProfileDirectoryToolStripMenuItem.Name = "openProfileDirectoryToolStripMenuItem";
            this.openProfileDirectoryToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openProfileDirectoryToolStripMenuItem.Text = "Open Profile Directory";
            // 
            // openGameDirectoryToolStripMenuItem
            // 
            this.openGameDirectoryToolStripMenuItem.Name = "openGameDirectoryToolStripMenuItem";
            this.openGameDirectoryToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openGameDirectoryToolStripMenuItem.Text = "Open Game Directory";
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
            // 
            // Main2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1359, 749);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main2";
            this.Text = "Game Save Swapper by Jackz";
            this.Load += new System.EventHandler(this.Main2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.game_picBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label nogame_text;
        private System.Windows.Forms.Button game_add;
        private System.Windows.Forms.Button game_swap;
        private System.Windows.Forms.Button settings_btn;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label game_profile;
        private System.Windows.Forms.Label profile_stats;
        private System.Windows.Forms.ListView game_profileList;
        private System.Windows.Forms.Label label_gameName;
        private System.Windows.Forms.PictureBox game_picBox;
        private System.Windows.Forms.Button game_play;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button legacy_btn;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ColumnHeader col_size;
        private System.Windows.Forms.ColumnHeader col_lastPlayed;
        private System.Windows.Forms.ColumnHeader col_saveLoc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem swapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveExistingSaveHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProfileDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGameDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}