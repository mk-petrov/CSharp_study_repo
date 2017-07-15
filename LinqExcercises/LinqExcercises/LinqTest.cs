
namespace LinqExcercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class LinqTest
    {
        public static void Main()
        {
            //Every method represents a small problem

            //MinMaxAverage();
            //LargestNNumbers();
            //ShortWordsSorted();
            //FoldAndSum();
            

            Console.WriteLine();
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