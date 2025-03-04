using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
    static void Main()
    {
        try
        {
            // Step 1: Collect Victim Details
            int numVictims = GetValidInput<int>("Enter the number of victims: ", x => x > 0);
            VictimDetails[] victims = new VictimDetails[numVictims];

            for (int i = 0; i < numVictims; i++)
            {
                Console.WriteLine($"\nEnter details for Victim {i + 1}:");
                victims[i] = CollectVictimDetails();
            }

            // Step 2: Choose Data Structure
            int structureChoice = GetValidInput<int>("\nSelect the data structure to use:\n1. Queue\n2. Linked List\n3. Tree\n4. Graph\n5. Stack\nEnter choice (1-5): ",
                x => x >= 1 && x <= 5);
            VictimSaver victimSaver = new VictimSaver(structureChoice);

            // Step 3: Add victims
            foreach (var victim in victims)
            {
                victimSaver.AddVictim(victim);
            }

            // Step 4: Display victims
            Console.WriteLine("\nCurrent Victim List:");
            victimSaver.DisplayVictims();

            // Step 5: Sorting Selection
            int sortingChoice = GetValidInput<int>("\nWhich sorting algorithm would you like to use?\n1. Bubble Sort\n2. Merge Sort\n3. Quick Sort\nEnter choice (1-3): ",
                x => x >= 1 && x <= 3);

            // Step 6: Sort and Display
            SortAndDisplayVictims(victims, sortingChoice);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static T GetValidInput<T>(string prompt, Func<T, bool> validator = null)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            try
            {
                T result = (T)Convert.ChangeType(input, typeof(T));
                if (validator == null || validator(result))
                    return result;
                Console.WriteLine($"Invalid input. Please try again.");
            }
            catch
            {
                Console.WriteLine($"Invalid input format. Please enter a valid {typeof(T).Name}.");
            }
        }
    }

    static VictimDetails CollectVictimDetails()
    {
        var victim = new VictimDetails
        {
            Name = GetValidInput<string>("Name: ", s => !string.IsNullOrEmpty(s)),
            Priority = GetValidInput<int>("Enter the Priority\n1. Emergency\n2. Medical\n3. Elderly\n4. Children\nEnter choice (1-4): ",
                x => x >= 1 && x <= 4) switch
            {
                1 => "Emergency",
                2 => "Medical",
                3 => "Elderly",
                4 => "Children",
                _ => "Other" // This should never happen due to validation
            }
        };

        // Collect Food Items
        int foodCount = GetValidInput<int>("Enter number of food items (0 if none): ", x => x >= 0);
        victim.FoodItems = new string[foodCount];
        for (int j = 0; j < foodCount; j++)
        {
            victim.FoodItems[j] = GetValidInput<string>($"Food item {j + 1}: ", s => !string.IsNullOrEmpty(s));
        }

        // Collect Medicine Items
        int medicineCount = GetValidInput<int>("Enter number of medicine items (0 if none): ", x => x >= 0);
        victim.MedicineItems = new string[medicineCount];
        for (int j = 0; j < medicineCount; j++)
        {
            victim.MedicineItems[j] = GetValidInput<string>($"Medicine item {j + 1}: ", s => !string.IsNullOrEmpty(s));
        }

        // Collect Clothing Items
        int clothingCount = GetValidInput<int>("Enter number of clothing items (0 if none): ", x => x >= 0);
        victim.Clothing = new List<string>();
        for (int j = 0; j < clothingCount; j++)
        {
            victim.Clothing.Add(GetValidInput<string>($"Clothing item {j + 1}: ", s => !string.IsNullOrEmpty(s)));
        }

        victim.Distance = GetValidInput<int>("Distance from relief center (in km): ", x => x >= 0);
        return victim;
    }

    static void SortAndDisplayVictims(VictimDetails[] victims, int sortingChoice)
    {
        Func<VictimDetails, IComparable> priorityMapping = victim => victim.Priority switch
        {
            "Emergency" => 1,
            "Medical" => 2,
            "Elderly" => 3,
            "Children" => 4,
            _ => 5
        };

        Action<string, Func<VictimDetails, IComparable>, Func<VictimDetails, string>, List<VictimDetails>> sortAndDisplay =
            (title, keySelector, displaySelector, victimList) =>
            {
                Console.WriteLine($"\n{title}");

                // Start the stopwatch for time analysis
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Sort based on the selected algorithm
                switch (sortingChoice)
                {
                    case 1:  // Bubble Sort
                        BubbleSort.Sort(victimList, keySelector);
                        break;
                    case 2:  // Merge Sort
                        MergeSort.Sort(victimList, keySelector);
                        break;
                    case 3:  // Quick Sort
                        QuickSort.Sort(victimList, 0, victimList.Count - 1, keySelector);
                        break;
                    default:
                        Console.WriteLine("Invalid sorting choice.");
                        stopwatch.Stop();
                        return;
                }

                // Stop the stopwatch after sorting
                stopwatch.Stop();

                // Calculate and display the elapsed time
                Console.WriteLine($"Time taken for sorting: {stopwatch.ElapsedMilliseconds} ms");

                // Display the sorted victims list
                foreach (var victim in victimList)
                    Console.WriteLine($"{victim.Name} - {displaySelector(victim)}");
            };

        // Loop to allow repeated sorting with different algorithms
        while (true)
        {
            var victimList = victims.ToList(); // Fresh copy for each iteration
            sortAndDisplay("Sorted by Distance:", v => v.Distance, v => v.Distance.ToString(), victimList);

            victimList = victims.ToList(); // Reset for priority sorting
            sortAndDisplay("Sorted by Priority:", priorityMapping, v => v.Priority, victimList);

            // Ask if the user wants to try another sorting algorithm
            Console.Write("\nWould you like to try another sorting algorithm? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
                break;

            // Prompt for a new sorting choice
            Console.WriteLine("\nWhich sorting algorithm would you like to use?");
            Console.WriteLine("1: Bubble Sort");
            Console.WriteLine("2: Merge Sort");
            Console.WriteLine("3: Quick Sort");
            Console.Write("Enter your choice (1-3): ");
            while (!int.TryParse(Console.ReadLine(), out sortingChoice) || sortingChoice < 1 || sortingChoice > 3)
            {
                Console.Write("Invalid input. Enter a number between 1 and 3: ");
            }
        }
    }


}