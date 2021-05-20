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

            DateTime datum = DateTime.Now;

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
                        string Data = ($"{CinemaData.CinemaHallList[f].HallReservation[n].Item1.Item1}/{CinemaData.CinemaHallList[f].HallReservation[n].Item1.Item2}/{CinemaData.CinemaHallList[f].HallReservation[n].Item1.Item3}");
                        string time = ($"{CinemaData.CinemaHallList[f].HallReservation[n].Item2.Item1}:{CinemaData.CinemaHallList[f].HallReservation[n].Item2.Item2}:00");
                        string date = Data + " " + time;
                        datum =  DateTime.Parse(date);
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
                            while (row > CinemaData.CinemaHallList[movieIndex].Rows - 1 || row < 0)
                            {

                                bool check = false;
                                while (!check)
                                {
                                    Console.WriteLine("This row does not exist.");
                                    Console.WriteLine("What will be the new row");
                                    var row2 = Console.ReadLine();
                                    check = isNumeric(row2);
                                    if (check)
                                    {
                                        row = MakeNumber(row2);
                                    }

                                }

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
                                    Console.WriteLine("seat is already been taken, please select another seat./n");
                                }
                            }
                            else
                            {
                                while (colom > CinemaData.CinemaHallList[movieIndex].Colums - 1 || colom < 0)
                                {

                                    bool check = false;
                                    while (!check)
                                    {
                                        Console.WriteLine("This row does not exist.");
                                        Console.WriteLine("What will be the new row");
                                        var colom2 = Console.ReadLine();
                                        check = isNumeric(colom2);
                                        if (check)
                                        {
                                            colom = MakeNumber(colom2);
                                        }

                                    }
                                }
                                CinemaData.CinemaHallList[movieIndex].HallReservation[zaalIndex].Item4[row, colom].Change_status();
                                availeble = true;
                            }
                        
                    }
                }
                Console.WriteLine(datum);
                    Console.WriteLine("\nReservation complete.\n");
                    Reservation res = new Reservation(movie, datum);
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
        public static int MakeNumber(string s)
        {
            int var;
            var = int.Parse(s);
            return var;
        }
    }
}
