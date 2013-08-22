using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindString
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

        static void FindStringInMatrix(char[,] mat, string s)
        {
            int m = mat.GetLength(0);
            int n = mat.GetLength(1);
            point[] points = new point[s.Length];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i, j] == s[0])
                    {
                        points[0] = new point(i, j);
                        FindIfValidCandidate(mat, i, j, s.Substring(1), points, 1);
                    }
                }
            }
        }

        static void FindIfValidCandidate(char[,] mat, int x, int y, string s, point[] points, int ndx)
        {
            if (s.Length == 0)
            {
                foreach (point p in points)
                {
                    Console.Write("{0} - [{1}, {2}] ", mat[p.x, p.y], p.x, p.y);
                }
                
                Console.WriteLine("\n");
                return;
            }

            if (ndx >= points.Length)
                return;
            
            int[] xmove = { 1, 1, 1, -1, -1, -1, 0, 0};
            int[] ymove = { 0, 1, -1, 1, -1, 0, 1, -1};                       

            for(int i = 0; i < xmove.Length; i++)
            {
                if (IsValidPoint(mat, x + xmove[i], y + ymove[i]) && mat[x + xmove[i], y + ymove[i]] == s[0])
                {
                    points[ndx] = new point(x + xmove[i], y + ymove[i]);
                    FindIfValidCandidate(mat, x + xmove[i], y + ymove[i], s.Substring(1), points, ndx + 1);
                }
            }
        }

        static bool IsValidPoint(char[,] mat, int x, int y)
        {
            if (x < 0 || y < 0 || x >= mat.GetLength(0) || y >= mat.GetLength(1))
                return false;
            return true;
        }

        static void Main(string[] args)
        {
            char[,] mat = { 
                         {'A', 'N', 'L', 'Y', 'S'},
                         {'I', 'S', 'D', 'E', 'S'},
                         {'I', 'E', 'E', 'D', 'E'},
                         {'A', 'D', 'S', 'X', 'G'}
                         };

            string s = "DES";
            FindStringInMatrix(mat, s);
            Console.ReadLine();
        }
    }
}
