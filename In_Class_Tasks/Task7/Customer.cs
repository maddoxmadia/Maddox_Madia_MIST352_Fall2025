/* Maddox Madia
In class task 7
11/13/25*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Customer
{
    // Fields
    public int _customerId;
    public string _name;
    public string _phone;
    public string _email;
    public string _address;

    public int CustomerID
    {
        get { return _customerId; }
        set { _customerId = value; }
    }
    public string Name
    {
        get { return _name; }
        set {
        if (value is null || value.Equals(""))
        {
            Console.Writeline($"Name cannot be null.")
        }
        else 
        _name = value;
        }
    }
    public string Phone
    {
        get { return _phone; }
        set
        {
            if (value is null || value.Equals(""))
            {
                Console.WriteLine($"Phone can not be null or empty. Customer phone remains {_phone}. Try again");
            }
            else
                _phone = value;
        }
    }
    public string Email
    {
        get { return _email; }
        set
        {
            if (value is null || value.Equals(""))
            {
                Console.WriteLine($"Email can not be null or empty. Customer phone remains {_phone}. Try again");
            }
            else
                _email = value;
        }
    }
    public string Address
    {
        get { return _address; }
        set
        {
            if (value is null || value.Equals(""))
            {
                Console.WriteLine($"Address can not be null or empty. Customer phone remains {_phone}. Try again");
            }
            else
                _address = value;
        }
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Customer ID: {_customerId}\tName: {_name}\tPhone: {_phone}\tEmail: {_email}\tAddress: {_address}");
    }
}