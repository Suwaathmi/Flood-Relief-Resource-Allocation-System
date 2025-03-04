using System;
using System.Collections.Generic;

public class VictimStack : VictimDataStructure
{
    private Stack<VictimDetails> _stack = new Stack<VictimDetails>();

    public override void AddVictim(VictimDetails victim)
    {
        _stack.Push(victim); // Add victim to the stack
    }

    public override void DisplayVictims()
    {
        Console.WriteLine("Victims in Stack (LIFO):");
        foreach (var victim in _stack)
        {
            victim.Display(); // Display victim details
        }
    }
}
