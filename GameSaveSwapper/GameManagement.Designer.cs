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
            this.listView1 = new System.Windows.Forms.ListView();
            this.game_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.game_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.game_exe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.browse_saveloc = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gameloc_box = new System.Windows.Forms.TextBox();
            this.gameexe_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.browse_exe = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.launchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSavePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseEXEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSaveDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.game_name,
            this.game_path,
            this.game_exe});
            this.listView1.Location = new System.Drawing.Point(12, 9);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(817, 365);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            this.game_exe.Width = 394;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(14, 380);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 20);
            this.textBox1.TabIndex = 1;
            // 
            // browse_saveloc
            // 
            this.browse_saveloc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browse_saveloc.Location = new System.Drawing.Point(378, 403);
            this.browse_saveloc.Name = "browse_saveloc";
            this.browse_saveloc.Size = new System.Drawing.Size(104, 20);
            this.browse_saveloc.TabIndex = 2;
            this.browse_saveloc.Text = "Browse...";
            this.browse_saveloc.UseVisualStyleBackColor = true;
            this.browse_saveloc.Click += new System.EventHandler(this.browsesaveloc_Click);
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add.Location = new System.Drawing.Point(754, 380);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 44);
            this.add.TabIndex = 3;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Game Save Location";
            // 
            // gameloc_box
            // 
            this.gameloc_box.Location = new System.Drawing.Point(178, 380);
            this.gameloc_box.Name = "gameloc_box";
            this.gameloc_box.ReadOnly = true;
            this.gameloc_box.Size = new System.Drawing.Size(304, 20);
            this.gameloc_box.TabIndex = 6;
            // 
            // gameexe_box
            // 
            this.gameexe_box.Location = new System.Drawing.Point(499, 380);
            this.gameexe_box.Name = "gameexe_box";
            this.gameexe_box.ReadOnly = true;
            this.gameexe_box.Size = new System.Drawing.Size(241, 20);
            this.gameexe_box.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "EXE Location (Optional)";
            // 
            // browse_exe
            // 
            this.browse_exe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browse_exe.Location = new System.Drawing.Point(636, 403);
            this.browse_exe.Name = "browse_exe";
            this.browse_exe.Size = new System.Drawing.Size(104, 20);
            this.browse_exe.TabIndex = 9;
            this.browse_exe.Text = "Browse...";
            this.browse_exe.UseVisualStyleBackColor = true;
            this.browse_exe.Click += new System.EventHandler(this.browse_exe_Click);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 170);
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
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // openSaveDirectoryToolStripMenuItem
            // 
            this.openSaveDirectoryToolStripMenuItem.Name = "openSaveDirectoryToolStripMenuItem";
            this.openSaveDirectoryToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openSaveDirectoryToolStripMenuItem.Text = "Open Save Directory";
            this.openSaveDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openSaveDirectoryToolStripMenuItem_Click);
            // 
            // GameManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 427);
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
    }
}