
namespace RegEx
{
    using System;
    using System.Text.RegularExpressions;

    public class RegEx
    {
        public static void Main()
        {
            //DemoOne();
            DemoTwo();

        }

        private static void DemoTwo()
        {
            var pattern = @"(\d{4})-(\w{3})-\d{2}";

            var regex = new Regex(pattern);
            var text = "First date is: 2017-Apr-04, second date is: 2016-Mar-18, third date is: 2001-Mai-12";

            var matches = regex.Matches(text); // return collection

            foreach (Match match in matches) // var will not work in this class
            {
                Console.WriteLine(match.Value);
                Console.WriteLine(match.Groups[1].Value);
                Console.WriteLine(match.Groups[2].Value);
            }


        }

        private static void DemoOne()
        {
            var pattern = @"(\d{4})-(\d{2})-\d{2}";
            var regex = new Regex(pattern);

            var text = "Today is 2017-09-14";

            var isMatch = regex.IsMatch(text);
            var match = regex.Match(text);

            Console.WriteLine(isMatch);  // Match- will return the first occurence, Matches - will return them all
            Console.WriteLine(match.Success);
            Console.WriteLine(match.Value);
            Console.WriteLine(match.Length);
            Console.WriteLine(match.Groups[0].Value); // groups[0] is the hole match
            Console.WriteLine(match.Groups[1].Value);
            Console.WriteLine(match.Groups[2].Value);
        }
    }
}
