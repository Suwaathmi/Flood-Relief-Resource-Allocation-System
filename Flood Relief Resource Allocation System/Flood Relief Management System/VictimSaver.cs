using System;

public class VictimSaver
{
    private VictimDataStructure _victimDataStructure;

    public VictimSaver(int structureChoice)
    {
        _victimDataStructure = structureChoice switch
        {
            1 => new VictimQueue(),
            2 => new VictimLinkedList(),
            3 => new VictimTree(),
            4 => new VictimGraph(),
            5 => new VictimStack(),  // New Stack option
            _ => throw new InvalidOperationException("Invalid choice.")
        };
    }

    public void AddVictim(VictimDetails victim)
    {
        _victimDataStructure.AddVictim(victim); // Add the victim to the chosen data structure
    }

    public void DisplayVictims()
    {
        _victimDataStructure.DisplayVictims(); // Display the victims stored in the chosen data structure
    }

}
