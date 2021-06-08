using System;
using System.Collections.Generic;

namespace cinema_app
{
    class SearchFunction
    {
        public static void Searchbar(List<Movie> movielist)
        {
            Console.WriteLine("\n\nWhat would you like to search for?: ");
            string search = (Console.ReadLine()).ToLower();
            List<Movie> results = new List<Movie>();
            int counter = 0;
            foreach (Movie i in results)
            {

                Console.WriteLine($"movie number = {counter}.\n");
                Console.WriteLine($"Movie name: \n {i.Name}\n");
                Console.WriteLine($"Year of origin: \n {i.Year}\n");
                Console.WriteLine($"Movie information: \n {i.Info}\n");
            }
            string choise = " ";
            while (!Reservation.isNumeric(choise) && choise != "")
            {
                Console.WriteLine("Type the number of the movie to make a reservation. Or type enter to go back");
                choise = Console.ReadLine();
                Console.WriteLine($"{choise.Length}");
            }
            if (Reservation.isNumeric(choise))
            {
                int movienum = Reservation.MakeNumber(choise);

                Reservation.reserveer(results[movienum]);
            }
            Console.WriteLine("Press any key to continue... ");
            string cont = Console.ReadLine();
            
            
        }
    }
}
