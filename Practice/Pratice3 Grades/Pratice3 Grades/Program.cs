namespace Pratice3_Grades;

class Program
{
    static void Main(string[] args)
    {
        String strNamedblGPA;
        Console.WriteLine("Give me your name");
        strName = Console.ReadLine();
        double dblGrade1, dblGrade2, dblGrade3;

        //Accept Grade1
        Console.WriteLine("Give me your Grade 1?");
        dblGrade1 = Double.Parse(Console.ReadLine());

        //Accept Grade2
        Console.WriteLine("Give me your Grade 2?");
        dblGrade2 = Double.Parse(Console.ReadLine());

        //Accept Grade3
        Console.WriteLine("Give me your Grade 3?");
        dblGrade3 = Double.Parse(Console.ReadLine());

        double dblGPA = (dblGrade1 + dblGrade2 + dblGrade3) / 3;

        Console.WriteLine($"Hello {strName} the 4.0 scale gpa of your grades {dblGrade1}, {dblGrade2}, and {dblGrade3} is {dblGPA}");

        bool blnFail = true;
        Console.WriteLine($"Failed? {blnFail}");

    }
}
