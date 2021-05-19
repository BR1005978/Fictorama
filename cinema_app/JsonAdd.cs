
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
        public void SaveToJsonUser(Userlist UserData)
        {
            string file = Newtonsoft.Json.JsonConvert.SerializeObject(UserData, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Location, file);
        }

        public Userlist LoadFromJson2()
        {
            Userlist UserData = Newtonsoft.Json.JsonConvert.DeserializeObject<Userlist>(File.ReadAllText(Location));
            return UserData;
        }


    }
}
