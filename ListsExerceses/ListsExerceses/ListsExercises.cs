
namespace ListsExerceses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            //Every method represents a small problem 

            //CounterOccurrencesSecondWay();
            //RemoveElementsAtOddPositions();
            //BlackListWords();
            //BlackListWordsSecond();
            //FlipListsSides();
            //TearListInHalf();
            //BinarySearchedList();
            //StuckZipper();
            //DistinctList();


            //CalculateNumberOfDigits(number);
            //var number = int.Parse(Console.ReadLine());

            //var num = CalculateNumberOfDigits(number);
            //Console.WriteLine(num);
            //DigitsContainedInNumber();

        }

        private static void DistinctList()
        {
            var inputedNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            // with list sorting :)

            //inputedNumbers.Sort();

            //for (int i = 0; i < inputedNumbers.Count - 1; i++)
            //{
            //    var currentNum = inputedNumbers[i];
            //    var nextNum = inputedNumbers[i + 1];

            //    if (currentNum == nextNum)
            //    {
            //        inputedNumbers.Remove(nextNum);
            //    }

            //}

            //without list sorting :)

            for (int i = 0; i < inputedNumbers.Count - 1; i++)
            {
                var currentNum = inputedNumbers[i];

                inputedNumbers.Remove(currentNum);

                while (inputedNumbers.Contains(currentNum))
                {
                    inputedNumbers.Remove(currentNum);
                }

                inputedNumbers.Insert(i, currentNum);
                
            }
            
            Console.WriteLine(string.Join(" ", inputedNumbers));
        }

        private static void DigitsContainedInNumber()
        {
            // input a NUMBER, then another Num and chek if the NUMBER contains Num 
            // ex.  84567912,  5679  -> Yes
            var num = long.Parse(Console.ReadLine());
            var num1 = Console.ReadLine();
            var str = num.ToString().Contains(num1);
            if (str)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static void StuckZipper()
        {
            var list1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var list2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            
            var repearedList1 = RemoveBadElements(list1);
            var repearedList2 = RemoveBadElements(list2);

            var zippedList = ListZipper(repearedList1, repearedList2);

            
            Console.WriteLine(string.Join(" ", zippedList));
            //Console.WriteLine(string.Join(" ", repearedList1));
        }

        private static List<int> RemoveBadElements(List<int> list)
        {
            var currNumberList = new List<int>();
            var idealNumber = 0;

            for (int i = 0; i < list.Count; i++)
            {
                var currentNumber = Math.Abs(list[i]).ToString().Length;
                                
                currNumberList.Add(currentNumber);
                                
            }

            idealNumber = currNumberList.Min();

            for (int i = 0; i < list.Count; i++)
            {
                var currentNumber = Math.Abs(list[i]).ToString().Length;

                if (currentNumber > idealNumber)
                {
                    list.Remove(list[i]);
                    i --;
                }
            }

            return list;
        }

        private static List<int> ListZipper(List<int> list1, List<int> list2)
        {
            
            var toIndex = 1;

            for (int i = 0; i < list1.Count; i++)
            {
                list2.Insert(Math.Min(list2.Count ,toIndex), list1[i]);
                toIndex += 2;
                
            }
            return list2;
        }

        private static void BinarySearchedList()
        {
            var listOfNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var wantedNum = int.Parse(Console.ReadLine());
            var currentNum = 0;

            listOfNumbers.Sort();
            currentNum = listOfNumbers.BinarySearch(wantedNum);   // returns the index of wantedNum

            
            Console.WriteLine(currentNum);
            Console.WriteLine(string.Join("", listOfNumbers));
        }

        static int CalculateNumberOfDigits(int number)
        {
            number = Math.Abs(number);
            var numberOfDigits = number.ToString().Length; // makes the integer a string a take length 

            return numberOfDigits;
        }

        private static void BlackListWordsSecond()
        {
            var blacklist = Console.ReadLine().Split();
            var line = Console.ReadLine();
            var downloadedTracks = new List<string>();

            while (line != "end")
            {
                var isInBlackList = false;

                foreach (var blackListedWord in blacklist)
                {
                    if (line.Contains(blackListedWord))
                    {
                        isInBlackList = true;
                        break;
                    }

                }

                if (!isInBlackList)
                {
                    downloadedTracks.Add(line);
                }

                line = Console.ReadLine();
            }

            downloadedTracks.Sort();

            Console.WriteLine(string.Join(Environment.NewLine, downloadedTracks));

        }

        private static void TearListInHalf()
        {
            var listOne = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var listTwo = new List<int>();
            var counter = 1;

            for (int i = 0; i < listOne.Count; i++)
            {
                if (i >= listOne.Count / 2)
                {
                    var lastDigit = listOne[i] % 10;
                    var firstDigit = (listOne[i] / 10) % 10;

                    listTwo.Add(firstDigit);
                    listTwo.Add(lastDigit);
                }
            }
            for (int i = 0; i < listOne.Count / 2; i++)
            {
                listTwo.Insert(counter, listOne[i]);
                counter += 3;
            }

            Console.WriteLine(string.Join(" ", listTwo));
        }

        private static void FlipListsSides()
        {
            var inputedList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            
            for (int i = 1; i < inputedList.Count/2; i++)
            {
                var leftSideElement = inputedList[i];
                var rightSideElement = inputedList[inputedList.Count - i - 1];

                inputedList[i] = rightSideElement;
                inputedList[inputedList.Count - i - 1] = leftSideElement;
                
            }

            Console.WriteLine(string.Join(" ", inputedList));
            Console.WriteLine();
        }

        private static void BlackListWords()
        {
            var blackList = Console.ReadLine().Split(' ').ToList();

            var words = new List<string>();
            var inputLine = Console.ReadLine();
            //StringComparison comp = StringComparison.Ordinal;
            //comp = StringComparison.OrdinalIgnoreCase;

            while (inputLine != "end")
            {
                words.Add(inputLine);
                inputLine = Console.ReadLine();
                           
                
            }
            //Console.WriteLine(string.Join(" \n", words));

            for (int i = 0; i < blackList.Count; i++)
            {

                for (int j = 0; j < words.Count; j++)
                {
                    if (words[j].Contains(blackList[i]))
                    {
                        words.Remove(words[j]);
                    }
                }

            }
            
            words.Sort();

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }

        }
    
        private static void RemoveElementsAtOddPositions()
        {
            // positions in string start from 1, remove 1..3..5..etc
            var inputedString = Console.ReadLine().Split(' ').ToList();

            var evenPositionElements = new List<string>();

            for (int i = 0; i < inputedString.Count; i++)
            {
                if (i % 2 != 0)
                {
                    evenPositionElements.Add(inputedString[i]);
                }
            }
            Console.WriteLine(string.Join("",evenPositionElements));
            Console.WriteLine();

        }

        private static void CounterOccurrencesSecondWay()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            numbers.Sort();
            numbers.Add(int.MaxValue);     // this will give me the last number from counter

            int counter = 1;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                var currentNumber = numbers[i];
                var nextNumber = numbers[i + 1];

                if (currentNumber == nextNumber)
                {
                    counter++;
                }
                else
                {
                    Console.WriteLine($"{currentNumber} -> {counter}");
                    counter = 1;
                }
            }
            Console.WriteLine();
            
        }
    }
}