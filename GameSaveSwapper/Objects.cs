using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.ListViewItem;

namespace GameSaveSwapper {
    public class Game {
        public string Name;
        public string save_path; //legacy
        public string savePath;
        public string exePath;

        public Game(String name, String exeLocation, String save_path) {
            this.Name = name;
            this.save_path = save_path; //legacy
            this.savePath = save_path;
            this.exePath = exeLocation;
        }


        public ListViewItem GetListViewItem() {
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
        public Int32 unix;
        public string group; //legacy
        [JsonIgnore]
        public Game game;

        [JsonConstructor]
        public Profile(String name, String storeLocation,  String group, DateTime? lastPlayed = null) {
            this.name = name;
            if (lastPlayed != null) this.unix = GetUnixTime(lastPlayed.Value);
            this.storeLocation = storeLocation;
            this.group = group;
        }

        public Profile(String name, String storeLocation, Game game, DateTime? lastPlayed = null) {
            this.name = name;
            if (lastPlayed != null) this.unix = GetUnixTime(lastPlayed.Value);
            this.storeLocation = storeLocation;
            this.game = game;
        }

        public long GetSize() {
            return DirSize(new DirectoryInfo(this.storeLocation));
        }
        private static long DirSize(DirectoryInfo d) {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis) {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis) {
                size += DirSize(di);
            }
            return size;
        }

        private static Int32 GetUnixTime(DateTimeOffset time) {
            Int32 unixTimestamp = (Int32)(time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }
        //todo: possibly make it grab game and have the load logic based on class
    }

}
