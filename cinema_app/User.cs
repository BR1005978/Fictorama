using System;
namespace cinema_app
{
    
    
        public class User
        {
            public string first_name;
            public string last_name;
            public string date_of_birth;
            public string email;
            public string phone_number;
            public string userName;
            public string password;
            
        public User(string First_name, string Last_name, string Date_of_birth, string Email, string Phone_number, string Username, string Password )
        {
            this.first_name = First_name;
            this.last_name = Last_name;
            this.date_of_birth = Date_of_birth;
            this.email = Email;
            this.phone_number = Phone_number;
            this.userName = Username;
            this.password = Password;
            
        }


            public void introduce()
            {
                Console.WriteLine("welcome {0}", userName);
            }

            
        }
    }
