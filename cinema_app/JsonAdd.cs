using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace cinema_app
{
    public class JsonAdd
    {
        public void SaveToJsonMovies(List<Movie> movies)
        {

            string file =  Newtonsoft.Json.JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText("Movies.json",file);
        }

        public List<Movie> LoadFromJsonMovies()
        {
            string location = "Movies.json";

            List < Movie > Movielist= Newtonsoft.Json.JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(location));

            return Movielist;

        }
        
    }
}
