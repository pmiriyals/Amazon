using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegexMatching
{
    class Program
    {
        static bool regex(string str, string pat)
        {
            if (pat.Length == 0 && str.Length == 0)
                return true;

            if (pat.Length == 1  && pat[0] == '?' && str.Length == 0)
                return false;

            if ((pat.Length > 0 && pat[0] == '?') || (pat.Length > 0 && str.Length > 0 && pat[0] == str[0]))
                return regex(str.Substring(1), pat.Substring(1));

            if (pat.Length > 0 && pat[0] == '*')
                return regex(str, pat.Substring(1)) || regex(str.Substring(1), pat);

            return false;
        }
        
        static void Main(string[] args)
        {
            string str = "abc";
            string pat = "a*";
            Console.WriteLine("pattern matched = {0}", regex(str, pat));
            Console.ReadLine();
        }
    }
}
