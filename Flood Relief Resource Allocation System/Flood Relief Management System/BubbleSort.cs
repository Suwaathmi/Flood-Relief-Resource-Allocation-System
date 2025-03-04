using System;
using System.Collections.Generic;

public class BubbleSort
{
    public static void Sort(List<VictimDetails> victims, Func<VictimDetails, IComparable> keySelector)
    {
        int n = victims.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (keySelector(victims[j]).CompareTo(keySelector(victims[j + 1])) > 0)
                {
                    var temp = victims[j];
                    victims[j] = victims[j + 1];
                    victims[j + 1] = temp;
                }
            }
        }
    }
}