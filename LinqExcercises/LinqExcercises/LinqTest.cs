
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
            //FlattenDictionary();
            //OrderedBankingSystem();                    
            

            Console.WriteLine();
        }

        private static void OrderedBankingSystem()
        {
            var bankAccountData = new Dictionary<string, Dictionary<string, decimal>>();

            var line = Console.ReadLine();

            while (line != "end")
            {
                var tokens = line.Split(new string[] { " -> " }, 
                    StringSplitOptions.RemoveEmptyEntries);

                var bankName = tokens[0];
                var account = tokens[1];
                decimal balance = decimal.Parse(tokens[2]);

                if (! bankAccountData.ContainsKey(bankName))
                {
                    bankAccountData[bankName] = new Dictionary<string, decimal>();
                }
                if (! bankAccountData[bankName].ContainsKey(account))
                {
                    bankAccountData[bankName][account] = balance;
                }
                else
                {
                    bankAccountData[bankName][account] += balance;
                }
                

                line = Console.ReadLine();
            }

            foreach (var kvp in bankAccountData.OrderBy(x => x.Key))
            {
                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Key} has {item.Value} in {kvp.Key}");
                }
            }

        }

        private static void FlattenDictionary()
        {
            var dictionary = new Dictionary<string, Dictionary<string, string>>();

            var line = Console.ReadLine();

            while (! line.Equals("end"))
            {
                var inputParams = line.Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (inputParams[0] != "flatten")
                {
                    var key = inputParams[0];
                    var innerKey = inputParams[1];
                    var innerValue = inputParams[2];

                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary[key] = new Dictionary<string, string>();
                    }

                    dictionary[key][innerKey] = innerValue;
                }
                else
                {
                    var key = inputParams[1];


                    // make new dictionary with key: KEY + VALUE from the old one, and value: "flattened" 
                    dictionary[key] = dictionary[key]
                        .ToDictionary(x => x.Key + x.Value, x => "flattened");
                }

                line = Console.ReadLine();
            }

            //primery KEYs in descending order
            var orderedDictionary = dictionary
                .OrderByDescending(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in orderedDictionary)
            {
                Console.WriteLine("{0}", kvp.Key);

                var orderedInnerDictionary = kvp.Value
                    .Where(x => x.Value != "flattened")
                    .OrderBy(x => x.Key.Length)
                    .ToDictionary(x => x.Key, x => x.Value);

                var flattenedValues = kvp.Value
                    .Where(x => x.Value == "flattened")
                    .ToDictionary(x => x.Key, x => x.Value);

                var count = 1;

                foreach (var innerKvp in orderedInnerDictionary)
                {
                    Console.WriteLine($"{count}. {innerKvp.Key} - {innerKvp.Value}");
                    count++;
                }

                foreach (var flattened in flattenedValues)
                {
                    Console.WriteLine("{0}. {1}",count , flattened.Key);
                    count++;
                }
            }
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