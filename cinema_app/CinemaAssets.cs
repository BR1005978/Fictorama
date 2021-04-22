using System;
using System.Collections.Generic;
namespace cinema_app
{
    public class CinemaAssets
    {
        public List<CinemaHall> CinemaHallList = new List<CinemaHall>();
        public List<Movie> MovieList = new List<Movie>();




        // CinemaHall Control
        public void CreateCinemaHall()
        {
            Console.WriteLine("How many rows: ");
            int row = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many colums: ");
            int colum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the name of the hall");
            string name = Console.ReadLine();

            this.CinemaHallList.Add(new CinemaHall(row,colum,name));

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
                                        string newName =Console.ReadLine();

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
            Console.WriteLine("Ehat is the genre: ");
            string genger = Console.ReadLine();
            Console.WriteLine("Who is the actor: ");
            string Actor = Console.ReadLine();
            Console.WriteLine("What is the duration");
            string Duration = Console.ReadLine();

            this.MovieList.Add(new Movie(name,info,year,new string[] {genger },Actor,Duration));
            Console.WriteLine("Done");
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
