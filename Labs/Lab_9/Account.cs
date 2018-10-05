using System;
using System.Text;

namespace Lab_9
{
    public class Account
    {
        private const int TRANSIT_NUMBER = 314;
        static int CurrentAccountNumber;

        public readonly string Number;

        public double Balance { get; private set; }

        public string[] Names { get; private set; } = new string[10];

        static Account()
        {
            CurrentAccountNumber = 100000;
        }
    
        private Account(string number, string name, double balance = 0)
        {
            Number = number;
            Balance = balance;
            Names[0] = name;
        }

        public static Account CreateAccount(string name, double balance = 0)
        {
            var accountNumber = $"AC-{TRANSIT_NUMBER}-{CurrentAccountNumber}";
            CurrentAccountNumber++;

            return new Account(accountNumber, name, balance);
        }

        public void AddName(string name)
        {
            foreach (var s in Names)
            { 
                if (s != null && s.Equals(name))
                {
                    throw new ArgumentException("Name already exists in a collection of names");
                }
            }

            for (var i = 0; i < Names.Length; i++)
            {
                if (Names[i] == null)
                {
                    Names[i] = name;

                    break;
                }
            }
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > 250)
            {
                throw new ArgumentException("Withdrawal amount could not be more than 250$");
            }

            if (Balance - amount < 0)
            {
                throw new ArgumentException("Not enough funds");
            }

            Balance -= amount;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(150);
            stringBuilder.Append($"Account number: {Number}\n");
            stringBuilder.Append($"Balance: {Balance}\n");
            stringBuilder.Append("Associated names: ");
            foreach (var name in Names)
            {
                if (name != null)
                {
                    stringBuilder.Append($"{name}, ");
                }
            }

            return stringBuilder.ToString();
        }
    }
}