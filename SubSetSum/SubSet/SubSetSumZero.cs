using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubSet
{
    class SubSetSumZero
    {
        public static void FindSubSetWithZeroSum(int[] a)
        {
            int[] sum = new int[a.Length];
            int temp = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum[i] = temp + a[i];
                temp += a[i];
            }

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < sum.Length; i++)
            {
                Console.WriteLine("sum[{0}] = {1}", i, sum[i]);
                if (!dict.ContainsKey(sum[i]))
                {
                    List<int> indexes = new List<int>();
                    indexes.Add(i);
                    dict.Add(sum[i], indexes);
                }
                else
                {
                    foreach(int j in dict[sum[i]])
                        Console.WriteLine("Sum found between indexes {0} and {1}", j + 1, i);
                    dict[sum[i]].Add(i);
                }
                    
            }
        }

        //only works for positive numbers
        public static void SubSetSum(int[] a, int sum)
        {
            int cur = a[0];
            int start = 0;

            for (int i = 1; i <= a.Length; i++)
            {
                while (cur > sum && start < i - 1)
                {
                    cur = cur - a[start++];
                }

                if (cur == sum)
                {
                    Console.WriteLine("sum found between a[{0}] = {1} and a[{2}] = {3}", start, a[start], i - 1, a[i - 1]);
                }

                if(i < a.Length)
                    cur += a[i];
            }
        }

        public static void driver()
        {
            int[] a = { 1, 2, -6, 5, 2, 3, -5, -1, 10};
            FindSubSetWithZeroSum(a);
            //SubSetSum(a, 14);
        }
    }
}
