using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncodeString
{
    class Program
    {
        static void Encode(string s)
        {
            char cur = s[0];
            int cnt = 1;
            string encoded = "";
            for(int i = 1; i < s.Length; i++)
            {
                if (s[i] != cur)
                {
                    encoded += cnt.ToString() + cur.ToString();
                    cnt = 1;
                    cur = s[i];
                }
                else
                    cnt++;
            }
            encoded += cnt.ToString() + cur.ToString();
            Console.WriteLine("Encoded string = {0}", encoded);
        }
        
        static void Main(string[] args)
        {
            string s = "AAABABBCZZZZZL";
            Encode(s);
            Console.ReadLine();
        }
    }
}
