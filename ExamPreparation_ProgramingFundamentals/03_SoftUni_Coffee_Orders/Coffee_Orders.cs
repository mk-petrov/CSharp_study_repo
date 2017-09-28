using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _03_SoftUni_Coffee_Orders
{
    public class Coffee_Orders
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalPrice = 0M;    // D -double, F-float, M-decimal

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime
                    .ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int capsuleCount = int.Parse(Console.ReadLine());

                decimal currentPrice = ((DateTime.
                    DaysInMonth(orderDate.Year, orderDate.Month) * capsuleCount) * (long)pricePerCapsule);

                Console.WriteLine("The price for the coffee is: ${0:F2}", currentPrice);

                totalPrice += currentPrice;
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
