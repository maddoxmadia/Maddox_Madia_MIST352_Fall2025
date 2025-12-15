/* Maddox Madia
HW3
MIST351
12/2/25*/

using System;

public class Program
{
    // Helper method to read integer
    static int ReadInt(string strPrompt)
    {
        Console.Write(strPrompt);
        int intValue;
        while (!int.TryParse(Console.ReadLine(), out intValue))
        {
            Console.Write("Invalid. " + strPrompt);
        }
        return intValue;
    }

    // Helper method to read non-empty string
    static string ReadNonEmpty(string strPrompt)
    {
        Console.Write(strPrompt);
        string strText = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(strText))
        {
            Console.Write("Invalid. " + strPrompt);
            strText = Console.ReadLine();
        }
        return strText.Trim();
    }

    // Helper method to read email
    static string ReadEmail(string strPrompt)
    {
        Console.Write(strPrompt);
        string strEmail = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(strEmail) || !strEmail.Contains("@"))
        {
            Console.Write("Invalid email. " + strPrompt);
            strEmail = Console.ReadLine();
        }
        return strEmail.Trim();
    }

    // Helper method to ask Yes/No
    static bool AskYesNo(string strPrompt)
    {
        Console.Write(strPrompt);
        string strAnswer = Console.ReadLine().Trim().ToUpper();
        return strAnswer == "Y" || strAnswer == "YES";
    }

    // Show menu
    static void ShowMenu()
    {
        Console.WriteLine("\nWelcome to the Workshop Reservation System.");
        Console.WriteLine("\nPlease choose an option:");
        Console.WriteLine("1) Assign Premium seat");
        Console.WriteLine("2) Assign Standard seat");
        Console.WriteLine("3) Display status of all seats");
        Console.WriteLine("4) Exit");
        Console.WriteLine("9) DEBUG: Auto-fill all seats (optional)");
    }

    // Method to handle assigning Premium seat
    static void AssignPremiumSeatOption(WorkshopSession objSession)
    {
        // Check if workshop completely full
        if (objSession.IsWorkshopFull())
        {
            Console.WriteLine("Workshop is full.");
            return;
        }

        // Get participant info
        int intId = ReadInt("Enter ID: ");
        string strName = ReadNonEmpty("Enter Name: ");
        string strEmail = ReadEmail("Enter Email: ");

        // Create participant
        Participant objParticipant = new Participant(intId, strName, strEmail);

        // Try to assign Premium
        bool blnSuccess = objSession.AssignPremiumSeat(objParticipant);

        if (blnSuccess)
        {
            Console.WriteLine("Premium seat assigned.");
        }
        else
        {
            // Premium is full
            if (objSession.IsStandardFull())
            {
                Console.WriteLine("Next workshop starts in 3 hours.");
            }
            else
            {
                bool blnTryStandard = AskYesNo("Premium is full. Assign Standard instead? (Y/N): ");
                if (blnTryStandard)
                {
                    bool blnStandardSuccess = objSession.AssignStandardSeat(objParticipant);
                    if (blnStandardSuccess)
                    {
                        Console.WriteLine("Standard seat assigned.");
                    }
                    else
                    {
                        Console.WriteLine("Could not assign seat.");
                    }
                }
                else
                {
                    Console.WriteLine("Next workshop starts in 3 hours.");
                }
            }
        }
    }

    // Method to handle assigning Standard seat
    static void AssignStandardSeatOption(WorkshopSession objSession)
    {
        // Check if workshop completely full
        if (objSession.IsWorkshopFull())
        {
            Console.WriteLine("Workshop is full.");
            return;
        }

        // Get participant info
        int intId = ReadInt("Enter ID: ");
        string strName = ReadNonEmpty("Enter Name: ");
        string strEmail = ReadEmail("Enter Email: ");

        // Create participant
        Participant objParticipant = new Participant(intId, strName, strEmail);

        // Try to assign Standard
        bool blnSuccess = objSession.AssignStandardSeat(objParticipant);

        if (blnSuccess)
        {
            Console.WriteLine("Standard seat assigned.");
        }
        else
        {
            // Standard is full
            if (objSession.IsPremiumFull())
            {
                Console.WriteLine("Next workshop starts in 3 hours.");
            }
            else
            {
                bool blnTryPremium = AskYesNo("Standard is full. Assign Premium instead? (Y/N): ");
                if (blnTryPremium)
                {
                    bool blnPremiumSuccess = objSession.AssignPremiumSeat(objParticipant);
                    if (blnPremiumSuccess)
                    {
                        Console.WriteLine("Premium seat assigned.");
                    }
                    else
                    {
                        Console.WriteLine("Could not assign seat.");
                    }
                }
                else
                {
                    Console.WriteLine("Next workshop starts in 3 hours.");
                }
            }
        }
    }

    // MAIN METHOD
    public static void Main()
    {
        // Create workshop session
        WorkshopSession objSession = new WorkshopSession("MIST352 Workshop");

        bool blnRunning = true;

        while (blnRunning)
        {
            ShowMenu();
            int intChoice = ReadInt("Your choice: ");

            switch (intChoice)
            {
                case 1:
                    AssignPremiumSeatOption(objSession);
                    break;

                case 2:
                    AssignStandardSeatOption(objSession);
                    break;

                case 3:
                    objSession.DisplayAllSeats();
                    break;

                case 4:
                    blnRunning = false;
                    break;

                case 9:
                    DebugFillAllSeats(objSession);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3, 4, or 9.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the system.");
    }

    /// <summary>
    /// DEBUG METHOD – Automatically fills all seats in the workshop.
    /// --------------------------------------------------------------
    /// This method is used ONLY for testing and grading. It allows you
    /// to instantly fill all Premium and Standard seats without typing
    /// 20 participants manually.
    ///
    /// HOW IT WORKS:
    /// 1. Starts with ID = 9000 and increments for each debug participant.
    /// 2. While the workshop still has empty seats:
    ///    • If Premium section still has free seats → try Premium first.
    ///    • Otherwise → fill Standard section.
    /// 3. Creates a Participant object with:
    ///       ID    = nextId
    ///       Name  = "Premium_Debug_ID" or "Standard_Debug_ID"
    ///       Email = "premiumID@test.com" or "standardID@test.com"
    /// 4. Attempts to assign the participant to the preferred section:
    ///    - If assignment succeeds → continue.
    ///    - If assignment fails (section just filled):
    ///         • If Premium failed  → try Standard (if not full)
    ///         • If Standard failed → try Premium (if not full)
    /// 5. This logic guarantees:
    ///    - Every seat gets filled.
    ///    - No seat is overwritten.
    ///    - No infinite loops or invalid assignments.
    /// 6. When complete, prints: "DEBUG: All seats auto-filled."
    ///
    /// WHY THIS EXISTS:
    /// • Makes grading MUCH faster (fills full workshop in < 1 second)
    /// • You can test DisplayAllSeats() instantly.
    /// • Allows you to spot layout errors, timestamp issues,
    ///   and booking logic problems immediately.
    ///
    /// PARAMETERS:
    ///   <param name="session">
    ///     The WorkshopSession object the method will operate on.
    ///     Must already be created in Main(). This object contains:
    ///       - The 20 Seat objects
    ///       - All section/row information
    ///       - Seat-booking methods used internally
    ///   </param>
    ///
    /// RETURNS:
    ///   <returns>
    ///     This method does not return a value (void). It updates the state
    ///     of the WorkshopSession object by filling every empty seat with
    ///     auto-generated Participant objects.
    ///   </returns>
    ///
    /// NOTE:
    ///   • Do NOT modify this method.
    ///   • You must enable this by pressing option 9 (or similar) from the menu.
    /// </summary>
    static void DebugFillAllSeats(WorkshopSession session)
    {
        int nextId = 9000;

        while (!session.IsWorkshopFull())
        {
            bool preferPremium = !session.IsPremiumFull();

            string section = preferPremium ? "Premium" : "Standard";
            Participant p = new Participant(
                nextId,
                section + "_Debug_" + nextId,
                section.ToLower() + nextId + "@test.com"
            );

            bool assigned = preferPremium
                ? session.AssignPremiumSeat(p)
                : session.AssignStandardSeat(p);

            if (!assigned)
            {
                if (preferPremium && !session.IsStandardFull())
                    session.AssignStandardSeat(p);
                else if (!preferPremium && !session.IsPremiumFull())
                    session.AssignPremiumSeat(p);
            }

            nextId++;
        }

        Console.WriteLine("DEBUG: All seats auto-filled.\n");
    }
}