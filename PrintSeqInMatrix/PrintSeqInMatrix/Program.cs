using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintSeqInMatrix
{
    class Program
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

        static void PrintSeq(int[,] mat)
        {            
            Stack<point> stk = new Stack<point>();
                        
            point cur = null;
            int m = mat.GetLength(0);
            int n = mat.GetLength(1);
            int[] xmove = { 0, 1, -1, 0 };
            int[] ymove = { 1, 0, 0, -1};

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i, j] > 0)
                    {
                        stk.Push(new point(i, j));

                        bool isseq = false;

                        while (stk.Count > 0)
                        {
                            cur = stk.Pop();

                            for (int k = 0; k < xmove.Length; k++)
                            {
                                if (IsValid(mat, cur.x, cur.y, xmove[k], ymove[k]))  //if this is a valid point
                                {                                    
                                    stk.Push(new point(cur.x + xmove[k], cur.y + ymove[k]));
                                    isseq = true;
                                    break;  //find only one sequence with this point                                    
                                }
                            }
                            if (isseq)
                            {
                                Console.Write("{0} ", mat[cur.x, cur.y]);
                                mat[cur.x, cur.y] = -1; //marking this node as visited
                            }
                        }
                        if(isseq)
                            Console.WriteLine();
                    }
                }
            }
        }

        static bool IsValid(int[, ] mat, int x, int y, int i, int j)
        {
            if ((x + i) < 0 || (y + j) < 0 || (x + i) >= mat.GetLength(0) || (y + j) >= mat.GetLength(1) || (Math.Abs(mat[x, y] - mat[x + i, y+ j]) != 1))
                return false;

            return true;
        }

        static void Main(string[] args)
        {
            int[,] mat = { 
                         {3, 4, 7, 3},
                         {4, 5, 8, 1},
                         {6, 4, 5, 2}
                         };
            PrintSeq(mat);
            Console.ReadLine();
        }
    }
}
