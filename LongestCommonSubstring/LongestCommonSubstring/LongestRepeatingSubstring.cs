using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestCommonSubstring
{
    class LongestRepeatingSubstring
    {
        //1. Using dynamic prog: Time = O(n2)
        //2. lrs[i, j] is length of longest repeating substring between a[0 to i] and a[i+1, j]
        
        static void LRS(string a)
        {
            int la = a.Length;
            int[,] lrs = new int[la + 1, la + 1];
            int max = 0, mi = 0, mj = 0;

            for (int i = 1; i < la; i++)
            {
                for (int j = i + 1; j <= la; j++)
                {
                    if (a[i - 1] == a[j - 1])
                    {
                        lrs[i, j] = lrs[i - 1, j - 1] + 1;
                        if (max < lrs[i, j])
                        {
                            max = lrs[i, j];
                            mi = i;
                            mj = j;
                        }
                    }
                    else
                        lrs[i, j] = 0;
                }
            }

            string sub = "";
            
            while (mi > 0 && mj > 0 && lrs[mi, mj] > 0)
            {
                sub = a[mi - 1] + sub;
                mi--; mj--;
            }

            Console.WriteLine("Length of lrs = {0}\nLongest Repeating Substring = {1}", max, sub);
        }

        public static void driver()
        {
            string a = "Do not ask what the country has done for you ask what you have done for the country";
            LRS(a);
        }
    }
}
