/* Name: Maddox Madia
* Class: MIST 352 Fall 2025
* 9/8/25
*This program prompts the user for hero's name and quest
*/

using System.ComponentModel.DataAnnotations;

namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        // Define variables
        string strHeroName, strFavoritePlace, strLuckyNumberText;

        Console.WriteLine("What is your name?");
        Console.Write("Hero name:  ");
        strHeroName = Console.ReadLine().Trim();

        Console.WriteLine("What is your favorite place?");
        Console.Write("Favorite place:  ");
        strFavoritePlace = Console.ReadLine().Trim();

        Console.WriteLine("What is your lucky number?");
        Console.Write("Lucky number:  ");
        strLuckyNumberText = Console.ReadLine().Trim();
        bool parseOkay = int.TryParse(strLuckyNumberText, out int LuckyNumber);

        // Line 1 Meet heroName + !
        string line1 = "Meet" + strHeroName.ToUpper() + "!";
        // Line 2 Today's quest starts in
        string line2 = "Today your quest starts in " + strFavoritePlace + ".";
        // Line 3 "LuckyNumber" + luckynumber
        string line3 = "Lucky Number: " + strLuckyNumberText;
        // Build nick
        string Nick = strHeroName.Length >= 3 ? strHeroName.Substring(0, 3).ToUpper() : strHeroName.ToUpper();

        // Build code
        string Code = "#" + Nick + "-" + strLuckyNumberText;

        // Build strings + NEWLINE
        string report = line1 + Environment.NewLine + line2 + Environment.NewLine + line3 + Environment.NewLine + Code;

        // Print report
        Console.WriteLine(report);

        // Print parse success & parseOkay
        Console.WriteLine("Parse success:" + parseOkay);
        Console.WriteLine("Hero length:" + strHeroName.Length);
        Console.WriteLine("Place contains a space: " + (strFavoritePlace.IndexOf(" ") >= 0));

    }
}
