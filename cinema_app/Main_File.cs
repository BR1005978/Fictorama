using System;
using System.Collections.Generic;

namespace cinema_app
{

    class MainProgram
    {
        public static User onlineUser = null;

        public static void MainMenu()
        {
           

            Console.WriteLine(" \n" +
"▒█▀▀▀ ▀█▀ ▒█▀▀█ ▀▀█▀▀ ▒█▀▀▀█ ▒█▀▀█ ░█▀▀█ ▒█▀▄▀█ ░█▀▀█ \n" +
"▒█▀▀▀ ▒█░ ▒█░░░ ░▒█░░ ▒█░░▒█ ▒█▄▄▀ ▒█▄▄█ ▒█▒█▒█ ▒█▄▄█ \n" +
"▒█░░░ ▄█▄ ▒█▄▄█ ░▒█░░ ▒█▄▄▄█ ▒█░▒█ ▒█░▒█ ▒█░░▒█ ▒█░▒█ \n");
            Console.WriteLine("\nWelcome to Fictorama! \n" +
                "This is Fictoram Interface 0.03\n\n");

            List<string> options = new List<string> { "1", "2", "3", "4", "5", "6", "7" };
            string answer = "";
            while (!options.Contains(answer))
            {

                Console.WriteLine("Please choose what you want to do (type the numbers): \n" +
                "1. See available movies\n" +
                "2. Login\n" +
                "3. Register\n" +
                "4. Search movies\n" +
                "5. See upcoming movies\n"+
                "6. See restaurant reviews\n" +
                "7. Exit program\n"
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
                    var Json = new JsonAdd("CinemaAssets.json");
                    var CinemaData = Json.LoadFromJson();
                    SearchFunction.Searchbar(CinemaData.MovieList);
                }
                else if (answer == "5")
                {
                    MovieBrowser.UpcomingMovieBrowserMenu();
                }
                else if (answer == "6")
                {
                    AddReview.showresreviews();
                }
                else if (answer == "7")
                {
                    Console.WriteLine("Shutting down...");
                    Environment.Exit(0);
                }

                else
                {
                    { Console.WriteLine("Your input was: " + answer + "\nInput not recognised. Please try again\n"); }
                }
                //Console.Clear();
            }
        }
        public static void Main()
        {
            // hier maakt het programma objecten aan van CinemaAssets, Userlist, en later EmployeeList
            CinemaAssets CinemaData = new CinemaAssets();
            Userlist UserData = new Userlist();
            Catering catering = new Catering();
            // EmployeeList EmployeeData = new EmployeeList();


            var Json = new JsonAdd("CinemaAssets.json");
            var UserJson = new JsonAdd("Users.json");
            var CateringJson = new JsonAdd("Catering.json");
            // var EmployeeJson = new JsonAdd("Employees.json");



            // hiermee checkt of er iets zit in de JSON bestanden, zo niet dan maakt hij die aan 

            try // probeer CinemaAssets JsonAdd.LoadFromJson
            {
                CinemaData = Json.LoadFromJson();

                try // probeer data te laden van userlist UserData
                {
                    UserData = UserJson.LoadFromJson2();
                    try
                    {
                        catering = CateringJson.LoadFromJsoncatering();
                    }
                    catch (Exception ex)
                    {
                        catering = new Catering();
                    }
                }
                catch (Exception ex) // als die er niet is, dan maakt hij een nieuw object van Userlist aan
                {
                    UserData = new Userlist();
                }

            }
            // als er geen informatie geladen kan worden (omdat die informatie er nog niet is) van de cinemadata, dan 
            // maakt hij een nieuwe aan
            catch (Exception ex)
            {
                CinemaData = new CinemaAssets();
            }

            // hier slaat hij de informatie die in de lijsten staat, op in de JSON bestanden
            UserJson.SaveToJsonUser(UserData);
            Json.SaveToJson(CinemaData);
            CateringJson.SaveToJsonCatering(catering);


            ///Hiermee wordt MainMenu aangeroepen en het programma dus geïnstantieerd
            MainMenu();
        }
    }
}
