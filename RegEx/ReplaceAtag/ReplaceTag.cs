
namespace ReplaceATag
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceTag
    {
        static void Main()
        {                        
            var pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";

            var text = "<ul> <li> <a href=\"http://softuni.bg\">SoftUni</a> </ li > </ ul > ";

            var regex = new Regex(pattern);

            var replace = @"[URL href=$1]$2[/URL]";

            var replaced = regex.Replace(text, replace);

            Console.WriteLine(replaced);

        }
    }
}
