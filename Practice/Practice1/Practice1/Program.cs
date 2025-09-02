
/* Name: Maddox Madia 
* Date: Thursday, 8/28/25
* In class practice
* This program does something
*/

namespace Practice1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to practice 1!");
        Console.WriteLine("This portion shows us how to print things out");
        //---------- Functionality 1 ----------
        Console.WriteLine("You are now in functionality 1");
        Console.WriteLine("A circle with a radius of 1 is 3.14");
        //The formula to calculate area of a circle is r * r * 3.14, where r is radius
        //r stores the radius
        int theRadius = 52;
        //a stores the area
        double theArea = theRadius * theRadius * 3.14;

        String n = "Circle 1";
        //The following 3 lines show different ways to print out the area
        //Console.WriteLine("A circle with a radius of " + r + " is " + a");
        //Console.WriteLine("A circle with a radius of {0} is {1}", r, a);
        //Console.WriteLine("A circle with a radius of {a} is {r}");

        Console.WriteLine($"{n} with a radius of {theRadius} is {theArea}");
        Console.WriteLine("-----------------------");
}
    }
