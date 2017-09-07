
namespace SerializeString
{
    using System;
    using System.Collections.Generic;

    public class SerializeString
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<char, List<int>> letters = new Dictionary<char, List<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!letters.ContainsKey(input[i]))
                {
                    letters[input[i]] = new List<int>();
                }

                letters[input[i]].Add(i);
            }

            foreach (var kvp in letters)
            {
                Console.WriteLine($"{kvp.Key}:{string.Join("/", kvp.Value)}");
            }
        }
    }
}
