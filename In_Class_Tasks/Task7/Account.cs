/* Maddox Madia
In class task 7
11/13/25*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Account
{
    //Fields
    private int _id
    private string _type
    private DateTime _opendate 
    private string _customer 
    private double _balance

    //Properties

    public int ID
    {
        get { return _id; }
    }

    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public DateTime OpenDate
    {
        get { return _opendate; }
    }

    public string Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    //Account constructors

    public Account(int ID)
    {
        if (intID > 0)
        {
            _id = intID;
        }
        else
        {
            Console.Writeline("ID must be above 0.");
            _id = 1;
        }

        _type = "Standard"
        _opendate = DateTime.Now;
        _balance = 0
        _customer = null;
    }

    public Account (int intID, string srtType)
    {
        if (intID > 0)
        {
            _id = intID;
        }
        else
        {
            Console.WriteLine "ID must be greater than 0. ID will be set to 1."
            _id = 1;
        }

        if (strType is null || strType.Equals(""))
        {
            Console.Writeline("Account type cannot be null.")
            _type = "Standard";
        }
        else
        {
            _type = str_type;
        }
        
        _openDate = DateTime.Now;
        _balance = 0.0;
        _customer = null;
    }
    public Account(Customer customerData)
    {
        if (customerData is null)
        {
            Console.WriteLine("Customer cannot be null.");
        }
        else
        {
            _customer = customerData;
        }

        _id = 1;
        _type = "Standard";
        _openDate = DateTime.Now;
        _balance = 0;
    }
    
    //Methods
     public void DisplayInfo()
    {
        Console.WriteLine($"ID: {_id}\tType {_type}\tCustomer {_customer}\tDate: {_opendate}\tBalance: {_balance}");
    }
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            _balance = _balance + amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${_balance}");
        }
        else
        {
            Console.WriteLine("Deposit must be greater than 0.");
        }
    }
    public bool Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdraw amount must be greater than 0.");
            return false;
        }
        else if (amount > _balance)
        {
            Console.WriteLine("Insufficient funds.");
            return false;
        }
        else
        {
            _balance = _balance - amount;
            Console.WriteLine($"Withdrew ${amount}. New balance: ${_balance}");
            return true;
        }
    }
}