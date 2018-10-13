using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.ListViewItem;

namespace GameSaveSwapper {
    public class Game {
        public string Name;
        public string save_path;
        public string exePath;

        public Game(String name, String exeLocation, String save_path) {
            this.Name = name;
            this.save_path = save_path;
            this.exePath = exeLocation;
        }

        public ListViewItem getListViewItem() {
            var item = new ListViewItem();
            item.Name = this.Name;
            item.Text = this.Name;
            item.SubItems.Add(new ListViewSubItem().Text = this.save_path);
            return item;
        }


    }

    public class Profile {
        public string name;
        public string storeLocation;
        public string group;
        [JsonIgnore]
        public Game game;

        [JsonConstructor]
        public Profile(String name, String storeLocation,  String group) {
            this.name = name;
            this.storeLocation = storeLocation;
            this.group = group;
        }

        public Profile(String name, String storeLocation, Game game) {
            this.name = name;
            this.storeLocation = storeLocation;
            this.game = game;
        }
        //todo: possibly make it grab game and have the load logic based on class
    }
}
