using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualDistributionApples
{
    class Program
    {
        static void MinEqualDistribution(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
                sum += i;
            if (sum % arr.Length != 0)
            {
                Console.WriteLine("No combination possible");
                return;
            }

            int n = sum / arr.Length;
            int min = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] -= n;
            }

            foreach (int i in arr)
                Console.Write("{0} ", i);

            int[] med = new int[arr.Length];
            med[0] = 0;
            for (int i = 1; i < med.Length; i++)
                med[i] = med[i - 1] + arr[i - 1];

            Console.WriteLine();
            foreach (int i in med)
                Console.Write("{0} ", i);
            Array.Sort(med);
            int median;
            if (med.Length % 2 == 0)
            {
                median = (med[med.Length / 2 - 1] + med[med.Length / 2]) / 2;
            }
            else
                median = med[med.Length / 2];
            Console.WriteLine("\nmedian = {0}", median);
            foreach (int i in med)
                min += Math.Abs(median + i);
            Console.WriteLine("\nMin steps = {0}", min);
        }

        static void Main(string[] args)
        {
            int[] arr = { 0, 2, 8, 6};//{ 2, 10, 4, 3, 8, 9, 6};
            MinEqualDistribution(arr);
            Console.ReadLine();
        }
    }
}
