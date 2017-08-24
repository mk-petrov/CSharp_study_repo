
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
                    .Split(new string[] { "->" },
                    StringSplitOptions.RemoveEmptyEntries);

                var lineToPrint = inputParams[0];

                var placeholders = inputParams[1]
                    .Split(new[] { ',', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                               

                Console.WriteLine(lineToPrint, placeholders[0], placeholders[1]);
                
                line = Console.ReadLine();
            }
        }
    }
}
