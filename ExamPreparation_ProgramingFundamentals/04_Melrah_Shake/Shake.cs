using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _04_Melrah_Shake
{
    public class Shake
    {
        public static void Main()
        {
            /*Cut pattern from left and right, remove the middle from pattern and try again,
             * till there is no matches to remove
             * 
              input:  asdffadggadffasd
                      asd
              output:
                      Shaked it.   // ffadggadff and pattern: ad
                      Shaked it.   // ffggff and no further match
                      No shake.
                      ffggff
            */

            string inputString = Console.ReadLine();
            string inputPattern = Console.ReadLine();

            //Regex.Escape() is needed because the pattern can be any ASCII char
            //and the dot(.) need to be escaped  
            Regex regex = new Regex(Regex.Escape(inputPattern));

            MatchCollection matches = regex.Matches(inputString);

            while (true)
            {
                if (matches.Count >= 2 && inputPattern.Length > 0)
                {
                    int startIndex = inputString.IndexOf(inputPattern);
                    int lastIndex = inputString.LastIndexOf(inputPattern);

                    inputString = inputString.Remove(lastIndex, inputPattern.Length);
                    inputString = inputString.Remove(startIndex, inputPattern.Length);

                    inputPattern = inputPattern.Remove(inputPattern.Length / 2, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }

                regex = new Regex(Regex.Escape(inputPattern));
                matches = regex.Matches(inputString);
            }

            Console.WriteLine(inputString);
        }
    }
}
