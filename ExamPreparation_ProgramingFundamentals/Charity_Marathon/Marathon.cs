using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Marathon
{
    public class Marathon
    {
        public static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            int lapsPerRunner = int.Parse(Console.ReadLine());
            long lapLenght = long.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            trackCapacity = trackCapacity * days;

            runners = Math.Min(trackCapacity, runners);

            long totalMeters = runners * lapLenght * lapsPerRunner;
            long totalKm = totalMeters / 1000;
            double totalMoney = totalKm * moneyPerKm;

            Console.WriteLine($"Money raised: {totalMoney:F2}");


        }
    }
}
