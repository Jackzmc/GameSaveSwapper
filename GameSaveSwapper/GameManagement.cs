﻿using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        
        public GameManagement() {
            this.main = (Main) Application.OpenForms[0];
            InitializeComponent();
        }
        
        //variables
        private Main main;
        private static readonly ILog log = LogManager.GetLogger("gamemanagement");
        static string SAVEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameSaveSwapper");
        private List<Game> games;

        //misc events
        private void GameManagement_Load(object sender, EventArgs e) {
            this.games = getGames();
            LoadGamesList(listView1);
        }

        private void GameManagement_FormClosing(object sender, FormClosingEventArgs e) {
            main.reloadGameChooser();
        }
        //click events
        private void browsesaveloc_Click(object sender, EventArgs e) { //browse button
            var dialog = new FolderBrowserDialog {
                Description = "Game Save File Directory",

                //TODO: match game name == predefined locations, or steam?
                ShowNewFolderButton = true
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                //gamepath = dialog.SelectedPath.ToString();
                gameloc_box.Text = dialog.SelectedPath.ToString();
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
                //exepath = dialog.FileName;
                gameexe_box.Text = dialog.FileName;
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
            var gamepath = gameloc_box.Text;
            var exepath = gameexe_box.Text;
            if (textBox1.Text == null) {
                MessageBox.Show("Please enter a game name","Missing game name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (gamepath == null) {
                MessageBox.Show("Please select the save location of the game.","Missing Saves Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dir = new DirectoryInfo(Path.Combine(SAVEPATH,textBox1.Text));
            if (!dir.Exists) {
                Directory.CreateDirectory(dir.FullName);
            }

            if (!Directory.Exists(gamepath)) {
                MessageBox.Show(
                    "Inputted save path does not exist. Please use browse or check to make sure save path is valid.",
                    "Save Path Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Specified Path Invalid: " + gamepath);
                return;
            }else if(exepath != null && exepath != "" && !File.Exists(exepath)) {
                MessageBox.Show(
                    "Specified EXE does not exist. Please use browse or check to make sure path is valid.",
                    "Exe Path Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Game game in this.games) {
                Debug.WriteLine(game.Name + "|" + textBox1.Text);
                if (game.Name.ToLower().Equals(textBox1.Text.ToLower())) {
                    MessageBox.Show("There is another game that already contains that name.", "Game Already Exists",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Game " + textBox1.Name + " has been already added");
                    return;
                }
            }
            log.Debug("New Game Added: " + textBox1.Text + "; path: " + gamepath);

            Game newGame = new Game(textBox1.Text, exepath, gamepath);
            this.games.Add(newGame);
            this.listView1.Items.Add(newGame.getListViewItem());
            textBox1.Text = "";
            gamepath = null;
            exepath = null;
            SaveGames(this.games);
            
        }
        //internal functions

        private void LoadGamesList(ListView list) {
            list.Items.Clear();
            Game[] games = this.games.ToArray();
            foreach (Game game in games) {
                var newList = new ListViewItem();
                newList.Name = game.Name;
                newList.Text = game.Name;
                newList.SubItems.Add(new ListViewSubItem().Text = game.save_path);
                list.Items.Add(newList);
            
            }
        }

        //NEEDS MOVING
        private void SaveGames(List<Game> games) {
            var json = JsonConvert.SerializeObject(games);
            System.IO.File.WriteAllText(Path.Combine(SAVEPATH, "games.json"), json);
        }

        public List<Game> getGames() {
            String json = System.IO.File.ReadAllText(Path.Combine(SAVEPATH, "games.json"));
            return JsonConvert.DeserializeObject<List<Game>>(json);
        }
        //END NEEDS MOVING

        //click events

        private void launchGameToolStripMenuItem_Click(object sender, EventArgs e) {
            var item = listView1.FocusedItem;
            for (var i = 0; i < this.games.Count; i++) {
                if (this.games[i].Name == item.SubItems[0].Text) {
                    Game game = this.games[i];
                    if (game.exePath == null || game.exePath == "") {
                        var result = MessageBox.Show("Game does not have an exe specified, would you like to add one?",
                            "EXE Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes) {
                            main.NotImplemented();
                            
                        }
                        return;
                    }
                    if (File.Exists(game.exePath)) {
                        Process.Start(game.exePath);
                    } else {
                        MessageBox.Show("Exe provided does not exist", "EXE Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    return;
                }
            }

            MessageBox.Show("Game was not found in list of games, try reloading.", "Game not found",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            main.NotImplemented();
        }

        private void changeSavePathToolStripMenuItem_Click(object sender, EventArgs e) {
            main.NotImplemented();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            var item = listView1.FocusedItem;
            for (var i = 0; i < this.games.Count; i++) {
                if (this.games[i].Name.Equals(item.SubItems[0].Text)) {
                    String gamesavepath = Path.Combine(SAVEPATH, this.games[i].Name);
                    if (main.IsDirectoryEmpty(gamesavepath)) {
                        Directory.Delete(gamesavepath);
                    } else {
                        var result = MessageBox.Show(
                            "There are profiles for this game. Please delete all profiles first before deleting the game.",
                            "Existing Profiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        log.Error("GameDelete: Existing Profiles in location");
                        return;
                    }
                    this.games.RemoveAt(i);
                }
            }
            //TODO: check for folder and if has no files, delete
           
            //check deleteToolStripMenuItem_Click on main to see what it does
            SaveGames(this.games);
            LoadGamesList(listView1); 
        }

        private void chooseEXEToolStripMenuItem_Click(object sender, EventArgs e) {
            main.NotImplemented();
        }

        private void openSaveDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
            var item = listView1.FocusedItem;
            Game game = main.findGame(item.SubItems[0].Text);
            Process.Start(game.save_path);
        }
    }

    
}
