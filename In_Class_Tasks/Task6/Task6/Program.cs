/*Maddox Madia
MIST 352
11/4//25
Task6*/

using System;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 6: Classes Demo ===\n");

            // ===== CARS SECTION =====
            Car car1 = new Car();
            Car car2 = new Car("Honda", "Civic");
            Car car3 = new Car("Toyota", "Camry", 2020);

            Console.WriteLine("CARS:");
            car1.DisplayInfo();
            car2.DisplayInfo();
            car3.DisplayInfo();

            // ===== EMPLOYEES SECTION =====
            Employee emp1 = new Employee();
            Employee emp2 = new Employee("John Smith");
            Employee emp3 = new Employee("Jane Doe", 25.50, 35);

            Console.WriteLine("\nEMPLOYEES:");
            emp1.DisplaySummary();
            emp2.DisplaySummary();
            emp3.DisplaySummary();

            // ===== ACCOUNTS SECTION =====
            Account acc1 = new Account();
            Account acc2 = new Account(12345, "Alice Johnson");
            Account acc3 = new Account(67890, "Bob Williams", 1000.00);

            Console.WriteLine("\nACCOUNTS:");
            acc1.DisplayInfo();
            acc2.DisplayInfo();
            acc3.DisplayInfo();

            // Test deposit and withdraw
            Console.WriteLine("\n--- Testing Deposit and Withdraw ---");
            acc2.Deposit(500.00);
            acc2.Withdraw(200.00);
            acc3.Withdraw(1500.00);  // This should fail (insufficient funds)
            acc3.Withdraw(300.00);   // This should succeed

            Console.WriteLine("\n--- Final Account Balances ---");
            acc2.DisplayInfo();
            acc3.DisplayInfo();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}