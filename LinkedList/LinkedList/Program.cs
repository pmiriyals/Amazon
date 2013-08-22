using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    class Program
    {
        static int sumrecur(int[] arr, int n, int sum)
        {
            if (n == 0)
                return sum;

            sum += arr[n-1];
            return sumrecur(arr, n - 1, sum);
        }
        
        static void Main(string[] args)
        {
            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Console.WriteLine("Sum = {0}", sumrecur(arr, 5, 0));
            
            LinkedList.driver();
            Console.ReadLine();
        }
    }
}
