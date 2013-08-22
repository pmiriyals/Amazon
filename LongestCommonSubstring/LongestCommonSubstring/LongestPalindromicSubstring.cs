using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestCommonSubstring
{
    class LongestPalindromicSubstring
    {
        static void lps(string a)
        {
            int start = 0;
            int max = 1;

            for (int i = 1; i < a.Length; i++)
            {
                int low = i - 1;
                int high = i;

                while (low >= 0 && high < a.Length && a[low] == a[high])
                {
                    if ((high - low + 1) > max)
                    {
                        max = high - low + 1;
                        start = low;
                    }
                    low--;
                    high++;
                }

                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < a.Length && a[low] == a[high])
                {
                    if ((high - low + 1) > max)
                    {
                        max = high - low + 1;
                        start = low;
                    }
                    low--;
                    high++;
                }
            }

            Console.WriteLine("Lenght = {0}\nPalindrome = {1}", max, a.Substring(start, max));
        }

        
        //1. lps[i, j] = boolean array represents if a[i to j] is palindrome or not
        //2. lps[i, j] = if(lps[i+1, j-1] is true && a[i] == a[j]) true, else false;
        //3. At each step, whenever lps[i, j] is true, calculate j-i+1 and check against max

        //Not efficient dynamic programming refer above comments for the right one
        static void lpsDynProg(string a)
        {
            int la = a.Length;
            int[,] lps = new int[la, la];
            int max = 1, mi = 0;
            for (int i = 0; i < la; i++)
            {
                for (int j = 0; j < la; j++)
                {
                    int m = i;
                    int n = j;
                    while (n >= m && a[n] == a[m])
                    {
                        if (n == m)
                        {
                            lps[m, n] = j - i + 1;
                            if (max < lps[m, n])
                            {
                                max = lps[m, n];
                                mi = i;                                
                            }
                        }
                        m++;
                        n--;
                    }
                }
            }

            Console.WriteLine("\nUsing Dynamic Programming:\nLength = {0}\nLPS = {1}", max, a.Substring(mi, max));
        }

        public static void driver()
        {
            string a = "mississipi";
            lps(a);
            lpsDynProg(a);
        }
    }
}
