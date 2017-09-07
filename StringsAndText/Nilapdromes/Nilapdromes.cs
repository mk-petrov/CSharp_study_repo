
namespace Nilapdromes
{
    using System;
    

    public class Nilapdromes
    {
        public static void Main()
        {
            // asdthisasd|dsasihtdsa 
            string line = Console.ReadLine();
            
            while (line != "end")
            {
                string middleOfString = string.Empty;
                string b = ReverseString(line);

                string borderLeft = string.Empty;
                string borderRight = string.Empty;

                for (int i = 0; i < line.Length; i++)
                {
                    char currentLetter = line[i];
                    char initialLetterOfReversed = b[0];


                    if (currentLetter == initialLetterOfReversed)
                    {
                        //BUILDING RIGHT BORDER AND MATCH IT WITH THE LEFT BORDER
                        borderLeft += currentLetter;

                        var stringToCheck = b.Substring(0, (i + 1)).ToString();

                        borderRight = ReverseString(stringToCheck);

                        if (borderLeft == borderRight)
                        {
                            //CUT THE TWO BORDERS FROM THE INITIAL STRING
                            middleOfString = line.Replace(borderLeft, string.Empty);
                            break;
                        }
                    }

                    else  //BUILDING LEFT BORDER
                    {
                        borderLeft += currentLetter;
                    }
                }

                string nilapdrome = middleOfString + borderLeft + middleOfString;

                if (line != nilapdrome)
                {
                    Console.WriteLine(nilapdrome);
                }

                line = Console.ReadLine();
            }
        }

        private static string ReverseString(string a)
        {
            var b = string.Empty;

            char[] stringAsArray = new char[a.Length];

            for (int i = a.Length - 1; i >= 0; i--)
            {
                char currentChar = a[i];
                b += currentChar;
            }

            return b;
        }
    }
}
