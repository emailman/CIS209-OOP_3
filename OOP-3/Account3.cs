using System;

namespace OOP_3
{
    class Account3
    {
        public string Name { get; }
        public decimal Balance { get; private set; }

        public Account3(string acctName, decimal acctBalance = 0)
        {
            Name = acctName;
            Balance = acctBalance;
        }

        public void Deposit(decimal amt)
        {
            Balance += amt;
        }

        public void Withdraw(decimal amt)
        {
            if (Balance - amt >= 0)
                Balance -= amt;
            else
                throw new ArgumentOutOfRangeException("Can't withdaw more than balance");
        }

        override public string ToString()
        {
            return $"Account: {Name} / Balance = {Balance:C}";
        }
    }
}
