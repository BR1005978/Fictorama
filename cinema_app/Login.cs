using System;
using System.Collections.Generic;
using System.Text;

namespace cinema_app
{
    public class Login
    {
        public static void LoginScreen()
        {
            Console.WriteLine("You picked \"2. Login\" \n");

            string username = "";
            string password = "";

            Console.WriteLine("Please enter username: ");
            username = Console.ReadLine();

            Console.WriteLine("\nPlease enter password");
            password = Console.ReadLine();

            // primitieve typecheck
            if (username == "admin" && password == "admin")
            {
                Admin.AdminPanel();
            }
            else if (username == "employee" && password == "employee")
            {
                MainProgram.onlineEmployee = 1;
                Employee.panel();
            }
            else
            {
                var UserJson = new JsonAdd("Users.json");
                var UserData = UserJson.LoadFromJson2();
                for (int i = 0; i < UserData.userlist.Count; i++)
                {


                    if (UserData.userlist[i].userName == username && UserData.userlist[i].password.Item1 == EncrpytPassword.Encryptpassword(password, UserData.userlist[i].password.Item2).Item1)
                    {

                        Console.WriteLine("login succes");
                        Console.WriteLine($"welcome {UserData.userlist[i].userName}");
                        MainProgram.onlineUser = UserData.userlist[i];
                        User.panel();

                    }
                    
                }
                for (int i = 0; i < UserData.employeelist.Count; i++)
                {
                     if (UserData.employeelist[i].userName == username && UserData.employeelist[i].password.Item1 == EncrpytPassword.Encryptpassword(password, UserData.employeelist[i].password.Item2).Item1)
                    {
                        Console.WriteLine("login succes");
                        Console.WriteLine($"welcome {UserData.employeelist[i].userName}");
                        MainProgram.onlineUser = UserData.employeelist[i];
                        Employee.panel();

                    }

                }



                Console.WriteLine("\nUsername or password is wrong!\n");
                List<string> options = new List<string> { "1", "2" };
                string answer = "";

                while (!options.Contains(answer))
                {

                    Console.WriteLine("\nPlease choose what you want to do (type the numbers): \n" +
                    "1. Try again\n" +
                    "2. Go back to the home screen\n");

                    answer = Console.ReadLine();
                }
                if (answer == "1")
                {
                    LoginScreen();
                }
                else if (answer == "2")
                {
                    MainProgram.MainMenu();
                }


            }
        }
    }


}
