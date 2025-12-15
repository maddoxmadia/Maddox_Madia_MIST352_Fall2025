/* Maddox Madia
HW3_LLM
12/14/25
ChatGPT was used
Prompt: 
Im making a workshop reservation system for in C#, please write out all of the code for me including the main method and 4 files.

Setup: 20 seats total, 10 rows with 2 seats each. Rows 1-5 are Premium, rows 6-10 are Standard.

Make these 3 classes:

Participant - fields intId, strName, strEmail (private). Two constructors one with id and name, one with id name and email. Properties Id (get only), Name and Email (get and set). Validate ID greater than 0, name not empty, email has @.

Seat - fields intRowNumber, intSeatNumber, strSectionType, blnIsBooked, objAssignedParticipant, dtReservationTime (private). Constructor takes row, seat, section. All properties read only. Method AssignParticipant returns bool and sets DateTime.Now. Method GetSeatStatus returns "FREE" or "TAKEN by [name] (ID [id]) at [time]" formatted as MM/dd/yyyy hh:mm tt.

WorkshopSession - field arrSeats array of 20 Seats, strName, intMaxSeats (private). Constructor takes just name and creates all 20 seats. Methods AssignPremiumSeat (rows 1-5), AssignStandardSeat (rows 6-10), IsPremiumFull, IsStandardFull, IsWorkshopFull, DisplayAllSeats.

Program.cs menu:
1) Assign Premium seat
2) Assign Standard seat
3) Display all seats
4) Exit
9) Auto-fill (debug)

If a section is full ask user "Premium is full. Assign Standard instead? (Y/N)" or vice versa. If they say no print "Next workshop starts in 3 hours."

Include helper methods ReadInt, ReadNonEmpty, ReadEmail, AskYesNo.

Include this debug method exactly as is:
static void DebugFillAllSeats(WorkshopSession session)
{
    int nextId = 9000;
    while (!session.IsWorkshopFull())
    {
        bool preferPremium = !session.IsPremiumFull();
        string section = preferPremium ? "Premium" : "Standard";
        Participant p = new Participant(nextId, section + "_Debug_" + nextId, section.ToLower() + nextId + "@test.com");
        bool assigned = preferPremium ? session.AssignPremiumSeat(p) : session.AssignStandardSeat(p);
        if (!assigned)
        {
            if (preferPremium && !session.IsStandardFull()) session.AssignStandardSeat(p);
            else if (!preferPremium && !session.IsPremiumFull()) session.AssignPremiumSeat(p);
        }
        nextId++;
    }
    Console.WriteLine("DEBUG: All seats auto-filled.\n");
}

Use this naming: int variables = intId, string = strName, bool = blnIsBooked, objects = objParticipant, arrays = arrSeats, DateTime = dtReservationTime.

Throw ArgumentException for invalid inputs.

Give me complete code for Participant.cs, Seat.cs, WorkshopSession.cs, and Program.cs.
*/

namespace HW3_LLM;

using System;

class Program
{
    static void Main()
    {
        WorkshopSession session = new WorkshopSession("C# Workshop");

        while (true)
        {
            Console.WriteLine("1) Assign Premium seat");
            Console.WriteLine("2) Assign Standard seat");
            Console.WriteLine("3) Display all seats");
            Console.WriteLine("4) Exit");
            Console.WriteLine("9) Auto-fill (debug)");

            int choice = ReadInt("Choose option: ");

            if (choice == 4) break;

            try
            {
                switch (choice)
                {
                    case 1:
                        AssignSeat(session, true);
                        break;
                    case 2:
                        AssignSeat(session, false);
                        break;
                    case 3:
                        session.DisplayAllSeats();
                        break;
                    case 9:
                        DebugFillAllSeats(session);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
        }
    }

    static void AssignSeat(WorkshopSession session, bool premium)
    {
        if (premium && session.IsPremiumFull())
        {
            if (AskYesNo("Premium is full. Assign Standard instead? (Y/N): "))
                premium = false;
            else
            {
                Console.WriteLine("Next workshop starts in 3 hours.\n");
                return;
            }
        }

        if (!premium && session.IsStandardFull())
        {
            if (AskYesNo("Standard is full. Assign Premium instead? (Y/N): "))
                premium = true;
            else
            {
                Console.WriteLine("Next workshop starts in 3 hours.\n");
                return;
            }
        }

        int id = ReadInt("Enter ID: ");
        string name = ReadNonEmpty("Enter name: ");
        string email = ReadEmail("Enter email: ");

        Participant p = new Participant(id, name, email);

        bool success = premium ? session.AssignPremiumSeat(p)
                               : session.AssignStandardSeat(p);

        if (!success) Console.WriteLine("Seat assignment failed.\n");
    }

    static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.Parse(Console.ReadLine());
    }

    static string ReadNonEmpty(string prompt)
    {
        Console.Write(prompt);
        string value = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Input cannot be empty.");
        return value;
    }

    static string ReadEmail(string prompt)
    {
        Console.Write(prompt);
        string value = Console.ReadLine();
        if (!value.Contains("@")) throw new ArgumentException("Invalid email.");
        return value;
    }

    static bool AskYesNo(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine().ToUpper();
        return input == "Y";
    }

    static void DebugFillAllSeats(WorkshopSession session)
    {
        int nextId = 9000;
        while (!session.IsWorkshopFull())
        {
            bool preferPremium = !session.IsPremiumFull();
            string section = preferPremium ? "Premium" : "Standard";
            Participant p = new Participant(nextId, section + "_Debug_" + nextId, section.ToLower() + nextId + "@test.com");
            bool assigned = preferPremium ? session.AssignPremiumSeat(p) : session.AssignStandardSeat(p);
            if (!assigned)
            {
                if (preferPremium && !session.IsStandardFull()) session.AssignStandardSeat(p);
                else if (!preferPremium && !session.IsPremiumFull()) session.AssignPremiumSeat(p);
            }
            nextId++;
        }
        Console.WriteLine("DEBUG: All seats auto-filled.\n");
    }
}
