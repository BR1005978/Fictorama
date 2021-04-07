using System;
namespace cinema_app
{
    public class Seats
    {

        private double Price;
        public bool Status = true;

        public Seats(double price)
        {
            this.Price = price;
        }


        public void Change_price(double new_price)
        {
            this.Price = new_price;
        }


        public double Get_price()
        {
            return Price;
        }

        public bool Change_status()
        {
            if (this.Status)
            {
                this.Status = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string get_status()
        {
            if (this.Status)
            {
                return " 0 ";
            }
            else
            {
                return " X ";
            }
        }


    }
}
