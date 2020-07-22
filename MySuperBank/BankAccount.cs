using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    class BankAccount
    {
        public string number { get; }

        public string owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private int accountSeed { get; set; } = 123456;
        public BankAccount(string name,decimal initialBalance)
        {
            this.owner = name;
            this.number = accountSeed.ToString();
            accountSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "initial balance");
           
        }

        private List<Transaction> allTransactions = new List<Transaction>();


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("insufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string accounthistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date }\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}
