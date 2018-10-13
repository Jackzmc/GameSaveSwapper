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
         * [Done] Create new folder on profile save browse
         * Find game path by name?
         * [Done] Add folder SAVEPATH/(GAME NAME)/(PROFILE NAME)
         * [Done] Remove "saveLocation" and just save it in appdata and relative?
         * Loop all files and folders instead of subfolders and their contents
         * Implement ContextMenuStrip items for Main form:
         *      Play -> Swap & Launch EXE
         *      [Done?] Swap (Formely Play) -> Swap directories
         *      Rename -> Rename name of Profile
         *      Change Path-> Change Path of profile
         *      Delete -> delete profile
         * Implement ContextMenuStrip items for GameMangement:
         *      Launch Game
         *      Rename
         *      Change Path
         *      Delete
         */

        static string SAVEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameSaveSwapper");

        public Main() {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e) {
            String gamesJSON = Path.Combine(SAVEPATH, "games.json");
            String profilesJSON = Path.Combine(SAVEPATH, "profiles.json");
            if (!File.Exists(gamesJSON)) System.IO.File.WriteAllText(gamesJSON,"[]");
            if (!File.Exists(profilesJSON)) System.IO.File.WriteAllText(profilesJSON, "[]");

            reloadGameChooser(); //reload the combobox
            LoadGroups(); //Load group to listview list
            LoadProfiles(listView1); //grab profiles.json
        }

        public void reloadGameChooser() {
            game_choose.Items.Clear();
            Game[] games = new GameManagement().getGames();
            foreach (Game game in games) {
                if (game != null && game.Name != "Misc") game_choose.Items.Add(game.Name);
            }
            if(game_choose.Items.Count > 0) game_choose.SelectedIndex = 0;
            LoadGroups();
        }

        private void SaveProfiles(Profile[] profiles) {
            var json = JsonConvert.SerializeObject(profiles);
            System.IO.File.WriteAllText(Path.Combine(SAVEPATH, "profiles.json"), json);
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
            list.Items.Clear();
            foreach (Profile profile in profiles) {
                var listitem = new ListViewItem();
                var path = new ListViewSubItem();

                ListViewGroup group = GetGameGroup(profile.group);
                //list.Groups.Add(group);

                path.Text = profile.storeLocation;

                listitem.Group = GetGameGroup(profile.group);
                listitem.Name = profile.name;
                listitem.Text = profile.name;

                listitem.SubItems.Add(path);
                list.Items.Add(listitem);

            }
        }


        private void LoadGroups() {
            listView1.Groups.Clear();
            Game[] games = new GameManagement().getGames();
            foreach (Game game in games) {
                listView1.Groups.Add(new ListViewGroup(game.Name));
            }
            listView1.Groups.Add(new ListViewGroup("Unknown/Invalid"));
        }
        private ListViewGroup GetGameGroup(Game game) {
            return GetGameGroup(game.Name);
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
                MessageBox.Show("Please enter a profile name","Missing Profile Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (game_choose.SelectedText == null) {
                MessageBox.Show("Please select a game for this profile","Missing Profile Game",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            List<Profile> profiles = GetProfiles().ToList();

            String savepath = Path.Combine(SAVEPATH, game_choose.SelectedItem.ToString(), game_input.Text);
            if (!Directory.Exists(savepath)) {
                Directory.CreateDirectory(savepath);
            }


            Profile profile = new Profile(game_input.Text,savepath,game_choose.SelectedItem.ToString());

            profiles.Add(profile);
            ListViewItem listItem = new ListViewItem();

            listItem.Group = GetGameGroup(profile.group);
            listItem.SubItems.Add(new ListViewSubItem().Text = profile.storeLocation);

            listItem.Name = profile.name;
            listItem.Text = profile.name;
            listView1.Items.Add(listItem);
            SaveProfiles(profiles.ToArray());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveProfilesFromListView(listView1.Items);
        }

        private void gameSetupToolStripMenuItem_Click(object sender, EventArgs e) {
            //this.Hide();
            new GameManagement().Show();
        }

        private bool EmptyGameSaveFolder(Game game) {
            try {   // Open the text file using a stream reader.
                var swapFile = Path.Combine(game.save_path, ".swapper");
                //file contents = name of profile
                if (!File.Exists(swapFile)) {
                    MessageBox.Show("The game save's directory has saves that are not set for a certain profile. Please right click on a profile and click the 'Move Existing Here' button.","First Time Setup",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
                using (StreamReader sr = new StreamReader(swapFile)) {
                    String profileName = sr.ReadToEnd();
                    Profile profile = findProfile(profileName);
                    if (profile == null) {
                        MessageBox.Show(
                            "Game save directory is set for a profile that does not exist. Either create a new profile or click on 'Move Existing Here'",
                            "Unknown Swapper Profile", MessageBoxButtons.OK);
                        return false;
                    }

                    Debug.WriteLine("Existing Profile: " + profile.name);
                    string saveLocation = profile.storeLocation;
                    if (!Directory.Exists(saveLocation)) {
                        Directory.CreateDirectory(saveLocation);
                    }

                    DirectoryInfo gameFolder = new DirectoryInfo(game.save_path);
                    //TODO: Wipe storage folders & files (autosaves stack up)
                    List<DirectoryInfo> subFolders = gameFolder.GetDirectories().ToList();
                    Debug.WriteLine("Moving " + subFolders.Count + " files to %PROFILEPATH%/" + game.Name + "/" + profile.name);
                    foreach (DirectoryInfo dir in subFolders) {
                        //dir.MoveTo(Path.Combine(profilename,dir.Name));
                        List<FileInfo> saveFiles = dir.GetFiles("*", SearchOption.AllDirectories).ToList();
                        foreach (FileInfo file in saveFiles) {
                            try {
                                string destinationSubFolder = Path.Combine(profile.storeLocation, dir.Name);
                                string destFile = Path.Combine(destinationSubFolder, file.Name);
                                if (!Directory.Exists(destinationSubFolder)) {
                                    Directory.CreateDirectory(destinationSubFolder);
                                }
                                if (File.Exists(destFile)) {
                                    File.Delete(destFile);
                                }
                                Debug.WriteLine(destFile);
                                file.MoveTo(destFile);
                            } catch (Exception ex) when (ex is UnauthorizedAccessException || ex is IOException) {
                                Debug.WriteLine("Failed move: " + ex.Message);
                            }
                        }
                    }
                }
                Debug.WriteLine("Emptied files & folders");
                return true;
            } catch (Exception e) {
                Console.WriteLine("The file could not be read: " + e.Message);
                throw;
            }
        }

        private void LoadGameSave(Game game, Profile profile) {
            string saveLocation = game.save_path;
            if (!Directory.Exists(saveLocation) || !Directory.Exists(profile.storeLocation)) {
                //Directory.CreateDirectory(saveLocation);
                Debug.WriteLine("Invalid folder or missing folder for profile " + profile.name);
                return; //Don't do anything; no need
            }
            List<DirectoryInfo> subFolders = new DirectoryInfo(profile.storeLocation).GetDirectories().ToList();
            Debug.WriteLine("Loading profile: " + profile.name);
            Debug.WriteLine("Moving " + subFolders.Count + " files to GAME");
            foreach (DirectoryInfo dir in subFolders) {
                //dir.MoveTo(Path.Combine(profilename,dir.Name));
                List<FileInfo> sourceFiles = dir.GetFiles("*", SearchOption.TopDirectoryOnly).ToList();
                foreach (FileInfo file in sourceFiles) {
                    try {
                        string destDir = Path.Combine(game.save_path, dir.Name);
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
            System.IO.File.WriteAllText(Path.Combine(game.save_path, ".swapper"), profile.name);
        }

        private void LoadGameSave(Profile profile) {
            if (profile.game == null) {
                throw new ArgumentException("Profile does not contain Game class");
            }
            Game game = profile.game;
            LoadGameSave(game,profile);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                if (listView1.FocusedItem.Bounds.Contains(e.Location)) {
                    var item = listView1.FocusedItem;
                    Game game = findGame(item.Group.Header); //todo: optimize, have a global list of games instead of fetching
                    Debug.WriteLine(game);
                    if (game != null && game.Name != null) {
                        var swapFile = Path.Combine(game.save_path, ".swapper");
                        Debug.WriteLine(File.Exists(swapFile));
                        if (!File.Exists(swapFile)) {
                            moveExistingSaveHereToolStripMenuItem.Enabled = true;
                        } else {
                            moveExistingSaveHereToolStripMenuItem.Enabled = false;
                        }
                    } else {
                        moveExistingSaveHereToolStripMenuItem.Enabled = false;
                    }
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private Profile findProfile(String name) {
            Profile[] profiles = GetProfiles();
            foreach (var profile in profiles) {
                if (profile.name.Equals(name)) return profile;
            }
            return null;
        }

        private Game findGame(String name) {
            Game[] games = new GameManagement().getGames();
            foreach (var game in games) {
                if (game.Name.Equals(name)) return game;
            }
            return null;
        }

        private Profile convertToProfile(ListViewItem item) {
            Profile profile = new Profile(item.SubItems[0].Text, item.SubItems[1].Text, findGame(item.Group.Header));
            return profile;
        }

        private void swapToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem clicked = (ToolStripMenuItem)sender;
            var item = listView1.FocusedItem;

            Profile profile = convertToProfile(item);
            Debug.WriteLine("New Profile: " + profile.name);
            bool emptySuccess = EmptyGameSaveFolder(profile.game);
            if(emptySuccess) LoadGameSave(profile);
        }

        private void playToolStripMenuItem1_Click(object sender, EventArgs e) {
            Profile profile = convertToProfile(listView1.FocusedItem);
            if (profile != null && profile.game != null) {
                if (File.Exists(profile.game.exePath)) {
                    swapToolStripMenuItem.PerformClick(); //just swap
                    Process.Start(profile.game.exePath);
                    return;
                }
            }
            MessageBox.Show("No exe has been specified for this game.", "Missing EXE Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void changePathToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            var item = listView1.FocusedItem;
            List<Profile> profiles = GetProfiles().ToList();
            for (var i = 0; i < profiles.Count; i++) {
                if (profiles[i].name.Equals(item.SubItems[0].Text)) {
                    profiles.RemoveAt(i);
                }
            }
            /* Gets a list of profiles
             * Finds profile and removes it from list
             * Saves profiles to disk
             * Loads profiles from disk (should rewrite this)
             */
            SaveProfiles(profiles.ToArray());
            LoadProfiles(listView1);
        }

        public void NotImplemented() {
            MessageBox.Show("Feature not implemented");
        }

        private void reloadProfilesToolStripMenuItem_Click(object sender, EventArgs e) {
            LoadProfiles(listView1);
        }

        private void moveExistingSaveHereToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/Jackzmc/GameSaveSwapper/blob/master/README.md");
        }

        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/Jackzmc/GameSaveSwapper/issues/new");
        }
    }
}
