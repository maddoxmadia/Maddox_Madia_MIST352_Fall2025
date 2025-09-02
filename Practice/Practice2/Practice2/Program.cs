/*
*Maddox Madia
*MIST352-002
*Tuesday 9/2/25
*Pseudo code example 1 - Sums two variables
*/
namespace Practice2;

class Program
{
    static void Main(string[] args)
    {
        //defined two variables
        double dblVal1, dblVal2;

        //Ask user for input 1
        Console.WriteLine("Give me value 1");
        dblVal1 = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine(dblVal1);

        //Ask user for input 2
        Console.WriteLine("Give me value 2");
        dblVal2 = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine(dblVal2);

        Console.WriteLine(dblVal1 + dblVal2);
        Console.WriteLine($7"The sum of {dblVal1} and {dblVal2} is {dblVal1 + dblVal2}");

                //defined two variables
       /* double dblVal1, dblVal2;

        //Ask user for input 1
        Console.WriteLine("Give me value 1");
        dblVal1 = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine(dblVal1);

        //Ask user for input 2
        Console.WriteLine("Give me value 2");
        dblVal2 = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine(dblVal2);

        Console.WriteLine(dblVal1 + dblVal2);
        Console.WriteLine($7"The sum of {dblVal1} and {dblVal2} is {dblVal1 + dblVal2}");*\
    }
}
