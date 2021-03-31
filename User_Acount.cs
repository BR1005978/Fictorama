using System;

namespace sign_in
{
    class User
    {
        public string first_name;
        public string last_name;
        public string date_of_birth;
        public string email;
        public string phone_number;
        public string UserName;
        public string password;
        public string status;

        

        public void introduce()
        {
            Console.WriteLine("welcome {0}", UserName);
        }

        public static User Sign_in()
        {
            var user = new User();

            Console.WriteLine("What is your first name?");
            user.first_name = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            user.last_name = Console.ReadLine();

            Console.WriteLine("What is your date of birth? \n(example: 01-01-2000)");
            user.date_of_birth = Console.ReadLine();

            Console.WriteLine("What is your email?");
            user.email = Console.ReadLine();

            Console.WriteLine("What is your phone number?");
            user.phone_number = Console.ReadLine();

            Console.WriteLine("pleas enter a username: ");
            user.UserName = Console.ReadLine();

            Console.WriteLine("pleas enter a password: ");
            user.password = Console.ReadLine();

            //worker or admin or user
            user.status = "user";

            return user;
        }

        public static User login()
        {
            return null;
        }

    }


    class Program
    {
        static void Main()
        {
            var user = new User();  

            Console.WriteLine("1. signin\n2. login");
            string member = Console.ReadLine();
            if (member == "1")
            {
                user = User.Sign_in();
            }else if (member == "2")
            {
                //Person.login();
                //user.introduce();
                
            }

            Main();
            
        }
    }
}

  
