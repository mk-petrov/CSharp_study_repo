
using System;
using System.Linq;
using System.Collections.Generic;

namespace Websites
{
    public class Website
    {
        public string Host { get; set; }

        public string Domain { get; set; }

        public List<string> Queries { get; set; }

        public static Website Parse (string line)
        {
            var input = line
                .Split(new char[] { ' ', '|', ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            return new Website
            {
                Host = input[0],
                Domain = input[1],
                Queries = input.Skip(2).ToList()
            };
        }
    }
}
