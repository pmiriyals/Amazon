using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MobileKeyPad
{
    class Program
    {
        static string str;
        static char[] arr;
        static string[] key = { "0", "1", "ABC", "DEF", "GHI", "JKL", "MNO", "PQR", "STU", "VWXYZ" };
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number: ");
            str = Console.ReadLine();
            str = Regex.Replace(Regex.Replace(str, "0", ""), "1", "");
            arr = new char[str.Length];
            Parse(0);
            Console.ReadLine();
        }

        static void Parse(int index)
        {
            if (index < str.Length)
            {
                for (int i = 0; i < key[str[index] - 48].Length; i++)
                {
                    arr[index] = key[str[index] - 48][i];
                    Parse(index + 1);
                }
            }
            else
                Console.WriteLine(arr);
        }
    }
}
