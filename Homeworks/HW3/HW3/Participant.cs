using System;

public class Participant
{
    // Private fields (storage)
    private int intId;
    private string strName;
    private string strEmail;

    // ID and Name Constructor
    public Participant(int intId, string strName)
    {
        // Validate id
        if (intId <= 0)
        {
            throw new ArgumentException("ID must be greater than 0.");
        }

        // Validate name
        if (string.IsNullOrWhiteSpace(strName))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        this.intId = intId;
        this.strName = strName.Trim();
        this.strEmail = "";  // Empty email for this constructor
    }

    // Name ID and Email Constructor
    public Participant(int intId, string strName, string strEmail)
    {
        // Validate id
        if (intId <= 0)
        {
            throw new ArgumentException("ID must be greater than 0.");
        }

        // Validate name
        if (string.IsNullOrWhiteSpace(strName))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        // Validate email
        if (string.IsNullOrWhiteSpace(strEmail) || !strEmail.Contains("@"))
        {
            throw new ArgumentException("Email must contain @.");
        }

        this.intId = intId;
        this.strName = strName.Trim();
        this.strEmail = strEmail.Trim();
    }

    // Property for Id 
    public int Id
    {
        get { return intId; }
    }

    // Property for Name 
    public string Name
    {
        get { return strName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            strName = value.Trim();
        }
    }

    // Property for Email 
    public string Email
    {
        get { return strEmail; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Email must contain @.");
            }
            strEmail = value.Trim();
        }
    }

    // Participant info
    public void DisplayInfo()
    {
        Console.WriteLine("ID: " + intId + ", Name: " + strName + ", Email: " + strEmail);
    }
}