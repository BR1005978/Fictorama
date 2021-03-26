using System;
using System.Collections.Generic;

namespace cinema_app
{
    class MovieBrowser
    {
        public static void MovieBrowserMenu()
        {

            List<string> options = new List<string> { "1", "2", "3", "4", "5" };
            string answer = "";
            while (!options.Contains(answer))
            {
                Console.WriteLine(
                "\nYou picked \"1. See available movies\" \n\n" +


                "NOW PLAYING: \n" +

                "1. Star Wars: The Rise of Skywalker (2019) \n" +
                "2. Archive (2020)\n" +
                "3. Underwater  (2020)\n" +
                "4. The Martian (2015)\n" +
                "5. Guardians of the Galaxy Vol 2\n"
                );

                Console.WriteLine(
                    "Select a movie to learn more about it..."
                    );
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    // Hier misschien een method genaamd StarWarsTheRiseOfTheSkyWalker()
                    // Met daarmee een call naar die film waarin je weer losse info kan zetten

                    Console.WriteLine("1.Star Wars: The Rise of Skywalker(2019) \n" +
                        "No information available yet.");

                }
                else if (answer == "2")
                {

                    Console.WriteLine("2. Archive (2020)\n" +
                        "No information available yet.");

                }
                else if (answer == "3")
                {

                    Console.WriteLine("3. Underwater  (2020)\n" +
                        "No information available yet.");

                }
                else if (answer == "4")
                {
                    Console.WriteLine("4. The Martian (2015)\n" +
                        "No information available yet.");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("5. Guardians of the Galaxy Vol 2\n" +
                        "No information available yet.");
                }
                else
                { Console.WriteLine("Your input was: " + answer + "\nInput not recognised. Please try again\n"); }

            }
        }
    }
}
