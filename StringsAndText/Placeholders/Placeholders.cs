
namespace Placeholders
{
    using System;

    public class Placeholders
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            while (line != "end")
            {
                var inputParams = line
                    .Split(new[] { '-', '>' },
                    StringSplitOptions.RemoveEmptyEntries);

                var lineToPrint = inputParams[0].Trim();

                var placeholders = inputParams[1].Trim()
                    .Split(new[] { ',', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < placeholders.Length; i++)
                {
                    string currentPlaceholder = "{" + i + "}";

                    lineToPrint = lineToPrint.Replace(currentPlaceholder, placeholders[i]);
                }

                Console.WriteLine(lineToPrint);

                line = Console.ReadLine();
            }
        }
    }
}
