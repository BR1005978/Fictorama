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
            for (int i = 0; i < movielist.Count; i++)
            {
                if (search == movielist[i].Name.ToLower() || search == movielist[i].Year)
                {
                    results.Add(movielist[i]);
                }
            }
            Console.WriteLine("Search Results: ");
            foreach (Movie i in results)
            {


                Console.WriteLine($"Movie name: \n {i.Name}\n");
                Console.WriteLine($"Year of origin: \n {i.Year}\n");
                Console.WriteLine($"Movie information: \n {i.Info}\n");
            }
            Console.WriteLine("Press any key to continue... ");
            string cont = Console.ReadLine();
            MainProgram.MainMenu();
        }
    }
}
