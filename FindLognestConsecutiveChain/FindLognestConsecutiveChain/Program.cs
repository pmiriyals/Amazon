using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindLognestConsecutiveChain
{
    class Program
    {
        class point
        {
            public int x { get; set; }
            public int y { get; set; }
            public bool isvisited { get; set; }

            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
                isvisited = false;
            }
        }
        
        static void FindLongestChain(int[,] mat)
        {
            HashSet<point> sol = new HashSet<point>();
            HashSet<point> buf = new HashSet<point>();

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    bool[,] visited = new bool[mat.GetLength(0), mat.GetLength(1)];
                    FindSeq(mat, new point(i, j), sol, buf, visited);
                    buf.Clear();
                }
            }
            Console.WriteLine("\n\nFinal solution: ");
            foreach (point p in sol)
            {
                Console.Write("{0} ", mat[p.x, p.y]);
            }
        }

        static int sol_num = 0;

        static void FindSeq(int[,] mat, point p, HashSet<point> sol, HashSet<point> buf, bool[, ] visited)
        {
            Stack<point> stk = new Stack<point>();
            stk.Push(p);
            int[] xmove = { 0, 0, 1, -1};
            int[] ymove = { 1, -1, 0, 0};
            visited[p.x, p.y] = true;
            while (stk.Count > 0)
            {
                point pt = stk.Pop();
                buf.Add(pt);
                bool noSeq = true;
                for (int i = 0; i < xmove.Length; i++)
                {
                    if (isValid(mat, pt.x + xmove[i], pt.y + ymove[i], pt, visited))
                    {
                        stk.Push(new point(pt.x + xmove[i], pt.y + ymove[i]));
                        visited[pt.x + xmove[i], pt.y + ymove[i]] = true;
                        noSeq = false;
                    }
                }
                if (noSeq)
                { 
                    //traverse back, path ends
                    if (sol.Count < buf.Count)  
                    {
                        sol.Clear();
                        Console.Write("Sol{0}: ", sol_num++);
                        foreach (point psol in buf)
                        {
                            sol.Add(psol);
                            Console.Write("{0} ", mat[psol.x, psol.y]);
                        }
                        Console.WriteLine();
                    }
                    buf.Remove(pt);
                }
            }

        }

        static bool isValid(int[,] mat, int x, int y, point pt, bool[, ] visited)
        {
            if (x < 0 || y < 0 || x >= mat.GetLength(0) || y >= mat.GetLength(1) || visited[x, y] == true || (Math.Abs(mat[x, y] - mat[pt.x, pt.y]) != 1))
                return false;
            return true;
        }
        
        static void Main(string[] args)
        {
            int[,] mat = { 
                         {4, 7, 9, 8},
                         {5, 6, 5, 4},
                         {6, 7, 8, 5},
                         {10, 9, 7, 6}
                         };
            FindLongestChain(mat);
            Console.ReadLine();
        }
    }
}
