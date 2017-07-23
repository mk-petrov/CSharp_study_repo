
namespace LottoGame
{
    using System;
    using System.Linq;

    public class LottoGame
    {
        public static void Main()
        {
            var random = new Random();
            var randomNums = new int[6];
            var count = 0;
            
            for (int i = 0; i < randomNums.Length; i++)
            {
                randomNums[i] = random.Next(1, 50);
            }


            Console.WriteLine("=====  Lottery Game 6/49  =====");
            Console.WriteLine();
            Console.WriteLine("Enter your numbers with space between:");

            var userInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (userInput.Length > 6)
            {
                Console.WriteLine("Please enter only six numbers");
            }

            for (int i = 0; i < userInput.Length; i++)
            {
                if (randomNums.Contains(userInput[i]))
                {
                    count++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"The winning numbers are:{Environment.NewLine}  {string.Join(" ", randomNums)}");
            Console.WriteLine();

            switch (count)
            {
                case 1:
                    Console.WriteLine("You have one number matching. Try one more time.");
                    break;
                case 2:
                    Console.WriteLine("You have two numbers matching. Try one more time.");
                    break;
                case 3:
                    Console.WriteLine("Congratulations you have won 50$");
                    break;
                case 4:
                    Console.WriteLine("Congratulations you have won 500$");
                    break;
                case 5:
                    Console.WriteLine("Congratulations you have won 5000$");
                    break;
                case 6:
                    Console.WriteLine($"Congratulations you are the winner." +
                        $"{Environment.NewLine}  **** Your reward is 1 500 000 $ ****");
                    break;
                default:
                    Console.WriteLine("Try one more time.");
                    break;
            }
        }
    }
}