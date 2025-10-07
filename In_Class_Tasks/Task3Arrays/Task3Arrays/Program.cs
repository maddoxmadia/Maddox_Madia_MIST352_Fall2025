/* 
* Thursday 9/11/2025
*
*/
namespace Task3Arrays;

class Program
{
    static void Main(string[] args)
    {
        // Define an array of grades and assessments
        string[] strAssessments = { "Task1", "HW1", "Task2", "Quiz1", "Exam1", "HW2", "task3", "QUIZ2" };
        float[] fltGrades = { 90, 88, 70, 95, 60, 50, 77, 50 };

        // For loop top access/read/manipulate contents of the array
        Console.WriteLine("Print out all arrays contents");
        for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
        {
            Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");
        }

        Console.WriteLine("=============================");
        Console.WriteLine("Print out homeworks only and thier grades");

        for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
        {
            if (strAssessments[intIndex].Contains("HW"))
            {
                Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");

            }
        }
        Console.WriteLine("=============================");
        Console.WriteLine("Print out homeworks and tasks only and thier grades");

        for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
        {
            if (strAssessments[intIndex].ToLower().Contains("HW".ToLower()) || strAssessments[intIndex].ToLower().Contains("Task".ToLower())) ;
            {
                Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");
            }
            Console.WriteLine("=============================");
            Console.WriteLine("Print out homeworks and tasks only and thier grades. Fancy");


        }
        for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
        {
            if (strAssessments[intIndex].ToLower().Contains("HW".ToLower()) || strAssessments[intIndex].ToLower().Contains("Task".ToLower())) ;
            {
                Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");
            }
        }
    }
}

