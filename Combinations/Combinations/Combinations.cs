using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinations
{
    class Combinations
    {
        static void GenerateComb(int[] arr)
        {
            double n = Math.Pow(2, arr.Length);

            for (int i = 0; i < n; i++)
            {
                int val = i;
                int ndx = 0;

                while (val > 0)
                {
                    if ((val & 1) > 0)
                    {
                        Console.Write("{0} ", arr[ndx]);
                    }

                    ndx++;
                    val >>= 1;
                }
                Console.WriteLine();
            }
        }

        public static void driver()
        {
            int[] arr = { 1, 2, 3 };
            Console.WriteLine("Generating all combinations of the array: ");
            GenerateComb(arr);
        }
    }
}
