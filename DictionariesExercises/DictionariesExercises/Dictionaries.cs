
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
            //LetterRepetition();
            //DictRef();
            //MixedPhones();
            //ExamShopping();
                    
                        
            //TryParseMethod();
            //OldEnoughToDrive();

        }

        private static void ExamShopping()
        {
            var inventory = new Dictionary<string, int>();
            var line = Console.ReadLine();

            while (!line.Equals("exam time"))
            {
                var input = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];
                var product = input[1];
                var lastElement = input[input.Length - 1];
                int quantity;
                if (int.TryParse(lastElement, out quantity))
                {

                }

                switch (command)
                {
                    
                    case "stock":
                                                
                        if (inventory.ContainsKey(product))
                        {
                            var temp = inventory[product];
                            inventory[product] = temp + quantity;
                        }
                        else
                        {
                            inventory[product] = quantity;
                        }
                        
                        break;

                    case "shopping time":
                        continue;

                    case "buy":

                        if (inventory.ContainsKey(product))
                        {
                            var stockQuantity = inventory[product];
                            stockQuantity -= quantity;

                            if (stockQuantity < 0)
                            {
                                stockQuantity = 0;
                            }

                            inventory[product] = stockQuantity;
                        }
                        else
                        {
                            Console.WriteLine($"{product} doesn't exist");
                        }
                        break;

                                                                
                }                               

                line = Console.ReadLine();
            }

            Console.WriteLine();

            foreach (var kvp in inventory)
            {
                if (kvp.Value <= 0)
                {
                    continue;
                }
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine();
        }

        private static void MixedPhones()
        {
            var mixedPhones = new SortedDictionary<string, decimal>();
            var line = Console.ReadLine();

            while (!line.Equals("Over"))
            {
                var inputedString = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                var firstElement = inputedString[0];
                var lastElement = inputedString[inputedString.Length - 1];

                decimal number;
                if (decimal.TryParse(lastElement, out number))
                {
                    mixedPhones[firstElement] = number;
                }
                else if (decimal.TryParse(firstElement, out number))
                {
                    mixedPhones[lastElement] = number;
                }
                else
                {
                    Console.WriteLine("Not valid input");
                    Console.WriteLine("Required format: Name : phone");
                }
                
                line = Console.ReadLine();
            }

            foreach (var kvp in mixedPhones)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }

        private static void DictRef()
        {
            var resultDict = new Dictionary<string, int>();
            var line = Console.ReadLine();
            

            while (!line.Equals("end"))
            {
                var tokens = line.Split();
                var firstElement = tokens[0];
                var lastElement = tokens[tokens.Length - 1];

                var number = 0;
                if (int.TryParse(lastElement, out number))
                {
                    resultDict[firstElement] = number;
                }
                else
                {
                    if (resultDict.ContainsKey(lastElement))
                    {
                        var referencedValue = resultDict[lastElement];
                        resultDict[firstElement] = referencedValue;
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var kvp in resultDict)
            {
                Console.WriteLine($"{kvp.Key} === {kvp.Value}");
            }
            
        }

        private static void LetterRepetition()
        {
            var inputedWord = Console.ReadLine();

            var letters = new Dictionary<char, int>();

            foreach (var character in inputedWord)
            {
                if (!letters.ContainsKey(character))
                {
                    letters[character] = 0;
                }

                letters[character]++;
            }

            foreach (var letter in letters)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
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