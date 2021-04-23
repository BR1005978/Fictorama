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
                            $"\nName: {MovieList.movielist[answerint].Name}\n" +
                            $"Description: {MovieList.movielist[answerint].Info}\n" +
                            $"Year of Release:  {MovieList.movielist[answerint].Year}\n" +
                            //$"Genre:  {MovieList.movielist[answerint].Genre}\n" +
                            $"Actors:  {MovieList.movielist[answerint].Actors}\n" +
                            $"Duration: {MovieList.movielist[answerint].Duration}"
                           );

                        //hiermee print je alle genre's van een film
                        Console.WriteLine($"Genre:  {MovieList.movielist[answerint].Genre[0]}");
                        for (int i = 1; i < MovieList.movielist[answerint].Genre.Length; i++) {
                            Console.WriteLine(MovieList.movielist[answerint].Genre[i]);

                        }

                        Console.WriteLine("1. Make reservation for this movie\n" +
                            "or type enter to continue");
                        string resv = Console.ReadLine();
                        if (resv == "1")
                        {
                            Reservation.make_reservation();
                        }
                    }
                    else
                        Console.WriteLine("\nInput not recognised. Please try again.\n ");
                }
                Console.WriteLine("Press any key to continue ...");

                Console.ReadLine();

            }
            //MovieBrowserMenu();
        }
    }
}
