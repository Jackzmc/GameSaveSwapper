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

namespace GameSaveSwapper {
    public partial class Main : Form {
        static string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // AppData folder
        static string SAVEPATH = Path.Combine(APPDATA_PATH, "GameSaveSwapper");
        private static DirectoryInfo HITMANPATH = new DirectoryInfo(@"D:\Jackz\Documents\_temp\hitmanshit\remote");

        private Setup setup = new Setup();

        public Main() {
            InitializeComponent();
            if (Properties.Settings.Default.profilenum <= 0) Properties.Settings.Default.profilenum = 1;

            saveProfile1.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            saveProfile2.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            saveProfile3.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            saveProfile4.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

            textBox1.TextChanged += new EventHandler(textBox_Changed);
            textBox2.TextChanged += new EventHandler(textBox_Changed);
            textBox3.TextChanged += new EventHandler(textBox_Changed);
            textBox4.TextChanged += new EventHandler(textBox_Changed);
        }

        

        private void Form1_Shown(object sender, EventArgs e) {
            if (!Properties.Settings.Default.firstSetup) {
                setup.Show();
                this.Hide();
                return;
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            

            Control[] ArrControls = groupBox1.Controls.Find("saveProfile" + Properties.Settings.Default.profilenum, true);
            Debug.Print("saveProfile" + Properties.Settings.Default.profilenum);
            if (ArrControls.Length == 0) {
                MessageBox.Show("Did not find any checkboxes", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            
            RadioButton rb = (RadioButton)ArrControls[0];
            rb.Checked = true;
            FormatTexts();
            /*for (int i = 0; i < 4; i++) {
                Debug.WriteLine(Properties.Settings.Default["save" + ++i]);
            }*/

            
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e) {
            RadioButton radioButton = sender as RadioButton;
            if (!radioButton.Checked) return;
            int buttonid = (int) int.Parse(radioButton.Name.Replace("saveProfile", ""));
            TextBox tb = (TextBox) groupBox1.Controls["TextBox" + buttonid];
            Properties.Settings.Default.profilenum = buttonid;
            //SwapToID(buttonid);
        }

        private void textBox_Changed(object sender, EventArgs e) {
            FormatTexts();
        }

        private void FormatTexts() {
            TextBox[] texts = groupBox1.Controls.OfType<TextBox>().ToArray();
            for (int i = 0; i < 4; i++) {
                texts[i].BackColor = (texts[i].Text == "") ? Color.White : SystemColors.Control;
                /*var settings = Properties.Settings.Default["save" + (++i)];
                if(settings != null) settings = texts[i].Text;
                */
            }

            
            //todo: save
        }
 
        private void SwapToID(int id) {
            if (!Directory.Exists(SAVEPATH)) {
                Directory.CreateDirectory(SAVEPATH);
            }else if (!HITMANPATH.Exists) {
                MessageBox.Show("No files found!!!%$@#%");
            }

            MoveExistingToStorage();
            Debug.WriteLine("Done, Copying save now");
            copySavedFromStorage(id); 
            Debug.WriteLine("moved?");
        }

        private void MoveExistingToStorage() {
            //get ID of source via swapper.txt

            try {   // Open the text file using a stream reader.
                var swapFile = Path.Combine(HITMANPATH.FullName, "swapper.txt");
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

            
        }

        private void copySavedFromStorage(int id) {
            string sourceLocation = Path.Combine(SAVEPATH, "save" + id);
            string saveLocation = HITMANPATH.FullName;
            if (!Directory.Exists(saveLocation) || !Directory.Exists(sourceLocation)) {
                //Directory.CreateDirectory(saveLocation);
                return; //Don't do anything; no need
            }
            Debug.WriteLine(HITMANPATH.ToString());
            List<DirectoryInfo> subFolders = new DirectoryInfo(sourceLocation).GetDirectories().ToList();
            Debug.WriteLine("[" + id + "] Moving " + subFolders.Count + " files to HITMAN" + id);
            foreach (DirectoryInfo dir in subFolders) {
                //dir.MoveTo(Path.Combine(profilename,dir.Name));
                List<FileInfo> hitmanFiles = dir.GetFiles("*", SearchOption.TopDirectoryOnly).ToList();
                foreach (FileInfo file in hitmanFiles) {
                    try {
                        string destDir = Path.Combine(HITMANPATH.FullName, dir.Name);
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
            System.IO.File.WriteAllText(Path.Combine(HITMANPATH.FullName,"swapper.txt"), id.ToString());
        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {

        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e) {
            setup.Show();
            this.Hide();
        }
    }
}
