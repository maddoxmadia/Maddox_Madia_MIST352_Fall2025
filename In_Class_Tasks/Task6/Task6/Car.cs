using System;

namespace Task6
{
    internal class Car
    {
        // Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        // Constructor 1: Default
        public Car()
        {
            Make = "Unknown";
            Model = "Unknown";
            Year = DateTime.Now.Year;
        }

        // Constructor 2: Make and Model
        public Car(string make, string model)
        {
            Make = make;
            Model = model;
            Year = DateTime.Now.Year;
        }

        // Constructor 3: All parameters
        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            
            if (year >= 1900 && year <= DateTime.Now.Year)
            {
                Year = year;
            }
            else
            {
                Year = DateTime.Now.Year;
            }
        }

        // Display method
        public void DisplayInfo()
        {
            Console.WriteLine($"Car: {Year} {Make} {Model}");
        }
    }
}