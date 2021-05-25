using System;
using System.Collections.Generic;
namespace cinema_app
{


    public class User
    {
        public string first_name;
        public string last_name;
        public string date_of_birth;
        public string email;
        public string phone_number;
        public string userName;
        public Tuple<string, int> password;
        public List<Reservation> reservations;

        public User(string First_name, string Last_name, string Date_of_birth, string Email, string Phone_number, string Username, Tuple<string, int> Password)
        {
            this.first_name = First_name;
            this.last_name = Last_name;
            this.date_of_birth = Date_of_birth;
            this.email = Email;
            this.phone_number = Phone_number;
            this.userName = Username;
            this.password = Password;

        }


        public void introduce()
        {
            Console.WriteLine("welcome {0}", userName);
        }

        public void PastReservation()
        {
            foreach (var reservation in this.reservations)
            {
                Console.WriteLine(reservation.BasicInformation());
            }
        }

        public static void panel()
        {
            List<string> options = new List<string> { "1", "2", "3", "4", "5", "6" };
            string answer = "";

            while (!options.Contains(answer))
            {
                Console.WriteLine("\nPlease choose what you want to do (type the number): \n" +
                "1. See available movies\n" +
                "2. Edit reviews\n" +
                "3. Search movies\n" +
                "4. Leave review on restaurant\n" +
                "5. Previous reservations\n" +
                "6. Log out\n");
                answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.WriteLine("\n You picked: 1. See available movies\n\n");
                    MovieBrowser.MovieBrowserMenu();
                    panel();
                }
                else if (answer == "2")
                {
                    Console.WriteLine("\n You picked: 2. Edit reviews\n\n");
                    //AddReview.editReview();
                }
                else if (answer == "3")
                {
                    Console.WriteLine("\n You picked: 3. Search movie\n\n");
                    var Json = new JsonAdd("CinemaAssets.json");
                    var CinemaData = Json.LoadFromJson();
                    SearchFunction.Searchbar(CinemaData.MovieList);
                }
                else if (answer == "4")
                {
                    AddReview.RestaurantReview();
                }
                else if (answer == "5")
                {
                    Reservation.PastReservation();
                }
                else if (answer == "6")
                {
                    Console.WriteLine("\n You picked: 4. Log out\n\n");
                    MainProgram.onlineUser = null;
                    MainProgram.MainMenu();
                }
            }
        }

    }
}