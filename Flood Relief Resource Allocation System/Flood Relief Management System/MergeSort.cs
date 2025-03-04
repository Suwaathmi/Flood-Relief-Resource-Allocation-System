using System;
using System.Collections.Generic;

public class MergeSort
{
    public static void Sort(List<VictimDetails> victims, Func<VictimDetails, IComparable> keySelector)
    {
        if (victims.Count <= 1) return;

        var middle = victims.Count / 2;
        var left = victims.Take(middle).ToList();
        var right = victims.Skip(middle).ToList();

        Sort(left, keySelector);
        Sort(right, keySelector);

        Merge(victims, left, right, keySelector);
    }

    private static void Merge(List<VictimDetails> victims, List<VictimDetails> left, List<VictimDetails> right, Func<VictimDetails, IComparable> keySelector)
    {
        int i = 0, j = 0, k = 0;
        while (i < left.Count && j < right.Count)
        {
            if (keySelector(left[i]).CompareTo(keySelector(right[j])) <= 0)
                victims[k++] = left[i++];
            else
                victims[k++] = right[j++];
        }

        while (i < left.Count) victims[k++] = left[i++];
        while (j < right.Count) victims[k++] = right[j++];
    }
}
