using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateSubsets
{
    class Program
    {
        //Combinations using bitvector
        static void driver(int[] set)
        {
            double l = Math.Pow(2.0, set.Length);

            for (int i = 0; i < l; i++)
            {
                int n = i;
                int ndx = 0;
                Console.Write("\nSet {0} = ", i);
                while (n > 0)
                {                    
                    if ((n & 1) > 0)
                    {
                        Console.Write("{0} ", set[ndx]);
                    }
                    ndx++;
                    n >>= 1;
                }                
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            driver(arr);
            Console.ReadLine();
        }
    }
}
