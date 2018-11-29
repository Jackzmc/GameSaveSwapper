using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace GameSaveSwapper {
    public partial class Main2 : Form {
        public Main2() {
            InitializeComponent();
        }
        private static readonly ILog log = LogManager.GetLogger("main2");
        private static readonly string SAVEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameSaveSwapper");
        private List<Game> games;
        private List<Profile> profiles;
        private Game selectedGame
        
        private Functions functions;

        private void groupBox2_Enter(object sender, EventArgs e) {

        }

        private void Main2_Load(object sender, EventArgs e) {
            /* program.cs -> Functions.init();
             * on load -> functions.getProfiles() -> has Game object
             *
             * load textbox and shit
             */
            //check if files are here:
            functions = new Functions();
            String gamesJson = Path.Combine(SAVEPATH, "games.json");
            String profilesJson = Path.Combine(SAVEPATH, "profiles.json");
            if (!File.Exists(gamesJson)) System.IO.File.WriteAllText(gamesJson, "[]");
            if (!File.Exists(profilesJson)) System.IO.File.WriteAllText(profilesJson, "[]");

            ReloadUI();
            game_profileList.FullRowSelect = true;
            version.Text = @"V" + Properties.Settings.Default.version;
            profile_stats.Text = "Loaded " + profiles.Count + " profiles";
        }

        private void ReloadUI() {
            var funcs = functions;
            this.games = funcs.games;
            this.profiles = funcs.profiles;
            log.Info($"Loaded {games.Count} games & {profiles.Count} profiles");
            if (games.Count == 0) {
                ShowGameChooser(false);
            } else {
                ShowGameChooser(true);
                comboBox1.Items.Clear();
                foreach (var game in games) {
                    comboBox1.Items.Add(game.Name);
                }
                //auto select first in combolist: 
                //todo: get last used?
                selectedGame = games[0];
                comboBox1.SelectedIndex = 0;
                ReloadProfileUI(selectedGame);
            }
            
        }

        private void ReloadProfileUI(Game game) { //rename? also reloads game
            var funcs = functions;
            var activeProfile = GetActiveProfile(game);
            game_profileList.Items.Clear();
            foreach (Profile prof in profiles) {
                Debug.Print("Profile; name: {0}, saveLoc: {1}",prof.name,prof.storeLocation);
                //TODO: check if profile's game == this game
                ListViewItem item = new ListViewItem() {Name = prof.name, Text = prof.name};
                item.SubItems.Add(new ListViewItem.ListViewSubItem().Text = funcs.BytesToString(prof.GetSize()));
                item.SubItems.Add(new ListViewItem.ListViewSubItem().Text = prof.unix.ToString());
                item.SubItems.Add(new ListViewItem.ListViewSubItem().Text = prof.storeLocation);
                if (prof.name.Equals(activeProfile?.name)) {
                    item.Font = new Font(item.Font,FontStyle.Bold);
                }
                game_profileList.Items.Add(item);
            }

            game_picBox.ImageLocation = "https://placehold.it/462x377?text=No+Image";
            game_profile.Text = (activeProfile != null) ? activeProfile.name : "No Active Profile";
        }

        private Profile GetActiveProfile(Game game) {
            if (File.Exists(Path.Combine(game.savePath, ".swapper"))) {
                string profile = System.IO.File.ReadAllText(Path.Combine(game.savePath, ".swapper"));
                Profile p = functions.FindProfile(profile);
                if (p != null && p.name != null) {
                    return p;
                }else {
                    return null;
                }
            }
            return null;
        }
        private void game_profileList_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                if (game_profileList.FocusedItem.Bounds.Contains(e.Location)) {
                    var item = game_profileList.FocusedItem;
                    var game = selectedGame;
                    if (game?.Name != null) {
                        var swapFile = Path.Combine(game.savePath, ".swapper");
                        moveExistingSaveHereToolStripMenuItem.Enabled = !File.Exists(swapFile);
                    } else {
                        moveExistingSaveHereToolStripMenuItem.Enabled = false;
                    }
                    for (var i = 0; i < contextMenuStrip1.Items.Count; i++) {
                        contextMenuStrip1.Items[i].Enabled = false;
                    }
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            e.Cancel = game_profileList.SelectedItems.Count <= 0;
        }
        private void ShowGameChooser(bool enabled) {
            if (enabled) {
                label_gameName.Visible = true;
                game_profile.Visible = true;
                nogame_text.Visible = false;
                game_picBox.Visible = true;
            } else {
                label_gameName.Visible = false;
                game_profile.Visible = false;
                nogame_text.Visible = true;
                game_picBox.Visible = false;
            }
        }
        private bool EmptyGameSaveFolder(Game game) {
            var swapFile = Path.Combine(game.savePath, ".swapper");
            bool ignoreSwap = false;
            if (!File.Exists(swapFile)) {
                Debug.WriteLine(IsDirectoryEmpty(game.savePath));
                if (!IsDirectoryEmpty(game.savePath)) {
                    log.Warn("EmptyGameSaveFolder: Swap file not found");
                    var result = MessageBox.Show(
                        strings.EmptySaves_ExistingFiles_Content,
                        strings.FirstTimeSetup_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) {
                        MessageBox.Show(
                            strings.EmptySaves_ExistingFiles_TIP, "Tip",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    } else {
                        ignoreSwap = true;
                    }
                    //continue
                } else {
                    ignoreSwap = true;
                }
            }

            if (!ignoreSwap) {
                String swapperText = File.ReadAllText(swapFile);
                Profile profile = functions.FindProfile(swapperText);
                if (profile == null) {
                    log.Error("EmptyGameSaveFolder: Swapper Profile unknown");
                    var result = MessageBox.Show(
                        strings.EmptySaves_UnknownProfile_Content,
                        strings.EmptySaves_UnknownProfile_Title,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result != DialogResult.Yes) {
                        return false;
                    }
                }
            }

            log.Info("Empty save game folder");
            DirectoryInfo gameSaveDirectory = new DirectoryInfo(game.savePath);
            foreach (FileInfo file in gameSaveDirectory.GetFiles()) {
                file.Delete();
            }
            foreach (DirectoryInfo dir in gameSaveDirectory.GetDirectories()) {
                dir.Delete(true);
            }
            return true;

        }

        private void LoadGameSave(Profile profile) {
            if (profile.game == null) {
                throw new ArgumentException("Profile does not contain game class");
                //Todo: own error
            }
            if (!Directory.Exists(profile.game.savePath)) {
                Directory.CreateDirectory(profile.game.savePath);
            }
            if (!Directory.Exists(profile.storeLocation)) {
                log.Error("LoadGameSave: Save Location for Profile " + profile.name + " not found");
                throw new DirectoryNotFoundException("Profile save location not found: " + profile.storeLocation);
            }
            MoveFiles(profile.storeLocation, profile.game.savePath, true);
            System.IO.File.WriteAllText(Path.Combine(profile.game.savePath, ".swapper"), profile.name);
        }

        private void MoveFiles(String source, String destination, bool CopyInstead) {
            if (!Directory.Exists(source)) {
                log.Error("MoveFiles: Source location not found");
                throw new DirectoryNotFoundException("Source directory could not be found: " + source);
            } else if (!Directory.Exists(destination)) {
                Directory.CreateDirectory(destination);
            }
            DirectoryInfo root = new DirectoryInfo(source);
            DirectoryInfo dest = new DirectoryInfo(destination);
            DirectoryInfo[] dirs = root.GetDirectories();
            FileInfo[] files = root.GetFiles();
            foreach (FileInfo file in files) {
                string temppath = Path.Combine(destination, file.Name);

                file.CopyTo(temppath, false);
                if (!CopyInstead) file.Delete();
            }
            foreach (DirectoryInfo subdir in dirs) {
                string temppath = Path.Combine(destination, subdir.Name);
                MoveFiles(subdir.FullName, temppath, CopyInstead);
            }
        }
        public bool IsDirectoryEmpty(string path) {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }


        private void label1_Click(object sender, EventArgs e) {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void splitter2_SplitterMoved(object sender, SplitterEventArgs e) {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var game = functions.FindGame(comboBox1.SelectedItem.ToString());
            //SetGameChooser(true);
            selectedGame = game;
            label_gameName.Text = game.Name;
            var profile = GetActiveProfile(game);
            game_profile.Text = profile?.name;
            ReloadProfileUI(game);
            //label_gameName.Text
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) {
            
        }

        private void legacy_btn_Click(object sender, EventArgs e) {
            new Main().ShowDialog();
        }

        private void game_add_Click(object sender, EventArgs e) {
            var adder = new GameAdder();
            var result = adder.ShowDialog();
            //can be cancel, OK
            if (result == DialogResult.OK) {
                this.games.Add(adder.Game);
                functions.SaveGames(this.games);
                ReloadUI();
            }
        }

        private void game_play_Click(object sender, EventArgs e) {
            var selectedProfile = game_profileList.selectedItem;
            var profile = functions.FindProfile(selectedProfile.SubItems[0]));
            if(profile == null) {
                MessageBox.Show("Selected profile does not seem to exist. Try recreating or try again.","Unknown Profile",MessageBoxButtons.OK,MessageBoxIcon.warning);
                //possibly _attempt_ to fix
                return;
            }
            if (!string.IsNullOrEmpty(selectedGame.exePath)) {
                EmptyGameSaveFolder(selectedGame);
                LoadGameSave(profile);
                LoadGameSave(GetActiveProfile(selectedGame));
                log.Debug($"Launch Game {selectedGame.Name}: {selectedGame.exePath}");
                Process.Start(selectedGame.exePath);
            } else {
                log.Debug($"Game {selectedGame.Name} has no exe, prompting");
                var dialog = MessageBox.Show("This game does not have an EXE specified, do you wish to add one?","No EXE Specified",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes) {
                    var adder = new GameAdder();
                    adder.game = selectedGame;
                    adder.showDialog();
                    //new Main().NotImplemented();
                }
            }
        }

        private void game_swap_Click(object sender, EventArgs e) {
            EmptyGameSaveFolder(selectedGame);
            LoadGameSave(GetActiveProfile(selectedGame));
        }
    }
}
