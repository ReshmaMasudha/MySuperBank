using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Reshma",100000000);
            Console.WriteLine($"a new account {account.number} is opened for {account.owner} with a balance of {account.Balance}");

            account.MakeWithdrawal(120, DateTime.Now, "Me");
            Console.WriteLine(account.Balance);
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.accounthistory());
           
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
