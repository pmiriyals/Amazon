using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void LPS(string s)
        {
            int max = 1;
            int start = 0;

            for (int i = 1; i < s.Length; i++)
            {
                int low = i - 1;
                int high = i + 1;

                while (low >= 0 && high < s.Length && s[low] == s[high])
                {
                    if ((high - low + 1) > max)
                    {
                        max = high - low + 1;
                        start = low;
                    }
                    low--; high++;
                }

                low = i - 1;
                high = i;

                while (low >= 0 && high < s.Length && s[low] == s[high])
                {
                    if ((high - low + 1) > max)
                    {
                        max = high - low + 1;
                        start = low;
                    }

                    low--; high++;
                }                
            }

            Console.WriteLine("Length of longest palindromic substring = {0}\nLPS = {1}", max, s.Substring(start, max));            
        }

        static void Main(string[] args)
        {
            string s = "thegeeksskeegforgeeks";
            LPS(s);
            Console.ReadLine();
        }
    }
}
