using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestRepeatingSubString
{
    class Program
    {
        //1. lrs[i, j] represents length of longest repeating substring from S[0 to i] and S[i+1 to j]
        //2. Time: O(n2) to build lrs
        //3. lrs[i,j] = lrs[i-1, j-1], iff(s[i-1] == s[j-1])
        //4. lrs[i,j] = 0, otherwise (similar to longest common substring)
        //5. Best solution is using suffix tree. We can construction suffix tree in O(n) time and then find the node at max depth that has at least 2 children. Substring till that node is the lrs.
        static void LRS(string s)
        {
            int[,] lrs = new int[s.Length + 1, s.Length + 1];
            int max = 0;
            int mi = 0, mj = 0;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = i+1; j <= s.Length; j++)
                {
                    if (s[i - 1] == s[j - 1])
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
            string str = "";

            while (lrs[mi, mj] > 0)
            {
                str = s[mi-1] + str;
                mi--; mj--;
            }
            Console.WriteLine("Length of longest repeating substring = {0}\nLRS = {1}", max, str);

            print2D(lrs);
        }

        //inefficient compared to dynamic programming
        static string longest(string v, string r, int pos)
        {
            if (pos >= v.Length)
                return r;

            string newR = r + v[pos];
            int fromIndex = v.IndexOf(newR) + 1;
            if (fromIndex >= v.Length)
                return r;

            //there is no substring newR from index after newR
            int indexOf = v.IndexOf(newR, fromIndex);
            if (indexOf == -1)
                return r;

            return longest(v, newR, pos + 1);
        }

        static void lrsPerm(string s)
        {
            string temp = "";
            string max = "";

            for (int i = 0; i < s.Length; i++)
            {
                temp = longest(s, "", i);
                if (max.Length < temp.Length)
                    max = temp;        
            }

            Console.WriteLine(max);
        }

        static void print2D(int[,] lrs)
        {
            for (int i = 0; i < lrs.GetLength(0); i++)
            {
                for (int j = 0; j < lrs.GetLength(1); j++)
                {
                    Console.Write("{0} ", lrs[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string s = "banana";
            LRS(s);
            lcs(s);
            //lrsPerm(s);
            Console.ReadLine();
        }
    }
}
