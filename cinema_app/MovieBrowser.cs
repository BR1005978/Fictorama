using System;
using System.Collections.Generic;

namespace cinema_app
{
    class MovieBrowser
    {
        public static void MovieBrowserMenu()
        {

            string answer = "";
            while (answer != "exit")
            { 

                int counter = 0;

                foreach (Movie film in MovieList.movielist)
                {
                    Console.WriteLine($"{counter}: {film.Name}");
                    counter++;
                }

                Console.WriteLine("Select a movie to learn more about it, or type 'exit' to go back.");
                answer = Console.ReadLine();

                if (answer == "exit")
                {
                    MainProgram.MainMenu();
                }
                else
                {
                    int answerint;

                    // hiermee controleer je of het wel een int is
                    // en of hij niet langer is dan de lengte van de filmlijst
                    if (int.TryParse(answer, out answerint) && int.Parse(answer) < MovieList.movielist.Count)
                    {

                        Console.WriteLine(
                            $"Name: {MovieList.movielist[answerint].Name}\n" +
                            $"Description: {MovieList.movielist[answerint].Info}\n" +
                            $"Year of Release:  {MovieList.movielist[answerint].Year}\n" +
                            $"Genre:  {MovieList.movielist[answerint].Genre}\n" +
                            $"Actors:  {MovieList.movielist[answerint].Actors}\n" +
                            $"Duration: {MovieList.movielist[answerint].Duration}\n"
                           );

                    }
                    else
                        Console.WriteLine("\nInput not recognised. Please try again.\n ");
                }
                Console.WriteLine("Press any key to continue ...");

                string cont = Console.ReadLine();

            }
            //MovieBrowserMenu();
        }
    }
}
