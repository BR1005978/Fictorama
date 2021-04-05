using System;
using System.Collections.Generic;

namespace cinema_app
{

    class MainProgram
    {
        //dit is een handige hulpfunctie die je kunt gebruiken om op de python manier
        //iets te printen. gewoon print("hallo") bijvoorbeeld
        public static void print(string s)
        {


        public static void MainMenu()
        {

            Console.WriteLine("\nWelcome to Fictorama! \n" +
                "This is Fictoram Interface 0.03\n\n");
            //if (UserCheck){
            //    Console.WriteLine("Usercheck is true");
            //}
            //else
            //{
            //    Console.WriteLine("Usercheck is false");
            //}
            List<string> options = new List<string> { "1", "2", "3", "4", "5" };
            string answer = "";
            while (!options.Contains(answer))
            {

                    Console.WriteLine("Please choose what you want to do: \n" +
                    "1. See available movies\n" +
                    "2. Login\n" +
                    "3. Register\n" +
                    "4. Search movies\n" +
                    "5. Exit program\n"
                    );
                    answer = Console.ReadLine();


                    if (answer == "1")
                    {

                        MovieBrowser.MovieBrowserMenu();

                    }
                    else if (answer == "2")
                    {

                        Login.LoginScreen();

                    }
                    else if (answer == "3")
                    {

                        Register.RegisterScreen();

                }
                else if (answer == "4")
                {
                    SearchFunction.Searchbar(MovieList.movielist);
                }
                else if (answer == "5")
                {
                    Console.WriteLine("Shutting down...");
                }
                else if (answer == "admin")
                {
                    Admin.AdminPanel();
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

            ///<summary>
            /// Dit is de Fictorama demonstratieversie voor sprint review 2 op 8-4-2021
            ///</summary>


            ///Hiermee wordt MainMenu aangeroepen en het programma dus geïnstantieerd
            MainMenu();
        }
    }
}
