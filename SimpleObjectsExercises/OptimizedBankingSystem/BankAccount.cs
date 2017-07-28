using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizedBankingSystem
{
    public class BankAccount
    {
        public string Name { get; set; }

        public string Bank { get; set; }

        public decimal Balance { get; set; }

        public static BankAccount Parse (string inputLine)
        {
            var input = inputLine
                .Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            return new BankAccount
            {
                Bank = input[0],
                Name = input[1],
                Balance = decimal.Parse(input[2])
            };           
            
        }
    }
}
