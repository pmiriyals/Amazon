using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestRepeatingSubstring
{
    class LRSUsingPermutation
    {
        public static String longest(String v, String r, int pos)
        {
            if (pos >= v.Length)
            {
                return r;
            }
            String newR = r + v[pos];
            int fromIndex = v.IndexOf(newR) + 1;
            if (fromIndex >= v.Length)
                return r;

            int indexOf = v.IndexOf(newR, fromIndex);
            if (indexOf == -1)
                return r;

            return longest(v, newR, pos + 1);
        }

        private static void driver()
        {
            String a = "banana";
            String l = "";
            for (int i = 0; i < a.Length; i++)
            {
                String temp = longest(a, "", i);
                if (temp.Length > l.Length)
                    l = temp;
            }
            Console.WriteLine(l);
        }
    }
}
