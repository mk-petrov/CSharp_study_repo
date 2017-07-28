
namespace OptimizedBankingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BankingSystem
    {
        public static void Main()
        {
            var bankAccountData = new List<BankAccount>();
            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                var currentAccount = BankAccount.Parse(line);
                               
                
                bankAccountData.Add(currentAccount);

                line = Console.ReadLine();
            }

            var sortedByAccount = bankAccountData.OrderByDescending(b => b.Balance)
                    .ThenBy(n => n.Bank.Length).ToArray();

            foreach (var account in sortedByAccount)
            {
                
                Console.WriteLine($"{account.Name} -> {account.Balance} ({account.Bank})");
            }
        }
    }
}
