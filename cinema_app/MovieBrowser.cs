﻿using System;
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
                            $"Duration: {CinemaData.MovieList[answerint].Duration}"
                           );

                        //hiermee print je alle genre's van een film
                        Console.WriteLine($"Genre:  {CinemaData.MovieList[answerint].Genre[0]}");
                        for (int i = 1; i < CinemaData.MovieList[answerint].Genre.Length; i++) {
                            Console.WriteLine(CinemaData.MovieList[answerint].Genre[i]);


                        }
                        if(MainProgram.onlineUser != null)
                        {
                            string choice = "";
                            Console.WriteLine("Type 'res' to make a reservation for this movie.");
                            //reservationscreen
                            Console.WriteLine("Type 'review' to leave a comment.");
                            //AddReview()
                            choice = Console.ReadLine();
                            if(choice == "res")
                            {
                                Reservation.reserveer(CinemaData.MovieList[answerint]);
                            }
                            else if (choice == "review")
                            {
                                
                                AddReview.review(CinemaData.MovieList[answerint]);
                                //Costumer.costumer();
                            }
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
