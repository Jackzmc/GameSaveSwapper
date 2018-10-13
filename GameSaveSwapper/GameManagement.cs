using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace GameSaveSwapper {
    public partial class GameManagement : Form {
        private Main main;
        public GameManagement() {
            this.main = (Main) Application.OpenForms[0];
            InitializeComponent();
        }

        private string gamepath;
        private string exepath;
        static string SAVEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameSaveSwapper");

        private void browsesaveloc_Click(object sender, EventArgs e) { //browse button
            var dialog = new FolderBrowserDialog {
                Description = "Game Save File Directory",

                //TODO: match game name == predefined locations, or steam?
                ShowNewFolderButton = true
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                gamepath = dialog.SelectedPath.ToString();
                gameloc_box.Text = gamepath;
            }
        }
        private void browse_exe_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog() {
                CheckFileExists = true,
                Filter = "Executables|*.exe",
                InitialDirectory = @"C:/Program Files (x86)/Steam",
                Title = "Choose game .exe"
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                exepath = dialog.FileName;
                gameexe_box.Text = exepath;
            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                if (listView1.FocusedItem.Bounds.Contains(e.Location)) {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void add_Click(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                MessageBox.Show("Please enter a game name");
                return;
            }else if (gamepath == "") {
                MessageBox.Show("Please select the save location of the game.");
                return;
            }
            var dir = new DirectoryInfo(Path.Combine(SAVEPATH,textBox1.Text));
            if (!dir.Exists) {
                Directory.CreateDirectory(dir.FullName);
            }
            addGame(new Game(textBox1.Text,exepath,gamepath));
            textBox1.Text = "";
            gamepath = null;
            exepath = null;
        }

        private void addGame(Game game) {
            List<Game> games = getGames().ToList();
            games.Add(game);
            listView1.Items.Add(game.getListViewItem());
            SaveGames(games.ToArray());
        }

        private void SaveGames(Game[] games) {
            var json = JsonConvert.SerializeObject(games);
            System.IO.File.WriteAllText(Path.Combine(SAVEPATH, "games.json"), json);
        }

        private void LoadGames(ListView list) {
            String json = System.IO.File.ReadAllText(Path.Combine(SAVEPATH, "games.json"));
            Game[] games = getGames();
            foreach (Game game in games) {
                var newList = new ListViewItem();
                newList.Name = game.Name;
                newList.Text = game.Name;
                newList.SubItems.Add(new ListViewSubItem().Text = game.save_path);
                list.Items.Add(newList);
            
            }
        }

        public Game[] getGames() {
            String json = System.IO.File.ReadAllText(Path.Combine(SAVEPATH, "games.json"));
            return JsonConvert.DeserializeObject<List<Game>>(json).ToArray();
        }

        private void GameManagement_Load(object sender, EventArgs e) {
            LoadGames(listView1);
        }

        private void GameManagement_FormClosing(object sender, FormClosingEventArgs e) {
            main.reloadGameChooser();  
        }

        private void launchGameToolStripMenuItem_Click(object sender, EventArgs e) {
            main.NotImplemented();
            
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            main.NotImplemented();
        }

        private void changeSavePathToolStripMenuItem_Click(object sender, EventArgs e) {
            main.NotImplemented();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            main.NotImplemented();
        }

        private void chooseEXEToolStripMenuItem_Click(object sender, EventArgs e) {
            main.NotImplemented();
        }
    }

    
}
