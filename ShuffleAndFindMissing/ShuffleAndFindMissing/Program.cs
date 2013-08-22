using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShuffleAndFindMissing
{
    class Program
    {
        static void Shuffle(List<int> lstNum)
        {
            Random r = new Random();
            for (int i = 0; i < lstNum.Count; i++)
            {
                int j = r.Next(0, i);

                int temp = lstNum[i];
                lstNum[i] = lstNum[j];
                lstNum[j] = temp;
            }
            Console.Write("After shuffling: ");
            foreach (int n in lstNum)
                Console.Write("{0} ", n);
        }

        static int findMissing(List<int> lstNum)
        {
            int sum = 0;
            int max = -1;
            for (int i = 0; i < lstNum.Count; i++)
            {
                sum += lstNum[i];
                if(max < lstNum[i])
                    max = lstNum[i];
            }

            int n = (max * (max + 1) / 2) - sum;
            Console.WriteLine("\nMissing number = {0}", n);
            return n;
        }

        static void Main(string[] args)
        {
            List<int> lstNum = new List<int>();
            lstNum.Add(1);
            lstNum.Add(2);
            lstNum.Add(3);
            lstNum.Add(4);
            //lstNum.Add(5);
            lstNum.Add(6);
            lstNum.Add(7);
            lstNum.Add(8);
            Shuffle(lstNum);
            findMissing(lstNum);
            Console.ReadLine();
        }
    }
}
