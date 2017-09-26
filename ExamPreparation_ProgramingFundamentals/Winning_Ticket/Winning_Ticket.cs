using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Winning_Ticket
{
    public class Winning_Ticket
    {
        public static void Main()
        {
            // match 6 consecutive equals char like: $, #, ^ or @
            var pattern = @"([$#^@])\1{5,}";

            var ticketRegex = new Regex(pattern);

            var tickets = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;   // will start again from the next string in the loop
                }

                var leftHalf = ticket.Substring(0, ticket.Length / 2);
                var rightHalf = ticket.Substring(ticket.Length / 2);

                var leftMatch = ticketRegex.Match(leftHalf);
                var rightMatch = ticketRegex.Match(rightHalf);

                if (leftMatch.Success && rightMatch.Success)
                {
                    var winningSymbol = leftMatch.Value[0];
                    var shorterMatch = Math.Min(leftMatch.Length, rightMatch.Length);
                    var jackpot = string.Empty;

                    if (shorterMatch == 10)
                    {
                        jackpot = " Jackpot!";
                    }


                    Console.WriteLine($"ticket \"{ticket}\" - {shorterMatch}{winningSymbol}{jackpot}");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }

        }
    }
}
