using System;
using System.Collections.Generic;

namespace cinema_app
{
    class MovieBrowser
    {
        public static void MovieBrowserMenu()
        {
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();

            string answer = "";
            while (answer != "exit")
            { 

                int counter = 0;

                foreach (Movie film in CinemaData.MovieList)
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
                    if (int.TryParse(answer, out answerint) && int.Parse(answer) < CinemaData.MovieList.Count)
                    {

                        Console.WriteLine(
                            $"\nName: {CinemaData.MovieList[answerint].Name}\n" +
                            $"Description: {CinemaData.MovieList[answerint].Info}\n" +
                            $"Year of Release:  {CinemaData.MovieList[answerint].Year}\n" +
                            //$"Genre:  {MovieList.movielist[answerint].Genre}\n" +
                            $"Actors:  {CinemaData.MovieList[answerint].Actors}\n" +
                            $"Duration: {CinemaData.MovieList[answerint].Duration}\n"+
                            $"Duration: {CinemaData.MovieList[answerint].Link}"
                           );

                        //hiermee print je alle genre's van een film
                        Console.WriteLine($"Genre:  {CinemaData.MovieList[answerint].Genre[0]}");
                        for (int i = 1; i < CinemaData.MovieList[answerint].Genre.Length; i++) {
                            Console.WriteLine(CinemaData.MovieList[answerint].Genre[i]);


                        }
                        Console.WriteLine("Press [0] to see trailer.");
                        Console.WriteLine("Press [1] to make a reservation.");
                        Console.WriteLine("Press [2] to see reviews about this movie.");
                        Console.WriteLine("Press [3] to leave a review. \nor type any other key to exit.");
                        string key = Console.ReadLine();
                        if (key == "0")
                        {
                            Trailer.Seetrailer(CinemaData.MovieList[answerint].Link);

                        }


                        
                        
                       
                        

                        
                        if (key == "1")
                        {
                            Reservation.reserveer(CinemaData.MovieList[answerint]);
                        }
                        if (key == "2")
                        {
                            //see reviews
                            AddReview.showreviews(answerint);
                        }
                        if (key == "3" && MainProgram.onlineUser != null)
                        {

                            AddReview.review(answerint);
                            User.panel();

                        }
                        else {
                            MainProgram.MainMenu();
                        }


                    }
                    else
                        Console.WriteLine("\nInput not recognised. Please try again.\n ");
                        Console.WriteLine("Press any key to continue ...");
                }
                

                Console.ReadLine();

            }
            //MovieBrowserMenu();
        }
        ////////////////////////////////////////////
        public static void UpcomingMovieBrowserMenu()
        {
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();

            string answer = "";
            while (answer != "exit")
            {

                int counter = 0;

                foreach (Movie film in CinemaData.UpcomingMovieList)
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
                    if (int.TryParse(answer, out answerint) && int.Parse(answer) < CinemaData.UpcomingMovieList.Count)
                    {

                        Console.WriteLine(
                            $"\nName: {CinemaData.UpcomingMovieList[answerint].Name}\n" +
                            $"Description: {CinemaData.UpcomingMovieList[answerint].Info}\n" +
                            $"Year of Release:  {CinemaData.UpcomingMovieList[answerint].Year}\n" +
                            //$"Genre:  {MovieList.movielist[answerint].Genre}\n" +
                            $"Actors:  {CinemaData.UpcomingMovieList[answerint].Actors}\n" +
                            $"Duration: {CinemaData.UpcomingMovieList[answerint].Duration}\n"+
                            $"Duration: {CinemaData.MovieList[answerint].Link}"
                           );

                        //hiermee print je alle genre's van een film
                        Console.WriteLine($"Genre:  {CinemaData.UpcomingMovieList[answerint].Genre[0]}");
                        for (int i = 1; i < CinemaData.UpcomingMovieList[answerint].Genre.Length; i++)
                        {
                            Console.WriteLine(CinemaData.UpcomingMovieList[answerint].Genre[i]);


                        }
                        Console.WriteLine("Press [0] to see trailer.");
                        Console.WriteLine("Press [1] to make a reservation.");
                        Console.WriteLine("Press [2] to leave a review. \nor type any other key to exit.");
                        string key = Console.ReadLine();
                        if (key == "0")
                        {
                            Trailer.Seetrailer(CinemaData.MovieList[answerint].Link);

                        }




                        //go to reservationscreen
                        if (MainProgram.onlineUser != null)
                        {
                            Console.WriteLine("Type 'review' to leave a comment.");
                        }


                        if (key == "1")
                        {
                            Reservation.reserveer(CinemaData.MovieList[answerint]);
                        }
                        if (MainProgram.onlineUser != null)
                        {
                            if (key == "2")
                            {

                                AddReview.review(answerint);
                                User.panel();
                            }
                        }
                    }
                    else
                        Console.WriteLine("\nInput not recognised. Please try again.\n ");
                        Console.WriteLine("Press any key to continue ...");
                }
                

                Console.ReadLine();

            }
            //MovieBrowserMenu();
        }
    }
}
