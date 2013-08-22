using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfPairs
{
    class Program
    {
        static int CountSumPairs(int[] arr, int sum)
        {
            HashSet<int> hs = new HashSet<int>();
            int count = 0;
            foreach (int i in arr)
            {
                int rem = sum - i;

                if (hs.Contains(rem))
                {
                    Console.WriteLine("Pair = ({0}, {1})", rem, i);
                    count++;
                }
                if (!hs.Contains(i))
                    hs.Add(i);
            }
            Console.WriteLine("Total pairs = {0}", count);
            return count;
        }
        
        static void Main(string[] args)
        {
            int[] arr = { 2, 4, 1, 34, 5, 6, 3 };
            CountSumPairs(arr, 10);
            Console.ReadLine();
        }
    }
}
