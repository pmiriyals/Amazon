using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrequentNonEmptySubArr
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 5, 6, 1, 3, 2, 6, 4, 5, 6, 2};
            Dictionary<int, List<int>> arrIndex = new Dictionary<int, List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arrIndex.ContainsKey(arr[i]))
                {
                    arrIndex[arr[i]].Add(i);
                }
                else
                {
                    List<int> nl = new List<int>();
                    nl.Add(i);
                    arrIndex.Add(arr[i], nl);
                }
            }

        }
    }
}
