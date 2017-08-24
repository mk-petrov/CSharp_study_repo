
namespace StringsAndText
{
    using System;
    using System.Text;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections.Generic;

    public class Strings
    {
        public static void Main()
        {            
            //Palindromes();
            //CountSubstringOccurrences();
            //TextFilter();
            //TestStringBuilderSpeed();
            //StringReverse();
        }
        
        private static void Palindromes()
        {
            var text = Console.ReadLine()
                .Split(new[] { '.', ',', ':', ';', '(', ')', '[', ']', '\"', '\'', '\\', '/', '!', '?', ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            var palindromes = new SortedSet<string>();

            foreach (var word in text)
            {
                var reversedWord = word.Reverse().ToArray();
                
                if (word == string.Join("", reversedWord))
                {
                    palindromes.Add(word);
                }

            }

            Console.WriteLine(string.Join(", ", palindromes));

        }

        private static void StringReverse()
        {
            var text = Console.ReadLine();
            var sb = new StringBuilder();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }

            Console.WriteLine(sb.ToString());
        }

        private static void TestStringBuilderSpeed()
        {
            var stopwatch = Stopwatch.StartNew();
            var sb = new StringBuilder();
            //var a = "a";

            for (int i = 0; i < 1000000000; i++)
            {
                sb.Append("a");
                //a += "a";
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void TextFilter()
        {
            var bannedWords = Console.ReadLine()
                .Split(new[] { ' ', ',' }, 
                StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);
        }

        private static void CountSubstringOccurrences()
        {
            var text = Console.ReadLine().ToLower();
            var pattern = Console.ReadLine();
            var count = 0;
            var index = -1;

            while (true)
            {
                index = text.IndexOf(pattern, index + 1);

                if (index < 0)
                {
                    break;
                }

                count++;
            }

            Console.WriteLine(count);
        }
    }
}
