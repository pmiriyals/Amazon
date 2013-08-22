using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuffixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            SuffixLRS lrs = new SuffixLRS();
            string s = "Dont ask what the country has done for ask what did you do for your country";
            lrs.LargestRepeatedSubString(s);
            Console.ReadLine();
        }
    }
}
