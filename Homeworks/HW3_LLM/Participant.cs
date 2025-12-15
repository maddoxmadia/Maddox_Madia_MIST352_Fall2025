using System;

public class Participant
{
    private int intId;
    private string strName;
    private string strEmail;

    public Participant(int id, string name)
    {
        if (id <= 0) throw new ArgumentException("ID must be greater than 0.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");

        intId = id;
        strName = name;
        strEmail = "";
    }

    public Participant(int id, string name, string email)
    {
        if (id <= 0) throw new ArgumentException("ID must be greater than 0.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
        if (!email.Contains("@")) throw new ArgumentException("Invalid email.");

        intId = id;
        strName = name;
        strEmail = email;
    }

    public int Id
    {
        get { return intId; }
    }

    public string Name
    {
        get { return strName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty.");
            strName = value;
        }
    }

    public string Email
    {
        get { return strEmail; }
        set
        {
            if (!value.Contains("@")) throw new ArgumentException("Invalid email.");
            strEmail = value;
        }
    }
}
