using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwayGame
{
    class Program
    {
        static int step = 1;

        static void Conway(int[,] mat)
        {
            int m = mat.GetLength(0);
            int n = mat.GetLength(1);
            printMat(mat, "before Conway");

            int[,] neighbor = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    neighbor[i, j] = getLiveNeighbors(mat, i, j);
                }
            }
            printMat(neighbor, "Neighbor matrix");

            ExecuteConwayStep(mat, neighbor);
            printMat(mat, "after Conway");
        }

        static void ExecuteConwayStep(int[,] mat, int[,] neighbor)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] == 1 && (neighbor[i, j] < 2 || neighbor[i, j] > 3))
                        mat[i, j] = 0;
                    else if (mat[i, j] == 0 && neighbor[i, j] == 3)
                        mat[i, j] = 1;
                }
            }
        }

        static void printMat(int[,] mat, string msg)
        {
            Console.WriteLine("\nMatrix {0}, step {1}: ", msg, step);
            for (int i = 0; i < mat.GetLength(0); i++)
            { 
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int getLiveNeighbors(int[,] mat, int x, int y)
        {
            int cnt = 0;
            int m = mat.GetLength(0);
            int n = mat.GetLength(1);

            int[] xcor = { -1, 1, -1, -1, 1, 1, 0, 0};
            int[] ycor = { 0, 0, -1, 1, 1, -1, -1, 1};

            for (int i = 0; i < xcor.Length; i++)
            {
                if (validatePoint(x + xcor[i], y + ycor[i], m, n) && mat[x + xcor[i], y + ycor[i]] == 1)
                    cnt++;
            }

            return cnt;
        }

        static bool validatePoint(int x, int y, int m, int n)
        {
            if (x < 0 || y < 0 || x >= m || y >= n)
                return false;
            return true;
        }

        static void Main(string[] args)
        {
            int[,] mat = { 
                         {0, 0, 0, 0, 0, 0},
                         {0, 0, 1, 0, 0, 0},
                         {0, 0, 1, 0, 0, 0},
                         {0, 0, 1, 0, 0, 0},
                         {0, 0, 0, 0, 0, 0}
                         };
            for (int i = 0; i < 10; i++)
            {
                Conway(mat);
                step++;
            }
            Console.ReadLine();
        }
    }
}
