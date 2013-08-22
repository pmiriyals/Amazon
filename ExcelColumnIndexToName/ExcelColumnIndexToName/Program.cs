using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelColumnIndexToName
{
    class Program
    {
        //assumes index  = 1 to 26
        static char getChar(int index)
        { 
            if(index < 0 || index >= 26)
                return '\0';

            return (char)('A' + index);
        }

        static string GetColName(int val, string s)
        {
            if (val <= 0)
                return s;
            
            string res = "";

            while (val > 0) {
            int idx = (val - 1) % 26;
            res = (char)(idx + 65) + res;
            val = (val - 1) / 26;
            }

            return res;
        }
        
        static void Main(string[] args)
        {
            int[] arr = {1, 2, 26, 52, 53, 54};
            foreach (int i in arr)
                Console.WriteLine(GetColName(i, ""));
            Console.ReadLine();
        }
    }
}
