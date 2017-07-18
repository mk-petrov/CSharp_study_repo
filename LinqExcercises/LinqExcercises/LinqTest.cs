
namespace LinqExcercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    public class LinqTest
    {
        public static void Main()
        {
            //Every method represents a small problem

            //MinMaxAverage();
            //LargestNNumbers();
            //ShortWordsSorted();
            //FoldAndSum();
            //RegisteredUsers();
            //DefaultValues();

            
            

            Console.WriteLine();
        }

        private static void DefaultValues()
        {
            var baseDictionary = new Dictionary<string, string>();

            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                var tokens = line.Split(new[] { ' ', '-', '>' },
                    StringSplitOptions.RemoveEmptyEntries);

                var key = tokens[0];
                var value = tokens[1];

                baseDictionary[key] = value;

                line = Console.ReadLine();
            }
            
            var defaultValue = Console.ReadLine();

            var unchangedBaseDict = baseDictionary
                .Where(x => x.Value != "null")
                .OrderByDescending(x => x.Value.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            var changedBaseDict = baseDictionary
                .Where(x => x.Value == "null")
                .ToDictionary(x => x.Key, x => defaultValue);


            Console.WriteLine();
            foreach (var kvp in unchangedBaseDict)
            {
                Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
            }

            foreach (var kvp in changedBaseDict)
            {
                Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
            }
        }

        private static void RegisteredUsers()
        {
            var userRegistryDate = new Dictionary<string, DateTime>();
            var line = Console.ReadLine();

            while (line != "end")
            {
                var tokens = line.Split(new[] { ' ', '-', '>' },
                    StringSplitOptions.RemoveEmptyEntries);

                var userName = tokens[0];
                var format = "dd/MM/yyyy";
                var registryDate = DateTime.ParseExact(tokens[1], format,
                    CultureInfo.InvariantCulture);

                //userRegistryDate.Add(userName, registryDate);  //only initialize, but dont update value

                userRegistryDate[userName] = registryDate;

                line = Console.ReadLine();
            }

            var orderdUsers = userRegistryDate
                .Reverse()
                .OrderBy(x => x.Value)
                .Take(5)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine();

            foreach (var kvp in orderdUsers)
            {
                Console.WriteLine("{0}", kvp.Key);
            }
        }

        private static void FoldAndSum()
        {
            var nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)                
                .ToArray();

            var k = nums.Length / 4;

            var leftUpSide = nums.Take(k).Reverse().ToArray();

            var rightUpSide = nums.Skip(3 * k).Reverse().ToArray();

            var upRow = leftUpSide.Concat(rightUpSide).ToArray();

            var downRow = nums.Skip(k).Take(2 * k).ToArray();

            var sumOfNumsInTwoRows = upRow
                .Select((x, index) => x + downRow[index])
                .ToArray();

            Console.WriteLine();
            Console.WriteLine(string.Join(" ", sumOfNumsInTwoRows));
        }

        private static void ShortWordsSorted()
        {
            var words = Console.ReadLine()
                .Split(new[] {'.', ',', ':', ';', '(', ')', '[', ']', '\"', '\'', '\\', '/', '!', '?', ' '},
                StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length < 5)
                .Select(w => w.ToLower())
                .OrderBy(w => w)
                .Distinct()
                .ToList();

            Console.WriteLine(string.Join(", ", words));

        }

        private static void LargestNNumbers()
        {
            var n = int.Parse(Console.ReadLine());

            var nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(n)
                .ToArray();

            Console.WriteLine();
            Console.WriteLine(string.Join(" ", nums));

        }

        private static void MinMaxAverage()
        {
            var n = int.Parse(Console.ReadLine());

            var nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("Sum = " + nums.Sum());
            Console.WriteLine("Min = " + nums.Min());
            Console.WriteLine("Max = " + nums.Max());
            Console.WriteLine("Average = " + nums.Average());


        }
    }
}