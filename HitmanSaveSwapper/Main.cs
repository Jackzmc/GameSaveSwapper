using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.ListViewItem;

namespace GameSaveSwapper {
    public partial class Main : Form {
        /* TODO:
         * [DONE] Adding games
         * [Done?] Adding a new save profile //Can manually save File->Save
         * [Done] Saving Games
         * [Done] Create new folder on game add 
         * Create new folder on profile save browse
         * Find game path by name?
         * Implement ContextMenuStrip items (Play,Rename,Change Path, Delete)
         * 
         */

        static string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // AppData folder
        static string SAVEPATH = Path.Combine(APPDATA_PATH, "GameSaveSwapper");

        private string profileSaveDir = "/dev/";

        public Main() {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e) {
            reloadGameChooser(); //reload the combobox
            LoadGroups(); //Load group to listview list
            LoadProfiles(listView1); //grab profiles.json
        }

        private void reloadGameChooser() {
            Game[] games = new GameManagement().getGames();
            foreach (Game game in games) {
                if (game != null && game.Name != "Misc") game_choose.Items.Add(game.Name);
            }
            game_choose.SelectedIndex = 0;
        }

        private void SaveProfiles(Profile[] profiles) {
            var json = JsonConvert.SerializeObject(profiles);
            System.IO.File.WriteAllText(Path.Combine(SAVEPATH, "profiles.json"), json);

            /*List<dynamic> listitems = new List<dynamic>();
            foreach(ListViewItem item in list.Items) {
                dynamic obj = new ExpandoObject();
                obj.Name = item.SubItems[0].Text.ToString();
                obj.Path = item.SubItems[1].Text.ToString();
                obj.Group = item.Group;
                listitems.Add(obj);
            }
            var json = JsonConvert.SerializeObject(listitems);
            System.IO.File.WriteAllText(Path.Combine(SAVEPATH,"profiles.json"),json);*/
        }
        private void SaveProfilesFromListView(ListView.ListViewItemCollection list) {
            List<Profile> listitems = new List<Profile>();
            foreach (ListViewItem item in list) {
                Profile profile = new Profile(item.SubItems[0].Text, item.SubItems[1].Text, item.Group.Header);
                listitems.Add(profile);
            }
            SaveProfiles(listitems.ToArray());
        }

        private Profile[] GetProfiles() {
            String json = System.IO.File.ReadAllText(Path.Combine(SAVEPATH, "profiles.json"));
            List<Profile> profiles = JsonConvert.DeserializeObject<List<Profile>>(json);
            return profiles.ToArray();
        }

        

        private void LoadProfiles(ListView list) {
            Profile[] profiles = GetProfiles();

            foreach (Profile profile in profiles) {
                var listitem = new ListViewItem();
                var path = new ListViewSubItem();

                ListViewGroup group = GetGameGroup(profile.Group);
                //list.Groups.Add(group);

                path.Text = profile.storeLocation;

                listitem.Group = GetGameGroup(profile.Group);
                listitem.Name = profile.name;
                listitem.Text = profile.name;

                listitem.SubItems.Add(path);
                list.Items.Add(listitem);

            }
        }

        /*private void GetProfiles(ListView list) {
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

            }
        }*/

        private void LoadGroups() {
            Game[] games = new GameManagement().getGames();
            foreach (Game game in games) {
                listView1.Groups.Add(new ListViewGroup(game.Name));
            }
            listView1.Groups.Add(new ListViewGroup("Unknown/Invalid"));
        }
        private ListViewGroup getGameGroup(Game game) {
            ListViewGroupCollection collection = listView1.Groups;
            foreach (ListViewGroup group in collection) {
                if (group.Header != null && game.Name.Equals(group.Header)) {
                    return group;
                }
            }
            return collection[collection.Count - 1];
        }

        private ListViewGroup GetGameGroup(String groupname) {
            ListViewGroupCollection collection = listView1.Groups;
            foreach (ListViewGroup group in collection) {
                if (group.Header != null && groupname.Equals(group.Header)) {
                    return group;
                }   
            }
            return collection[collection.Count - 1];
            //return new ListViewGroup(groupname);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            e.Cancel = this.listView1.SelectedItems.Count <= 0;
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

            listItem.Group = GetGameGroup(game_choose.SelectedItem.ToString());

            listItem.SubItems.Add(new ListViewSubItem().Text = profileSaveDir);

            listItem.Name = game_input.Text;
            listItem.Text = game_input.Text;

            listView1.Items.Add(listItem);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveProfilesFromListView(listView1.Items);
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

        /*private void EmptyGameSave(Game game) {
            try {   // Open the text file using a stream reader.
                var swapFile = Path.Combine(game.save_path, ".swapper");
                //file contents = name of profile
                if (!File.Exists(swapFile)) {
                    return;
                }
                using (StreamReader sr = new StreamReader(swapFile)) {
                    String line = sr.ReadToEnd();
                    int fromID;
                    if (!int.TryParse(line, out fromID)) {
                        MessageBox.Show("Unknown location to store hitman save - Not A number. Explode world?");
                        return;
                    }
                    Debug.WriteLine("Line: " + line + "| ID:" + fromID);
                    string saveLocation = Path.Combine(SAVEPATH, "save" + fromID);
                    if (!Directory.Exists(saveLocation)) {
                        Directory.CreateDirectory(saveLocation);
                    }
                    //TODO: Wipe storage folders & files (autosaves stack up)
                    Debug.WriteLine(HITMANPATH.Parent + HITMANPATH.ToString());
                    List<DirectoryInfo> subFolders = HITMANPATH.GetDirectories().ToList();
                    Debug.WriteLine("[" + fromID + "] Moving " + subFolders.Count + " files to %PROFILEPATH%/save" + fromID);
                    foreach (DirectoryInfo dir in subFolders) {
                        //dir.MoveTo(Path.Combine(profilename,dir.Name));
                        List<FileInfo> hitmanFiles = dir.GetFiles("*", SearchOption.TopDirectoryOnly).ToList();
                        foreach (FileInfo file in hitmanFiles) {
                            try {
                                string destDir = Path.Combine(saveLocation, dir.Name);
                                string destFile = Path.Combine(destDir, file.Name);
                                if (!new DirectoryInfo(destDir).Exists) {
                                    Directory.CreateDirectory(destDir);
                                }
                                if (File.Exists(destFile)) {
                                    File.Delete(destFile);
                                }
                                file.MoveTo(destFile);
                            } catch (Exception ex) when (ex is UnauthorizedAccessException || ex is IOException) {
                                Debug.WriteLine("Failed move: " + ex.Message);
                            }
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("The file could not be read: " + e.Message);
                throw;
            }
        }*/

        private void LoadGameSave(Game game, Profile profile) {

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
