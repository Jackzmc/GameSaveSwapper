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
        public GameManagement() {
            InitializeComponent();
        }
    
        private string gamepath = "";
        static string SAVEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameSaveSwapper");

        private void browse_Click(object sender, EventArgs e) { //browse button
            var dialog = new FolderBrowserDialog {
                Description = "Game Save File Directory",

                //TODO: match game name == predefined locations, or steam?
                ShowNewFolderButton = true
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                gamepath = dialog.SelectedPath.ToString();
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
            addGame(new Game(textBox1.Text,gamepath));
            textBox1.Text = "";
            gamepath = "";
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

        /*private void SaveGames(ListView list) {
            List<dynamic> listitems = new List<dynamic>();
            foreach (ListViewItem item in list.Items) {
                dynamic obj = new ExpandoObject();
                obj.Name = item.SubItems[0].Text.ToString();
                obj.save_path = item.SubItems[1].Text.ToString();
                listitems.Add(obj);
            }
            var json = JsonConvert.SerializeObject(listitems);
            System.IO.File.WriteAllText(Path.Combine(SAVEPATH, "games.json"), json);
        }*/

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
            List<dynamic> jsonOut = JsonConvert.DeserializeObject<List<dynamic>>(json);
            List<Game> games = new List<Game>();
            foreach (dynamic item in jsonOut) {
                games.Add(new Game(item.Name.ToString(),item.save_path.ToString()));

            }

            return games.ToArray();
        }

        private void GameManagement_Load(object sender, EventArgs e) {
            LoadGames(listView1);
        }

    }

    
}
