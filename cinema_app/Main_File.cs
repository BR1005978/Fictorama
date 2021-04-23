using System;
using System.Collections.Generic;

namespace cinema_app
{

    class MainProgram
    {


        public static void MainMenu()
        {
           // User user1 = new User("Sydney", "Beek", "13-05-2003", "1014378@hr.nl", "0612345678", "sydneyb", "syd123");
            //User user1 = new User("Brandan", "Beek", "13-05-2003", "1014378@hr.nl", "0612345678", "sydneyb", "syd123");
           // List<User> listUser1 = new List<User>() ;
            //listUser1.Add(user1);
            //JsonAdd saveUser1 = new JsonAdd("sydney.json");
           // saveUser1.SaveToJsonUser(listUser1);
            //user1.password = "nieuw";
            //saveUser1.SaveToJsonUser(listUser1);

            Console.WriteLine(" \n" +
"▒█▀▀▀ ▀█▀ ▒█▀▀█ ▀▀█▀▀ ▒█▀▀▀█ ▒█▀▀█ ░█▀▀█ ▒█▀▄▀█ ░█▀▀█ \n" +
"▒█▀▀▀ ▒█░ ▒█░░░ ░▒█░░ ▒█░░▒█ ▒█▄▄▀ ▒█▄▄█ ▒█▒█▒█ ▒█▄▄█ \n" +
"▒█░░░ ▄█▄ ▒█▄▄█ ░▒█░░ ▒█▄▄▄█ ▒█░▒█ ▒█░▒█ ▒█░░▒█ ▒█░▒█ \n");
            Console.WriteLine("\nWelcome to Fictorama! \n" +
                "This is Fictoram Interface 0.03\n\n");

            List<string> options = new List<string> { "1", "2", "3", "4", "5" };
            string answer = "";
            while (!options.Contains(answer))
            {

                Console.WriteLine("Please choose what you want to do (type the numbers): \n" +
                "1. See available movies\n" +
                "2. Login\n" +
                "3. Signin\n" +
                "4. Register\n" +
                "5. Search movies\n" +
                "6. Exit program\n"
                );
                answer = Console.ReadLine();


                if (answer == "1")
                {
                    Console.WriteLine("\nYou picked \"1. See available movies\" \n\n");
                    MovieBrowser.MovieBrowserMenu();

                }
                else if (answer == "2")
                {
                    

                    Login.LoginScreen();

                }
                else if (answer == "3")
                {

                    Signin.SigninScreen();

                }
                else if (answer == "4")
                {

                    Register.RegisterScreen();

                }
                
                else if (answer == "5")
                {
                    SearchFunction.Searchbar(MovieList.movielist);
                }
                else if (answer == "6")
                {
                    Console.WriteLine("Shutting down...");
                }
                

                else
                {
                    { Console.WriteLine("Your input was: " + answer + "\nInput not recognised. Please try again\n"); }
                }
                Console.WriteLine("Shutting down ...");
            }
        }
        public static void Main()
        {
            CinemaAssets CinemaData = new CinemaAssets();
            Userlist UserData = new Userlist();

            var Json = new JsonAdd("CinemaAssets.json");
            var UserJson = new JsonAdd("Users.json");

            try
            {
                CinemaData = Json.LoadFromJson();

                try
                {
                    UserData = UserJson.LoadFromJson2();
                }
                catch (Exception ex)
                {
                    UserData = new Userlist();
                }
            }
            catch (Exception ex)
            {
                CinemaData = new CinemaAssets();
            }
            UserJson.SaveToJsonUser(UserData);
            Json.SaveToJson(CinemaData);


            ///<summary>
            /// Dit is de Fictorama demonstratieversie voor sprint review 2 op 8-4-2021
            ///</summary>


            ///Hiermee wordt MainMenu aangeroepen en het programma dus geïnstantieerd
            MainMenu();
        }
    }
}
