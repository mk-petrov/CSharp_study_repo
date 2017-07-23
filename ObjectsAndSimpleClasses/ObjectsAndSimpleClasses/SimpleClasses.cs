
namespace ObjectsAndSimpleClasses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Diagnostics;
    using System.Numerics;

    public class SimpleClasses
    {
        public static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;


            //Every method represents a small problem

            
            //BigFactorial();
            //RandomizeWords();
            //DayOfWeekByDate();
            //ObjectExample();
            //SimpleTime();
            //RandomNumbers();

            Console.WriteLine();
        }

        private static void BigFactorial()
        {
            int factorialNum = int.Parse(Console.ReadLine());

            BigInteger result = 1;

            for (int i = factorialNum; i > 1; i--)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }

        private static void RandomizeWords()
        {            
            var inputLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var rnd = new Random();

            for (int i = 0; i < inputLine.Length; i++)
            {
                var randomIndex = rnd.Next(0, inputLine.Length);

                var temp = inputLine[i];
                inputLine[i] = inputLine[randomIndex];
                inputLine[randomIndex] = temp;
            }


            Console.WriteLine(string.Join(" ", inputLine));
            
        }

        private static void DayOfWeekByDate()
        {
            var dateAsString = Console.ReadLine();
            
            DateTime date = DateTime.ParseExact(dateAsString, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);

        }

        private static void ObjectExample()
        {
            var cat = new Cat();
            cat.Name = "Saimon";
            cat.Age = 2;
            

            if (cat.Age > 1)
            {
                cat.IsEaten = true;
            }

            Cat.Sleep();
            Console.WriteLine(cat.IsEaten);

            var secondCat = new Cat()
            {
                Name = "Kiro",
                Color = "white",
                Age = 3,
                IsEaten = true                
            };

            Console.WriteLine(cat.SayHi());
            Console.WriteLine(secondCat.SayHi());
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