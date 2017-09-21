
namespace HappinessIndex
{
    using System;
    using System.Text.RegularExpressions;

    public class HappinessIndex
    {
        public static void Main()
        {
            string happyEmoticons = @"(:\))|(:D)|(;\))|(:\*)|(:\])|(;\])|(:})|(;})|(\(:)|(\*:)|(c:)|(\[:)|(\[;)";

            string sadEmoticons = @"(:\()|(D:)|(;\()|(:\[)|(;\[)|(:{)|(;{)|(\):)|(:c)|(]:)|(];)";

            var regexHappy = new Regex(happyEmoticons);
            var regexSad = new Regex(sadEmoticons);

            var line = Console.ReadLine();

            double happyCount = regexHappy.Matches(line).Count;
            var sadCount = regexSad.Matches(line).Count;

            double index = happyCount / sadCount; // min one must be double for precise division
            string indexEmoticon = string.Empty;

            if (index >= 2)
            {
                indexEmoticon = ":D";
            }
            else if (index > 1)
            {
                indexEmoticon = ":)";
            }
            else if (index == 1)
            {
                indexEmoticon = ":|";
            }
            else if (index < 1)
            {
                indexEmoticon = ":(";
            }

            Console.WriteLine("Happiness index: {0:f2} {1}", index, indexEmoticon);
            Console.WriteLine("[Happy count: {0}, Sad count: {1}]", happyCount, sadCount);

        }
    }
}
