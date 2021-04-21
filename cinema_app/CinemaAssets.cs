using System;
using System.Collections.Generic;
namespace cinema_app
{
    public class CinemaAssets
    {
        public List<CinemaHall> CinemaHallList = new List<CinemaHall>();
        public List<Movie> MovieList = new List<Movie>();




        // CinemaHall Control
        public void CreateCinemaHall()
        {
            Console.WriteLine("How many rows: ");
            int row = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many colums: ");
            int colum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the name of the hall");
            string name = Console.ReadLine();

            this.CinemaHallList.Add(new CinemaHall(row,colum,name));

            Console.WriteLine("Done");
        }

        public void ShowCinemaHalls()
        {
            foreach (var hall in this.CinemaHallList)
            {
                Console.WriteLine(hall.HallName);
            }
        }


        // Movie control
        public void CreateMovie()
        {
            Console.WriteLine("What is the name of the movie: ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the movie about: ");
            string info = Console.ReadLine();
            Console.WriteLine("From with year: ");
            string year = Console.ReadLine();
            Console.WriteLine("Ehat is the genre: ");
            string genger = Console.ReadLine();
            Console.WriteLine("Who is the actor: ");
            string Actor = Console.ReadLine();
            Console.WriteLine("What is the duration");
            string Duration = Console.ReadLine();

            this.MovieList.Add(new Movie(name,info,year,new string[] {genger },Actor,Duration));
            Console.WriteLine("Done");
        }

        public void ShowMovies()
        {
            foreach (var movie in this.MovieList)
            {
                Console.WriteLine(movie.Name);
            }
        }
    }
}
