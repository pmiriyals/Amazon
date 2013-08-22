using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditDistance
{
    class Program
    {
        static int ic = 2;
        static int dc = 3;
        static int sc = 4;

        static int LevDist(string a, string b)
        {
            if (a == b)
                return 0;
            
            if (a == null || b == null)
                return -1;

            if (a.Length == 0)
                return b.Length * ic;

            if (b.Length == 0)
                return a.Length * dc;

            Console.WriteLine("Lev Dist using Matrix = {0}", LevDistUsingMatrix(a, b));
            
            return LevDistUsingVectors(a, b);
        }

        static int LevDistUsingMatrix(string a, string b)
        {
            int[,] mat = new int[a.Length + 1, b.Length + 1];   //mat[i, j] is the lev dist of a[0 to i-1] and b[0 to j-1]

            for (int i = 0; i <= a.Length; i++)
                mat[i, 0] = i * dc; //b is empty, delete chars in a 

            for (int i = 0; i <= b.Length; i++)
                mat[0, i] = i * ic; //a is empty, insert to 'a' to convert to b

            for (int j = 1; j <= b.Length; j++)
            {
                for (int i = 1; i <= a.Length; i++)
                {
                    if (a[i - 1] == b[j - 1])
                        mat[i, j] = mat[i - 1, j - 1];
                    else
                        mat[i, j] = Math.Min(Math.Min(mat[i - 1, j] + dc, mat[i, j - 1] + ic), mat[i - 1, j - 1] + sc);
                }
            }

            return mat[a.Length, b.Length];
        }

        static int LevDistUsingVectors(string a, string b)
        {
            int[] v0 = new int[b.Length + 1];
            int[] v1 = new int[b.Length + 1];

            for (int i = 0; i < v0.Length; i++)
                v0[i] = i * ic; //mat[0, i]: source is empty (row 1)

            for (int i = 0; i < a.Length; i++)
            {
                v1[0] = (i + 1) * dc;   //mat[i+1, 0]: target empty, so delete i+1 chars from s

                for (int j = 0; j < b.Length; j++)
                {
                    int cost = (a[i] == b[j]) ? 0 : sc;
                    v1[j + 1] = Math.Min(Math.Min(v1[j] + ic, v0[j + 1] + dc), v0[j] + cost);
                }

                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }

            return v1[b.Length];
        }

        static void Main(string[] args)
        {
            string a = "";
            string b = "ac";
            Console.WriteLine("Lev Dist = {0}", LevDist(a, b));
            Console.ReadLine();
        }
    }
}
