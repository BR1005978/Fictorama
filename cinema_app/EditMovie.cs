using System;
using System.Collections.Generic;
using System.Text;

namespace cinema_app
{
    class EditMovie
    {
        public static void MovieEditor() {
            int count = 0;
            foreach (Movie i in MovieList.movielist) {
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





            while (answer > count-1 || answer<0) {
                Console.WriteLine("Movie not found, try again.\n");
                answer = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("What would you like to edit?\n[0] Name\n[1] Info\n[2] Duration\n[3] Release Year\n[4] Actors\n");
            bool check2 = false;
            int answer2;
            answer2 = 0;
            while (!check2) {

                try
                {
                    
                    answer2 = int.Parse(Console.ReadLine());
                    if (answer2.GetType() == typeof(int)) {
                        check2 = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, Input invalid. Try again");
                    
                }  
                }
                     
            
            while (!(answer2 >=0 && answer2 < 5))
            {
                Console.WriteLine("Field not found, try again.\n");
                answer2 = int.Parse(Console.ReadLine());
            }
            if (answer2 == 0) {
                Console.WriteLine("What would you like the new name to be?\n");
                MovieList.movielist[answer].Name = Console.ReadLine();
            }
            else if (answer2 == 1)
            {
                Console.WriteLine("What would you like the new info to be?\n");
                MovieList.movielist[answer].Info = Console.ReadLine();
            }
            else if (answer2 == 2)
            {
                Console.WriteLine("What would you like the new duration to be?\n");
                MovieList.movielist[answer].Duration = Console.ReadLine();
            }
            else if (answer2 == 3)
            {
                Console.WriteLine("What would you like the new release year to be?\n");
                MovieList.movielist[answer].Year = Console.ReadLine();
            }
            else if (answer2 == 4)
            {
                Console.WriteLine("Who would you like the new actor(s) to be?\n");
                MovieList.movielist[answer].Actors = Console.ReadLine();
            }
            Console.WriteLine("Movie updated! Press enter to do more editing or any other key to go back to the main screen.\n");
            string a =Console.ReadLine();
            if (a == "")
            {
                MovieEditor();
            }

        }
    }
}
