using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinations
{
    class RCombinations
    {
        static bool RCombFixOneRecur(int[] arr, int[] data, int r, int index, int start, int end)
        {
            if (index == r)
            {
                foreach (int j in data)
                {
                    Console.Write("{0} ", j);
                }
                Console.WriteLine();
                return true;
            }

            for (int i = start; i <= end && ((end - i + 1) >= (r - index)); i++)
            {
                data[index] = arr[i];   //fix one
                //To handle duplicates, we need to sort arr[] before passing to this function
                //while (i < arr.Length - 1 && arr[i] == arr[i + 1])
                  //  i++;
                RCombFixOneRecur(arr, data, r, index + 1, i + 1, end);
            }

            return false;   //if no combination is found
        }

        static void RCombInclExcl(int[] arr, int[] data, int r, int index, int i)
        {
            if (index == r)
            {
                foreach (int j in data)
                {
                    Console.Write("{0} ", j);
                }
                Console.WriteLine();
                return;
            }

            if (i >= arr.Length)
                return;

            data[index] = arr[i];

            RCombInclExcl(arr, data, r, index + 1, i + 1);  //include current i in data(increment index and i)
            RCombInclExcl(arr, data, r, index, i + 1);  //exlcude (increment only i)
        }

        public static void driver()
        {
            int[] arr = { 1, 2, 3 };
            int r = 2;
            int[] data = new int[r];
            Console.WriteLine("RCombinations using FixOneRecur: ");
            RCombFixOneRecur(arr, data, r, 0, 0, arr.Length - 1);
            Console.WriteLine("RCombinations using Incl/Excl: ");
            RCombInclExcl(arr, data, r, 0, 0);
        }
    }
}
