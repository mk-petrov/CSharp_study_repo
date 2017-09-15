

namespace RegExLab
{
    using System;
    using System.Text.RegularExpressions;

    public class Lab
    {
        public static void Main()
        {
            //MatchFullName();
            //MatchPhoneNumber();


        }

        private static void MatchPhoneNumber()
        {
            var pattern = @"\+359( |-)2\1\d{3}\1\d{4}";
            var text = @"+359 2 222 2222 
                         +359-2-222-2222 
                          359-2-222-2222  
                         +359/2/222/2222 
                         +359-2 222 2222 
                         +359 2-222-2222 
                         +359-2-222-222 
                         +359-2-222-22222 ";

            var regex = new Regex(pattern);

            var numbers = regex.Matches(text);

            foreach (Match number in numbers)
            {
                Console.WriteLine(number);
            }
            
        }

        private static void MatchFullName()
        {
            var pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b"; // match like: "Petko Petrov"

            var text = "Ivan Ivanov, ivan ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Ivan IvAnov, Ivan	Ivanov, IvanIvanov, Petko Petrov";

            var regex = new Regex(pattern);

            var firstMatch = regex.Match(text);

            var matches = regex.Matches(text);

            Console.WriteLine(firstMatch);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
