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

        public Game(String name, String save_path) {
            this.Name = name;
            this.save_path = save_path;
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
        public string Group;
        public Game game;

        [JsonConstructor]
        public Profile(String name, String storeLocation, String Group) {
            this.name = name;
            this.storeLocation = storeLocation;
            this.Group = Group;
        }

        public Profile(String name, String storeLocation, Game game) {
            this.name = name;
            this.storeLocation = storeLocation;
            this.game = game;
        }
        //todo: possibly make it grab game and have the load logic based on class
    }
}
