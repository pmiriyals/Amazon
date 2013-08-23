using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedianOfStreamOfIntegers
{
    class Program
    {
        //median is the root element
        //minHeap contains set of all elemenst greater than the one's in maxHeap, that is minHeap is the right sub arr of a sorted list
        //similarly maxHeap is the leftSub arr of a sorted list
        
        static List<int> minHeap = new List<int>();
        static List<int> maxHeap = new List<int>();
        static int median = -1;


        static int Median(int data)
        {
            if (median < 0) //base case for the 1st element (entire heap is empty at the moment)
            {
                median = data;
                minHeap.Add(data); // add to the right sub tree 
            }
            else
            {
                bool siftMin = false;
                bool siftMax = false;
                
                if (data < minHeap[0])  //then element should go into left sub tree
                {
                    if (maxHeap.Count <= minHeap.Count)
                    {
                        maxHeap.Add(data);
                        siftMax = true;
                    }
                    else if (data < maxHeap[0])  //copy root of maxHeap to minHeap and add data to maxHeap, so that difference always remains at most 1
                    {
                        minHeap.Add(maxHeap[0]);
                        maxHeap[0] = data;  //data is max in maxheap
                        siftMin = true;
                    }
                    else
                    {
                        minHeap.Add(data);
                        siftMin = true;
                    }
                }
                else
                {
                    if (minHeap.Count <= maxHeap.Count)
                    {
                        minHeap.Add(data);
                        siftMin = true;
                    }
                    else
                    {
                        maxHeap.Add(minHeap[0]);    //if data is greater than min of right subarr, then move min to left subarr and copy data to right subarr (when minHeap count is more)
                        minHeap[0] = data;
                        siftMax = true;
                    }
                }

                if(siftMin)
                    minSiftDown(minHeap, 0, minHeap.Count - 1);
                if(siftMax)
                    maxSiftDown(maxHeap, 0, maxHeap.Count - 1);

                if (minHeap.Count == maxHeap.Count)
                    median = (minHeap[0] + maxHeap[0]) / 2;
                else if (minHeap.Count > maxHeap.Count)
                    median = minHeap[0];
                else
                    median = maxHeap[0];
            }

            return median;
        }

        //static void minHeapify(List<int> arr)
        //{
        //    int end = arr.Count - 1;
        //    int start = (end - 1) / 2;

        //    while (start >= 0)
        //    {
                
        //    }
        //}

        static void maxSiftDown(List<int> data, int start, int end)
        {
            int root = start;

            while ((root * 2 + 1) <= end)
            {
                int child = root * 2 + 1;
                int swap = root;

                if (data[swap] < data[child])
                    swap = child;

                if ((child + 1) <= end && data[swap] < data[child + 1])
                    swap = child + 1;

                if (root != swap)
                {
                    int temp = data[root];
                    data[root] = data[swap];
                    data[swap] = temp;

                    root = swap;
                }
                else
                    return;
            }
        }

        static void minSiftDown(List<int> data, int start, int end)
        {
            int root = start;

            while ((root * 2 + 1) <= end)
            {
                int child = root * 2 + 1;
                int swap = root;

                if (data[swap] > data[child])
                    swap = child;

                if ((child + 1) <= end && data[swap] > data[child + 1])
                    swap = child + 1;

                if (root != swap)
                {
                    int temp = data[root];
                    data[root] = data[swap];
                    data[swap] = temp;

                    root = swap;
                }
                else
                    return;
            }
        }
        
        static void Main(string[] args)
        {
            int[] arr = { 5, 15, 1, 3, 2, 8, 7, 9, 10, 6, 11, 4 };

            foreach (int i in arr)
                Console.WriteLine("Median = {0} (after inserting {1})", Median(i), i);
            Console.ReadLine();
        }
    }
}
