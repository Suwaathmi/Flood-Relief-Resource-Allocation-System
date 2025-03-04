using System;
using System.Collections.Generic;
public static class QuickSort
{
    // Updated to work with List<T> instead of arrays
    public static void Sort(List<VictimDetails> list, int low, int high, Func<VictimDetails, IComparable> keySelector)
    {
        if (low < high)
        {
            int pi = Partition(list, low, high, keySelector);

            // Recursively sort the two halves
            Sort(list, low, pi - 1, keySelector);
            Sort(list, pi + 1, high, keySelector);
        }
    }

    private static int Partition(List<VictimDetails> list, int low, int high, Func<VictimDetails, IComparable> keySelector)
    {
        // Use the pivot element
        var pivot = keySelector(list[high]);

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (keySelector(list[j]).CompareTo(pivot) < 0)
            {
                i++;
                Swap(list, i, j);
            }
        }

        Swap(list, i + 1, high);  // Move pivot to correct place
        return i + 1;
    }

    private static void Swap(List<VictimDetails> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
