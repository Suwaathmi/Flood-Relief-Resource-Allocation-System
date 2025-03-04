using System;
using System.Collections.Generic;

public class VictimDetails
{
    public string? Name { get; set; }
    public string? Priority { get; set; }
    public string[]? FoodItems { get; set; }
    public string[]? MedicineItems { get; set; }
    public List<string> Clothing { get; set; } = new List<string>();
    public int Distance { get; set; }

    // Display method to print victim details
    public void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Priority: {Priority}");

        // Display food items if any
        if (FoodItems != null && FoodItems.Length > 0)
        {
            Console.WriteLine("Food Items:");
            foreach (var foodItem in FoodItems)
            {
                Console.WriteLine($" - {foodItem}");
            }
        }

        // Display medicine items if any
        if (MedicineItems != null && MedicineItems.Length > 0)
        {
            Console.WriteLine("Medicine Items:");
            foreach (var medicineItem in MedicineItems)
            {
                Console.WriteLine($" - {medicineItem}");
            }
        }

        // Display clothing items if any
        if (Clothing != null && Clothing.Count > 0)
        {
            Console.WriteLine("Clothing Items:");
            foreach (var clothingItem in Clothing)
            {
                Console.WriteLine($" - {clothingItem}");
            }
        }

        Console.WriteLine($"Distance from relief center: {Distance} km");
    }
}
