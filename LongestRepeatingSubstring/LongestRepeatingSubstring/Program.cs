using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestRepeatingSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            //driver();
            SuffixLRS lrs = new SuffixLRS();
            lrs.LargestRepeatedSubString("banana");
            Console.ReadLine();
        }
    }
}
