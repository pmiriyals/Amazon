using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexRank
{
    class Program
    {
        static void computeCnt(int[] cnt, string s)
        {
            foreach (char c in s)
                cnt[c]++;

            for (int i = 1; i < cnt.Length; i++)
                cnt[i] += cnt[i - 1];
        }

        static int PermuteN(int n)
        {
            return (n <= 1) ? 1 : (n * PermuteN(n - 1));
        }

        static void update(int[] cnt, char c)
        {
            for (int i = (int)c ; i < cnt.Length; i++)
                --cnt[i];
        }

        static int lexRank(string s)
        {
            int[] cnt = new int[256];
            int mul = PermuteN(s.Length);
            int len = s.Length;
            int rank = 1;
            computeCnt(cnt, s);
            for (int i = 0; i < s.Length; i++)
            {
                mul /= (len - i);

                rank += (cnt[s[i] - 1] * mul);
                update(cnt, s[i]);
            }

            Console.WriteLine("rank = {0}", rank);
            return rank;
        }
        
        static void Main(string[] args)
        {
            string s = "abc";
            lexRank(s);
            Console.ReadLine();
        }
    }
}
