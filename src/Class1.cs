using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace kata_09_checkout
{
    internal class Offer
    {
        public int Threashold { get; set; }
        public decimal Cost { get; set; }
    }

    public class Checkout : ICheckout
    {

        private Dictionary<string, decimal> _prices;
        private Dictionary<string, Offer> _offers;

        private List<string> _basket;

        public Checkout()
        {
            _prices = new Dictionary<string, decimal> {
                    {"A",     50},
                    {"B",     30},
                    {"C",     20},
                    {"D",     15}};

            _offers = new Dictionary<string, Offer>{
                    {"A", new Offer { Threashold = 3, Cost = 130m} },
                    {"B", new Offer {  Threashold = 2, Cost = 45m}} };

            _basket = new List<string>();

        }

        public int ItemsCount()
        {
            return _basket.Count;
        }

        public void Scan(string item)
        {
            _basket.Add(item);
        }

        public decimal TotalCost()
        {
            decimal basketTotal = 0m;
            foreach (var item in _basket)
            {
                basketTotal += _prices[item];
            }

            return basketTotal;
        }
    }

    public interface ICheckout
    {
        decimal TotalCost();

        void Scan(string item);

        int ItemsCount();
    }
}
