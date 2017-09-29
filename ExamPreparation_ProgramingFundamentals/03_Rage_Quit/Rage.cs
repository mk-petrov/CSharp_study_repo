using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03_Rage_Quit
{
    public class Rage
    {
        public static void Main()
        {
            // INPUT LIKE: 
            //

            var pattern = @"(\D+)(\d+)";

            var regex = new Regex(pattern);

            string inputLine = Console.ReadLine();

            MatchCollection matches = regex.Matches(inputLine);

            StringBuilder result = new StringBuilder();
            

            foreach (Match match in matches)
            {
                string partition = match.Groups[1].Value;
                int times = int.Parse(match.Groups[2].Value);

                result.Append(Repeat(partition, times).ToUpper());
            }

            int uniqueSymbols = result.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(result);
        }

        private static string Repeat(string partition, int times)
        {
            StringBuilder final = new StringBuilder();

            for (int i = 0; i < times; i++)
            {
                final.Append(partition);
            }

            return final.ToString();
        }
    }
}
