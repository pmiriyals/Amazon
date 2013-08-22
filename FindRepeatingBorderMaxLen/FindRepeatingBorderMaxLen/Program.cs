using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindRepeatingBorderMaxLen
{
    class Program
    {
        //Border of a string is both prefix and suffix of that string
        
        static void FindBorder(string s)
        {
            int i = 0; 
            int j = s.Length - 1;

            while (i <= j && s[i] == s[j])
            {
                i++; j--;
            }
            if (i == 0)
            {
                Console.WriteLine("No borders at all");
                return;
            }

            string border = s.Substring(0, i);
            s = s.Substring(1, s.Length-1);
            Console.WriteLine("Border = {0}", border);
            Console.WriteLine("Remaining string = {0}", s);

            GenerateRepeatingBorder(s, border);

        }

        //Search border in the remainder of the string
        private static void GenerateRepeatingBorder(string s, string border)
        {
            string longestRepeatingBorder = KMP(s, border);
            Console.WriteLine("Longest Repeating Border = {0}", longestRepeatingBorder);

            //longest common substring of s and border is our longest repeating border: O(n2)
            //suffix tree takes O(m+n)
            //prefix tree using dictionary takes O(k) time to construct and O(k^2) space
            //KMP takes O(n-2k) = O(n) time to search max len
        }

        static string KMP(string txt, string pat)
        {
            int[] lps = new int[pat.Length];
            ComputeLPS(pat, lps);

            int i = 0, j = 0;
            int start = -1;
            int max = 0;
            
            while (i < txt.Length)
            {
                if (txt[i] == pat[j])
                {
                    if (max < (j + 1))
                    {
                        start = i - j;
                        max = j + 1;
                    }
                    i++; j++;
                }

                if (j == pat.Length)
                {
                    break;  //found max length border
                }
                else if (txt[i] != pat[j])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return (start < 0) ? "" : txt.Substring(start, max);
        }

        static void ComputeLPS(string pat, int[] lps)
        {
            int len = 0;
            int i = 1;
            lps[0] = 0;

            while (i < pat.Length)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            string s = "aaaaaa";
            FindBorder(s);
            Console.ReadLine();
        }
    }
}
