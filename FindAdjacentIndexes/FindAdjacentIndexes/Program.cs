using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindAdjacentIndexes
{
    class Program
    {
        //Construct MinHeap of Array Objects, where Objects contains (val, index), Sort by val and get the indexes: O(n log n) time and O(n) space, will be problematic with equal elements
        //Use a Dictionary<val, List<index>>: Sorting Dictionary by val is an issue

        class node
        {
            public int val { get; set; }
            public int index { get; set; }
            public node(int val, int index)
            {
                this.val = val;
                this.index = index;
            }
        }

        static void heapify(node[] arr)
        {
            int end = arr.Length - 1;
            int start = (end - 1) / 2;

            while (start >= 0)
            {
                siftDown(arr, start, end);
                start--;
            }
        }

        static void siftDown(node[] arr, int start, int end)
        {
            int root = start;

            while ((2 * root + 1) <= end)
            {
                int swap = root;
                int child = 2 * root + 1;

                if (arr[swap].val < arr[child].val)
                    swap = child;

                if ((child + 1) <= end && arr[swap].val < arr[child + 1].val)
                    swap = child + 1;

                if (root != swap)
                {
                    node temp = arr[swap];
                    arr[swap] = arr[root];
                    arr[root] = temp;
                    root = swap;
                }
                else
                    return;
            }
        }

        static void heapSort(node[] arr)
        {
            heapify(arr);;
            int end = arr.Length - 1;
            while (end > 0)
            {
                node temp = arr[0];
                arr[0] = arr[end];
                arr[end] = temp;
                end--;
                siftDown(arr, 0, end);
            }
        }
        
        static void FindAdjacentIndex(int[] arr)
        {
            node[] n = new node[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                n[i] = new node(arr[i], i);
            }

            heapSort(n);
            Console.WriteLine("After sorting elements: ");
            foreach (node ele in n)
            {
                Console.WriteLine("val = {0} & index = {1}", ele.val, ele.index);
            }

            Console.WriteLine("Adjacent Pairs: ");

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            //node cur = n[0];
            //int prevIndex = cur.index;
            //List<int> dup = new List<int>();
            //for(int i = 1; i < n.Length; i++)
            //{
            //    if (cur.val == n[i].val)
            //    {
            //        dup.Add(n[i].val);
            //    }
            //    else if (dup.Count > 0)
            //    {
            //        foreach (int j in dup)
            //        {
            //            Console.Write("({0}, {1}) ", prevIndex, j);
            //            Console.Write("({0}, {1}) ", j, n[i].index);
            //        }
            //        dup.Clear();
            //        Console.WriteLine();

            //        Console.WriteLine("({0}, {1})", cur.index, n[i].index);
            //        prevIndex = cur.index;
            //        cur = n[i];
            //    }
            //    else
            //    {                    
            //        Console.WriteLine("({0}, {1})", cur.index, n[i].index);
            //        prevIndex = cur.index;
            //        cur = n[i];
            //    }
                
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 0, 3, 3, 7, 5, 3, 11, 1};
            FindAdjacentIndex(arr);
            Console.ReadLine();
        }
    }
}
