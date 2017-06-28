
namespace ArraysExercises
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //Every method represents a small problem. 

            //LargestElementInArray();
            //CountOfNegativeElementsInArray();
            //CountOfGivenElementInArray();
            //CountOcurrencesInArray();
            //IncreasingSequenceOfElements();
            //EqualSequenceOfElements();
            //CapitalOneWordLetters();
            //ArraySymmetry();
            //LastThreeConsecutiveEqualStrings();
            //ArrayElementsEqualsToTheirIndex();
            //PhoneBook();              // uses PrintElement method
            //CountOfConsecutiveStrings();


        }

        private static void CountOfConsecutiveStrings()
        {
            string[] arrStr = Console.ReadLine().Split(' ');
            int count = 1;       // needet to count the number of Consecutive Str

            for (int i = arrStr.Length - 1; i > 0; i--)
            {
                if (arrStr[i] == arrStr[i - 1])
                {
                    count++;

                    if (count == 3)
                    {
                        Console.WriteLine("{0} {0} {0}", arrStr[i]);
                        break;
                    }
                }
                else             // need to restart the counter
                {
                    count = 1;
                }
            }


        }

        private static void PhoneBook()
        {
            var phoneNumber = Console.ReadLine().Split(' ');
            var ownerName = Console.ReadLine().Split(' ');
            string inputLine = Console.ReadLine();

            while (inputLine != "done")
            {
                PrintElement(ownerName, phoneNumber, inputLine);
                inputLine = Console.ReadLine();
            }



        }

        private static void PrintElement(string[] ownerName, string[] phoneNumber, string inputLine)
        {
            for (int i = 0; i < ownerName.Length; i++)
            {
                if (ownerName[i] == inputLine)
                {
                    Console.WriteLine($"{ownerName[i]} -> {phoneNumber[i]}");
                }
            }
        }


        private static void ArrayElementsEqualsToTheirIndex()
        {
            var numbersArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            

            for (int i = 0; i < numbersArr.Length; i++)
            {
                if (i == numbersArr[i])
                {
                    Console.Write(numbersArr[i] + " ");
                }
            }
            Console.WriteLine();

        }

        private static void LastThreeConsecutiveEqualStrings()
        {
            string[] words = Console.ReadLine().Split(' ');
            string repeatedString = string.Empty;

            for (int i = words.Length-1; i > 0; i--)
            {
                if (words[i].Equals(words[i - 1]) && words[i].Equals(words[i - 2]))
                {
                    repeatedString = $"{words[i]} {words[i]} {words[i]}";
                    break;
                }
                else
                {
                    repeatedString = "No match found";
                }
            }
            Console.WriteLine(repeatedString);

        }

        private static void ArraySymmetry()
        {
            string[] arrayWords = Console.ReadLine().Split(' ');

            bool isSymmetric = true;

            for (int i = 0; i < arrayWords.Length / 2; i++)
            {
                string firstWord = arrayWords[i];
                string secondWord = arrayWords[arrayWords.Length - 1 - i];

                if (firstWord != secondWord)
                {
                    isSymmetric = false;
                    break;
                }
            }

            if (isSymmetric)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }

        private static void CapitalOneWordLetters()
        {
            string[] words = Console.ReadLine().Split(' ');
            var count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];

                if (currentWord.Length == 1)
                {
                    char.IsUpper(currentWord[0]);
                    count++;

                    //char character = currentWord[0];
                    //if (character >= 65 || character <= 90)    // if (character >= 'A' && character <= 'Z') 
                    //{
                    //    count++;
                    //}
                }
            }
            Console.WriteLine(count);


        }

        private static void EqualSequenceOfElements()
        {
            var inputedArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var resultEnd = string.Empty;

            for (int i = 0; i < inputedArr.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                else if (inputedArr[i] == inputedArr[i - 1])
                {
                    resultEnd = "Yes";
                }
                else
                {
                    resultEnd = "No";
                    break;
                }

            }

            Console.WriteLine(resultEnd);
            Console.WriteLine();
           
        }

        private static void IncreasingSequenceOfElements()
        {
            var inputedArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var resultEnd = string.Empty;

            for (int i = 0; i < inputedArr.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                else if (inputedArr[i] > inputedArr[i - 1])
                {
                    resultEnd = "Yes, this is an increasing sequence";
                }
                else
                {
                    resultEnd = "No, this is not an increasing sequence";
                    break;
                }

            }

            Console.WriteLine(resultEnd);
            Console.WriteLine();
        }

        private static void CountOcurrencesInArray()
        {
            var inputedNum = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var givenNum = double.Parse(Console.ReadLine());
            var count = 0;
            var countTimes = " numbers";

            //for (int i = 0; i < inputedNum.Length; i++)
            //{
            //    if (inputedNum[i] > givenNum)
            //    {
            //        count++;
            //    }
            //}

            foreach (var item in inputedNum)
            {
                if (item > givenNum)
                {
                    count++;
                }
            }

            if (count == 1)
            {
                countTimes = " number";
            }

            Console.WriteLine(count + countTimes + " are bigger");
        }

        private static void CountOfGivenElementInArray()
        {
            var inputOfNum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var givenNum = int.Parse(Console.ReadLine());
            var count = 0;
            var countTimes = " times.";

            for (int i = 0; i < inputOfNum.Length; i++)
            {
                if (inputOfNum[i] == givenNum)
                {
                    count++;
                }

            }
            if (count == 1)
            {
                countTimes = " time.";
            }

            Console.WriteLine("The given number appears " + count + countTimes);
        }

        private static void CountOfNegativeElementsInArray()
        {
            var inputedNum = int.Parse(Console.ReadLine());
            int[] numbers = new int[inputedNum];
            var count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());

                if (numbers[i] < 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);


        }

        private static void LargestElementInArray()
        {
            var inputedNum = int.Parse(Console.ReadLine());
            int[] numbers = new int[inputedNum];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Largest Ineteger in Array is : " + numbers.Max());
            Console.WriteLine(string.Join(", ", numbers));
        }


    }
}