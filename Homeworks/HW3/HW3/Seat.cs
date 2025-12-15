using System;

public class Seat
{
    private int intRowNumber;
    private int intSeatNumber;
    private string strSectionType;
    private bool blnIsBooked;
    private Participant objAssignedParticipant;
    private DateTime dtReservationTime;

    public Seat(int intRowNumber, int intSeatNumber, string strSectionType)
    {
        if (intRowNumber < 1 || intRowNumber > 10)
        {
            throw new ArgumentException("Row must be 1-10.");
        }

        if (intSeatNumber < 1 || intSeatNumber > 2)
        {
            throw new ArgumentException("Seat must be 1 or 2.");
        }

        if (strSectionType != "Premium" && strSectionType != "Standard")
        {
            throw new ArgumentException("Section must be Premium or Standard.");
        }

        this.intRowNumber = intRowNumber;
        this.intSeatNumber = intSeatNumber;
        this.strSectionType = strSectionType;
        this.blnIsBooked = false;
        this.objAssignedParticipant = null;
        this.dtReservationTime = DateTime.MinValue;
    }

    public int RowNumber
    {
        get { return intRowNumber; }
    }

    public int SeatNumber
    {
        get { return intSeatNumber; }
    }

    public string SectionType
    {
        get { return strSectionType; }
    }

    public bool IsBooked
    {
        get { return blnIsBooked; }
    }

    public Participant AssignedParticipant
    {
        get { return objAssignedParticipant; }
    }

    public DateTime ReservationTime
    {
        get { return dtReservationTime; }
    }

    public bool AssignParticipant(Participant objParticipant)
    {
        if (blnIsBooked)
        {
            return false;
        }

        objAssignedParticipant = objParticipant;
        blnIsBooked = true;
        dtReservationTime = DateTime.Now;
        return true;
    }

    public string GetSeatStatus()
    {
        if (!blnIsBooked)
        {
            return "FREE";
        }
        else
        {
            return "TAKEN by " + objAssignedParticipant.Name + 
                   " (ID " + objAssignedParticipant.Id + ") at " + 
                   dtReservationTime.ToString("MM/dd/yyyy hh:mm tt");
        }
    }
}