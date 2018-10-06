using System;
using System.Collections.Generic;

namespace OOP_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of accounts
            var accounts = new List<Account3>
            {
                new Account3("Dopey", 500),
                new Account3("Sleepy"),
                new Account3("Sneezy", 300)
            };

            Reports(accounts, "Opening Report");

            // Do some transactions
            accounts[0].Withdraw(150);
            Console.WriteLine($"{accounts[0].Name}: Withdraw $150");

            accounts[1].Deposit(100);
            Console.WriteLine($"{accounts[1].Name}: Deposit $100");

            try
            {
                accounts[2].Withdraw(375);
                Console.WriteLine($"{accounts[2].Name}: Withdraw $375");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"{accounts[2].Name}: {e.ParamName}");
                Console.WriteLine($"Requested withdrawl: $375.00 / Account Balance: {accounts[2].Balance:C}");
            }

            Reports(accounts, "\nClosing Report");
        }

        static void Reports(List<Account3> accts, string heading)
        {
            Console.WriteLine(heading);
            Console.WriteLine("--------------");
            Console.WriteLine("List of accounts and balances:");
            foreach (var acct in accts)
                Console.WriteLine(acct);
            Console.WriteLine();

            Console.WriteLine("List of account names:");
            foreach (var acct in accts)
                Console.WriteLine(acct.Name);

            Console.Write("\nTotal Balance = ");
            decimal balance = 0;
            foreach (var acct in accts)
                balance += acct.Balance;
            Console.WriteLine($"{balance:C}\n");
        }
    }
}
