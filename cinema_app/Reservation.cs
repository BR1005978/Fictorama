using System;
namespace cinema_app
{
    public class Reservation
    {
        public Movie movie;
        public DateTime Date;


        public Reservation(Movie movie, DateTime date)
        {
            this.movie = movie;
            this.Date = date;
        }

        public string BasicInformation()
        {
            return movie.Name + " At " + Date;
        }
    }
}
