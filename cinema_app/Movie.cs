using System.Collections.Generic;
using System;
namespace cinema_app

{
    public class Movie
    {

        public string Name { get; set; }
        public string Info { get; set; }
        public string Year { get; set; }
        public string Link { get; set; }
        public string[] Genre { get; set; }
        public string Actors{ get; set; }
        public string Duration { get; set; }
        

        public List<Tuple<string, DateTime, User>> review;
        public Movie(string name, string info, string year,string[] genre,string actors,string duration, string link)
        {
            this.Name = name;
            this.Info = info;
            this.Year = year;
            this.Genre = genre;
            this.Actors = actors;
            this.Duration= duration;
            this.Link = link;
            

        }
        public void addreview(string review, User user, DateTime date)
        {
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();
            Tuple<string, DateTime, User> Review = Tuple.Create(review, date, user);
            List<Tuple<string, DateTime, User>> reviewList = new List<Tuple<string, DateTime, User>>();
            reviewList.Add(Review);
            this.review = reviewList;

            Json.SaveToJson(CinemaData);
        }


    }

}

