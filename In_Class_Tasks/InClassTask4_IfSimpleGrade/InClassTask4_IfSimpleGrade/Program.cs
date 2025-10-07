/*
Tuesday 9/16/25
Program to convert a given into a letter grade
*/

using System.Runtime.CompilerServices;

namespace InClassTask4_IfSimpleGrade;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Give me a grade");
        //Accepts double from user, converts string to a dbl
        double dblGrade = Double.Parse(Console.ReadLine());
        char chrLetterGrade;

        if (dblGrade > 100 || dblGrade < 0)
        {
            Console.WriteLine("Invalid Input. Provide a grade between 0 and 100.");
            return;
        }

        if (dblGrade >= 90)
            {
                chrLetterGrade = 'A';
                //Console.WriteLine("A");
            }
            else if (dblGrade >= 80)
            {
                chrLetterGrade = 'B';
                //Console.WriteLine("B");
            }
            else if (dblGrade >= 70)
            {
                chrLetterGrade = 'C';
                //Console.WriteLine("C");
            }
            else if (dblGrade >= 60)
            {
                chrLetterGrade = 'D';
                //Console.WriteLine("D");
            }
            else
            {
                chrLetterGrade = 'F';
                //Console.WriteLine("F");
            }
        Console.WriteLine($"Your grade {dblGrade} is {chrLetterGrade}");
    }
}
