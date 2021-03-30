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



        public void SaveToJson(List<Movie> movies)
        {

            string file =  Newtonsoft.Json.JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(Location, file);
        }



        public List<Movie> LoadFromJson()
        {

            List <Movie> Movielist= Newtonsoft.Json.JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(Location));
            return Movielist;

        }


        public void SaveToJson(List<object> item)
        {

            string file = Newtonsoft.Json.JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(Location, file);
        }



        public List<object> LoadFromJson2()
        {

            List<object> Movielist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(File.ReadAllText(Location));
            return Movielist;

        }

    }
}
