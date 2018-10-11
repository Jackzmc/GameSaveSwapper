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
    public partial class Setup : Form {
        static string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // AppData folder
        static string SAVEPATH = Path.Combine(APPDATA_PATH, "GameSaveSwapper");

        private string profileSaveDir = "/dev/";

        public Setup() {
            InitializeComponent();
        }

        private void Setup_FormClosing(object sender, FormClosingEventArgs e) {
            Application.OpenForms[0].Close();
        }

        private void Setup_Load(object sender, EventArgs e) {
            var games = FromJson(listView1).Distinct().ToArray();
 
            Debug.Write(String.Join(",",games));
            foreach (String game in games) {
                if(game != null && game != "Misc") game_choose.Items.Add(game);
            }

            game_choose.SelectedIndex = 0;

            //ToJson(listView1);
        }

        private void ToJson(ListView list) {
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

        private String[] FromJson(ListView list) {
            String json = System.IO.File.ReadAllText(Path.Combine(SAVEPATH, "profiles.json"));
            List<dynamic> jsonOut = JsonConvert.DeserializeObject<List<dynamic>>(json);
            List<String> games = new List<String>();

            foreach (dynamic item in jsonOut) {
                games.Add(item.Group.ToString());

                var listitem = new ListViewItem();
                var path = new ListViewSubItem();

                String groupname = ((Object) item.Group).ToString();

                ListViewGroup group = GetGroup(groupname, list.Groups);
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
            return games.ToArray();
        }

        private ListViewGroup GetGroup(String groupname,ListViewGroupCollection collection) {
            foreach (ListViewGroup grp in collection) {
                if (groupname == "Misc" && grp.Name == null) {
                    return grp;
                }
                if (grp.Name != null && grp.Name.Equals(groupname)) {
                    return grp;
                }
            }
            return new ListViewGroup(groupname);
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

            listItem.Group = GetGroup(game_choose.SelectedItem.ToString(), listView1.Groups);

            listItem.SubItems.Add(new ListViewSubItem().Text = profileSaveDir);

            listItem.Name = game_input.Text;
            listItem.Text = game_input.Text;

            listView1.Items.Add(listItem);
        }
    }
}
