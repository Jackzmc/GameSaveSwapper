using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;
using static System.Windows.Forms.ListViewItem;

namespace GameSaveSwapper {
    public partial class Main : Form {
        //TODO is on github projects
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static string SAVEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameSaveSwapper");
        private List<Profile> profiles;

        public Main() {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
        }
        //events
        private void Setup_Load(object sender, EventArgs e) {
            //create files if dont exist
            String gamesJSON = Path.Combine(SAVEPATH, "games.json");
            String profilesJSON = Path.Combine(SAVEPATH, "profiles.json");
            if (!File.Exists(gamesJSON)) System.IO.File.WriteAllText(gamesJSON, "[]");
            if (!File.Exists(profilesJSON)) System.IO.File.WriteAllText(profilesJSON, "[]");
            this.profiles = GetProfiles();

            reloadGameChooser(); //reload the combobox
             //Load group to listview list
            LoadGroupsToList();
            //LoadProfiles(listView1); //grab profiles.json
            log.Info("Program has started");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            e.Cancel = this.listView1.SelectedItems.Count <= 0;
        }
        
        private void button2_Click(object sender, EventArgs e) {
            if (game_input.Text == "") {
                log.Error("ProfileAdd: Missing Profile Name");
                MessageBox.Show("Please enter a profile name","Missing Profile Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }else if (game_choose.SelectedText == null) {
                log.Error("ProfileAdd: Missing game");
                MessageBox.Show("Please select a game for this profile","Missing Profile Game",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String savepath = Path.Combine(SAVEPATH, game_choose.SelectedItem.ToString(), game_input.Text);
            if (!Directory.Exists(savepath)) {
                Directory.CreateDirectory(savepath);
            }


            Profile profile = new Profile(game_input.Text,savepath,game_choose.SelectedItem.ToString());
            log.Info("ProfileAdd: Created Profile " + profile.name + " for game " + profile.game);
            this.profiles.Add(profile);
            ListViewItem listItem = new ListViewItem();

            listItem.Group = GetGameGroup(profile.group);
            listItem.SubItems.Add(new ListViewSubItem().Text = profile.storeLocation);

            listItem.Name = profile.name;
            listItem.Text = profile.name;
            listView1.Items.Add(listItem);
            SaveProfiles(this.profiles);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveProfilesFromListView(listView1.Items);
        }

        private void gameSetupToolStripMenuItem_Click(object sender, EventArgs e) {
            //this.Hide();
            new GameManagement().Show();
        }

        //internal methods
        
        private void SaveProfiles(List<Profile> profiles) {
            var json = JsonConvert.SerializeObject(profiles);
            System.IO.File.WriteAllText(Path.Combine(SAVEPATH, "profiles.json"), json);
        }
        private void SaveProfilesFromListView(ListView.ListViewItemCollection list) {
            List<Profile> listitems = new List<Profile>();
            foreach (ListViewItem item in list) {
                Profile profile = new Profile(item.SubItems[0].Text, item.SubItems[1].Text, item.Group.Header);
                listitems.Add(profile);
            }
            SaveProfiles(listitems);
        }

        private List<Profile> GetProfiles() {
            String json = System.IO.File.ReadAllText(Path.Combine(SAVEPATH, "profiles.json"));
            return JsonConvert.DeserializeObject<List<Profile>>(json);
        }



        private void LoadProfiles(ListView list,List<String> activeProfiles) {
            list.Items.Clear();
            foreach (Profile profile in this.profiles) {
                var listitem = new ListViewItem();
                var path = new ListViewSubItem();

                ListViewGroup group = GetGameGroup(profile.group);
                //list.Groups.Add(group);

                path.Text = profile.storeLocation;
                if(activeProfiles.Contains(profile.name)) listitem.Font = new Font(listitem.Font, FontStyle.Bold);


                listitem.Group = GetGameGroup(profile.group);
                listitem.Name = profile.name;
                listitem.Text = profile.name;

                listitem.SubItems.Add(path);
                list.Items.Add(listitem);
            }
        }


        private void LoadGroupsToList() {
            listView1.Groups.Clear();
            List<Game> games= new GameManagement().getGames();
            List<String> profileNames = new List<string>();
            foreach (Game game in games) {
                listView1.Groups.Add(new ListViewGroup(game.Name));
                if (File.Exists(Path.Combine(game.save_path, ".swapper"))) {
                    string profile = System.IO.File.ReadAllText(Path.Combine(game.save_path, ".swapper"));
                    Profile p = findProfile(profile);
                    if (p != null && p.name != null) {
                        profileNames.Add(p.name);
                    }
                }
            }
            LoadProfiles(listView1,profileNames);
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
        private void LoadGameSave(Profile profile) {
            if (profile.game == null) {
                throw new ArgumentException("Profile does not contain Game class");
            }
            Game game = profile.game;
            LoadGameSave(game, profile);
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
                File.Delete(swapFile);
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

        private void MoveFiles(String source, String destination) {
            if (!Directory.Exists(source)) {
                log.Error("MoveFiles: Source location not found");
                throw new DirectoryNotFoundException("Source directory could not be found: " + source);
            }else if (!Directory.Exists(destination)) {
                Directory.CreateDirectory(destination);
            }

            if (!IsDirectoryEmpty(destination)) {
                var dialog = MessageBox.Show("Profile folder already contains profile data, do you wish to continue?", "Existing Files in Destination",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                log.Error("Destination directory already contains profile data.");
                if (dialog != DialogResult.Yes) {
                    return;
                }
            }
            DirectoryInfo root = new DirectoryInfo(source);
            DirectoryInfo dest = new DirectoryInfo(destination);
            DirectoryInfo[] dirs = root.GetDirectories();
            FileInfo[] files = root.GetFiles();
            foreach (FileInfo file in files) {
                string temppath = Path.Combine(destination, file.Name);

                file.CopyTo(temppath, false);
                file.Delete();
            }
            foreach (DirectoryInfo subdir in dirs) {
                string temppath = Path.Combine(destination, subdir.Name);
                MoveFiles(subdir.FullName, temppath);
            }
            /*
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;
            string[] entries = null;
            //check if dest exists, empty?
            try {
                entries = Directory.GetFileSystemEntries(source, "*", SearchOption.AllDirectories);
                
                //Directory.Move(source,destination);
            } catch (UnauthorizedAccessException e) {
                log.Error("MoveFiles: " + e.Message);
            } catch (System.IO.DirectoryNotFoundException e) {
                log.Error(e.Message);
            }

            List<String> output = new List<string>();
            foreach (String str in entries) {
                output.Add(str.Substring(Path.GetPathRoot(str).Length));
            }
            log.Debug(String.Join(",", output.ToArray()));*/
        }
        private bool IsDirectoryEmpty(string path) {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                if (listView1.FocusedItem.Bounds.Contains(e.Location)) {
                    var item = listView1.FocusedItem;
                    Game game = findGame(item.Group.Header); //todo: optimize, have a global list of games instead of fetching
                    if (game != null && game.Name != null) {
                        var swapFile = Path.Combine(game.save_path, ".swapper");
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
        //public methods
        public Profile findProfile(String name) {
            foreach (var profile in this.profiles) {
                if (profile.name.Equals(name)) return profile;
            }
            return null;
        }

        public Game findGame(String name) {
            List<Game> games = new GameManagement().getGames();
            foreach (var game in games) {
                if (game.Name.Equals(name)) return game;
            }
            return null;
        }
        public void NotImplemented() {
            MessageBox.Show("Feature not implemented");
        }

        public Profile convertToProfile(ListViewItem item) {
            Profile profile = new Profile(item.SubItems[0].Text, item.SubItems[1].Text, findGame(item.Group.Header));
            return profile;
        }

        public void reloadGameChooser() {
            game_choose.Items.Clear();
            List<Game> games= new GameManagement().getGames();
            foreach (Game game in games) {
                if (game != null && game.Name != "Misc") game_choose.Items.Add(game.Name);
            }
            if (game_choose.Items.Count > 0) game_choose.SelectedIndex = 0;
            LoadGroupsToList();
        }

        //context menu
        private void swapToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem clicked = (ToolStripMenuItem)sender;
            var item = listView1.FocusedItem;

            Profile profile = convertToProfile(item);
            Debug.WriteLine("New Profile: " + profile.name);
            bool emptySuccess = EmptyGameSaveFolder(profile.game);
            if (emptySuccess) {
                LoadGameSave(profile);
                LoadGroupsToList();
            }
        }

        private void playToolStripMenuItem1_Click(object sender, EventArgs e) {
            Profile profile = convertToProfile(listView1.FocusedItem);
            if (profile != null && profile.game != null) {
                if (File.Exists(profile.game.exePath)) {
                    bool emptySuccess = EmptyGameSaveFolder(profile.game);
                    if (emptySuccess) {
                        LoadGameSave(profile);
                        LoadGroupsToList();
                        Process.Start(profile.game.exePath); 
                    } else {
                        MessageBox.Show("Failed to empty the game save directory.", "Empty Game Saves Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            for (var i = 0; i < this.profiles.Count; i++) {
                if (this.profiles[i].name.Equals(item.SubItems[0].Text)) {
                    this.profiles.RemoveAt(i);
                }
            }
           
            /* Gets a list of profiles from global
             * Finds profile and removes it from list
             * Saves profiles to disk
             * Loads profiles from disk (should rewrite this)
             */
            SaveProfiles(this.profiles);
            LoadGroupsToList();
        }


        
        private void moveExistingSaveHereToolStripMenuItem_Click(object sender, EventArgs e) {
            var item = listView1.FocusedItem;
            Profile profile = findProfile(item.SubItems[0].Text); //name, 
            Game game = findGame(item.Group.Header);
            Debug.WriteLine(profile.name  + "|" + game.Name);
            if (game == null || profile == null) {
                MessageBox.Show("Could not find game or profile to move to.", "Game or Profile Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("MoveExisting: Game or profile was null");
                return;
            }
            /*System.IO.File.WriteAllText(Path.Combine(game.save_path, ".swapper"), profile.name);
            bool moved = EmptyGameSaveFolder(game); //stupid/lazy way but 
            if (!moved) {
              
                MessageBox.Show("Failed to move existing save files to this profile. ", "Move Existing Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            MoveFiles(game.save_path,profile.storeLocation);
            LoadGroupsToList();
        }
        private void openProfileDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
            var item = listView1.FocusedItem;
            Profile profile = findProfile(item.SubItems[0].Text);
            if (!Directory.Exists(profile.storeLocation)) {
                Process.Start(SAVEPATH);
                return;
            }
            Process.Start(profile.storeLocation);

        }

        //tool/status bar items:
        //file
        private void reloadProfilesToolStripMenuItem_Click(object sender, EventArgs e) {
            LoadGroupsToList();
        }


        //help menu items
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            NotImplemented();
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/Jackzmc/GameSaveSwapper/blob/master/README.md");
        }

        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/Jackzmc/GameSaveSwapper/issues/new");
        }

        private void openLogToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(Path.Combine(SAVEPATH,"swapper.log"));
        }
    }
}
