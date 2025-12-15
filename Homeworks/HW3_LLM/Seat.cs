using System;

public class Seat
{
    private int intRowNumber;
    private int intSeatNumber;
    private string strSectionType;
    private bool blnIsBooked;
    private Participant objAssignedParticipant;
    private DateTime dtReservationTime;

    public Seat(int row, int seat, string section)
    {
        intRowNumber = row;
        intSeatNumber = seat;
        strSectionType = section;
        blnIsBooked = false;
    }

    public int RowNumber { get { return intRowNumber; } }
    public int SeatNumber { get { return intSeatNumber; } }
    public string SectionType { get { return strSectionType; } }
    public bool IsBooked { get { return blnIsBooked; } }
    public Participant AssignedParticipant { get { return objAssignedParticipant; } }
    public DateTime ReservationTime { get { return dtReservationTime; } }

    public bool AssignParticipant(Participant objParticipant)
    {
        if (blnIsBooked) return false;

        objAssignedParticipant = objParticipant;
        blnIsBooked = true;
        dtReservationTime = DateTime.Now;
        return true;
    }

    public string GetSeatStatus()
    {
        if (!blnIsBooked) return "FREE";

        return "TAKEN by " + objAssignedParticipant.Name +
               " (ID " + objAssignedParticipant.Id + ") at " +
               dtReservationTime.ToString("MM/dd/yyyy hh:mm tt");
    }
}
