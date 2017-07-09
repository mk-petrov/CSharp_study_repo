
namespace MultiDictionariesExerecises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    public class MultiDictionary
    {
        public static void Main()
        {
            //Every method represents a small problem

            //AverageStudentGrades();
            //CitiesByContinentAndCountry();
            //RecordUniqueNames();
            //GroupContinentsCounriesAndCities();

            

            //NestedDictionary();
            //FillDictionary();
        }

        private static void GroupContinentsCounriesAndCities()
        {
            var continentData =
                new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();

            var inputLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLine; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var continent = tokens[0];
                var country = tokens[1];
                var city = tokens[2];

                if (! continentData.ContainsKey(continent))
                {
                    continentData[continent] = 
                        new SortedDictionary<string, SortedSet<string>>();
                }

                if (! continentData[continent].ContainsKey(country))
                {
                    continentData[continent][country] = new SortedSet<string>();
                }

                continentData[continent][country].Add(city);
            }

            Console.WriteLine();
            foreach (var continent in continentData)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var kvp in continent.Value)
                {
                    Console.WriteLine($"    {kvp.Key} -> {string.Join(", ", kvp.Value)}");
                }
            }
            Console.WriteLine();
        }

        private static void RecordUniqueNames()
        {
            var names = new HashSet<string>();
            var sortedNames = new SortedSet<string>();
            var linesOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesOfInput; i++)
            {
                var token = Console.ReadLine();

                names.Add(token);
                sortedNames.Add(token);
            }

            Console.WriteLine("===== OUTPUT =====");
            Console.WriteLine(string.Join(Environment.NewLine, names));

            Console.WriteLine("===== SORTED =====");
            Console.WriteLine(string.Join(Environment.NewLine, sortedNames));

        }

        private static void NestedDictionary()
        {
            var countryAndPopulation = 
                new Dictionary<string, Dictionary<string, int>>();

            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                var tokens = line.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var country = tokens[0];
                var city = tokens[1];
                var population = int.Parse(tokens[2]);

                if (! countryAndPopulation.ContainsKey(country))
                {
                    countryAndPopulation[country] = new Dictionary<string, int>();
                }

                countryAndPopulation[country][city] = population;

                line = Console.ReadLine();
            }

            foreach (var item in countryAndPopulation)
            {                
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"{item.Key} -> {kvp.Key} -> {kvp.Value}");
                }
            }
        }

        private static void CitiesByContinentAndCountry()
        {
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var continent = tokens[0];
                var country = tokens[1];
                var city = tokens[2];

                if ( ! cities.ContainsKey(continent))
                {
                    cities[continent] = new Dictionary<string, List<string>>();                    
                }
                                
                if (!cities[continent].ContainsKey(country))
                {
                    cities[continent][country] = new List<string>();
                }

                cities[continent][country].Add(city);
                
            }

            Console.WriteLine();
            foreach (var continent in cities)
            {
                Console.WriteLine("{0}:", continent.Key);

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }


        }

        private static void AverageStudentGrades()
        {
            var studentGrades = new Dictionary<string, List<double>>();
            var studentCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentCount; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var stringGrade = tokens[1];
                double grade;

                if (double.TryParse(stringGrade, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out grade))   // input double: 5.50 format
                {
                    if ( ! studentGrades.ContainsKey(name))
                    {
                        studentGrades[name] = new List<double>();
                    }

                    studentGrades[name].Add(grade);
                }
                else
                {
                    Console.WriteLine("Grade is not a double");
                }

                
            }
            Console.WriteLine("====================");

            foreach (var kvp in studentGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", kvp.Value)} " +
                    $"(avg: {kvp.Value.Average():F2})");
            }

            Console.WriteLine("====================");
        }

        private static void FillDictionary()
        {
            var dataBase = new Dictionary<string, List<int>>();
            var line = Console.ReadLine();
            while (!line.Equals("end"))
            {
                var tokens = line.Split(' ');
                var name = tokens[0];
                var grade = int.Parse(tokens[1]);

                AddGrade(dataBase, name, grade);
                line = Console.ReadLine();
            }

            foreach (var kvp in dataBase)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(" ", kvp.Value)}");
            }
        }

        public static void AddGrade(Dictionary<string, List<int>> dataBase, string name, int grade)
        {
            if (!dataBase.ContainsKey(name))
            {
                dataBase[name] = new List<int>();
            }

            dataBase[name].Add(grade);
        }
    }
}