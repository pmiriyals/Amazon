using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextGreaterEleemnt
{
    class Program
    {
        static void NGE(int[] arr)
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(arr[0]);
            
            for (int i = 1; i < arr.Length; i++)
            {
                while (stk.Count > 0 && arr[i] > stk.Peek())
                {
                    Console.WriteLine("{0} -> {1} (NGE)", stk.Pop(), arr[i]);
                }
                stk.Push(arr[i]);
            }

            while (stk.Count > 0)
            {
                Console.WriteLine("{0} -> {1} (NGE)", stk.Pop(), -1);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 11, 4, 5, 2, 25, 13, 21, 3 };
            NGE(arr);
            Console.ReadLine();
        }
    }
}
