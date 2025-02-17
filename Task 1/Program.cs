// Task 1
using System;
using System.Collections.Generic;

// Class representing a customer and their wiring requirements
class Customer
{
    public string Name { get; set; }
    public string BuildingType { get; set; }
    public int Size { get; set; }
    public int LightBulbs { get; set; }
    public int Outlets { get; set; }
    public string CreditCard { get; set; }

    // Constructor to initialize customer details with validation
    public Customer(string name, string buildingType, int size, int lightBulbs, int outlets, string creditCard)
    {
        Name = name;
        BuildingType = buildingType;
        Size = Math.Clamp(size, 1000, 50000); // Ensuring valid size
        LightBulbs = Math.Clamp(lightBulbs, 0, 20); // Ensuring valid bulb count
        Outlets = Math.Clamp(outlets, 0, 50); // Ensuring valid outlet count
        CreditCard = MaskCreditCard(creditCard);
    }

    // Method to mask the credit card number for privacy
    private string MaskCreditCard(string cardNumber)
    {
        return $"{cardNumber.Substring(0, 4)} XXXX XXXX {cardNumber.Substring(cardNumber.Length - 4)}";
    }

    // Method to display customer details
    public void DisplayInfo()
    {
        Console.WriteLine($"{Name} | {BuildingType} | {Size} sqft | {LightBulbs} bulbs | {Outlets} outlets | {CreditCard}");
    }
}

class Program
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>();

        // Example data entry
        customers.Add(new Customer("Shyamal", "House", 2000, 10, 30, "8511987654327779"));
        customers.Add(new Customer("Bemzy", "Barn", 5000, 15, 40, "4551234567899494"));
        customers.Add(new Customer("Shiva", "Garage", 1500, 5, 20, "5523123412342569"));

        // Display all customer details
        Console.WriteLine("Customer Details:");
        foreach (var customer in customers)
        {
            customer.DisplayInfo();
        }
    }
}