using System;
using System.Collections.Generic;
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
            public Tuple<string ,int> password;
            public List<Reservation> reservations;
            
        public User(string First_name, string Last_name, string Date_of_birth, string Email, string Phone_number, string Username, Tuple<string, int> Password )
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

            public void PastReservation()
            {
                foreach (var reservation in this.reservations)
                {
                    Console.WriteLine(reservation.BasicInformation());
                }
            }


            
        }
}
