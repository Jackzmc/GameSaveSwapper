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
using Newtonsoft.Json;
using static System.Windows.Forms.ListViewItem;

namespace GameSaveSwapper {
    public partial class Main : Form {
        static string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // AppData folder
        static string SAVEPATH = Path.Combine(APPDATA_PATH, "GameSaveSwapper");

        private string profileSaveDir = "/dev/";

        public Main() {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e) {
            Game[] games = new GameManagement().getGames();
 
            foreach (Game game in games) {
                if(game != null && game.Name != "Misc") game_choose.Items.Add(game.Name);
            }
            game_choose.SelectedIndex = 0;

            LoadGroups();
            GetProfiles(listView1);
            //ToJson(listView1);
        }

        private void SaveProfiles(ListView list) {
            List<dynamic> listitems = new List<dynamic>();
            foreach(ListViewItem item in list.Items) {
                dynamic obj = new ExpandoObject();
                obj.Name = item.SubItems[0].Text.ToString();
                obj.Path = item.SubItems[1].Text.ToString();
                obj.Group = item.Group;
                listitems.Add(obj);
            }
            var json = JsonConvert.SerializeObject(listitems);
            System.IO.File.WriteAllText(Path.Combine(SAVEPATH,"profiles.json"),json);
        }

        private void GetProfiles(ListView list) {
            String json = System.IO.File.ReadAllText(Path.Combine(SAVEPATH, "profiles.json"));
            List<dynamic> jsonOut = JsonConvert.DeserializeObject<List<dynamic>>(json);

            foreach (dynamic item in jsonOut) {
                var listitem = new ListViewItem();
                var path = new ListViewSubItem();

                String groupname = ((Object) item.Group).ToString();

                ListViewGroup group = GetGroup(groupname);
                list.Groups.Add(group);

                path.Text = item.Path;

                listitem.Group = group;
                listitem.Name = item.Name;
                listitem.Text = item.Name;

                listitem.SubItems.Add(path);
                list.Items.Add(listitem);
                /*if (list.Groups.IndexOf(group) == -1) {
                    //
                    list.Groups.Add(group);
                } else {
                    group = list.Groups[list.Groups.IndexOf(item.Group)];
                }*/

            }
        }

        private void LoadGroups() {
            Game[] games = new GameManagement().getGames();
            foreach (Game game in games) {
                listView1.Groups.Add(new ListViewGroup(game.Name));
            }
            listView1.Groups.Add(new ListViewGroup("Unknown/Invalid"));
        }

        private ListViewGroup GetGroup(String groupname) {
            ListViewGroupCollection collection = listView1.Groups;
            foreach (ListViewGroup group in collection) {
                Debug.WriteLine(group.Header);
                if (group.Header != null && groupname.Equals(group.Header)) {
                    return group;
                }
                
            }

            return collection[collection.Count - 1];
            //return new ListViewGroup(groupname);
        }

        /* TODO:
         * [DONE] Adding games
         * Adding a new save profile
         * Saving Games
         */
        /* Old todo list: 
         * On (EventHandler) textbox change -> save
         * On Load -> save
         * Finish hitman -> save
         * Copy from save -> hitman 
         */

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            e.Cancel = this.listView1.SelectedItems.Count <= 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            if (game_input.Text == "") {
                MessageBox.Show("Please enter a name of a game");
                return;
            }else if (profileSaveDir == "") {
                MessageBox.Show("Please select a path");
                return;
            }else if (game_choose.SelectedText == null) {
                MessageBox.Show("Please select a game");
                return;
            }

            ListViewItem listItem = new ListViewItem();

            listItem.Group = GetGroup(game_choose.SelectedItem.ToString());

            listItem.SubItems.Add(new ListViewSubItem().Text = profileSaveDir);

            listItem.Name = game_input.Text;
            listItem.Text = game_input.Text;

            listView1.Items.Add(listItem);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveProfiles(listView1);
        }

        private void gameSetupToolStripMenuItem_Click(object sender, EventArgs e) {
            //this.Hide();
            new GameManagement().Show();
        }

        private void game_path_Click(object sender, EventArgs e) {
            var browse = new FolderBrowserDialog();
            browse.Description = "Choose where to save this profile";
            browse.ShowNewFolderButton = true;
            //TODO: create a new folder
            browse.SelectedPath = SAVEPATH;
            var result = browse.ShowDialog();
            if (result == DialogResult.OK) {
                profileSaveDir = browse.SelectedPath;
            }

        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void changePathToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void NotImplemented() {
            MessageBox.Show("Feature not implemented");
        }
    }
}
