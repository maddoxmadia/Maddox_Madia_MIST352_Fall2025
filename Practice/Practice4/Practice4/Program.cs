/* Maddox Madia
*More about strings
*/
using System.ComponentModel;

namespace Practice4;

class Program
{
    static void Main(string[] args)
    {
        String strData = "maddox rae madia";
        Console.WriteLine(strData.Length);
        // remove left side spaces
        //strData = strData.TrimStart();
        // remove left side spaces
        //strData = strData.TrimEnd();
        //Console.WriteLine("Use TrimStart and test");
        //Console.WriteLine(strData);
        //print out the text's length
        //Console.WriteLine(strData.Length);

        //Lets find some data in the text
        //Console.WriteLine(strData.IndexOf(" "));
        //int intIndexofM = strData.IndexOf("S");

        //Console.WriteLine(strData.ToLower());
        //Console.WriteLine(strData.ToUpper());

        //Console.WriteLine(strData.Substring(0));
        Console.WriteLine($"Original name is {strData}");
        int intFirstSpace = strData.IndexOf(' ');
        int intLastSpace = strData.LastIndexOf(' ');
        int intLengthOfMidName = intLastSpace - intFirstSpace;
        Console.WriteLine($"First space is at location {intFirstSpace} and last space is at location {intLastSpace}");
        //Print out everything between location 0 and location intFirstSpace which has the location of the first space
        Console.WriteLine($"The first name is {strData.Substring(0, intFirstSpace)}");
        Console.WriteLine($"The middle name is {strData.Substring(intFirstSpace, intLengthOfMidName)}");
        Console.WriteLine($"The Last name is {strData.Substring(intLastSpace)}");

        //See whether I can make first character in first name uppercase
        String strFirstName = strData.Substring(0, intFirstSpace);
        Console.WriteLine(strFirstName);
        char chrMid = 'A';
        char chrLast = 'B';
        String strBoth = String.Concat(chrMid, chrLast);
        Console.WriteLine(strBoth);
    }
}
