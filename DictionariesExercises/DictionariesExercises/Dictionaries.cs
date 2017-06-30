
namespace DictionariesExercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dictionaries
    {
        public static void Main()
        {
            //Every method represents a small problem

            //CountRealNumbers();
            //PrintOddTimesMetedWords();
                    
                        
            //TryParseMethod();
            //OldEnoughToDrive();

        }

        private static void PrintOddTimesMetedWords()
        {
            var words = Console.ReadLine()
                .ToLower()                      //to make case-insensitive everything
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!result.ContainsKey(word))
                {
                    result[word] = 0;            // initialize new kvp
                }

                result[word]++;
            }

            var oddNumberWords = new List<string>();

            foreach (var kvp in result)
            {
                var value = kvp.Value;
                if (value % 2 != 0)
                {
                    oddNumberWords.Add(kvp.Key);
                }
            }
            
            Console.WriteLine(string.Join(", ", oddNumberWords));

        }

        private static void CountRealNumbers()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var result = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!result.ContainsKey(number))
                {
                    result[number] = 0;
                }

                result[number]++;
            }

            foreach (var kvp in result)
            {
                var timeString = kvp.Value == 1 ? "time" : "times";
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} {timeString}");
            }


        }

        private static void OldEnoughToDrive()
        {
            Dictionary<string, string> names = new Dictionary<string, string>();

            var inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                var inputedString = inputLine.Split();
                names[inputedString[0]] = inputedString[1];

                inputLine = Console.ReadLine();
            }


            foreach (var item in names)
            {
                var age = 0;
                int.TryParse(item.Value, out age);

                if (age >= 18)
                {
                    Console.WriteLine(item.Key + " is old enough to drive");
                }

            }
        }

        private static void TryParseMethod()
        {
            string text1 = "1234s";
            int number1;

            bool parsed1 = int.TryParse(text1, out number1);

            Console.WriteLine(parsed1 + " " + number1);

            string text2 = "1234";
            int number2;

            bool parsed2 = int.TryParse(text2, out number2);
            Console.WriteLine(parsed2 + " " + number2);
        }
    }
}