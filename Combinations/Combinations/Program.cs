using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            RCombinations.driver();
            Combinations.driver();
            CombinationsComposingGivenPoint.driver();
            CombinationSum.driver();
            Console.ReadLine();
        }
    }
}
