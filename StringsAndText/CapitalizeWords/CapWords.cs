
namespace CapitalizeWords
{
    using System;
    using System.Collections.Generic;
    
    

    public class CapWords
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            

            while (input != "end")
            {
                var inputParts = input.Split(new[] { '.', ',', ':', ';', '(', ')',
                    '[', ']', '\"', '\\', '/', '!', '?', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                List<string> partsOfInput = new List<string>();


                for (int i = 0; i < inputParts.Length; i++)
                {
                    var partOne = inputParts[i].ToUpper().Substring(0, 1);
                    var partTwo = inputParts[i].Trim('.').ToLower().Substring(1);

                    //sb.Append(partOne);
                    //sb.Append(partTwo);

                    partsOfInput.Add(partOne + partTwo);
                }

                Console.WriteLine(string.Join(", ", partsOfInput));

                input = Console.ReadLine();
            }
        }
    }
}
