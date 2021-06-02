using System;
using System.Collections.Generic;
using System.Globalization;

namespace cinema_app
{
    public class AddReview
    {
        // voor de admin
        public static void DelReview()
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
                Console.WriteLine("Select a movie to delete reviews, or type 'exit' to go back.");
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
                        bool continueTF = true;
                        while (continueTF)
                        {
                            Console.WriteLine($"This are the review for the movie {CinemaData.MovieList[answerint].Name}\n");
                            counter = 0;
                            foreach (var review in CinemaData.MovieList[answerint].review)
                            {
                                Console.WriteLine($"{counter}. {review.Item3.userName}: {review.Item1}");
                                counter++;
                            }
                            Console.WriteLine("Select a review, or type 'exit' to go back.");
                            answer = Console.ReadLine();
                            if (answer == "exit")
                            {
                                MainProgram.MainMenu();
                            }
                            else
                            {
                                if (int.TryParse(answer, out answerint) && int.Parse(answer) < CinemaData.MovieList[answerint].review.Count)
                                {
                                    CinemaData.MovieList[answerint].review.Remove(CinemaData.MovieList[answerint].review[answerint]);
                                    continueTF = false;
                                    Json.SaveToJson(CinemaData);
                                    Admin.AdminPanel();
                                }
                                else
                                    Console.WriteLine("\nInput not recognised. Please try again.\n ");
                            }
                        }
                    }
                    else
                        Console.WriteLine("\nInput not recognised. Please try again.\n ");
                }
            }



        }

        public static void review(int i)
        {
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();
            Console.WriteLine("Please type the review:");
            string comment = "";
            comment = Console.ReadLine();
            Tuple<string, DateTime, User> tup = new Tuple<string, DateTime, User>(comment, DateTime.Now, MainProgram.onlineUser);
            if (CinemaData.MovieList[i].review == null)
            {
                var listrev = new List<Tuple<string, DateTime, User>>();
                listrev.Add(tup);
                CinemaData.MovieList[i].review = listrev;
            }
            else
            {
                CinemaData.MovieList[i].review.Add(tup);
            }
            Json.SaveToJson(CinemaData);
            //customer.customer();
        }
        public static void showreviews(int i)
        {
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();
            if (CinemaData.MovieList[i].review == null)
            {
                Console.WriteLine("Sorry, there are no reviews yet");
            }
            else
            {
                foreach (Tuple<string, DateTime, User> rev in CinemaData.MovieList[i].review)
                {
                    Console.WriteLine($"{rev.Item3.userName}: {rev.Item1}");
                }
            }
            Console.WriteLine("\nPress any button to leave.\n");
            Console.ReadLine();
            
        }
        public static void RestaurantReview()
        {
            Console.WriteLine("Please type the review:");
            string comment = "";
            comment = Console.ReadLine();
            Tuple<string,User,DateTime> tup= new Tuple<string, User, DateTime> (comment, MainProgram.onlineUser, DateTime.Now);
            
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();
            CinemaData.restaurantreviews.Add(tup);
            Json.SaveToJson(CinemaData);
            //Console.Clear();
            User.panel();
            //customer.customer();
        }
        public static void showresreviews() {
            
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();
            if (CinemaData.restaurantreviews.Count == 0)
            {
                Console.WriteLine("Sorry, there are no reviews yet");
            }
            else {
                foreach (Tuple<string, User, DateTime> rev in CinemaData.restaurantreviews) {
                    Console.WriteLine($"{rev.Item2.userName}: {rev.Item1}");
                }
            }
            Console.WriteLine("\nPress any button to leave.\n");
            Console.ReadLine();
            //Console.Clear();
        }

        

        
        public static void editreview()
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

                Console.WriteLine("Select a movie to edit the review, or type 'exit' to go back.");
                answer = Console.ReadLine();

                if (answer == "exit")
                {
                    //MainProgram.MainMenu();
                }
                else
                {
                    if (!Reservation.isNumeric(answer))
                    {
                        Console.Clear();
                        Console.WriteLine("wrong input\n");
                        EDitreview();
                    }
                    else
                    {
                        int movieIndex = Reservation.MakeNumber(answer);
                        counter = 0;

                        Console.Clear();
                        answer = "";
                        while (!Reservation.isNumeric(answer))
                        {


                            if (CinemaData.MovieList[movieIndex].review != null)
                            {
                                foreach (var review in CinemaData.MovieList[movieIndex].review)
                                {
                                    Console.WriteLine($"[{counter}] {review.Item3.userName}: {review.Item1}");
                                }
                                Console.WriteLine("Select a review to edit, or type 'exit' to go back.");
                                answer = Console.ReadLine();

                                if (answer.ToLower() == "exit")
                                {
                                    User.panel();
                                }
                                else
                                {
                                    if (!Reservation.isNumeric(answer))
                                    {
                                        // again
                                    }
                                    else
                                    {
                                        int reviewIndex = Reservation.MakeNumber(answer);
                                        if (CinemaData.MovieList[movieIndex].review[reviewIndex].Item3.userName == MainProgram.onlineUser.userName)
                                        {
                                            Console.WriteLine("[0] Delete review\n" +
                                                "[1] Edit review\n" +
                                                "press any other key to exit");
                                            string ans = Console.ReadLine();

                                            if (ans == "0")
                                            {
                                                CinemaData.MovieList[movieIndex].review.Remove(CinemaData.MovieList[movieIndex].review[reviewIndex]);
                                                Console.WriteLine("Delete review succes");
                                                Json.SaveToJson(CinemaData);
                                                Console.WriteLine("Press any key to continue...");
                                                Console.ReadLine();
                                            }
                                            else if (ans == "1")
                                            {
                                                CinemaData.MovieList[movieIndex].review.Remove(CinemaData.MovieList[movieIndex].review[reviewIndex]);
                                                Console.WriteLine("type the new review.");
                                                string newreview = Console.ReadLine();
                                                Tuple<string, DateTime, User> revtup = Tuple.Create(newreview, DateTime.Now, MainProgram.onlineUser);
                                                CinemaData.MovieList[movieIndex].review.Add(revtup);
                                                Json.SaveToJson(CinemaData);
                                                Console.WriteLine("Edit review succes");
                                                Console.WriteLine("Press any key to continue...");
                                                Console.ReadLine();
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("This is not your review, so you can not edit this review.");
                                            answer = "";
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("There are no reviews for this movie.");
                                Console.WriteLine("Press any key to continue...");
                                answer = "0";
                                Console.ReadLine();
                            }
                        }


                    }
                }
            }
        }
    }
}

