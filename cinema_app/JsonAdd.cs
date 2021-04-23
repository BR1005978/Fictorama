
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
namespace cinema_app
{
    public class JsonAdd
    {

        public string Location;
        public JsonAdd(string location)
        {
            this.Location = location;
        }

        public void SaveToJson(CinemaAssets Assests)
        {
            string file = Newtonsoft.Json.JsonConvert.SerializeObject(Assests, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Location, file);
        }
        public CinemaAssets LoadFromJson()
        {
            CinemaAssets Assests = Newtonsoft.Json.JsonConvert.DeserializeObject<CinemaAssets>(File.ReadAllText(Location));
            return Assests;
        }

        // Extra 
        public void SaveToJsonUser(List<User> item)
        {
            string file = Newtonsoft.Json.JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Location, file);
        }

        public List<User> LoadFromJson2()
        {
            List<User> Movielist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(Location));
            return Movielist;
        }
    }
}
