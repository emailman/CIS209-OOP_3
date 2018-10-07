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
            Transaction(accounts, "Dopey", "Withdraw", 150);
            Transaction(accounts, "Sleepy", "Deposit", 100);
            Transaction(accounts, "Sneezy", "Withdraw", 350);
            
            Reports(accounts, "\nClosing Report");
        }

        static void Transaction(List<Account3> accts, string acctName, string transactType, decimal transactAmt)
        {
            // Find the index for the account name
            int i;
            for (i = 0; i < accts.Count; i++)
                if (accts[i].Name == acctName)
                    break;

            try
            {
                if (transactType == "Deposit")
                {
                    accts[i].Deposit(transactAmt);
                    Console.WriteLine($"{accts[i].Name}: Deposit {transactAmt:C}");
                }
                else
                {
                    accts[i].Withdraw(transactAmt);
                    Console.WriteLine($"{accts[i].Name}: Withdraw {transactAmt:C}");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"{accts[i].Name}: {e.ParamName}");
                Console.WriteLine($"\tRequested {transactType}: {transactAmt:C} / Account Balance: {accts[2].Balance:C}");
            }
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
