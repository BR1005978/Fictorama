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
            Tuple<string,DateTime, User> tup= new Tuple<string, DateTime, User>(comment, DateTime.Now, MainProgram.onlineUser);
            CinemaData.MovieList[i].review.Add(tup);
            Json.SaveToJson(CinemaData);
            //Costumer.costumer();
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
            //Costumer.costumer();
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

        public static void editReview()
        {
            var Json = new JsonAdd("CinemaAssets.json");
            var CinemaData = Json.LoadFromJson();
            int count = 0;
            //ublic List<Tuple< string, DateTime, User >> review;
            List<Tuple<string, Movie, Tuple<string, DateTime, User>>> editList = new List<Tuple<string, Movie, Tuple<string, DateTime, User>>>();
            //var rev = 0;
            for (int i = 0; i < CinemaData.MovieList.Count; i++)
            {
                Console.WriteLine(CinemaData.MovieList.Count);
                for (int j = 0; i < CinemaData.MovieList[i].review.Count; j++)
                {
                    Console.WriteLine(CinemaData.MovieList[i].review.Count);
                    Console.WriteLine(CinemaData.MovieList[i].review == null);
                    if (CinemaData.MovieList[i].review == null)
                    {
                        Console.WriteLine("null");
                    }
                    else if (CinemaData.MovieList[i].review[0].Item3.userName == MainProgram.onlineUser.userName)
                    {

                        editList.Add(Tuple.Create($"{count}. {CinemaData.MovieList[i]}: {CinemaData.MovieList[i].review[0].Item1}", CinemaData.MovieList[i], CinemaData.MovieList[i].review[j]));

                        count++;
                    }
                }
            }
            string editnum = "";
            int n;
            bool isNumeric = int.TryParse(editnum, out n);
            while (!isNumeric)
            {
                for (int i = 0; i < editList.Count; i++)
                {
                    Console.WriteLine(editList[i].Item1);
                }
                Console.WriteLine("\nWhich review would you like to edit.\n Type the number of the review.");

                editnum = Console.ReadLine();
                isNumeric = int.TryParse(editnum, out n);
            }
            int numVal = Int32.Parse(editnum);
            var changeReview = editList[numVal];
            List<string> options = new List<string> { "1", "2" };
            string answer = "";
            while (!options.Contains(answer))
            {
                answer = Console.ReadLine();
                Console.WriteLine("Please choose what you want to do (type the numbers): \n" +
                "1. Delete review\n" +
                "2. Edit review\n");

                if (answer == "1")
                {
                    editList[numVal].Item2.review.Remove(editList[numVal].Item3);
                }
                else if (answer == "2")
                {
                    editList[numVal].Item2.review.Remove(editList[numVal].Item3);
                    Console.WriteLine("Type the new review");
                    string newReview = Console.ReadLine();
                    editList[numVal].Item2.addreview(newReview, MainProgram.onlineUser, DateTime.Now);
                }


                Json.SaveToJson(CinemaData);
            }


        }
    }
}

