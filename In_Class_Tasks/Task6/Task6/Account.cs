using System;

namespace Task6
{
    internal class Account
    {
        // Properties
        public int AccountNumber { get; set; }
        public string Owner { get; set; }
        public double Balance { get; set; }

        // Constructor 1: Default
        public Account()
        {
            AccountNumber = 0;
            Owner = "Unknown";
            Balance = 0.0;
        }

        // Constructor 2: Number and Owner
        public Account(int number, string owner)
        {
            AccountNumber = number;
            Owner = owner;
            Balance = 0.0;
        }

        // Constructor 3: All parameters
        public Account(int number, string owner, double balance)
        {
            AccountNumber = number;
            Owner = owner;
            
            // Validate balance is not negative
            if (balance >= 0)
            {
                Balance = balance;
            }
            else
            {
                Balance = 0.0;  // Set to 0 if negative
            }
        }

        // Deposit money into account
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited ${amount:F2}. New balance: ${Balance:F2}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        // Withdraw money from account
        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${Balance:F2}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds. Cannot withdraw.");
                }
            }
            else
            {
                Console.WriteLine("Withdrawal amount must be positive.");
            }
        }

        // Display account information
        public void DisplayInfo()
        {
            Console.WriteLine($"Account #{AccountNumber} - Owner: {Owner}, Balance: ${Balance:F2}");
        }
    }
}