using System;
namespace cinema_app
{
    public class Statics
    {
       public  string CurrentStatic(DateTime curretDate)
        {
            var UserJson = new JsonAdd("Users.json");
            var UserData = UserJson.LoadFromJson2();

            string curentStatic = curretDate.Date.ToString() + "Day static\n";
            double totalrevenu = 0.0;
            int totalcosumer = 0;


            foreach (var cos in UserData.userlist)
            {
                foreach (var reservation in cos.reservations)
                {
                    if (reservation.Date == curretDate)
                    {
                        totalcosumer += 1;
                        totalrevenu += reservation.Price;

                    }
                }
            }

            curentStatic += $"There were {totalcosumer} people\n" +
                $"Total revenu was {totalrevenu} euro\n";

            return curentStatic;
        }

       public  string Revenu(Func<DateTime,string> func, int day)
        {
            string message = $"The revenu for {day} days.\n";

            for (int i = 0; i < day; i++)
            {
                message += CurrentStatic(DateTime.Now.AddDays(i - day).Date);
                
            }

            return message;
        }


        public void SeeRevenu()
        {
            Console.WriteLine("[Stats]\n" +
            "\n1: for day\n" +
            "2: for week\n" +
            "3: for month\n");

            string op = Console.ReadLine();

            if (op == "1")
            {
                Console.WriteLine(Revenu(CurrentStatic, 1));
            }

            else if (op == "2")
            {

                Console.WriteLine(Revenu(CurrentStatic, 7));
            }

            else if (op == "3")
            {
                Console.WriteLine(Revenu(CurrentStatic, 30));
            }
        }
    }


}
