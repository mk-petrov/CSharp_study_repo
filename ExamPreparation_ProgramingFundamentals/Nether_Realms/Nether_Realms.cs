using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nether_Realms
{
    public class Nether_Realms
    {
        public static void Main()
        {
            var demons = Console.ReadLine()
                 .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            foreach (var demon in demons)
            {
                //all chars except for: [0-9] + - * / .
                var healthSymbols = demon
                    .Where(s => !char.IsDigit(s) &&
                    s != '+' &&
                    s != '-' &&
                    s != '*' &&
                    s != '/' &&
                    s != '.');

                var health = 0;

                foreach (var healthSymbol in healthSymbols)
                {
                    health += healthSymbol;
                }
            }

        }
    }
}
