using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinationsORPowerSet
{
    class Program
    {
        static void powerset(string s, string target, int n)
        {
            Console.WriteLine(target);
            if (target.Length == n)
                return;

            for (int i = 0; i < s.Length; i++)
            {
                powerset(s.Substring(0, i) + s.Substring(i + 1), target + s[i], n);
            }
        }

        static void powerset(string s, string target, int n, int start)
        {
            Console.WriteLine(target);
            if (target.Length == n)
                return;

            for (int i = start; i < s.Length; i++)
            {
                powerset(s, target + s[i], n, i+1);
            }
        }

        static void powerset(string s, char[] data, int ndx, int start)
        {
            for (int j = 0; j < ndx; j++)
                Console.Write("{0}", data[j]);
            Console.WriteLine();
            if (data.Length == ndx)
                return;

            for (int i = start; i < s.Length; i++)
            {
                data[ndx] = s[i];
                powerset(s, data, ndx + 1, i + 1);
            }
        }

        static void powerset(string s)
        {
            int num = (int) Math.Pow(2, s.Length);

            for (int i = 0; i < num; i++)
            {
                int val = i;
                int ndx = 0;
                while (val > 0)
                {
                    if ((val & 1) > 0)
                        Console.Write("{0}", s[ndx]);
                    val >>= 1;
                    ndx++;
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string s = "abc";
            char[] data = new char[s.Length];
            //powerset(s, "", s.Length, 0);
            //powerset(s, data, 0, 0);
            powerset(s);
            Console.ReadLine();
        }
    }
}
