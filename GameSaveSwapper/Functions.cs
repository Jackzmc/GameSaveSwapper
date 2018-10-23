using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GameSaveSwapper {
    class Functions {
        public List<Game> games;
        public List<Profile> profiles;
        private static readonly string Savepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameSaveSwapper");

        public Functions() {
            this.games = LoadGames();
            this.profiles = LoadProfiles();
        }

        public void SaveGames(List<Game> games) {
            SaveObject(games.ToList<dynamic>(), "games");
        }
        public void SaveProfiles(List<Profile> profiles) {
            SaveObject(profiles.ToList<dynamic>(), "profiles");
        }
        public Profile FindProfile(String name) {
            foreach (var profile in this.profiles) {
                if (profile.name.Equals(name)) return profile;
            }
            return null;
        }
        public Game FindGame(String name) {
            foreach (var game in this.games) {
                if (game.Name.Equals(name)) return game;
            }
            return null;
        }
        public void NotImplemented() {
            MessageBox.Show("Feature not implemented");
        }

        public Profile ConvertToProfile(ListViewItem item) {
            Profile profile = new Profile(item.SubItems[0].Text, item.SubItems[1].Text, FindGame(item.Group.Header));
            return profile;
        }

        //internal
        private List<Game> LoadGames() {
            String json = System.IO.File.ReadAllText(Path.Combine(Savepath, "games.json"));
            return JsonConvert.DeserializeObject<List<Game>>(json);
        }

        private List<Profile> LoadProfiles() {
            String json = System.IO.File.ReadAllText(Path.Combine(Savepath, "profiles.json"));
            return JsonConvert.DeserializeObject<List<Profile>>(json);
        }
        
        private void SaveObject(List<dynamic> objs,String Filename) {
            var json = JsonConvert.SerializeObject(objs);
            System.IO.File.WriteAllText(Path.Combine(Savepath, Filename + ".json"), json);
        }
    }
}
