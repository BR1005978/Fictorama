using System;
using System.Collections.Generic;
using static cinema_app.MainProgram;


namespace cinema_app
{
    public class Employee : User
    {

        public Employee(string First_name,
            string Last_name,
            string Date_of_birth,
            string Email,
            string Phone_number,
            string Username,
            string Password) :
            base(First_name, 
                Last_name, 
                Date_of_birth, 
                Email, Phone_number, 
                Username, 
                Password){ }


        public static new void panel()
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Console.Writeline("Welcome, {this.Username}");
            Dictionary<string, string> commands = new Dictionary<string, string>();
            commands.Add("help", "Displays a list of available commands.");
            commands.Add("editaccount", "Edit a customer account or an employee account.");
            commands.Add("editreview", "Edit a review left by a customer.");
            commands.Add("exit", "Exits the admin panel.");
            Console.WriteLine("[[EMPLOYEE PANEL]]");
            void EmployeeMenu()
            {
                List<string> options = new List<string> { "help", "addmovie", "editaccount", "editreview", };
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
                        EmployeeMenu();

                    }
                    else if (answer == "editaccount")
                    {

                       
                        //EmployeeMenu();
                        change_password();
                        EmployeeMenu();


                    }
                    else if (answer == "editreview")
                    {
                        Console.WriteLine($"You've selected {answer}, but I don't know how to do that yet. Please check back later.");
                        EmployeeMenu();
                    }
                    else if (answer == "exit")
                    {
                        Console.WriteLine("Returning to main menu ...\n");
                        Console.ResetColor();
                        MainProgram.MainMenu();

                    }
                    else
                    { Console.WriteLine("Invalid command: " + answer); }
                }
            }
            EmployeeMenu();
        }
        public static void change_password()
        {
            Console.WriteLine("You have selected the function: change password of costumer ");
            var UserJson = new JsonAdd("Users.json");
            var UserData = UserJson.LoadFromJson2();
            Console.WriteLine("What is the user name or full name of the custumer?");
            string costumer_name = Console.ReadLine();
            int index_user = 0;
            bool user_found = false;
            for(int i = 0; i < UserData.userlist.Count; i++)
            {
                if(costumer_name == UserData.userlist[i].userName || costumer_name.ToLower() == $"{UserData.userlist[i].first_name.ToLower()} { UserData.userlist[i].last_name.ToLower()}")
                {
                    index_user = i;
                    user_found = true;
                }
            }
            if (user_found)
            {
                Console.WriteLine("What will be the new password for {0} {1}?", UserData.userlist[index_user].first_name, UserData.userlist[index_user].last_name);
                UserData.userlist[index_user].password = Console.ReadLine();
                UserJson.SaveToJsonUser(UserData);
            }
            else
            {
                Console.WriteLine("This user doesn't exist");
                Console.WriteLine("Try again");
                change_password();
            }
        }
        
    }
    
}