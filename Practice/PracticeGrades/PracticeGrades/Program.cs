//Asks user for multiple grades, evaluates and summarizes. 
namespace PracticeGrades;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many grades do you have?");
        //Read number of grades as interger (conversion is needed)
        int intNoGrades = Convert.ToInt32(Console.ReadLine());
        //Variables to summarize letter grades
        int intAs = 0, intBs = 0, intCs = 0, intDs = 0, intFs = 0;
        //Create an array of doubles with the specified number of grades.
        double[] dblGrades = new double[intNoGrades];
        char[] chrLetterGrades = new char[intNoGrades];

        //Collecting grades and storing in the array
        for (int intIndex = 0; intIndex < dblGrades.Length; intIndex++)
        {
            Console.WriteLine($"What is grade no. {intIndex + 1}?");
            dblGrades[intIndex] = Double.Parse(Console.ReadLine());
        }

        //Evaluation
        for (int intIndex = 0; intIndex < dblGrades.Length; intIndex++)
        {
            if (dblGrades[intIndex] >= 90)
            {
                chrLetterGrades[intIndex] = 'A';
                intAs++;
            }
            else if (dblGrades[intIndex] >= 80)
            {
                chrLetterGrades[intIndex] = 'B';
                intBs++;
            }
            else if (dblGrades[intIndex] >= 70)
            {
                chrLetterGrades[intIndex] = 'C';
                intCs++;
            }
            else if (dblGrades[intIndex] >= 60)
            {
                chrLetterGrades[intIndex] = 'D';
                intDs++;
            }
            else
            {
                chrLetterGrades[intIndex] = 'F';
                intFs++;
            }
        }
        //Summarize grades
        Console.WriteLine($"No. of As\t\t{intAs}\nN.o of Bs\t\t{intBs}\nNo. of Cs\t\t{intCs}\nNo. of Ds\t\t{intDs}\nNo. of Fs\t\t{intFs}\n");
    }
}
