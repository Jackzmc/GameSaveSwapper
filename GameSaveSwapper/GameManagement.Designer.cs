namespace GameSaveSwapper {
    partial class GameManagement {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameManagement));
            this.listView1 = new System.Windows.Forms.ListView();
            this.game_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.game_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.game_exe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gameloc_box = new System.Windows.Forms.TextBox();
            this.gameexe_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.launchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSavePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseEXEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openSaveDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.browse_exe = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.browse_saveloc = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.game_name,
            this.game_path,
            this.game_exe});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(830, 425);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // game_name
            // 
            this.game_name.Text = "Game Name";
            this.game_name.Width = 106;
            // 
            // game_path
            // 
            this.game_path.Text = "Game Path";
            this.game_path.Width = 339;
            // 
            // game_exe
            // 
            this.game_exe.Text = "Game Executable Location";
            this.game_exe.Width = 375;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(12, 443);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Game Save Location";
            // 
            // gameloc_box
            // 
            this.gameloc_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gameloc_box.Location = new System.Drawing.Point(337, 443);
            this.gameloc_box.Name = "gameloc_box";
            this.gameloc_box.Size = new System.Drawing.Size(304, 20);
            this.gameloc_box.TabIndex = 6;
            // 
            // gameexe_box
            // 
            this.gameexe_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gameexe_box.Location = new System.Drawing.Point(337, 481);
            this.gameexe_box.Name = "gameexe_box";
            this.gameexe_box.Size = new System.Drawing.Size(304, 20);
            this.gameexe_box.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(204, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "EXE Location (Optional)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.renameToolStripMenuItem,
            this.changeSavePathToolStripMenuItem,
            this.chooseEXEToolStripMenuItem,
            this.toolStripSeparator2,
            this.openSaveDirectoryToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 148);
            // 
            // launchGameToolStripMenuItem
            // 
            this.launchGameToolStripMenuItem.Name = "launchGameToolStripMenuItem";
            this.launchGameToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.launchGameToolStripMenuItem.Text = "Launch Game";
            this.launchGameToolStripMenuItem.Click += new System.EventHandler(this.launchGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // changeSavePathToolStripMenuItem
            // 
            this.changeSavePathToolStripMenuItem.Name = "changeSavePathToolStripMenuItem";
            this.changeSavePathToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.changeSavePathToolStripMenuItem.Text = "Change Save Path";
            this.changeSavePathToolStripMenuItem.Click += new System.EventHandler(this.changeSavePathToolStripMenuItem_Click);
            // 
            // chooseEXEToolStripMenuItem
            // 
            this.chooseEXEToolStripMenuItem.Name = "chooseEXEToolStripMenuItem";
            this.chooseEXEToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.chooseEXEToolStripMenuItem.Text = "Choose EXE";
            this.chooseEXEToolStripMenuItem.Click += new System.EventHandler(this.chooseEXEToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // openSaveDirectoryToolStripMenuItem
            // 
            this.openSaveDirectoryToolStripMenuItem.Name = "openSaveDirectoryToolStripMenuItem";
            this.openSaveDirectoryToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openSaveDirectoryToolStripMenuItem.Text = "Open Save Directory";
            this.openSaveDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openSaveDirectoryToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("DejaVu Sans Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(22, 510);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(182, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "View list of tested games";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // browse_exe
            // 
            this.browse_exe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browse_exe.Image = global::GameSaveSwapper.Properties.Resources.Search_16x;
            this.browse_exe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browse_exe.Location = new System.Drawing.Point(647, 481);
            this.browse_exe.Name = "browse_exe";
            this.browse_exe.Size = new System.Drawing.Size(104, 28);
            this.browse_exe.TabIndex = 9;
            this.browse_exe.Text = "Choose Exe";
            this.browse_exe.UseVisualStyleBackColor = true;
            this.browse_exe.Click += new System.EventHandler(this.browse_exe_Click);
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add.Image = global::GameSaveSwapper.Properties.Resources.Add_16x;
            this.add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add.Location = new System.Drawing.Point(757, 441);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(85, 63);
            this.add.TabIndex = 3;
            this.add.Text = "Add \r\nGame";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // browse_saveloc
            // 
            this.browse_saveloc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browse_saveloc.Image = global::GameSaveSwapper.Properties.Resources.Search_16x;
            this.browse_saveloc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browse_saveloc.Location = new System.Drawing.Point(647, 438);
            this.browse_saveloc.Name = "browse_saveloc";
            this.browse_saveloc.Size = new System.Drawing.Size(104, 28);
            this.browse_saveloc.TabIndex = 2;
            this.browse_saveloc.Text = "Browse...";
            this.browse_saveloc.UseVisualStyleBackColor = true;
            this.browse_saveloc.Click += new System.EventHandler(this.browsesaveloc_Click);
            // 
            // GameManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 559);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.browse_exe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gameexe_box);
            this.Controls.Add(this.gameloc_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add);
            this.Controls.Add(this.browse_saveloc);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(861, 466);
            this.Name = "GameManagement";
            this.Text = "Game Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameManagement_FormClosing);
            this.Load += new System.EventHandler(this.GameManagement_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader game_name;
        private System.Windows.Forms.ColumnHeader game_path;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button browse_saveloc;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader game_exe;
        private System.Windows.Forms.TextBox gameloc_box;
        private System.Windows.Forms.TextBox gameexe_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browse_exe;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem launchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSavePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseEXEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSaveDirectoryToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}