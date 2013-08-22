using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NthLargestElement
{
    class Program
    {
        static void swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        
        static int partition(int[] a, int left, int right, int pivotIndex)
        {
            int pivot = a[pivotIndex];
            swap(a, pivotIndex, right);
            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (a[i] < pivot)
                {
                    swap(a, i, storeIndex);
                    storeIndex++;
                }
            }
            swap(a, storeIndex, right);
            return storeIndex;
        }

        static int KthLargestElement(int[] a, int k)
        {
            if (k <= 0 || k > a.Length)
                return -1;
            int left = 0;
            int right = a.Length - 1;

            while (true)
            {
                int pivotIndex = left + (right - left) / 2;
                pivotIndex = partition(a, left, right, pivotIndex);
                int pivotDist = right - pivotIndex + 1;
                if (pivotDist == k)
                    return a[pivotIndex];
                else if (k < pivotDist)
                {
                    left = pivotIndex + 1;
                }
                else
                {
                    k = k - pivotDist;
                    right = pivotIndex - 1;
                }
            }            
        }

        static void Main(string[] args)
        {
            int[] a = { 1, 23, 12, 9, 30, 2, 50 };
            Console.WriteLine(KthLargestElement(a, 1));
            Console.ReadLine();
        }
    }
}
