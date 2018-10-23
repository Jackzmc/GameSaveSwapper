namespace GameSaveSwapper {
    partial class GameAdder {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameAdder));
            this.in_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.in_saveloc = new System.Windows.Forms.TextBox();
            this.in_exepath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btn_browse_save = new System.Windows.Forms.Button();
            this.btn_browse_exe = new System.Windows.Forms.Button();
            this.in_appid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // in_name
            // 
            this.in_name.Location = new System.Drawing.Point(99, 12);
            this.in_name.Name = "in_name";
            this.in_name.Size = new System.Drawing.Size(144, 20);
            this.in_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game Name";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 136);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(93, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Steam Game?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save Location";
            // 
            // in_saveloc
            // 
            this.in_saveloc.Location = new System.Drawing.Point(99, 50);
            this.in_saveloc.Name = "in_saveloc";
            this.in_saveloc.Size = new System.Drawing.Size(359, 20);
            this.in_saveloc.TabIndex = 4;
            // 
            // in_exepath
            // 
            this.in_exepath.Location = new System.Drawing.Point(99, 92);
            this.in_exepath.Name = "in_exepath";
            this.in_exepath.Size = new System.Drawing.Size(359, 20);
            this.in_exepath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "EXE Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Steam APP ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(93, 227);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(40, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cancel";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btn_browse_save
            // 
            this.btn_browse_save.Image = global::GameSaveSwapper.Properties.Resources.Search_16x;
            this.btn_browse_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_browse_save.Location = new System.Drawing.Point(464, 47);
            this.btn_browse_save.Name = "btn_browse_save";
            this.btn_browse_save.Size = new System.Drawing.Size(90, 25);
            this.btn_browse_save.TabIndex = 11;
            this.btn_browse_save.Text = "Browse";
            this.btn_browse_save.UseVisualStyleBackColor = true;
            this.btn_browse_save.Click += new System.EventHandler(this.btn_browse_save_Click);
            // 
            // btn_browse_exe
            // 
            this.btn_browse_exe.Image = global::GameSaveSwapper.Properties.Resources.Search_16x;
            this.btn_browse_exe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_browse_exe.Location = new System.Drawing.Point(464, 89);
            this.btn_browse_exe.Name = "btn_browse_exe";
            this.btn_browse_exe.Size = new System.Drawing.Size(90, 25);
            this.btn_browse_exe.TabIndex = 12;
            this.btn_browse_exe.Text = "Browse";
            this.btn_browse_exe.UseVisualStyleBackColor = true;
            this.btn_browse_exe.Click += new System.EventHandler(this.btn_browse_exe_Click);
            // 
            // in_appid
            // 
            this.in_appid.Enabled = false;
            this.in_appid.Location = new System.Drawing.Point(102, 170);
            this.in_appid.Name = "in_appid";
            this.in_appid.Size = new System.Drawing.Size(100, 20);
            this.in_appid.TabIndex = 13;
            // 
            // GameAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 252);
            this.Controls.Add(this.in_appid);
            this.Controls.Add(this.btn_browse_exe);
            this.Controls.Add(this.btn_browse_save);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in_exepath);
            this.Controls.Add(this.in_saveloc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.in_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameAdder";
            this.Text = "GameAdder";
            this.Load += new System.EventHandler(this.GameAdder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox in_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox in_saveloc;
        private System.Windows.Forms.TextBox in_exepath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btn_browse_save;
        private System.Windows.Forms.Button btn_browse_exe;
        private System.Windows.Forms.TextBox in_appid;
    }
}