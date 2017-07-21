
namespace ObjectsAndSimpleClasses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    public class SimpleClasses
    {
        public static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //SimpleTime();
            //RandomNumbers();

            Console.WriteLine();
        }

        private static void RandomNumbers()
        {
            var randomGenerator = new Random();  //always use one random in the entire app

            Console.WriteLine(randomGenerator.Next(1, 50));    // generate 6/49 lotto nums
            Console.WriteLine(randomGenerator.Next(1, 50));
            Console.WriteLine(randomGenerator.Next(1, 50));
            Console.WriteLine(randomGenerator.Next(1, 50));
            Console.WriteLine(randomGenerator.Next(1, 50));
            Console.WriteLine(randomGenerator.Next(1, 50));

            Console.WriteLine("== Or ==");
            for (int i = 0; i <= 6; i++)
            {
                Console.WriteLine(randomGenerator.Next(1, 50));
            }

        }

        private static void SimpleTime()
        {
            var someDate = new DateTime(1989, 10, 23);
            var anotherDate = new DateTime(2017, 6, 21);
            var date = DateTime.Now;

            var result = someDate.AddDays(6); 

            TimeSpan diff = anotherDate - someDate;
            TimeSpan diff1 = DateTime.Today - someDate;

            Console.WriteLine(diff.TotalDays);
            Console.WriteLine(result.Day);
            Console.WriteLine(date.ToString("dd!MM!yyyy")); // format the way you want
            Console.WriteLine("{0:dd-MM-yyyy}", date);
        }
    }
}