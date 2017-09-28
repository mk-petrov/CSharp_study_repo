using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Command_Interpreter
{
    public class Cmd_Interpreter
    {
        public static void Main()
        {
            List<string> array = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string[] inputParams = inputLine.Split();

                string command = inputParams[0];

                switch (command)
                {
                    case "reverse":
                        int reverseStart = int.Parse(inputParams[2]);
                        int reverseCount = int.Parse(inputParams[4]);

                        Reverse(array, reverseStart, reverseCount);


                        break;
                    case "sort":
                        int sortStart = int.Parse(inputParams[2]);
                        int sortCount = int.Parse(inputParams[4]);

                        Sort(array, sortStart, sortCount);

                        break;
                    case "rollLeft":
                        //
                        break;
                    case "rollRight":
                        //
                        break;
                }

                inputLine = Console.ReadLine();
            }
        }

        private static void Sort(List<string> array, int sortStart, int sortCount)
        {
            array.Sort(sortStart, sortCount, null); 
        }

        private static void Reverse(List<string> array, int reverseStart, int reverseCount)
        {
            array.Reverse(reverseStart, reverseCount);
        }
    }
}
