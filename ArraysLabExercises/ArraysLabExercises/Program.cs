
namespace ArraysLabExercises
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //Every method represents a small problem. 

            Console.WriteLine("Select a method :) \n" );
            // SumArrayElements();
            // MultiplyArrayOfDoubles();
            //SmallestElementInArray();
            // CountOfOddNumInArray();
            //RotateArrayOfStrings();

        }

        private static void RotateArrayOfStrings()
        {
            var strArr = Console.ReadLine()
                .Split(' ')
                //.Select(int.Parse)       use only if Parse needed: bool, int, double, etc..      
                .ToArray();

            var rotatedArr = new string[strArr.Length];
            var lastIndexOfStrArr = strArr[strArr.Length-1];

            rotatedArr[0] = lastIndexOfStrArr;

            for (int i = 0; i < strArr.Length - 1; i++)
            {
                rotatedArr[i + 1] = strArr[i];

            }

           
            
            Console.WriteLine("Rotated array: " + string.Join(" ", rotatedArr));
            Console.WriteLine();


        }

        private static void CountOfOddNumInArray()
        {
            var inputOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var count = 0;
            var evenNum = 0;
            var oddNum = new int[inputOfIntegers.Length - evenNum];
            

            for (int i = 0; i < inputOfIntegers.Length; i++)
            {
                if (inputOfIntegers[i] % 2 != 0)
                {
                    count++;
                    oddNum[i] = inputOfIntegers[i];
                }
                else
                {
                    evenNum++;
                }
                
            }

            Console.WriteLine(count);
            Console.Write("The odd numbers are: " + string.Join(", ", oddNum));
            Console.WriteLine();



        }

        private static void SmallestElementInArray()
        {
            var enteredNumbersString = Console.ReadLine().Split(' ');
            var numbers = new int[enteredNumbersString.Length];
            var currentNum = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(enteredNumbersString[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < currentNum)
                {
                    currentNum = numbers[i];
                }
            }
            Console.WriteLine(currentNum);
            Console.WriteLine($"Min: {numbers.Min()}; Max: {numbers.Max()}; Avg: {numbers.Average()}" );
            Console.WriteLine("Sum: " + numbers.Sum());

        }

        private static void MultiplyArrayOfDoubles()
        {
            // read input from a one line string
            var stringArr = Console.ReadLine().Split(' ');
            var arr = new double[stringArr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = double.Parse(stringArr[i]);
            }

            var multiplyNumber = double.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= multiplyNumber;
            }
            //Console.WriteLine(arr.Min());

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();


        }

        private static void SumArrayElements()
        {
            var n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            var result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }

            Console.WriteLine(result);
            // Console.WriteLine(numbers.Sum());
        }
    }
}