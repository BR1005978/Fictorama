﻿using System;
using System.Collections.Generic;
using static cinema_app.MainProgram;


namespace cinema_app
{
    class Employee
    {
        public static void EmployeePanel()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Dictionary<string, string> commands = new Dictionary<string, string>();
            commands.Add("help", "Displays a list of available commands.");
            commands.Add("editaccount", "Edit a customer account or an employee account.");
            commands.Add("editreview", "Edit a review left by a customer.");
            commands.Add("exit", "Exits the admin panel.");
            print("[[EMPLOYEE PANEL]]");
            void EmployeeMenu()
            {
                List<string> options = new List<string> { "help", "addmovie", "editaccount", "editreview", };
                string answer = "";
                while (!options.Contains(answer))
                {

                    print("\nType \"help\" to see available commands.\n");
                    answer = Console.ReadLine();


                    if (answer == "help")
                    {

                        foreach (KeyValuePair<string, string> command in commands)
                        {
                            print($"{command.Key} : {command.Value}");
                        }
                        EmployeeMenu();

                    }
                    else if (answer == "editaccount")
                    {

                        print($"You've selected {answer}, but I don't know how to do that yet. Please check back later.");
                        EmployeeMenu();
                    }
                    else if (answer == "editreview")
                    {
                        print($"You've selected {answer}, but I don't know how to do that yet. Please check back later.");
                        EmployeeMenu();
                    }
                    else if (answer == "exit")
                    {
                        print("Returning to main menu ...\n");
                        Console.ResetColor();
                        MainProgram.MainMenu();

                    }
                    else
                    { Console.WriteLine("Invalid command: " + answer); }
                }
            }
            EmployeeMenu();
        }
    }
}