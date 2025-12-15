using System;

public class WorkshopSession
{
    // Private fields
    private Seat[] arrSeats;
    private string strName;
    private int intMaxSeats;

    // Constructor
    public WorkshopSession(string strName)
    {
        this.strName = strName;
        this.intMaxSeats = 20;
        arrSeats = new Seat[20];

        // Create all 20 seats
        int intIndex = 0;
        for (int intRow = 1; intRow <= 10; intRow++)
        {
            for (int intSeat = 1; intSeat <= 2; intSeat++)
            {
                string strSection;
                if (intRow <= 5)
                {
                    strSection = "Premium";
                }
                else
                {
                    strSection = "Standard";
                }

                arrSeats[intIndex] = new Seat(intRow, intSeat, strSection);
                intIndex = intIndex + 1;
            }
        }
    }

    // Property for Seats
    public Seat[] Seats
    {
        get { return arrSeats; }
    }

    // Private helper method to find first available seat in a range
    private int FindFirstAvailableSeat(int intStartRow, int intEndRow)
    {
        for (int intIndex = 0; intIndex < arrSeats.Length; intIndex++)
        {
            Seat objSeat = arrSeats[intIndex];
            if (objSeat.RowNumber >= intStartRow && objSeat.RowNumber <= intEndRow)
            {
                if (!objSeat.IsBooked)
                {
                    return intIndex;
                }
            }
        }
        return -1;
    }

    // Method to assign Premium seat
    public bool AssignPremiumSeat(Participant objParticipant)
    {
        int intIndex = FindFirstAvailableSeat(1, 5);
        if (intIndex == -1)
        {
            return false;
        }

        return arrSeats[intIndex].AssignParticipant(objParticipant);
    }

    // Method to assign Standard seat
    public bool AssignStandardSeat(Participant objParticipant)
    {
        int intIndex = FindFirstAvailableSeat(6, 10);
        if (intIndex == -1)
        {
            return false;
        }

        return arrSeats[intIndex].AssignParticipant(objParticipant);
    }

    // Method to check if Premium section is full
    public bool IsPremiumFull()
    {
        int intIndex = FindFirstAvailableSeat(1, 5);
        return intIndex == -1;
    }

    // Method to check if Standard section is full
    public bool IsStandardFull()
    {
        int intIndex = FindFirstAvailableSeat(6, 10);
        return intIndex == -1;
    }

    // Method to check if entire workshop is full
    public bool IsWorkshopFull()
    {
        for (int intIndex = 0; intIndex < arrSeats.Length; intIndex++)
        {
            if (!arrSeats[intIndex].IsBooked)
            {
                return false;
            }
        }
        return true;
    }

    // Method to display all seats
    public void DisplayAllSeats()
    {
        Console.WriteLine("\nWorkshop: " + strName);
        Console.WriteLine("----------------------------------------------------");

        for (int intIndex = 0; intIndex < arrSeats.Length; intIndex++)
        {
            Seat objSeat = arrSeats[intIndex];
            Console.WriteLine("Row " + objSeat.RowNumber + ", Seat " + objSeat.SeatNumber + 
                            " (" + objSeat.SectionType + ") - " + objSeat.GetSeatStatus());
        }

        Console.WriteLine("----------------------------------------------------");
    }
}