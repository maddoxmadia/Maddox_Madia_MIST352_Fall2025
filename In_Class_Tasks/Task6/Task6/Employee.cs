using System;

namespace Task6
{
    internal class Employee
    {
        // Properties
        public string Name { get; set; }
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        // Constructor 1: Default
        public Employee()
        {
            Name = "New Hire";
            HourlyRate = 15.00;  // Default $15/hour
            HoursWorked = 40;    // Default 40 hours/week
        }

        // Constructor 2: Name only
        public Employee(string name)
        {
            Name = name;
            HourlyRate = 15.00;
            HoursWorked = 40;
        }

        // Constructor 3: All parameters
        public Employee(string name, double rate, int hours)
        {
            Name = name;
            
            // Validate rate is positive
            if (rate > 0)
            {
                HourlyRate = rate;
            }
            else
            {
                HourlyRate = 15.00;  // Default if invalid
            }
            
            // Validate hours is positive
            if (hours > 0)
            {
                HoursWorked = hours;
            }
            else
            {
                HoursWorked = 40;  // Default if invalid
            }
        }

        // Display method - calculates yearly salary
        public void DisplaySummary()
        {
            double yearlySalary = HourlyRate * HoursWorked * 52;  // 52 weeks in a year
            Console.WriteLine($"Employee: {Name} - Yearly Salary: ${yearlySalary:F2}");
        }
    }
}