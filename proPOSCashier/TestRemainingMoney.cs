using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proPOSCashier
{
    internal class TestRemainingMoney
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------- MEXICAN PESOS ---------");
            RemainingMoney rm = new RemainingMoney("MX");
            rm.Change(8.25m, new decimal[] { 10.00m });
            rm.Change(491.05m, new decimal[] { 100.00m, 100.00m, 100.00m, 100.00m, 100.00m });
            rm.Change(99.01m, new decimal[] { 50.00m, 20.0m, 20.0m, 10.0m });
            Console.WriteLine("\n\n--------- AMERICAN DOLLARS ---------");
            rm = new RemainingMoney("US");
            rm.Change(350.00m, new decimal[] { 100.00m, 100.00m, 50.00m });
            rm.Change(49.01m, new decimal[] { 50.00m, 50.00m });
        }
    }
}
