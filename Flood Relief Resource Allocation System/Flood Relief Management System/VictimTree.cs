using System;
using System.Collections.Generic;

public class VictimTree : VictimDataStructure
{
    private List<VictimDetails> victimTree = new List<VictimDetails>();

    public override void AddVictim(VictimDetails victim)
    {
        victimTree.Add(victim); // Adding to a simple list for simplicity
    }

    public override void DisplayVictims()
    {
        Console.WriteLine("\nDisplaying victims in Tree order:");
        foreach (var victim in victimTree)
        {
            victim.Display();
        }
    }
}
