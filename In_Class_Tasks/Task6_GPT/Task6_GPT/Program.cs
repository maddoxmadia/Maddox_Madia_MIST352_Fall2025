/* Maddox Madia
CHATGPT Task6
Prompt:
"I need help with a C# assignment. Please create three classes for me:

1. Car Class with:
   - Properties: Make, Model, Year
   - Three constructors: default (sets generic values), one that takes make and model (uses current year), and one that takes all three parameters (validates year between 1900 and current year)
   - DisplayInfo() method that prints the car's information

2. Employee Class with:
   - Properties: Name, HourlyRate, HoursWorked
   - Three constructors: default (sets "New Hire" and default pay values), one that takes name only (uses default hourly pay), and one that takes all three parameters (validates rate and hours are positive)
   - DisplaySummary() method that displays name and calculated yearly salary (hourly rate × hours × 52 weeks)

3. Account Class with:
   - Properties: AccountNumber, Owner, Balance
   - Three constructors: default (unknown owner, zero balance), one that takes number and owner (balance starts at 0), and one that takes all three (validates balance is not negative)
   - Deposit(double amount) method that adds to balance if positive
   - Withdraw(double amount) method that deducts if funds available (no overdraft)
   - DisplayInfo() method that prints account details

In the Main method, create 3 objects from each class using different constructors and display their information. Also test the Deposit and Withdraw methods on the accounts.

Please provide complete, working C# code."

The differences I noticed:
Chat provided me with code that displayed account number as a string instead of an int, and also had me put in employee hours worked as a double instead of an int. It also formatted my if-else statements differently.
*/

namespace Task6_GPT;

class Program
{
    static void Main(string[] args)
    {
        using System;

namespace Assignment
{
    // ------------------ Car Class ------------------
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

```
    // Default constructor
    public Car()
        {
            Make = "Generic";
            Model = "Car";
            Year = DateTime.Now.Year;
        }

        // Constructor with Make and Model only
        public Car(string make, string model)
        {
            Make = make;
            Model = model;
            Year = DateTime.Now.Year;
        }

        // Constructor with all three parameters
        public Car(string make, string model, int year)
        {
            if (year < 1900 || year > DateTime.Now.Year)
                year = DateTime.Now.Year;

            Make = make;
            Model = model;
            Year = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Car: {Year} {Make} {Model}");
        }
    }

    // ------------------ Employee Class ------------------
    public class Employee
    {
        public string Name { get; set; }
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        // Default constructor
        public Employee()
        {
            Name = "New Hire";
            HourlyRate = 15.00;
            HoursWorked = 40.0;
        }

        // Constructor with Name only
        public Employee(string name)
        {
            Name = name;
            HourlyRate = 15.00;
            HoursWorked = 40.0;
        }

        // Constructor with all three parameters
        public Employee(string name, double hourlyRate, double hoursWorked)
        {
            Name = name;
            HourlyRate = hourlyRate > 0 ? hourlyRate : 15.00;
            HoursWorked = hoursWorked > 0 ? hoursWorked : 40.0;
        }

        public void DisplaySummary()
        {
            double yearlySalary = HourlyRate * HoursWorked * 52;
            Console.WriteLine($"Employee: {Name}, Yearly Salary: ${yearlySalary:F2}");
        }
    }

    // ------------------ Account Class ------------------
    public class Account
    {
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        public double Balance { get; private set; }

        // Default constructor
        public Account()
        {
            AccountNumber = "000000";
            Owner = "Unknown";
            Balance = 0.0;
        }

        // Constructor with AccountNumber and Owner
        public Account(string accountNumber, string owner)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = 0.0;
        }

        // Constructor with all three parameters
        public Account(string accountNumber, string owner, double balance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = balance >= 0 ? balance : 0.0;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
                Balance += amount;
            else
                Console.WriteLine("Deposit amount must be positive.");
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
                Balance -= amount;
            else
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Account #{AccountNumber}, Owner: {Owner}, Balance: ${Balance:F2}");
        }
    }

    // ------------------ Main Program ------------------
    class Program
    {
        static void Main(string[] args)
        {
            // Car objects
            Car car1 = new Car();
            Car car2 = new Car("Toyota", "Camry");
            Car car3 = new Car("Ford", "Mustang", 1968);

            car1.DisplayInfo();
            car2.DisplayInfo();
            car3.DisplayInfo();
            Console.WriteLine();

            // Employee objects
            Employee emp1 = new Employee();
            Employee emp2 = new Employee("Alice");
            Employee emp3 = new Employee("Bob", 25.50, 38);

            emp1.DisplaySummary();
            emp2.DisplaySummary();
            emp3.DisplaySummary();
            Console.WriteLine();

            // Account objects
            Account acc1 = new Account();
            Account acc2 = new Account("123456", "Maddox");
            Account acc3 = new Account("789012", "Alex", 500.00);

            acc1.DisplayInfo();
            acc2.DisplayInfo();
            acc3.DisplayInfo();
            Console.WriteLine();

            // Test deposit and withdraw
            acc3.Deposit(200);
            acc3.Withdraw(100);
            acc3.DisplayInfo();
        }
    }
```

}

}
