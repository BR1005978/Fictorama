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
            Userlist.getUserlist();
            string username = "";
            string password = "";

            Console.WriteLine("Please enter username: ");
            username = Console.ReadLine();

            Console.WriteLine("Please enter password");
            password = Console.ReadLine();

            // primitieve typecheck
            if (username == "admin" && password == "admin")
            {
                Admin.AdminPanel();
            }
            else if (username == "employee" && password == "employee")
            {
                Employee.EmployeePanel();
            }
            else if (username == "customer" && password == "customer")
            {
                
            }


        }
    }
}
