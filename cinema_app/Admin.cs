using System;
using System.Collections.Generic;
using static cinema_app.MainProgram;


namespace cinema_app
{
    class Admin
    {
        public static void AdminPanel()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Dictionary<string, string> commands = new Dictionary<string, string>();
            commands.Add("help", "Displays a list of available commands.");
            commands.Add("addmovie", "Adds a movie to the list of movies.");
            commands.Add("editaccount", "Edit a customer account or an employee account.");
            commands.Add("editmovie", "Edits a existing movie .");
            commands.Add("editreview", "Edit a review left by a customer.");
            commands.Add("stats", "Opens the menu for Fictorama statistics.");
            commands.Add("exit", "Exits the admin panel.");
            commands.Add("addhall", "To add a cinema hall.");
            commands.Add("edithall", "To edit a cinema hall.");
            
            Console.WriteLine("[[ADMIN PANEL]]");
            void AdminMenu()
            {
                List<string> options = new List<string> { "help", "addmovie", "editaccount", "editreview", "stats" };
                string answer = "";
                while (!options.Contains(answer))
                {

                    Console.WriteLine("\nType \"help\" to see available commands.\n");
                    answer = Console.ReadLine();


                    if (answer == "help")
                    {

                        foreach (KeyValuePair<string, string> command in commands)
                        {
                            Console.WriteLine($"{command.Key} : {command.Value}");
                        }
                        AdminMenu();

                    }
                    else if (answer == "addmovie")
                    {

                        var Json = new JsonAdd("CinemaAssets.json");
                        var CinemaData = Json.LoadFromJson();
                        CinemaData.CreateMovie();
                        Json.SaveToJson(CinemaData);
                        AdminMenu();
                    }
                    else if (answer == "editaccount")
                    {

                        
                        Employee.change_password();
                        AdminMenu();
                    }
                    else if (answer == "editreview")
                    {
                        Console.WriteLine($"You've selected {answer}, but I don't know how to do that yet. Please check back later.");
                        AdminMenu();
                    }
                    else if (answer == "editmovie")
                    {
                        Console.WriteLine($"You've selected {answer}.\n");
                        var Json = new JsonAdd("CinemaAssets.json");
                        var CinemaData = Json.LoadFromJson();
                        CinemaData.EditMovie();
                        Json.SaveToJson(CinemaData);
                        AdminMenu();
                    }
                    else if (answer == "stats")
                    {
                        Console.WriteLine($"You've selected {answer}, but I don't know how to do that yet. Please check back later.");
                        AdminMenu();
                    }
                    else if (answer == "exit")
                    {
                        Console.WriteLine("Returning to main menu ...\n");
                        Console.ResetColor();
                        MainProgram.MainMenu();

                    }
                    else if (answer == "addhall")
                    {
                        var Json = new JsonAdd("CinemaAssets.json");
                        var CinemaData = Json.LoadFromJson();
                        CinemaData.CreateCinemaHall();
                        Json.SaveToJson(CinemaData);
                        AdminMenu();
                    }
                    else if (answer == "edithall")
                    {
                        var Json = new JsonAdd("CinemaAssets.json");
                        var CinemaData = Json.LoadFromJson();
                        CinemaData.EditCinemaHall();
                        Json.SaveToJson(CinemaData);
                        AdminMenu();
                    }
                    else
                    { Console.WriteLine("Invalid command: " + answer); }
                }
            }
            AdminMenu();
        }
    }
}