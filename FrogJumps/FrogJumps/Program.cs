using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrogJumps
{
    class Program
    {
        //1. Use DynamicProgramming
        //2. jumps[j] is the min jumps required to reach arr[0 to j]
        //3. O(n2)
        static void MinJumps(int[] arr)
        {
            int[] jumps = new int[arr.Length];            

            if (arr[0] <= 0)
                return;

            jumps[0] = 0;
            for (int i = 1; i < arr.Length; i++)    //0 to i 
            {
                jumps[i] = Int32.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    if (i <= (j + arr[j]) && jumps[j] != Int32.MaxValue)
                    {
                        jumps[i] = jumps[j] + 1;
                        break;
                    }
                }
            }

            Console.WriteLine("Min jumps = {0}", jumps[jumps.Length - 1]);
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 };
            MinJumps(arr);
            Console.ReadLine();
        }
    }
}
