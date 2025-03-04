using System;
using System.Collections.Generic;

public class VictimQueue : VictimDataStructure
{
    private Queue<VictimDetails> _victimsQueue = new Queue<VictimDetails>();

    public override void AddVictim(VictimDetails victim)
    {
        _victimsQueue.Enqueue(victim);
    }

    public override void DisplayVictims()
    {
        Console.WriteLine("\nVictims in Queue:");
        foreach (var victim in _victimsQueue)
        {
            victim.Display();
            Console.WriteLine();
        }
    }
}
