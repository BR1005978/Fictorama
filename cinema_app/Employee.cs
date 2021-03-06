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
            Tuple<string, int> Password) :
            base(First_name,
                Last_name,
                Date_of_birth,
                Email, Phone_number,
                Username,
                Password)
        { }


        public static new void panel()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Console.Writeline("Welcome, {this.Username}");
            Dictionary<string, string> commands = new Dictionary<string, string>();
            commands.Add("help", "Displays a list of available commands.");
            commands.Add("editaccount", "Edit a customer account or an employee account.");
            commands.Add("editreview", "Edit a review left by a customer.");
            commands.Add("ownaccount", "Make your own reservation.");
            commands.Add("exit", "Logs out and exits the employee panel. ");
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
                        Console.WriteLine($"You've selected {answer}.\n");
                        AddReview.DelReview();
                        EmployeeMenu();
                    }
                    else if (answer == "ownaccount")
                    {
                        MovieBrowser.MovieBrowserMenu();
                    }
                    else if (answer == "exit")
                    {
                        Console.WriteLine("Returning to main menu ...\n");
                        Console.ResetColor();
                        MainProgram.onlineEmployee = false;
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
            Console.WriteLine("You have selected the function: change password of customer ");
            var UserJson = new JsonAdd("Users.json");
            var UserData = UserJson.LoadFromJson2();
            Console.WriteLine("What is the user name or full name of the customer? (type 'exit' to cancel)");
            string customer_name = Console.ReadLine();
            int index_user = 0;
            bool user_found = false;
            for (int i = 0; i < UserData.userlist.Count; i++)
            {
                if (customer_name == UserData.userlist[i].userName || customer_name.ToLower() == $"{UserData.userlist[i].first_name.ToLower()} { UserData.userlist[i].last_name.ToLower()}")
                {
                    index_user = i;
                    user_found = true;
                }
            }
            if (user_found)
            {
                Console.WriteLine("What will be the new password for {0} {1}?", UserData.userlist[index_user].first_name, UserData.userlist[index_user].last_name);
                var newPasword = Console.ReadLine();
                var x = EncrpytPassword.Encryptpassword(newPasword);
                
                UserData.userlist[index_user].password = x;
                UserJson.SaveToJsonUser(UserData);
            }
            else if (customer_name == "exit")
            {
                Console.WriteLine("Exiting...");
                panel();
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