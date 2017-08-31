
namespace JSON_stringify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class JSON
    {
        public static void Main()
        {
            var studentsBase = new Dictionary<string, Student>();

            var line = Console.ReadLine();

            while (line != "stringify")
            {
                var inputParams = line.Split(new[] { ' ', ':', '-', '>', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                var name = inputParams[0];
                var age = inputParams[1];
                var name = inputParams[0];
                var name = inputParams[0];

                line = Console.ReadLine();
            }

        }
    }
}
