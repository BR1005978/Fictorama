using System;
using System.Collections.Generic;

namespace cinema_app
{

    class MainProgram
    {
        public static void print(string s)
        {
            Console.WriteLine(s);
        }

        public static void MainMenu()
        // Het hoofdmenu
        // WelcomeScreen is hernoemd naar MainMenu, om het verschil tussen een eventueel welkomstscherm
        // en het hoofdmenu van de applicatie te behouden
        {

            Console.WriteLine("Welcome to Fictorama! \n" +
                "This is Fictoram Interface 0.03\n\n");

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
                    //SearchFunction.Searchbar(movielist);
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

            // hier staat nog de movielist. ik denk dat het handig is dat we dit verplaatsen naar
            // MovieList.cs, zodat we main file verder met rust kunnen laten. het lukt mij alleen niet want ik krijg allemaal errors die ik niet begrijp
            // als ik het probeer. misschien lukt één van jullie het? 
            Movie Pixels = new Movie("Pixels", "", "2015", new string[] { "Action", "Comedy", "Animation", "Fantasy", "Science Fiction" }, "Adam Sandler plays Sam Brenner \n Josh gad plays Ludlow Lamonsoff \n Peter Dinklage plays Eddie Plant", "1 H 46 M");
            Movie CHAPPIE = new Movie("CHAPIE", "", "2015", new string[] { "Science Fiction", "Action", "Crime", "Thriller" }, "Anri du Toit plays Yolandi \n Watkin Tudor Jones plays Ninja \n Hugh Jackman plays Vincent Moore", "2 H");
            Movie Jurassic_World = new Movie("Jurassic World", "", "2015", new string[] { "Science Fiction", "Action", "Thriller", "Fantasy", "Adventure" }, "Chris Pratt plays Owen Grady \n ", "2 H 4 M");
            Movie Tron = new Movie("Tron: Lengacy", "", "2010", new string[] { "Science Fiction, Action, Adventure, Fantasy" }, "Garrett Hedlund plays Sam Flynn \n Jeff Bridges plays Kevin Flynn", "2 H 7 M");
            Movie The_Maze_Runner = new Movie("The Maze Runner", "", "2014", new string[] { "Science Fiction", "Action", "Thriller", "Adventure" }, "Dylan O'Brien plays Thomas \n Thomas Brodie-Sangster plays Newt \n Will Poulter plays Gally", "1 H 54 M");

            Movie Wolverine = new Movie("X-Men Origins: Wolverine", "The early years of James Logan, featuring his rivalry with his brother Victor Creed, his service in the special forces team Weapon X, and his experimentation into the metal-lined mutant Wolverine.", "2009", new string[] { "science-fiction" }, "actor", "duration"); //test movie
            List<Movie> movielist = new List<Movie>();
            movielist.Add(Wolverine);




            ///Hiermee wordt MainMenu aangeroepen en het programma dus geïnstantieerd
            MainMenu();
        }

    }
}
