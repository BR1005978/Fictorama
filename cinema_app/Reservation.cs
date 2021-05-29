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
        public Tuple<int, int>[] Seat;
        public Tuple<string, string, string>[] Food;
        public static List<Reservation> ReservationList = new List<Reservation>();

        public Reservation(Movie movie, DateTime date, double price, Tuple<int, int>[] seat, Tuple<string, string, string>[] food)
        {
            this.movie = movie;
            this.Date = date;
            this.user = MainProgram.onlineUser;
            this.Price = price;
            this.Seat = seat;
            this.Food = food;
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
                Console.WriteLine($"this are/is the date(s) and time(s) for the movie {movie.Name}\n");
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
                Console.WriteLine("\nYou can not make a reservation for this movie.\n");
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
                string Data = "";
                if ( CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item2 > 9)
                {
                     Data = ($"{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item1}/{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item2}/{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item3}");

                }
                else
                {

                     Data = ($"{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item1}/0{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item2}/{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item3}");
                }

                string time = ($"{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item2.Item1}:{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item2.Item2}:00");
                string date = Data + " " + time;
                datum = DateTime.ParseExact(Data, "dd/MM/yyyy", null);






                //hiermee bepaal de klant welke stoel hij wilt


                Console.WriteLine("\nHow many tickets do you want.");
                var tickets_amount = Console.ReadLine();
                int ticket = int.Parse(tickets_amount);
                var price = 0.00;
                Console.WriteLine();
                Tuple<int, int>[] seats = new Tuple<int, int>[ticket];
                for (int i = 0; i < ticket; i++)
                {

                    bool availeble = false;
                    while (!availeble)
                    {
                        // hiermee print je alle stoelen en laat je zien welke stoelen nog beschikbaar zijn.
                        Console.Clear();
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
                                if (CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item4[row, colom].Price <= 0.0)
                                {
                                    price += CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item4[row, colom].Price;

                                }
                                else
                                {
                                    
                                    price += CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Price;
                                }
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

                            if (CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item4[row, colom].Price <= 0.0)
                            {
                                price += CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item4[row, colom].Price;

                            }
                            else
                            {

                                price += CinemaData.CinemaHallList[hallList[Selected_hall].Item1].Price;
                            }
                            availeble = true;
                        }

                    }
                }

                // voeg een combi menu toe
                Tuple<string, string, string>[] food = null;
                bool foodOrder = true;
                while (foodOrder)
                {
                    Console.WriteLine("Do you want to add a combo menu to your reservation?\n A combo menu costs 10 euro.");
                    Console.WriteLine("Type the number:");
                    Console.WriteLine("[0] Add combo menu.\n" +
                        "[1] Continue without combo menu.");
                    string menu = "";
                    menu = Console.ReadLine();
                    if (menu == "0")
                    {

                        var CateringJson = new JsonAdd("Catering.json");
                        Catering catering = CateringJson.LoadFromJsoncatering();
                        Console.WriteLine($"\nHow many combo menus do you want(Max {ticket} combo menus).");
                        var menu_amount = Console.ReadLine();
                        int menus = int.Parse(menu_amount);
                        while (menus > ticket || menus < 0)
                        {
                            Console.WriteLine("Wrong input.");
                            Console.WriteLine($"\nHow many combo menu(s) do you want(Max {ticket} combo menu(s)).");
                            bool order = true;
                            while (order)
                            {
                                menu = Console.ReadLine();
                                if (isNumeric(menu))
                                {
                                    menus = MakeNumber(menu);
                                    order = false;
                                }

                            }
                        }
                        food = new Tuple<string, string, string>[menus];
                        for (int i = 0; i < menus; i++)
                        {

                            food[i] = catering.createMenu();

                            price += 10;

                        }

                        foodOrder = false;
                    }
                    else if (menu == "1")
                    {
                        foodOrder = false;
                    }
                }


                // verstuur een email 
                Mail mailSystem = new Mail();
                var data = $"{CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item1}/{ CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item2}/{ CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item1.Item3}";
                int min = CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item2.Item2;
                int hour = CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item2.Item1;
                // verstruur email voor reservatie voor gebruikers zonder account
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

                    Reservation res = new Reservation(movie, datum, price, seats, food);
                    ReservationList.Add(res);
                    UserData.userlist[index_user].reservations.Add(res);
                    UserJson.SaveToJsonUser(UserData);


                    //Tuple<string,string,string>[] food = new Tuple<string, string, string>[1];


                    mailSystem.SendEmail(MainProgram.onlineUser.email, MainProgram.onlineUser.first_name, price, CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallName, CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item3.Name, data, hour, min, seats, food, randCode());
                    Json.SaveToJson(CinemaData);

                }

                // bevestig reservation
                Console.Clear();
                Console.WriteLine($"Your total price is {Math.Round(Convert.ToDecimal(price), 2)} euro.");
                Console.WriteLine("[0] Continue with this reservation.\n" +
                    "[1] Cancel this reservation.\n");
                Console.WriteLine("Please type the number.");
                string resnum = Console.ReadLine();
                if (!isNumeric(resnum))
                {
                    while (!isNumeric(resnum))
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input!");
                        Console.WriteLine($"Your total price is {Math.Round(Convert.ToDecimal(price), 2)} euro.");
                        Console.WriteLine("[0] Continue with this reservation.\n" +
                            "[1] Cancel this reservation.\n");
                        Console.WriteLine("Please type the number.");
                        resnum = Console.ReadLine();

                    }
                }
                int resint = MakeNumber(resnum);
                if (resint == 0)
                {
                    Console.WriteLine();
                }
                else if (resint == 1)
                {
                    User.panel();
                }

                // verstruur email voor reservatie voor gebruikers zonder account
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



                    mailSystem.SendEmail(email, name, price, CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallName, CinemaData.CinemaHallList[hallList[Selected_hall].Item1].HallReservation[hallList[Selected_hall].Item2].Item3.Name, data, hour, min, seats, food, randCode());
                    Json.SaveToJson(CinemaData);
                    Console.WriteLine("\nReservation complete.\n");
                }
            }


        }


        public static void PastReservation()
        {
            var UserJson = new JsonAdd("Users.json");
            var UserData = UserJson.LoadFromJson2();
            // find user index
            int index_user = 0;
            for (int i = 0; i < UserData.userlist.Count; i++)
            {
                if (MainProgram.onlineUser.userName == UserData.userlist[i].userName)
                {
                    index_user = i;

                }
            }
            List<Reservation> ResList = new List<Reservation>();
            if (UserData.userlist[index_user].reservations != null)

            {
                int counter = 0;
                foreach (Reservation reservation in UserData.userlist[index_user].reservations)
                {
                    Console.WriteLine("You have got reservation(s) for this movie(s)");
                    Console.WriteLine($"[{counter}] {reservation.movie.Name} at {reservation.Date}\n");

                    counter++;
                }
            }
            Console.WriteLine("Type the number of the movie to get more information about the reservation.\nType exit to go back.");
            string answer2;
            answer2 = Console.ReadLine();
            if (answer2 == "exit")
            {
                User.panel();
            }

            if (isNumeric(answer2))
            {
                int num = MakeNumber(answer2);
                if (num < UserData.userlist[index_user].reservations.Count && num > -1)
                {
                    Console.WriteLine(
                       $" Movie: {UserData.userlist[index_user].reservations[num].movie.Name}\n" +
                       $"Date: {UserData.userlist[index_user].reservations[num].Date} \n" +
                       $"Tickets: {UserData.userlist[index_user].reservations[num].Seat.Length}"

                        );
                    int counter2 = 1;
                    foreach (var seatnum in UserData.userlist[index_user].reservations[num].Seat)
                    {
                        Console.WriteLine($"Seat {counter2}. Row: {seatnum.Item1}   Seat number: {seatnum.Item2}");
                        counter2++;
                    }
                    int counter3 = 1;
                    foreach (var foodorder in UserData.userlist[index_user].reservations[num].Food)
                    {
                        Console.WriteLine($"Combo menu {counter3}. Drink: {foodorder.Item1}   Snack: {foodorder.Item2}   Food: {foodorder.Item3}");
                    }
                    Console.WriteLine($"Price: {UserData.userlist[index_user].reservations[num].Price}\n");
                }


                Console.WriteLine("Type 'cancel' to cancel te reservation or type any other key to continue. ");
                string cancel = Console.ReadLine();
                if (cancel.ToLower() == "cancel")
                {

                    var Json = new JsonAdd("CinemaAssets.json");
                    var CinemaData = Json.LoadFromJson();

                    List<Tuple<int, int>> hallList = new List<Tuple<int, int>>();


                    int hall_index = 0;
                    foreach (var hall in CinemaData.CinemaHallList)
                    {


                        int hallres_index = 0;
                        foreach (var hallRes in hall.HallReservation)
                        {
                            if (UserData.userlist[index_user].reservations[num].movie.Name == hallRes.Item3.Name)
                            {
                                if (UserData.userlist[index_user].reservations[num].Date == DateTime.Parse($"{hallRes.Item1.Item1}/{hallRes.Item1.Item2}/{hallRes.Item1.Item3} {hallRes.Item2.Item1}:{hallRes.Item2.Item2}:00"))
                                {
                                    hallList.Add(Tuple.Create(hall_index, hallres_index));
                                }


                            }
                            hallres_index++;
                        }
                        hall_index++;

                    }
                    for (int i = 0; i < UserData.userlist[index_user].reservations[num].Seat.Length; i++)
                    {


                        CinemaData.CinemaHallList[hallList[0].Item1].HallReservation[hallList[0].Item2].Item4[UserData.userlist[index_user].reservations[num].Seat[i].Item1, UserData.userlist[index_user].reservations[num].Seat[i].Item2].Status = true;
                    }

                    Json.SaveToJson(CinemaData);
                    UserData.userlist[index_user].reservations.Remove(UserData.userlist[index_user].reservations[num]);

                    UserJson.SaveToJsonUser(UserData);
                }
            }
        }

        public static string randCode()
        {

            Random random = new Random();
            string str = "";
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = random.Next(10, 13);
            for (int i = 0; i < length; i++)
            {
                int ch = random.Next(0, chars.Length );
                str += chars[ch];
            }
            return str;

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