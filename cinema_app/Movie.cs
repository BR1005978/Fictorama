namespace cinema_app
{
    public class Movie
    {

        public string Name { get; set; }
        public string Info { get; set; }
        public string Year { get; set; }
        public Movie(string name, string info, string year)
        {
            Name = name;
            Info = info;
            Year = year;
        }
    }
}

