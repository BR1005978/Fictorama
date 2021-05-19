using System;
using System.Collections.Generic;
namespace cinema_app
{
    public class Costumer
    {
        public static void costumer()
        {
            List<string> options = new List<string> { "1", "2", "3", "4" };
            string answer = "";

            while (!options.Contains(answer))
            {
                Console.WriteLine("\nPlease choose what you want to do (type the numbers): \n" +
                "1. See available movies\n" +
                "2. Edit reviews\n" +
                "3. Search movies\n" +
                "4. Log out\n");
                answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.WriteLine("\n You picked: 1. See available movies\n\n");
                    MovieBrowser.MovieBrowserMenu();
                    costumer();
                }
                else if(answer == "2")
                {
                    Console.WriteLine("\n You picked: 2. Edit reviews\n\n");
                    AddReview.editReview();
                }
                else if(answer == "3")
                {
                    Console.WriteLine("\n You picked: 3. Search movie\n\n");
                    var Json = new JsonAdd("CinemaAssets.json");
                    var CinemaData = Json.LoadFromJson();
                    SearchFunction.Searchbar(CinemaData.MovieList);
                }
                else if (answer == "4")
                {
                    Console.WriteLine("\n You picked: 4. Log out\n\n");
                    MainProgram.onlineUser = null;
                    MainProgram.MainMenu();
                }
            }
        }
        
        
    }
}
