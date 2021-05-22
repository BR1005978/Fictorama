using System;
using System.Collections.Generic;
namespace cinema_app
{
    public class CinemaAssets
    {
        // Cinema Data
        public List<CinemaHall> CinemaHallList = new List<CinemaHall>();
        public List<Movie> MovieList = new List<Movie>();
        public List<Movie> UpcomingMovieList = new List<Movie>();



        // CinemaHall Control
        public void CreateCinemaHall()
        {
            Console.WriteLine("How many rows: ");
            int row = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many colums: ");
            int colum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the name of the hall");
            string name = Console.ReadLine();

            Console.WriteLine("What is the price for all seats: ");
            double price = Convert.ToDouble(Console.ReadLine());

            this.CinemaHallList.Add(new CinemaHall(row, colum, name, price));

            Console.WriteLine("Done");
        }

        public void ShowCinemaHalls()
        {
            foreach (var hall in this.CinemaHallList)
            {
                Console.WriteLine(hall.HallName);
            }
        }

        public void EditCinemaHall()
        {
            int start = 0;
            foreach (CinemaHall hal in this.CinemaHallList)
            {
                Console.WriteLine($"{start}: {hal.HallName}");
                start++;
            }

            bool isChoosing = true;
            int Hallchoose;

            while (isChoosing)
            {
                try
                {
                    Console.WriteLine("\nPlease type the number of the hall: ");
                    Hallchoose = Convert.ToInt32(Console.ReadLine());
                    if (Hallchoose < start)
                    {
                        while (isChoosing)
                        {
                            int optionChoose;
                            try
                            {

                                Console.WriteLine("0: For editing the name \n1: Adding in movie to a hall time slot \n2: Changing the price of seats" +
                                    "\n3: Show status seats \n4: Show seats prices \n5: Quit\n");
                                Console.WriteLine("please type the number of the option");
                                optionChoose = Convert.ToInt32(Console.ReadLine());
                                if (optionChoose < 6)
                                {
                                    if (optionChoose == 0)
                                    {
                                        Console.WriteLine("What is the new name: ");
                                        string newName = Console.ReadLine();

                                        this.CinemaHallList[Hallchoose].HallName = newName;
                                        Console.WriteLine("Done...");
                                    }
                                    else if (optionChoose == 1)
                                    {
                                        this.CinemaHallList[Hallchoose].Addreservation(this.MovieList);
                                        Console.WriteLine("Done...");
                                    }
                                    else if (optionChoose == 2)
                                    {
                                        this.CinemaHallList[Hallchoose].SetPrice();
                                        Console.WriteLine("Done...");
                                    }
                                    else if (optionChoose == 4)
                                    {
                                        this.CinemaHallList[Hallchoose].SeePrice();
                                        Console.WriteLine("Done...");

                                    }
                                    else if (optionChoose == 3)
                                    {
                                        this.CinemaHallList[Hallchoose].GetHallSeatsScreen();
                                        Console.WriteLine("Done...");
                                    }
                                    else if (optionChoose == 5)
                                    {
                                        isChoosing = false;
                                        Console.WriteLine("Saving...");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"There is no option number {optionChoose}!");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("It most be a number!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There is no hall number {Hallchoose}!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("It most be a number!");
                }
            }


        }



        // Movie control
        public void CreateMovie()
        {
            Console.WriteLine("What is the name of the movie: ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the movie about: ");
            string info = Console.ReadLine();
            Console.WriteLine("From with year: ");
            string year = Console.ReadLine();
            Console.WriteLine("What is the genre: ");
            string genger = Console.ReadLine();
            Console.WriteLine("Who is the actor: ");
            string Actor = Console.ReadLine();
            Console.WriteLine("What is the duration");
            string Duration = Console.ReadLine();
            Console.WriteLine("What is the trailer link");
            string Link = Console.ReadLine();

            this.MovieList.Add(new Movie(name, info, year, new string[] { genger }, Actor, Duration,Link));
            Console.WriteLine("Done...");
        }
        public void CreateUpcomingMovie()
        {
            Console.WriteLine("What is the name of the movie: ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the movie about: ");
            string info = Console.ReadLine();
            Console.WriteLine("From with year: ");
            string year = Console.ReadLine();
            Console.WriteLine("What is the genre: ");
            string genger = Console.ReadLine();
            Console.WriteLine("Who is the actor: ");
            string Actor = Console.ReadLine();
            Console.WriteLine("What is the duration");
            string Duration = Console.ReadLine();
            Console.WriteLine("What is the trailer link");
            string Link = Console.ReadLine();

            this.UpcomingMovieList.Add(new Movie(name, info, year, new string[] { genger }, Actor, Duration,Link));
            Console.WriteLine("Done...");
        }

        public void EditMovie()
        {
            int count = 0;
            foreach (Movie i in this.MovieList)
            {
                Console.WriteLine($"[{count}] {i.Name}");
                count++;
            }
            Console.WriteLine("Which Movie would you like to edit?\n");
            int answer;
            answer = 0;
            bool check = false;
            while (!check)
            {

                try
                {

                    answer = int.Parse(Console.ReadLine());
                    if (answer.GetType() == typeof(int))
                    {
                        check = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, Input invalid. Try again");

                }
            }





            while (answer > count - 1 || answer < 0)
            {
                Console.WriteLine("Movie not found, try again.\n");
                answer = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("What would you like to edit?\n[0] Name\n[1] Info\n[2] Duration\n[3] Release Year\n[4] Actors\n[5] Link\n");
            bool check2 = false;
            int answer2;
            answer2 = 0;
            while (!check2)
            {

                try
                {

                    answer2 = int.Parse(Console.ReadLine());
                    if (answer2.GetType() == typeof(int))
                    {
                        check2 = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, Input invalid. Try again");

                }
            }


            while (!(answer2 >= 0 && answer2 < 6))
            {
                Console.WriteLine("Field not found, try again.\n");
                answer2 = int.Parse(Console.ReadLine());
            }
            if (answer2 == 0)
            {
                Console.WriteLine("What would you like the new name to be?\n");
                this.MovieList[answer].Name = Console.ReadLine();
            }
            else if (answer2 == 1)
            {
                Console.WriteLine("What would you like the new info to be?\n");
                this.MovieList[answer].Info = Console.ReadLine();
            }
            else if (answer2 == 2)
            {
                Console.WriteLine("What would you like the new duration to be?\n");
                this.MovieList[answer].Duration = Console.ReadLine();
            }
            else if (answer2 == 3)
            {
                Console.WriteLine("What would you like the new release year to be?\n");
                this.MovieList[answer].Year = Console.ReadLine();
            }
            else if (answer2 == 4)
            {
                Console.WriteLine("Who would you like the new actor(s) to be?\n");
                this.MovieList[answer].Actors = Console.ReadLine();
            }
            else if (answer2 == 5)
            {
                Console.WriteLine("Enter the new trailer link. Please be carefull when changing the link as entering a invalid link may result in an error!\n");
                this.MovieList[answer].Link = Console.ReadLine();
            }
            Console.WriteLine("Movie updated! Press enter to do more editing or any other key to go back to the main screen.\n");
            string a = Console.ReadLine();
            if (a == "")
            {
                EditMovie();
            }

        }
    
        public void ShowMovies()
        {
            foreach (var movie in this.MovieList)
            {
                Console.WriteLine(movie.Name);
            }
        }
    }
}
