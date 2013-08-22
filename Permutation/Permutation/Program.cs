using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutation
{
    class Program
    {
        static void LexicographicPermute(string s, string p, int l)
        {
            if (l == p.Length)
            {
                Console.WriteLine(p);
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {                
                LexicographicPermute(s.Substring(0, i) + s.Substring(i + 1), p + s[i], l);
            }
        }

        static void Main(string[] args)
        {
            string s = "cba";
            char[] str = s.ToCharArray();
            Array.Sort(str);
            s = new String(str);
            LexicographicPermute(s, "", s.Length);
            Console.ReadLine();
        }
    }
}
