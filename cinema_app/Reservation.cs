using System;
using System.Collections.Generic;
namespace cinema_app
{
    public class Reservation
    {
        public Movie movie;
        public DateTime Date;
        public User user;
        public double Price;
        public static List<Reservation> ReservationList = new List<Reservation>();

        public Reservation(Movie movie, DateTime date, double price)
        {
            this.movie = movie;
            this.Date = date;
            this.user = MainProgram.onlineUser;
            this.Price = price;

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



            // deze bool controleerd of de film is toegevoegd aan een zaal
            bool go_on = false;

            List<Tuple<int, int>> hallList = new List<Tuple<int, int>>();
            int hallChoice = 0;
            int hall_index = 0;
            foreach (var hall in CinemaData.CinemaHallList)
            {


                int hallres_index = 0;
                foreach (var hallRes in hall.HallReservation)
                {
                    if (movie.Name == hallRes.Item3.Name)
                    {
                        Console.WriteLine($"{hallChoice}: {hall.HallReservation[hallres_index].Item1.Item1}/{hall.HallReservation[hallres_index].Item1.Item2}/{hall.HallReservation[hallres_index].Item1.Item3} at {hall.HallReservation[0].Item2.Item1}:{hall.HallReservation[0].Item2.Item2}");
                        hallList.Add(Tuple.Create(hall_index, hallres_index));
                        hallChoice++;
                        hallres_index++;
                        go_on = true;
                    }
                }
                hall_index++;

            }
            //als de film niet in een zaal is togevoed geeft deze if statment dat aan.
            if (!go_on)
            {
                Console.WriteLine("You can not make a reservation for this movie.");
            }
            else
            {
                var Selected_hall = 0;
                bool Control = false;
                while (!Control)
                {

                    string selected_hall = Console.ReadLine();
                    Control = isNumeric(selected_hall);
                    if (Control)
                    {
                        Selected_hall = MakeNumber(selected_hall);
                        if (Selected_hall < hallList.Count && Selected_hall >= 0)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Input not correct");
                            Control = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input not correct");
                    }

                }
                // maak een DateTime van de tijd en datum.
                string Data = ($"{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item1}/{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item2}/{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item3}");
                string time = ($"{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item2.Item1}:{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item2.Item2}:00");
                string date = Data + " " + time;
                datum = DateTime.Parse(date);






                //hiermee bepaal de klant welke stoel hij wilt

                Console.WriteLine($"\nThe price for each ticket is {CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Price}");
                Console.WriteLine("\nHow many tickets do you want.");
                var tickets_amount = Console.ReadLine();
                int ticket = int.Parse(tickets_amount);
                var price = ticket * CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Price;
                Console.WriteLine();
                Tuple<int, int>[] seats = new Tuple<int, int>[ticket];
                for (int i = 0; i < ticket; i++)
                {

                    bool availeble = false;
                    while (!availeble)
                    {
                        // hiermee print je alle stoelen en laat je zien welke stoelen nog beschikbaar zijn.
                        string ss = "";
                        for (int j = 0; j < CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Rows; j++)
                        {
                            string s = $"{j}: ";
                            for (int g = 0; g < CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Colums; g++)
                            {
                                // print voor een stoel die beschik baar is 'O'
                                // print voor een stoel die niet beschik baar is 'X'
                                if (CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item4[j, g].Status)
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
                        Console.WriteLine($"\nType the row of the hall(0-{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Rows - 1})");

                        var rows = Console.ReadLine();
                        int row = int.Parse(rows);

                        if (row < CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Rows)
                        {


                            //var coloms = Console.ReadLine();
                            //int colom = int.Parse(coloms);


                        }
                        else
                        {
                            while (row > CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Rows - 1 || row < 0)
                            {

                                bool check = false;
                                while (!check)
                                {
                                    Console.WriteLine("This row does not exist.");
                                    Console.WriteLine("What will be the new row (0-{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Rows - 1})");
                                    var row2 = Console.ReadLine();
                                    check = isNumeric(row2);
                                    if (check)
                                    {
                                        row = MakeNumber(row2);
                                    }

                                }

                            }
                        }
                        Console.WriteLine($"\nType the seat number of the hall(0-{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Colums - 1})");

                        var coloms = Console.ReadLine();
                        int colom = int.Parse(coloms);

                        if (colom < CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Colums)
                        {
                            if (CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item4[row, colom].Status)
                            {
                                CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item4[row, colom].Change_status();
                                seats[i] = Tuple.Create(row, colom);
                                availeble = true;

                            }
                            else
                            {
                                Console.WriteLine("seat is already been taken, please select another seat./n");
                            }
                        }
                        else
                        {
                            while (colom > CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Colums - 1 || colom < 0)
                            {

                                bool check = false;
                                while (!check)
                                {
                                    Console.WriteLine("This seat number does not exist.");
                                    Console.WriteLine("What will be the new seat number (0-{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Colums - 1})");
                                    var colom2 = Console.ReadLine();
                                    check = isNumeric(colom2);
                                    if (check)
                                    {
                                        colom = MakeNumber(colom2);
                                    }

                                }
                            }
                            CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item4[row, colom].Change_status();
                            seats[i] = Tuple.Create(row, colom);
                            availeble = true;
                        }

                    }
                }
                Mail mailSystem = new Mail();
                var data = $"{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item1}/{ CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item2}/{ CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item3}";
                int min = CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item2.Item2;
                int hour = CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item2.Item1;
                if (MainProgram.onlineUser != null)
                {
                    // find user in user list
                    var UserJson = new JsonAdd("Users.json");
                    var UserData = UserJson.LoadFromJson2();
                    int index_user = 0;
                    for (int i = 0; i < UserData.userlist.Count; i++)
                    {
                        if (MainProgram.onlineUser.userName == UserData.userlist[i].userName)
                        {
                            index_user = i;

                        }
                    }

                    Reservation res = new Reservation(movie, datum, price);
                    ReservationList.Add(res);
                    UserData.userlist[index_user].reservations = ReservationList;
                    UserJson.SaveToJsonUser(UserData);

                    // de mail system werkt niet want hij geeft aan dat alle email addressen niet bestaan!!!!!
                    Tuple<string,string,string>[] food = new Tuple<string, string, string>[1];
                    food[0] = Tuple.Create("Test", "Test", "Test");

                    mailSystem.SendEmail(MainProgram.onlineUser.email, MainProgram.onlineUser.first_name, price, CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallName, CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item3.Name, data, hour, min, seats,food,"4782t4hbf");
                    Json.SaveToJson(CinemaData);

                }
                else
                {
                    bool isActic = false;
                    bool status = false;
                    string email = "";
                    string name = "";
                    Console.WriteLine("What is your name?");
                    name = Console.ReadLine();
                    while (!isActic)
                    {
                        Console.WriteLine("What is your email?");
                        email = Console.ReadLine();
                        status = mailSystem.controlEmail(email);

                        if (status)
                        {
                            isActic = true;
                        }

                    }
                    // de mail system werkt niet want hij geeft aan dat alle email addressen niet bestaan!!!!!
                    Tuple<string, string, string>[] food = new Tuple<string, string, string>[1];
                    food[0] = Tuple.Create("Test", "Test", "Test");
                    mailSystem.SendEmail(email, name, price, CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallName, CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item3.Name, data, hour, min, seats, food, "4782t4hbf");
                    Json.SaveToJson(CinemaData);
                    Console.WriteLine("\nReservation complete.\n");
                }
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
