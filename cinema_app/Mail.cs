using System;
using System.Net.Mail;
using System.Net;

namespace cinema_app
{
    public class Mail
    {

        public SmtpClient mailClient = new SmtpClient("smtp-mail.outlook.com", 587);

        


        public Mail()
        {
            this.mailClient.EnableSsl = true;
            this.mailClient.Credentials = new NetworkCredential("fictorama@outlook.com", "Ficto2021"); 
        }

        public bool controlEmail(string email)
        {
            try
            {
                System.Random ramdom = new System.Random();
                int controlNumber = ramdom.Next(10000, 99999);


                this.mailClient.Send("fictorama@outlook.com", email, "Fictorama registration code", $"Hi there, \n\nThank you for joining the Fictorama family.\nPlease type this code in the system: {controlNumber}");
                Console.WriteLine("Please type the code we sent to your mail");

                try
                {
                    int userCode = System.Convert.ToInt32(Console.ReadLine());
                    if (controlNumber == userCode)
                    {
                        Console.WriteLine("Email activation is succesfull");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("The code is wrong!");
                        return false;

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("The code is wrong!");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail does not exists!");
                return false;
            }
        }
        public void Changepassword(string email)
        {
            try
            {
                System.Random ramdom = new System.Random();
                int controlNumber = ramdom.Next(10000, 99999);


                this.mailClient.Send("fictorama@outlook.com", email, "Fictorama password reset code", $"Hi there, \n\nHere is your request for a password reset, if this wasn't you please ignore this email.\nPlease type this code in the system: {controlNumber}");
                Console.WriteLine("Please type the code we sent to your mail");

                try
                {
                    int userCode = System.Convert.ToInt32(Console.ReadLine());
                    if (controlNumber == userCode)
                    {
                        Console.WriteLine("Email verification  is succesfull\n");
                        Console.WriteLine("Please enter your new password\n");
                        var UserJson = new JsonAdd("Users.json");
                        var UserData = UserJson.LoadFromJson2();
                        string newpass = Console.ReadLine();
                        int index_user = 0;
                        bool user_found = false;
                        for (int i = 0; i < UserData.userlist.Count; i++)
                        {
                            if (email == UserData.userlist[i].email )
                            {
                                index_user = i;
                                user_found = true;
                            }
                        }
                        if (user_found)
                        {
                            
                            
                            var x = EncrpytPassword.Encryptpassword(newpass);

                            UserData.userlist[index_user].password = x;
                            UserJson.SaveToJsonUser(UserData);
                        }


                        User.panel();
                    }
                    else
                    {
                        Console.WriteLine("The code is wrong!");
                        

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("The code is wrong!");
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail does not exists!");
                
            }
        }
        public void SendEmail(string email, string name, double price, string zaal, string movie, string datum, int hour, int minute, Tuple<int,int>[] seats, Tuple<string,string,string>[] food, string code)
        {
            string seatsString = "";
            string menus = "";

            if (food == null)
            {
                menus = "There are no menu's added.";
            }
            else
            {
                foreach (var menu in food)
                {
                    menus += menu.Item1 +  ", " + menu.Item2 +", "+ menu.Item3 + "\n ";
                }
            }

            foreach (var seat in seats)
            {
                seatsString += "Row " + seat.Item1 +" Seat "+ seat.Item2 + ", ";
            }

            this.mailClient.Send("fictorama@outlook.com", email, "Movie Reservation",$"Hi {name}, \n\n" +
                $"Thank you for your reservation to {movie}. \n" +
                $"The movie will be begin at {datum} on {hour}:{minute}.\n" +
                $"Your expected be seated at {seatsString}{zaal}." +
                $"\n\nYour combie menus are:\n{menus}\n" +
                $"The Total price is {price} euro, and your code is {code}.\n\n" +
                $"Thank your for choosing Fictroma.");

        }
    }
}

