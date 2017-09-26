using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            var result = new SortedDictionary<string, Demon>();

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

                // to match: -127.27 or 5.4 or 7
                // zero or one: - ; one or more: nums; zero or one: . ; zero or more nums;
                var regex = new Regex(@"-?\d+\.?\d*");

                var matches = regex.Matches(demon);

                var damage = 0.0;

                foreach (Match match in matches)
                {
                    var currentNumber = double.Parse(match.Value);

                    damage += currentNumber;
                }

                var modifiers = demon.Where(s => s == '/' || s == '*');

                foreach (var modifier in modifiers)
                {
                    if (modifier == '*')
                    {
                        damage *= 2;
                    }
                    else if (modifier == '/')
                    {
                        damage /= 2;
                    }
                }

                result.Add(demon, new Demon
                {
                    Name = demon,
                    Health = health,
                    Damage = damage
                });

            }
            foreach (var demon in result)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.Health} health, " +
                    $"{demon.Value.Damage:F2} damage");
            }
            Console.WriteLine();
        }
    }
}
