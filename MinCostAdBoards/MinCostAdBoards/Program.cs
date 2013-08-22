using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinCostAdBoards
{
    class Program
    {
        class board
        {
            public int price { get; set; }
            public bool InHeap { get; set; }
            public int HeapIndex { get; set; }

            public board(int price)
            {
                this.price = price;
                this.InHeap = false;
                this.HeapIndex = -1;
            }
        }

        static void heapify(board[] arr)
        {
            int end = arr.Length - 1;   //last child
            int start = (end - 1) / 2;  //last parent

            while (start >= 0)
            {
                siftDown(arr, start, end);
                start--;
            }
        }

        static void siftDown(board[] arr, int start, int end)
        {
            int root = start;

            while ((2 * root + 1) <= end)
            {
                int child = 2 * root + 1;
                int swap = root;

                if (arr[swap].price < arr[child].price)
                    swap = child;

                if ((child + 1 <= end) && (arr[swap].price < arr[child + 1].price))
                    swap = child + 1;

                if (swap != root)
                {
                    board temp = arr[swap];
                    arr[swap] = arr[root];
                    arr[swap].HeapIndex = swap;
                    arr[root] = temp;
                    arr[root].HeapIndex = root;
                }
                else
                    return;
            }
        }

        static void FindMinCost(board[] boards, int M, int K)
        {
            int N = boards.Length;
            board[] cost = new board[K];

            int minCost;
            int totalCost = 0;

            int ndx;

            for (ndx = 0; ndx < K; ndx++)
            {
                cost[ndx] = boards[ndx];    //Get the 1st K boards
                cost[ndx].InHeap = true;
                cost[ndx].HeapIndex = ndx;
                totalCost += cost[ndx].price;
            }            
            //Place Cost arr in Max Heap
            heapify(cost);

            //For the 1st M boards, we will have the Min Cost at the end of the loop
            for (; ndx < M; ndx++)
            {
                if (cost[0].price > boards[ndx].price)
                {
                    cost[0].InHeap = false;  //Remove from heap
                    cost[0].HeapIndex = -1; //reset heap index to -1
                    totalCost -= cost[0].price;
                    cost[0] = boards[ndx];
                    cost[0].InHeap = true;
                    cost[0].HeapIndex = 0;
                    totalCost += cost[0].price;
                    siftDown(cost, 0, cost.Length - 1);
                }
            }
            int[] MinArr = new int[cost.Length];
            CopyPrice(MinArr, cost);
            minCost = totalCost;    
            //Iterate over each M consecutive boards
            int start = 0;
            for (; ndx < N; ndx++)
            {
                if (boards[start].InHeap)   //remove element out of current window
                { 
                    //Remove from heap
                    boards[start].InHeap = false;
                    totalCost -= boards[start].price;
                    cost[boards[start].HeapIndex] = boards[ndx];
                    totalCost += boards[ndx].price;
                    cost[boards[start].HeapIndex].HeapIndex = boards[start].HeapIndex;
                    boards[start].HeapIndex = -1;
                    siftDown(cost, 0, cost.Length - 1);
                }
                else if (cost[0].price > boards[ndx].price)
                {
                    cost[0].InHeap = false; //Replace Max Heap element with element in current window
                    cost[0].HeapIndex = -1;
                    totalCost -= cost[0].price;
                    cost[0] = boards[ndx];
                    cost[0].InHeap = true;
                    cost[0].HeapIndex = 0;
                    totalCost += cost[0].price;
                    siftDown(cost, 0, cost.Length - 1);
                }
                if (totalCost < minCost)
                {
                    CopyPrice(MinArr, cost);
                    minCost = totalCost;
                }
                start++;
            }
                        
            Console.Write("Min cost elements: ");
            foreach (int i in MinArr)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("\nTotal min cost = {0}", minCost);
        }

        static void CopyPrice(int[] cost, board[] MinBoards)
        {
            for (int i = 0; i < cost.Length; i++)
            {
                cost[i] = MinBoards[i].price;
            }
        }

        static void Main(string[] args)
        {            
            int[] price = { 7, 10, 9, 3, 10, 12, 4, 8, 6, 5 };
            board[] boards = new board[price.Length];

            for (int i = 0; i < price.Length; i++)
            {
                boards[i] = new board(price[i]);
            }

            FindMinCost(boards, 7, 3);
            Console.ReadLine();
        }
    }
}
