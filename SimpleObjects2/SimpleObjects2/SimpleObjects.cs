
namespace SimpleObjects2
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SimpleObjects
    {
        public static void Main()
        {
            //Every method represents a small problem

            GuessWords();
            //DistanceBetweenPoints();

        }

        private static void GuessWords()
        {
            var rnd = new Random();
            

            var userWords = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            ShuffleWords(rnd, userWords);

            var line = Console.ReadLine();
            //var isReady = false;

            while (line != "end")   //|| isReady
            {
                var inputWord = line.ToLower().Trim();

                
                if (!userWords.Contains(inputWord))
                {
                    Console.WriteLine("There is no such a word");
                }

                if (inputWord.Equals(userWords[0]))
                {
                    Console.WriteLine("You have luck!");
                    userWords.Remove(inputWord);

                    if (userWords.Count == 0)
                    {
                        //isReady = true;

                        Console.WriteLine("Game over :)");
                        break;
                    }
                }

                ShuffleWords(rnd, userWords);

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", userWords));
        }

        private static void ShuffleWords(Random rnd, List<string> userWords)
        {
            for (int i = 0; i < userWords.Count; i++)
            {
                var index = rnd.Next(0, userWords.Count);

                var temp = userWords[i];
                userWords[i] = userWords[index];
                userWords[index] = temp;
            }
        }

        public static void DistanceBetweenPoints()
        {
            


        }
    }
}
