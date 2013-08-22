using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortByFrequency
{
    class Program
    {
        class element
        {
            public int val { get; set; }
            public int freq { get; set; }
            public int firstIndex { get; set; }

            public element(int val, int firstIndex)
            {
                this.val = val;
                this.freq = 1;
                this.firstIndex = firstIndex;
            }
        }
        
        static void heapify(List<element> arr)
        {
            int end = arr.Count - 1;
            int start = (end - 1) / 2;

            while (start >= 0)
            {
                siftDown(arr, start, end);
                start--;
            }
        }

        static void siftDown(List<element> arr, int start, int end)
        {
            int root = start;
            while ((2 * root + 1) <= end)
            {
                int child = 2 * root + 1;
                int swap = root;

                if (arr[swap].freq < arr[child].freq)
                    swap = child;

                if ((child + 1) <= end && arr[swap].freq < arr[child + 1].freq)
                    swap = child + 1;

                if (swap != root)
                {
                    element temp = arr[swap];
                    arr[swap] = arr[root];
                    arr[root] = temp;
                    root = swap;
                }
                else
                    return;
            }
        }

        static void driver(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int mc = 1;
            int max = arr[0];
            int[] op = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], 1);
                }
                else
                    dict[arr[i]]++; //increment frequency

                if (mc < dict[arr[i]])
                {
                    mc = dict[arr[i]];
                    max = arr[i];
                }

                op[i] = max;
            }

            for (int i = 0; i < op.Length; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, op[i]);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 6, 3, 1, 3, 6, 3, 4, 2 };//o/p: 1, 1, 1, 1, 3, 
            driver(arr);
            //SortByFreqInefficient(arr);
            Console.ReadLine();
        }

        private static void SortByFreqInefficient(int[] arr)
        {
            int[] op = new int[arr.Length];
            Dictionary<int, element> dict = new Dictionary<int, element>();
            List<element> lstEle = new List<element>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    element e = new element(arr[i], i);
                    dict.Add(arr[i], e);
                    lstEle.Add(e);
                    heapify(lstEle);
                }
                else
                {
                    dict[arr[i]].freq++;
                    siftDown(lstEle, 0, lstEle.Count - 1);
                }

                op[i] = lstEle[0].val;
            }

            for (int i = 0; i < op.Length; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, op[i]);
            }
        }
    }
}
