/*
 * Program to calculate the best fit returning change money
 * 
 * Developer: Jose Ramos B.
 * Date: 12-02-2022
 */

using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

namespace proPOSCashier
{
    sealed class RemainingMoney
    {
        private Dictionary<decimal, int> dicChange = new Dictionary<decimal, int> { };
        private string Country = string.Empty;

        private static readonly Dictionary<decimal, int> ChangeUS = new Dictionary<decimal, int>
        {
            { 0.01m, 0 },
            { 0.05m, 0 },
            { 0.10m, 0 },
            { 0.25m, 0 },
            { 0.50m, 0 },
            { 1.00m, 0 },
            { 2.00m, 0 },
            { 5.00m, 0 },
            { 10.00m, 0 },
            { 20.00m, 0 },
            { 50.00m, 0 },
            { 100.00m, 0 }
        };

        private static readonly Dictionary<decimal, int> ChangeMX = new Dictionary<decimal, int>
        {
            { 0.05m, 0 },
            { 0.10m, 0 },
            { 0.20m, 0 },
            { 0.50m, 0 },
            { 1.00m, 0 },
            { 2.00m, 0 },
            { 5.00m, 0 },
            { 10.00m, 0 },
            { 20.00m, 0 },
            { 50.00m, 0 },
            { 100.00m, 0 }
        };

        public RemainingMoney(string country)
        {
            Country = country;
            resetValues();
        }

        private void resetValues()
        {
            dicChange = (Country.Equals("MX")) ? ChangeMX : ChangeUS;
            
            List<decimal> lsChange = new List<decimal>(dicChange.Keys);
            foreach (decimal key in lsChange)
            {
                dicChange[key] = 0;
            }
        }
        public void Change(decimal price, decimal[] payment)
        {
            string msg = string.Empty;
            decimal sum = 0, change = 0, actualValue = 0;

            resetValues();
            Array.ForEach(payment, i => sum += i);

            Console.WriteLine("\n\n------------------- STARTING -------------------");
            Console.WriteLine("price: " + price + ", pay: " + sum);

            if (price > sum)
            {
                Console.WriteLine("Not enough money to pay the price");
            }
            else
            {
                change = sum - price;
                Console.WriteLine("change: " + change);

                List<decimal> lsChange = new List<decimal>(dicChange.Keys);

                for (int i = lsChange.Count - 1; i >= 0; i--)
                {
                    actualValue = lsChange[i];
                    
                    while (change >= actualValue)
                    {
                        dicChange[actualValue]++;
                        change -= actualValue;
                    }
                }
                Console.WriteLine("==================== YOUR CHANGE ====================");
                foreach (KeyValuePair<decimal, int> item in dicChange)
                {
                    if (item.Value > 0)
                    {
                        Console.WriteLine("Money: " + item.Key + ", Qty: " + item.Value);
                    }
                }
            }
        }
    }
}