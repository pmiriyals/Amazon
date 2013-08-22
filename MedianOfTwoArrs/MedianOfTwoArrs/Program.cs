using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedianOfTwoArrs
{
    class Program
    {
        static int FindMedian(int[] a, int[] b, int na, int nb)
        {
            int m1, m2;

            if (na <= 0 && nb <= 0)
                return -1;

            if (na == 1 && nb == 1)
                return (a[0] + b[0]) / 2;

            if (na == 2 && nb == 2)
                return (Math.Max(a[0], b[0]) + Math.Min(a[1], b[1])) / 2;

            m1 = Median(a, na);
            m2 = Median(b, nb);

            if (m1 == m2)
                return m1;
            
            if (m1 < m2)
            {
                if (na % 2 == 0 && nb % 2 == 0)
                    return FindMedian(getarr(a, na / 2 - 1, false), getarr(b, nb / 2 + 1, true), na / 2 + 1, nb / 2 + 1);
                else //if (na % 2 != 0 && nb % 2 != 0)
                    return FindMedian(getarr(a, na / 2, false), getarr(b, nb / 2, true), na / 2, nb / 2);
            }
            else
            {
                if (na % 2 == 0 && nb % 2 == 0)
                    return FindMedian(getarr(a, na / 2 - 1, true), getarr(b, nb / 2 + 1, false), na / 2 + 1, nb / 2 + 1);
                else //if (na % 2 != 0 && nb % 2 != 0)
                    return FindMedian(getarr(a, na / 2, true), getarr(b, nb / 2, false), na / 2, nb / 2);
            }
        }

        static int[] getarr(int[] a, int n, bool isfront)
        {
            int[] arr = new int[n];
            int j = 0;
            if (isfront)
            {
                for (int i = 0; i < n; i++)
                    arr[j++] = a[i];
            }
            else
            {
                for (int i = n; i < a.Length; i++)
                {
                    arr[j++] = a[i];
                }
            }

            return arr;
        }

        static int Median(int[] arr, int l)
        {
            if (l % 2 == 0)
                return (arr[l / 2] + arr[l / 2 - 1]) / 2;
            else
                return arr[l / 2];
        }

        static void Main(string[] args)
        {
            //1, 2, 4, 5, 8, 10, 15, 16, 20, 25, 32, 64
            int[] a = { 1, 5, 10, 15, 20, 25 };
            int[] b = { 2, 4, 8, 16, 32, 64};
            Console.WriteLine("Median = {0}", FindMedian(a, b, a.Length, b.Length));
            Console.ReadLine();
        }
    }
}
