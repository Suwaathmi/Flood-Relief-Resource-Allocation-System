using System;
using System.Collections.Generic;

public class VictimGraph : VictimDataStructure
{
    private Dictionary<VictimDetails, List<VictimDetails>> _victimGraph = new Dictionary<VictimDetails, List<VictimDetails>>();

    public override void AddVictim(VictimDetails victim)
    {
        if (!_victimGraph.ContainsKey(victim))
        {
            _victimGraph[victim] = new List<VictimDetails>();
        }
    }

    public override void DisplayVictims()
    {
        Console.WriteLine("\nVictims in Graph:");
        foreach (var victim in _victimGraph)
        {
            victim.Key.Display();
            Console.WriteLine("Connected to:");
            foreach (var connectedVictim in victim.Value)
            {
                connectedVictim.Display();
            }
            Console.WriteLine();
        }
    }
}

