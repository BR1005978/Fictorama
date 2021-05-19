using System;
using System.Collections.Generic;
namespace cinema_app
{
    public class Reservation
    {
        public Movie movie;
        public DateTime Date;
        public User user;
        public static List<Reservation> ReservationList = new List<Reservation>();
        
        public Reservation(Movie movie, DateTime date)
        {
            this.movie = movie;
            this.Date = date;
            this.user = MainProgram.onlineUser;
            
        }

        public string BasicInformation()
        {
            return movie.Name + " At " + Date;
        }

        public static void reserveer(Movie movie)
        {
            //Movie films = null;
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();

            //Console.WriteLine("Choose the movie you want to reserve.");
            //int counter = 0;

            //foreach( Movie film in CinemaData.MovieList)
            //{
            //   Console.WriteLine($"{counter}: {film.Name}");
            // counter++;
            //}
            //int answerint;
            //string answer = Console.ReadLine();
            // hiermee controleer je of het wel een int is
            // en of hij niet langer is dan de lengte van de filmlijst
            //if (int.TryParse(answer, out answerint) && int.Parse(answer) < CinemaData.MovieList.Count)
            //{
            //    films = CinemaData.MovieList[answerint];
            //}

            // hiermee controleer je of een film wel is toegevoegd aan een zaal.
            int movieIndex = -1;
            int zaalIndex = -1;
            for (int f = 0; f < CinemaData.CinemaHallList.Count; f++)
            {
                for (int n = 0; n < CinemaData.CinemaHallList[f].HallReservation.Count; n++)
                {

                    if (CinemaData.CinemaHallList[f].HallReservation[n].Item3.Name == movie.Name)
                    {
                        movieIndex = f;
                        zaalIndex = n;
                        //DateTime Data = ($"{filmName.Item1.Item1}/{filmName.Item1.Item2}/{filmName.Item1.Item3}");
                    }
                }
            }
            

            
            
            if (movieIndex > -1 && movie.Name == CinemaData.CinemaHallList[movieIndex].HallReservation[0].Item3.Name)
            {

                Console.WriteLine("\nHow many seats do you want.");
                var tickets_amount = Console.ReadLine();
                int ticket = int.Parse(tickets_amount);
                Console.WriteLine();

                for (int i = 0; i < ticket; i++)
                {
                    //for (int b = 0; b < CinemaData.CinemaHallList.Count; b++)
                    //{
                    //if (movie.Name == CinemaData.CinemaHallList[b].HallReservation[0].Item3.Name)
                    //{
                    bool availeble = false;
                    while (!availeble)
                    {
                        // hiermee print je alle stoelen en laat je zien welke stoelen nog beschikbaar zijn.
                        string ss = "";
                        for (int j = 0; j < CinemaData.CinemaHallList[movieIndex].Rows; j++)
                        {
                            string s = $"{j}: ";
                            for (int g = 0; g < CinemaData.CinemaHallList[movieIndex].Colums; g++)
                            {
                                if (CinemaData.CinemaHallList[movieIndex].HallReservation[zaalIndex].Item4[j, g].Status)
                                {
                                    s += "O, ";
                                }
                                else
                                {
                                    s += "X, ";
                                }

                            }
                            s += "\n";
                            ss += s;

                        }
                        Console.WriteLine(ss);

                        Console.WriteLine("\nSelcet wich seats you want.");
                        Console.WriteLine($"\nType the row of the hall(0-{CinemaData.CinemaHallList[movieIndex].Rows - 1})");

                        var rows = Console.ReadLine();
                        int row = int.Parse(rows);

                        if (row < CinemaData.CinemaHallList[movieIndex].Rows)
                        {


                            //var coloms = Console.ReadLine();
                            //int colom = int.Parse(coloms);


                        }
                        else
                        {
                            while (row > CinemaData.CinemaHallList[movieIndex].Rows - 1|| row < 0)
                            {
                                Console.WriteLine("This row does not exist.");
                                var row2 = Console.ReadLine();
                                isNumeric(row2);
                                row = int.Parse(row2);

                            }

                        }
                        Console.WriteLine($"\nType the seat number of the hall(0-{CinemaData.CinemaHallList[movieIndex].Colums - 1})");

                        var coloms = Console.ReadLine();
                        int colom = int.Parse(coloms);

                        if (colom < CinemaData.CinemaHallList[movieIndex].Colums)
                        {
                            if (CinemaData.CinemaHallList[movieIndex].HallReservation[zaalIndex].Item4[row, colom].Status)
                            {
                                CinemaData.CinemaHallList[movieIndex].HallReservation[zaalIndex].Item4[row, colom].Change_status();
                                availeble = true;

                            }
                            else
                            {
                                Console.WriteLine("seat is already been taken, please select another seat.");
                            }
                        }
                        else
                        {
                            while (colom > CinemaData.CinemaHallList[movieIndex].Colums - 1|| colom < 0)
                            {
                                Console.WriteLine("This seat does not exist.");
                                var colom2 = Console.ReadLine();
                                colom = int.Parse(colom2);

                            }
                        }
                    }
                }
                Console.WriteLine("\nReservation complete.\n");
                Reservation res = new Reservation(movie, DateTime.Now);
                ReservationList.Add(res);
            }
            else
            {
                Console.WriteLine("\nYou can't make a reservation for this movie.\n");

            }
        }
        public static bool isNumeric(string numer)
        {
            int n;
            //var numer = Console.ReadLine();
            bool isnumeric = int.TryParse(numer, out n);
            return isnumeric;
        }
    }
}
