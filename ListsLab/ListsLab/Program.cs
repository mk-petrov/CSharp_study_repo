
namespace ListsLab
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            //Every method represents a small problem :)

            //RemoveNegativeAndReverse();
            //AppendLists();
            //SumOfAdjacentEqualNumbers();
            //SplitByWordCasing();
            //SortNumbers();
            //SquareNumbers();
            //CountingOccurrences();


            //FullListFromConsoleNewLine();
            //SplitBySlachAndSpaceList();
            //MixedLists();

        }

        private static void CountingOccurrences()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int[] count = new int[1001];         //till 1000 and 0

            foreach (var number in numbers)
            {
                count[number]++;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    Console.WriteLine($"{i} -> {count[i]}");
                }
            }

            Console.WriteLine();
        }

        private static void SquareNumbers()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var result = new List<int>();

            foreach (var number in numbers)
            {
                var square = Math.Sqrt(number);

                if (square == (int)square)
                {
                    result.Add(number);
                }
            }
            result.Sort();
            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
            Console.WriteLine();

        }

        private static void SortNumbers()
        {
            var inputedNumbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            inputedNumbers.Sort();

            Console.WriteLine(string.Join(" <= ", inputedNumbers));

        }

        private static void SplitByWordCasing()
        {
            var inputedString = Console.ReadLine()
                .Split(new char[] {' ', ',', ':', '!', ';', '.',
                    '\'', '"', '(', ')', '[', ']', '/', '\\' }
                , StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var lowerCase = new List<string>();
            var mixedCase = new List<string>();
            var upperCase = new List<string>();

            foreach (var item in inputedString)
            {
                var countUp = 0;
                var countDown = 0;
                var lenght = item.Length;

                foreach (var symbol in item)
                {
                                        
                    if (symbol >= 'A' && symbol <= 'Z')
                    {
                        countUp++;
                                                
                    }
                    else if (symbol >= 'a' && symbol <= 'z')
                    {
                        countDown++;
                                                
                    }
                    
                }

                if (countUp == lenght)
                {
                    upperCase.Add(item);
                }
                else if (countDown == lenght)
                {
                    lowerCase.Add(item);
                }
                else
                {
                    mixedCase.Add(item);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCase));
            Console.WriteLine();
        }

        private static void MixedLists()
        {
            var listOne = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var listTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var count = 0;

            for (int i = 0; i < listOne.Count; i++)
            {
                listTwo.Insert(count, listOne[i]);
                count += 2;
            }
            Console.WriteLine(string.Join(" ", listTwo));
        }

        private static void SumOfAdjacentEqualNumbers()
        {
            var inputList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < inputList.Count; i++)
            {

                if (i == inputList.Count-1)
                {
                    break;
                }
                while (inputList[i] == inputList[i + 1])
                {
                    var newNum = inputList[i] * 2;
                    inputList.RemoveAt(i);
                    inputList.RemoveAt(i);
                    inputList.Insert(i, newNum);
                    i = 0;

                }
                               
            }

            Console.WriteLine(string.Join(" ", inputList));

        }

        private static void FullListFromConsoleNewLine()
        {
            var n = int.Parse(Console.ReadLine());
            var numbersList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                numbersList.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(string.Join(" ", numbersList));
            foreach (var item in numbersList)
            {
                Console.WriteLine(item);
            }
        }

        private static void SplitBySlachAndSpaceList()
        {
            var inputedNumbers = Console.ReadLine()
                            .Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
            inputedNumbers.Reverse();
            Console.WriteLine(string.Join(" ", inputedNumbers));
        }

        private static void AppendLists()
        {
            var inputedNumbers = Console.ReadLine()
                .Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            inputedNumbers.Reverse();
            var newList = new List<int>();
            

            for (int i = 0; i < inputedNumbers.Count; i++)
            {
                
                var currStr = inputedNumbers[i]
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();

                foreach (var item in currStr)
                {
                    newList.Add(item);
                }
            }

            //Console.WriteLine(string.Join(" ", inputedNumbers).Trim());
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", newList));
                            


        }

        private static void RemoveNegativeAndReverse()
        {
            var numbersList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> positiveNums = new List<int>();

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (numbersList[i] > 0)
                {
                    positiveNums.Add(numbersList[i]);
                }
            }
            positiveNums.Reverse();
            if (positiveNums.Count == 0)
            {
                Console.WriteLine("empty");
            }

            Console.WriteLine(string.Join(" ", positiveNums));


        }
    }
}