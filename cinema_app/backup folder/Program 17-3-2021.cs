using System;
using System.Collections.Generic;

namespace cinema_app
{
    class Program
    {

        static void Main()
        {
            void WelcomeScreen()
            {
                // void GuestWelcome()
                Console.WriteLine("Welcome to Fictorama! \n" +
                    "This is Fictoram Interface 0.02\n\n");

                List<string> options = new List<string> { "1", "2", "3", "4" };
                string answer = "";
                while (!options.Contains(answer))
                {

                    Console.WriteLine("Please choose what you want to do: \n" +
                    "1. See available movies\n" +
                    "2. Login\n" +
                    "3. Register\n" +
                    "4. Exit program\n"
                    );
                    answer = Console.ReadLine();


                    if (answer == "1")
                    {
                        //Console.WriteLine("You picked \"1. See available movies\" \n" +
                        //    "WORK IN PROGRESS - Please come back later");
                        MovieBrowser();

                    }
                    else if (answer == "2")
                    {
                        //Console.WriteLine("You picked \"2. Login\" \n" +
                        //    "WORK IN PROGRESS - Please come back later");
                        LoginScreen();

                    }
                    else if (answer == "3")
                    {
                        //Console.WriteLine("You picked \"3. Register\" \n" +
                        //    "WORK IN PROGRESS - Please come back later");
                        RegisterScreen();

                    }
                    else if (answer == "4")
                    {
                        ExitScreen();
                    }
                    else
                    { Console.WriteLine("Your input was: " + answer + "\nInput not recognised. Please try again\n"); }
                }
                Console.WriteLine("Shutting down ...");
            }


            void MovieBrowser()
            {
                Console.WriteLine("You picked \"1. See available movies\" \n");

            }
            void LoginScreen()
            {
                Console.WriteLine("You picked \"2. Login\" \n" +
                        "WORK IN PROGRESS - Please come back later");
            }

            void RegisterScreen()
            {
                Console.WriteLine("You picked \"3. Register\" \n" +
                    "WORK IN PROGRESS - Please come back later");
            }
            void ExitScreen()
            {
                Console.WriteLine("Shutting down...");
            }

            WelcomeScreen();
        }
    }
}
