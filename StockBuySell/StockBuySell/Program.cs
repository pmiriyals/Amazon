using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBuySell
{
    class Program
    {
        class stock
        {
            public int buy;
            public int sell;
        }

        static void stockbuysell(int[] a)
        {
            if (a.Length <= 1)
                return;
            
            int i = 0;
            stock[] s = new stock[a.Length / 2];
            int count = 0;

            while (i < a.Length-1)
            {
                while (i < (a.Length - 1) && (a[i] >= a[i + 1]))
                    i++;

                s[count] = new stock();
                s[count].buy = a[i++];

                while (i < a.Length && (a[i] >= a[i - 1]))
                    i++;

                s[count].sell = a[i - 1];
                count++;
            }

            for (int j = 0; j < count; j++)
                Console.WriteLine("buy = {0} and sell = {1}", s[j].buy, s[j].sell);
        }

        static void Main(string[] args)
        {
            int[] a = { 100, 180, 260, 310, 40, 535, 695 };
            stockbuysell(a);
            Console.ReadLine();
        }
    }
}
