using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestCommonSubstring
{
    class LongestCommonSubSequence
    {
        static void LCSS(string a, string b)
        {
            int la = a.Length;
            int lb = b.Length;

            int[,] lcs = new int[la + 1, lb + 1];

            //if(i == 0 || j == 0), lcs will always be zero for empty strings
            for (int i = 1; i <= la; i++)
            {
                for (int j = 1; j <= lb; j++)
                {
                    if (a[i - 1] == b[j - 1])
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    else
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                }
            }

            string lcss = "";

            int m = la, n = lb;

            while (m > 0 && n > 0 && lcs[m, n] > 0)
            {
                while (n > 0 && lcs[m, n] == lcs[m, n - 1])
                    n--;

                while (m > 0 && lcs[m, n] == lcs[m - 1, n])
                    m--;

                lcss = a[m - 1] + lcss;
                m--;
                n--;
            }

            Console.WriteLine("Length of LCSS = {0}\nLongest Common Subsequence = {1}", lcs[la, lb], lcss);
            Console.WriteLine("\nLength of LCSS = {0}\nLongest Common Subsequence using recur = {1}", lcs[la, lb], lcssMat(lcs, la, lb, a, ""));
        }

        static string lcssMat(int[,] lcs, int i, int j, string a, string lcss)
        {
            if (i <= 0 || j <= 0 || lcs[i, j] <= 0)
                return lcss;

            if (lcs[i, j] == lcs[i, j - 1])
                return lcssMat(lcs, i, j - 1, a, lcss);
            else if (lcs[i, j] == lcs[i - 1, j])
                return lcssMat(lcs, i - 1, j, a, lcss);
            else
                return lcssMat(lcs, i - 1, j - 1, a, a[i - 1] + lcss);
        }

        public static void driver()
        {
            string a = "abdcaa";
            string b = "acdcab";
            LCSS(a, b);
        }
    }
}
