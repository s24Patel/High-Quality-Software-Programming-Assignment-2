//Task 2
using System;
using System.Collections.Generic;

// Interface defining the common functionality for all buildings
interface IBuilding
{
    void CreateWiringSchema(); // Method to create wiring schema
    void PurchaseParts(); // Method to purchase necessary parts
}

// Abstract base class implementing the interface
abstract class Building : IBuilding
{
    public string CustomerName { get; set; }
    public int Size { get; set; }
    public int LightBulbs { get; set; }
    public int Outlets { get; set; }
    public string CreditCard { get; set; }

    public Building(string customerName, int size, int lightBulbs, int outlets, string creditCard)
    {
        CustomerName = customerName;
        Size = Math.Clamp(size, 1000, 50000); // Ensuring size is within valid limits
        LightBulbs = Math.Clamp(lightBulbs, 0, 20); // Ensuring valid number of bulbs
        Outlets = Math.Clamp(outlets, 0, 50); // Ensuring valid number of outlets
        CreditCard = creditCard;
    }

    public void CreateWiringSchema()
    {
        Console.WriteLine($"{CustomerName}: Wiring schema created.");
    }

    public void PurchaseParts()
    {
        Console.WriteLine($"{CustomerName}: Necessary parts purchased.");
    }

    public abstract void PerformSpecialTask(); // Abstract method for specific building tasks
}

// Derived classes implementing specific behavior
class House : Building
{
    public House(string customerName, int size, int lightBulbs, int outlets, string creditCard)
        : base(customerName, size, lightBulbs, outlets, creditCard) { }

    public override void PerformSpecialTask()
    {
        Console.WriteLine($"{CustomerName}: Fire alarms installed.");
    }
}

class Barn : Building
{
    public Barn(string customerName, int size, int lightBulbs, int outlets, string creditCard)
        : base(customerName, size, lightBulbs, outlets, creditCard) { }

    public override void PerformSpecialTask()
    {
        Console.WriteLine($"{CustomerName}: Milking equipment wired.");
    }
}

class Garage : Building
{
    public Garage(string customerName, int size, int lightBulbs, int outlets, string creditCard)
        : base(customerName, size, lightBulbs, outlets, creditCard) { }

    public override void PerformSpecialTask()
    {
        Console.WriteLine($"{CustomerName}: Automatic doors installed.");
    }
}

// Main program execution
class Program
{
    static void Main()
    {
        List<Building> customers = new List<Building>(); // List to store customer details

        // Adding customer details
        customers.Add(new House("Shyamal", 2000, 10, 30, "8511987654327779"));
        customers.Add(new Barn("Bemzy", 5000, 15, 40, "4551234567899494"));
        customers.Add(new Garage("Shiva", 1500, 5, 20, "5523123412342569"));

        // Processing each customer
        foreach (var customer in customers)
        {
            customer.CreateWiringSchema();
            customer.PurchaseParts();
            customer.PerformSpecialTask();
            Console.WriteLine($"{customer.CustomerName}: {customer.Size} sq. ft, {customer.LightBulbs} bulbs, {customer.Outlets} outlets, Card: {MaskCreditCard(customer.CreditCard)}");
        }
    }

    // Method to mask credit card details except first and last four digits
    static string MaskCreditCard(string cardNumber)
    {
        return cardNumber.Substring(0, 4) + " XXXX XXXX " + cardNumber.Substring(12);
    }
}
