using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knight
{
    class Knight
    {
        class point
        {
            public int x { get; set; }
            public int y { get; set; }
            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        
        static void Tour(int[,] board, point p)
        {
            Stack<point> stk = new Stack<point>();
            stk.Push(p);

            int[] x = { 1, 2, 1, 2, -1, -1, -2, -2};
            int[] y = { 2, 1, -2, -1, 2, -2, 1, -1};
            point cur = null;
            int step = 1;
            int cnt = board.GetLength(0) * board.GetLength(1) - 1;
            while (stk.Count > 0)
            {
                cur = stk.Pop();
                board[cur.x, cur.y] = step++;

                if (cnt > 0)
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        if (isValid(board, cur.x + x[i], cur.y + y[i]))
                        {
                            board[cur.x + x[i], cur.y + y[i]] = -1; //mark as visited
                            stk.Push(new point(cur.x + x[i], cur.y + y[i]));
                            cnt--;
                        }
                    }
                }
            }

            printMat(board);
        }

        static void FindPath(int[,] board, point from, point to)
        {
            Queue<point> queue = new Queue<point>();
            queue.Enqueue(from);

            int[] x = { 1, 2, 1, 2, -1, -1, -2, -2 };
            int[] y = { 2, 1, -2, -1, 2, -2, 1, -1 };
            point cur = null;
            int step = 1;
            int cnt = board.GetLength(0) * board.GetLength(1) - 1;

            while (queue.Count > 0)
            {
                cur = queue.Dequeue();
                board[cur.x, cur.y] = step;

                if (cur.x == to.x && cur.y == to.y)
                {
                    Console.WriteLine("Length of path between given points = {0}", step);
                    break;
                }
                step++;
                if (cnt > 0)
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        if (isValid(board, cur.x + x[i], cur.y + y[i]))
                        {
                            board[cur.x + x[i], cur.y + y[i]] = -1;
                            queue.Enqueue(new point(cur.x + x[i], cur.y + y[i]));
                            cnt--;
                        }
                    }
                }
            }
            printMat(board);
        }

        static void printMat(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool isValid(int[,] board, int x, int y)
        {
            if (x < 0 || y < 0 || x >= board.GetLength(0) || y >= board.GetLength(1) || board[x, y] != 0)
                return false;
            return true;
        }
        
        public static void driver()
        {
            int[,] board = new int[8, 8];
            //Tour(board, new point(0, 0));
            FindPath(board, new point(0, 0), new point(2, 0));
        }
    }
}
