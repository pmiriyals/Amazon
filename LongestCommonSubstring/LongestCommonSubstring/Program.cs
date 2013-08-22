using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestCommonSubstring
{
    class Program
    {
        //1. lcs[i,j]: is the length of the longest common substring from a[0 to i-1] and b[0 to j-1]
        //2. Once we have the length, we just need to traverse the matrix in a way that generates the lcs
        //3. lcs[i, j] = lcs[i-1, j-1] + 1, iff(a[i-1] == b[j-1])
        //   lcs[i, j] = 0, otherwise (since this is a substring (this part will change for subsequence))
        //4. Time: O(mn)
        static void LCS(string a, string b)
        {
            int la = a.Length;
            int lb = b.Length;

            int[,] lcs = new int[la + 1, lb + 1];
            int max = 0, mi = 0, mj = 0;

            //if(i == 0 || j == 0), lcs will always be zero for empty strings
            for (int i = 1; i <= la; i++)
            {
                for (int j = 1; j <= lb; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                        if (max < lcs[i, j])
                        {
                            max = lcs[i, j];
                            mi = i; 
                            mj = j;
                        }
                    }
                    else
                        lcs[i, j] = 0;
                }
            }

            string lcsub = "";

            while (mi > 0 && mj > 0 && lcs[mi, mj] > 0)
            {
                lcsub = a[mi - 1] + lcsub;
                mi--;
                mj--;
            }

            Console.WriteLine("Length of LCS = {0}\nLongest Common Substring = {1}", max, lcsub);
        }


        static void Main(string[] args)
        {
            //driver();
            //LongestCommonSubSequence.driver();
            //LongestRepeatingSubstring.driver();
            LongestPalindromicSubstring.driver();
            Console.ReadLine();
        }

        private static void driver()
        {
            string a = "abdcaa";
            string b = "acdcab";
            LCS(a, b);
        }
    }
}
