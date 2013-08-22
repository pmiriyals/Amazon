using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinations
{
    class CombinationsComposingGivenPoint
    {
        static void FindCombOfPoints(int[] arr, int n, int i, int maxPoint)
        {
            if (n == 0)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("{0} ", arr[j]);                    
                }
                Console.WriteLine();
                return;
            }

            for (int k = 1; k <= maxPoint && i < arr.Length; k++)
            {
                arr[i] = k;
                FindCombOfPoints(arr, n - k, i + 1, maxPoint);
            }
        }

        public static void driver()
        {
            int maxPoint = 3;
            int[] arr = new int[maxPoint];
            int res = 5;
            Console.WriteLine("Max point compositions: ");
            FindCombOfPoints(arr, res, 0, maxPoint);
        }
    }
}
