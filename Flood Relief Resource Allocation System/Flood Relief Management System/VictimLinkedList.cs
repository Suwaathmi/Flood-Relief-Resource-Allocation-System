using System;
using System.Collections.Generic;

public class VictimLinkedList : VictimDataStructure
{
    private LinkedList<VictimDetails> _victimsList = new LinkedList<VictimDetails>();

    public override void AddVictim(VictimDetails victim)
    {
        _victimsList.AddLast(victim);
    }

    public override void DisplayVictims()
    {
        Console.WriteLine("\nVictims in Linked List:");
        foreach (var victim in _victimsList)
        {
            victim.Display();
            Console.WriteLine();
        }
    }
}
