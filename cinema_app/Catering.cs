using System;
using System.Collections.Generic;

namespace cinema_app
{
    public class Catering
    {
        public List<Tuple<string, double>> Drinks = new List<Tuple<string, double>>();
        public List<Tuple<string, double>> Snacks = new List<Tuple<string, double>>();
        public List<Tuple<string, double>> Food = new List<Tuple<string, double>>();



        public Catering()
        {
        }

        // Adding products for the admin 
        public void addDrinks()
        {
            Console.Clear();
            Console.WriteLine("[Adding drink item]\n");

            Console.WriteLine("What is the name of the drink: ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the price (0.00): ");
            double price = Convert.ToDouble(Console.ReadLine());

 

            this.Drinks.Add(Tuple.Create(name, price));
            Console.WriteLine("Done...");

        }
        public void ShowMenu() {
            List<string> options = new List<string> { "0", "1", "2" }; 
            Console.WriteLine("What would you like to see?\n[0] Drinks\n[1] Snacks\n[2] Food\n");
            string choice = "";
            while (!options.Contains(choice)) {
                choice = Console.ReadLine();
                if (choice=="0")
                {
                    foreach (Tuple<string, double> drink in Drinks) {
                        Console.WriteLine($"{drink.Item1}, ${drink.Item2}");
                    }
                    Console.WriteLine("\nPress enter to leave");
                    Console.ReadLine();
                    if (MainProgram.onlineUser!=null)
                    {
                        User.panel();
                    }
                    else
                    {
                        MainProgram.MainMenu();
                    }

                }
                if (choice == "1")
                {
                    foreach (Tuple<string, double> snack in Snacks)
                    {
                        Console.WriteLine($"{snack.Item1}, ${snack.Item2}");
                    }
                    Console.WriteLine("\nPress enter to leave");
                    Console.ReadLine();
                    if (MainProgram.onlineUser != null)
                    {
                        User.panel();
                    }
                    else
                    {
                        MainProgram.MainMenu();
                    }
                }
                if (choice == "2")
                {
                    foreach (Tuple<string, double> foods in Food)
                    {
                        Console.WriteLine($"{foods.Item1}, ${foods.Item2}");
                    }
                    Console.WriteLine("\nPress enter to leave");
                    Console.ReadLine();
                    if (MainProgram.onlineUser != null)
                    {
                        User.panel();
                    }
                    else
                    {
                        MainProgram.MainMenu();
                    }
                }
                else
                {
                    { Console.WriteLine("Your input was: " + choice + "\nInput not recognised. Please try again\n"); }
                }
            }
        }

        public void addSnack()
        {
            Console.Clear();
            Console.WriteLine("[Adding snack item]\n");

            Console.WriteLine("What is the name of the snack: ");
            string name = Console.ReadLine();

            Console.WriteLine("What is the price (0.00): ");
            double price = Convert.ToDouble(Console.ReadLine());

            this.Snacks.Add(Tuple.Create(name, price));
            Console.WriteLine("Done...");

        }

        public void addfood()
        {
            Console.Clear();
            Console.WriteLine("[Adding food item]\n");

            Console.WriteLine("What is the name of the food: ");
            string name = Console.ReadLine();

            Console.WriteLine("What is the price (0.00): ");
            double price = Convert.ToDouble(Console.ReadLine());

            this.Food.Add(Tuple.Create(name, price));
            Console.WriteLine("Done...");

        }

        // Creating a menu
        public Tuple<string,string,string> createMenu()
        {
            Console.Clear();
            Console.WriteLine("[Creating a combie menu]\n");
            Console.WriteLine("Type the number of the drink: ");

            for (int i = 0; i < this.Drinks.Count; i++ )
            {
                Console.WriteLine($"{i}: {this.Drinks[i].Item1}");

            }
            string drink = this.Drinks[Convert.ToInt32(Console.ReadLine())].Item1;

            Console.Clear();
            Console.WriteLine("[Creating a combie menu]\n");
            Console.WriteLine("Type the number of the food: ");
            for (int i = 0; i < this.Food.Count; i++)
            {
                Console.WriteLine($"{i}: {this.Food[i].Item1}");

            }
            string food = this.Food[Convert.ToInt32(Console.ReadLine())].Item1;

            Console.Clear();
            Console.WriteLine("[Creating a combie menu]\n");
            Console.WriteLine("Type the number of the snack: ");
            for (int i = 0; i < this.Snacks.Count; i++)
            {
                Console.WriteLine($"{i}: {this.Snacks[i].Item1}");

            }
            string snack = this.Snacks[Convert.ToInt32(Console.ReadLine())].Item1;



            return Tuple.Create(food, drink, snack);
        }

        public void EditCatering()
        {
            Console.Clear();
            Console.WriteLine("[Catering edit menu]\n");
            Console.WriteLine("0: For adding a drink" +
                "\n1: For adding a snack" +
                "\n2: For adding food" +
                "\n3: For exit");

            Console.WriteLine("Please type the number of the option: ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                this.addDrinks();
            }
            else if (input == "1")
            {
                this.addSnack();
            }
            else if (input == "2")
            {
                this.addfood();
            }
        }
    }
}
