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

        private void button1_Click(object sender, EventArgs e) {
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                MessageBox.Show("Please enter a game name");
                return;
            }else if (gamepath == "") {
                MessageBox.Show("Please select the save location of the game.");
                return;
            }
            SaveGames(listView1);
            textBox1.Text = "";
            gamepath = "";
        }

        private void SaveGames(ListView list) {
            List<dynamic> listitems = new List<dynamic>();
            foreach (ListViewItem item in list.Items) {
                dynamic obj = new ExpandoObject();
                obj.Name = item.SubItems[0].Text.ToString();
                obj.save_path = item.SubItems[1].Text.ToString();
                listitems.Add(obj);
            }
            var json = JsonConvert.SerializeObject(listitems);
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

    public class Game {
        public string Name;
        public string save_path;

        public Game(String name, String save_path) {
            this.Name = name;
            this.save_path = save_path;
        }

    }
}
