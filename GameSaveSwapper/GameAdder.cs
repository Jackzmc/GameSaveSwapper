using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSaveSwapper {
    public partial class GameAdder : Form {
        public GameAdder() {
            InitializeComponent();
        }

        public Game Game;
        public bool IsSteam;
        public string Appid;


        //events
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Game = new Game(in_name.Text, in_exepath.Text,in_saveloc.Text);
            this.IsSteam = checkBox1.Checked;
            this.Appid = (IsSteam) ? in_appid.Text : null;
            this.Close();
        }
        private void btn_browse_save_Click(object sender, EventArgs e) {
            var dialog = OpenSaveBrowser();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                //gamepath = dialog.SelectedPath.ToString();
                in_saveloc.Text = dialog.SelectedPath.ToString();
            }
        }

        private void btn_browse_exe_Click(object sender, EventArgs e) {
            var dialog = OpenExeBrowser();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                //exepath = dialog.FileName;
                in_exepath.Text = dialog.FileName;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                in_appid.Enabled = true;
            } else {
                in_appid.Enabled = false;
            }
        }
        //click
        private FolderBrowserDialog OpenSaveBrowser() {
            return new FolderBrowserDialog {
                Description = "Game Save File Directory",

                //TODO: match game name == predefined locations, or steam?
                ShowNewFolderButton = true
            };
        }

        private OpenFileDialog OpenExeBrowser() {
            return new OpenFileDialog() {
                CheckFileExists = true,
                Filter = "Executables|*.exe",
                InitialDirectory = @"C:/Program Files (x86)/Steam",
                Title = "Choose game .exe"
            };
        }

        private void GameAdder_Load(object sender, EventArgs e) {

        }
    }
}
