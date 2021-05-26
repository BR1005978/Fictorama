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
            commands.Add("stats", "Opens the menu for Fictorama statistics.");
            commands.Add("Movie", "To see the movie based options.");
            commands.Add("Cinemahall", "To see the cinemahall based options.");
            commands.Add("Account", "To see the account based options.");
            commands.Add("Catering", "To edit the catering.");
            commands.Add("exit", "Exits the admin panel.");


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


                    if (answer == "Movie")
                    {
                        while (answer != "back")
                        {
                            Console.WriteLine("\n[Movie]\n");
                            Console.WriteLine("Type \"help\" to see available commands.\n");
                            answer = Console.ReadLine();
                            Console.WriteLine();

                            if (answer == "help")
                            {
                                Console.WriteLine("addmovie, Adds a movie to the list of movies.\n" +
                                    "addupcomingmovie, Adds upcoming movie to the list of movies.\n" +
                                    "editmovie, Edits a existing movie.\n" +
                                    "editreview", "Edit a review left by a customer.\n" +
                                    "back, To go back to the admin screen");
                            }


                            else if (answer == "addmovie")
                            {

                                var Json = new JsonAdd("CinemaAssets.json");
                                var CinemaData = Json.LoadFromJson();
                                CinemaData.CreateMovie();
                                Json.SaveToJson(CinemaData);
                                AdminMenu();
                            }

                            else if (answer == "addupcomingmovie")
                            {

                                var Json = new JsonAdd("CinemaAssets.json");
                                var CinemaData = Json.LoadFromJson();
                                CinemaData.CreateUpcomingMovie();
                                Json.SaveToJson(CinemaData);
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
                            else
                            { Console.WriteLine("Invalid command: " + answer); }

                        }

                    }

                    else if (answer == "Cinemahall")
                    {
                        while (answer != "back")
                        {



                            Console.WriteLine("\n[Cinemahall]\n");
                            Console.WriteLine("Type \"help\" to see available commands.\n");
                            answer = Console.ReadLine();
                            Console.WriteLine();

                            if (answer == "help")
                            {
                                Console.WriteLine("addhall, To add a cinema hall.\n" +
                                    "edithall, To edit a cinema hall.\n" +
                                    "back, To go back to the admin screen");
                            }

                            else if (answer == "addhall")
                            {
                                var Json = new JsonAdd("CinemaAssets.json");
                                var CinemaData = Json.LoadFromJson();
                                CinemaData.CreateCinemaHall();
                                Json.SaveToJson(CinemaData);
                                Console.Clear();
                                AdminMenu();
                            }
                            else if (answer == "edithall")
                            {
                                var Json = new JsonAdd("CinemaAssets.json");
                                var CinemaData = Json.LoadFromJson();
                                CinemaData.EditCinemaHall();
                                Json.SaveToJson(CinemaData);
                                Console.Clear();
                                AdminMenu();
                            }
                        }
                    }

                    else if (answer == "Account")
                    {
                        while (answer != "back")
                        {

 
                            Console.WriteLine("\n[Account]\n");
                            Console.WriteLine("Type \"help\" to see available commands.\n");
                            answer = Console.ReadLine();
                            Console.WriteLine();

                            if (answer == "help")
                            {
                                Console.WriteLine("editaccount, Edit a customer account or an employee account.\n" +
                                    "createworker, Create a new worker account\n" +
                                    "back, To go back to the admin screen");
                            }

                            else if (answer == "editaccount")
                            {

                                // verandert het wachtwoord van een klant 
                                Employee.change_password();
                                Console.Clear();
                                AdminMenu();
                            }

                            else if (answer == "createworker")
                            {
                                Mail mailSystem = new Mail();

                                Console.WriteLine("You picked \"createworker\" \n");
                                Console.WriteLine("What is the employee's first name?");
                                string fist_name = Console.ReadLine();
                                Console.WriteLine("What is the employee's last name?");
                                string last_name = Console.ReadLine();
                                Console.WriteLine("What is the employee's date of birth?(00-00-2021)");
                                string dateOfBirth = Console.ReadLine();


                                bool isActic = false;
                                bool status = false;
                                string email = "";

                                while (!isActic)
                                {
                                    Console.WriteLine("What is the employee's email?");
                                    email = Console.ReadLine();
                                    status = mailSystem.controlEmail(email);

                                    if (status || (Console.ReadLine() == "pass"))
                                    {
                                        isActic = true;
                                    }

                                }

                                Console.WriteLine("What is the employee's phone number?");
                                string phone = Console.ReadLine();
                                Console.WriteLine("what will be the employee's username?");
                                string username = Console.ReadLine();
                                Console.WriteLine("What will be the employee's password?");
                                string password1 = Console.ReadLine();
                                var x = EncrpytPassword.Encryptpassword(password1);
                                Tuple<string, int> password = x;


                                var UserJson = new JsonAdd("Users.json");
                                var UserData = UserJson.LoadFromJson2();
                                UserData.employeelist.Add(new Employee(fist_name, last_name, dateOfBirth, email, phone, username, password));
                                UserJson.SaveToJsonUser(UserData);
                                Console.Clear();
                            }
                        }
                    }

                    else if (answer == "stats")
                    {
                        Console.WriteLine($"You've selected {answer}, but I don't know how to do that yet. Please check back later.");
                        Console.Clear();
                        AdminMenu();
                    }
                    else if (answer == "exit")
                    {
                        Console.WriteLine("Returning to main menu ...\n");
                        Console.ResetColor();
                        Console.Clear();
                        MainProgram.MainMenu();

                    }
                    else if (answer == "Catering")
                    {
                        var CateringJson = new JsonAdd("Catering.json");
                        Catering catering = CateringJson.LoadFromJsoncatering();
                        catering.EditCatering();
                        CateringJson.SaveToJsonCatering(catering);
                        AdminMenu();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid command: " + answer);
                        Console.Clear();
                    }
                }
            }
            AdminMenu();
        }
    }
}