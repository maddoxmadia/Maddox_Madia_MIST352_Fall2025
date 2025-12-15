using System;

public class WorkshopSession
{
    private Seat[] arrSeats;
    private string strName;
    private int intMaxSeats;

    public WorkshopSession(string name)
    {
        strName = name;
        intMaxSeats = 20;
        arrSeats = new Seat[intMaxSeats];

        int index = 0;
        for (int row = 1; row <= 10; row++)
        {
            for (int seat = 1; seat <= 2; seat++)
            {
                string section = row <= 5 ? "Premium" : "Standard";
                arrSeats[index++] = new Seat(row, seat, section);
            }
        }
    }

    public bool AssignPremiumSeat(Participant objParticipant)
    {
        foreach (Seat s in arrSeats)
        {
            if (s.SectionType == "Premium" && !s.IsBooked)
                return s.AssignParticipant(objParticipant);
        }
        return false;
    }

    public bool AssignStandardSeat(Participant objParticipant)
    {
        foreach (Seat s in arrSeats)
        {
            if (s.SectionType == "Standard" && !s.IsBooked)
                return s.AssignParticipant(objParticipant);
        }
        return false;
    }

    public bool IsPremiumFull()
    {
        foreach (Seat s in arrSeats)
            if (s.SectionType == "Premium" && !s.IsBooked) return false;
        return true;
    }

    public bool IsStandardFull()
    {
        foreach (Seat s in arrSeats)
            if (s.SectionType == "Standard" && !s.IsBooked) return false;
        return true;
    }

    public bool IsWorkshopFull()
    {
        foreach (Seat s in arrSeats)
            if (!s.IsBooked) return false;
        return true;
    }

    public void DisplayAllSeats()
    {
        foreach (Seat s in arrSeats)
        {
            Console.WriteLine(
                "Row " + s.RowNumber +
                " Seat " + s.SeatNumber +
                " (" + s.SectionType + "): " +
                s.GetSeatStatus());
        }
        Console.WriteLine();
    }
}
