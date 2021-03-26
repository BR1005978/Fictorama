using System;
using System.Collections.Generic;

namespace cinema_app
{
    /// test comment test test
    /// test weer een testcomment
    class MainProgram
    {
        /// <summary>
        /// oke, dus ik heb op 26-3-2021 alle functies verplaatst naar afzonderlijke bestanden, zie solution browser.
        /// dat houdt in dat we alleen maar in dit bestand hoeven te werken als we iets in het hoofdmenu willen aanpassen.
        /// in principe kunnen mensen nu alle individuele classes, methods en objects bewerken zonder dat daar in het hoofdmenu
        /// gewerkt wordt. 
        /// dit is handig want dan wordt niet met elke push het hoofdmenu overschreven en is de kans op conflicterende pushes kleiner.
        /// 
        /// het enige wat nog niet gelukt is, is de movielist in een apart bestand zetten want ik snap niet hoe je een attribute maakt.
        /// ik denk dat het de bedoeling is dat movielist een attribute moet worden van MovieList.cs ofzo maar ik begrijp niet hoe dat werkt
        /// </summary>
        public static void Main()
        {
            // hier staat nog de movielist. ik denk dat het handig is dat we dit verplaatsen naar
            // MovieList.cs, zodat we main file verder met rust kunnen laten. het lukt mij alleen niet want ik krijg allemaal errors die ik niet begrijp
            // als ik het probeer. misschien lukt één van jullie het? 

            Movie Wolverine = new Movie("X-Men Origins: Wolverine", "The early years of James Logan, featuring his rivalry with his brother Victor Creed, his service in the special forces team Weapon X, and his experimentation into the metal-lined mutant Wolverine.", "2009"); //test movie
            Movie[] movielist = new Movie[] { Wolverine };


            void MainMenu()
            // Het hoofdmenu
            // WelcomeScreen is hernoemd naar MainMenu, om het verschil tussen een eventueel welkomstscherm
            // en het hoofdmenu van de applicatie te behouden
            {

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
                        SearchFunction.Searchbar(movielist);
                    }
                    else if (answer == "5")
                    {
                        Console.WriteLine("Shutting down...");
                    }
                    else
                    { Console.WriteLine("Your input was: " + answer + "\nInput not recognised. Please try again\n"); }
                }
                Console.WriteLine("Shutting down ...");
            }

            ///Hiermee wordt MainMenu aangeroepen en het programma dus geïnstantieerd
            MainMenu();
        }
    }
}
