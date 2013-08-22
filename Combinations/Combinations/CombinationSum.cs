using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinations
{
    class CombinationSum
    {
        static void FindCombination(int[] arr, int[] data, int ndx, int sum)
        {
            if (sum == 0)
            {
                Console.Write("Result: ");
                int val = 0;
                foreach (int i in data)
                {
                    Console.Write("{0} ", i);
                    val += i;
                }
                Console.Write("\t sum = {0}", val);
                Console.WriteLine("\n");
                return;
            }

            for (int i = 0; i < arr.Length && ndx < data.Length; i++)
            {
                data[ndx] = arr[i];
                FindCombination(arr, data, ndx + 1, sum - arr[i]);
            }
        }

        public static void driver()
        {
            int[] arr = { 1, 5, 3, 0 };
            int[] data = new int[4];
            FindCombination(arr, data, 0, 8);
        }
    }
}
