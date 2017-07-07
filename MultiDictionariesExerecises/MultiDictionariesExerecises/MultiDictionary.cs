﻿
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



            //NestedDictionary();
            //FillDictionary();
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
            var cities = new Dictionary<string, Dictionary<string, string>>();
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
                    cities[continent] = new Dictionary<string, string>();
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