using System;
using System.Collections.Generic;
namespace cinema_app

{
    public class Signin
    {
        public static void SigninScreen()
        {
            Mail mailSystem = new Mail();

            Console.WriteLine("You picked \"4. Signin\" \n");
            Console.WriteLine("What is your first name?");
            string fist_name = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            string last_name = Console.ReadLine();
            Console.WriteLine("What is your date of birth?(00-00-2021)");
            string dateOfBirth = Console.ReadLine();


            bool isActic = false;
            bool status = false;
            string email = "";

            while (!isActic)
            {
                Console.WriteLine("What is your email?");
                email = Console.ReadLine();
                status = mailSystem.controlEmail(email);
                
                if (status)
                {
                    isActic = true;
                }

            }

            Console.WriteLine("What is your phone number?");
            string phone = Console.ReadLine();
            Console.WriteLine("what will be your username?");
            string username = Console.ReadLine();
            Console.WriteLine("What will be your password?");
            string password1 = Console.ReadLine();
            var x = EncrpytPassword.Encryptpassword(password1);
            Tuple<string, int> password = x;


            var UserJson = new JsonAdd("Users.json");
            var UserData = UserJson.LoadFromJson2();
            UserData.userlist.Add(new User(fist_name, last_name, dateOfBirth, email, phone, username, password));
            UserJson.SaveToJsonUser(UserData);
            
            MainProgram.MainMenu();
        }
    }
}
