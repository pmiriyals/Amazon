using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTour
{
    class Program
    {
        static int N = 8;

        static void KTour()
        { 
            int[,] sol = new int[N, N];
            for (int i = 0; i < sol.GetLength(0); i++)
            {
                for (int j = 0; j < sol.GetLength(1); j++)
                    sol[i, j] = -1;
            }

            int[] xmove = {1, 2, -1, -2, -1, -2, 1, 2 };
            int[] ymove = {2, 1, 2, 1, -2, -1, -2, -1 };

            if (KTUtil(sol, xmove, ymove, 1, 0, 0))
            {
                Console.WriteLine("No solution exists");
            }
            else
                printsol(sol);

        }

        static void printsol(int[,] sol)
        {
            Console.WriteLine("Knights tour = ");
            for (int i = 0; i < sol.GetLength(0); i++)
            {
                for (int j = 0; j < sol.GetLength(1); j++)
                        Console.Write("{0} ", sol[i, j]);
                Console.WriteLine();
            }
        }

        static bool KTUtil(int[,] sol, int[] xmove, int[] ymove, int imove, int x, int y)
        { 
            if(imove == N*N)
                return true;

            int k, next_x, next_y;

            for (k = 0; k < 8; k++)
            {
                next_x = x + xmove[k];
                next_y = y + ymove[k];

                if (isSafe(next_x, next_y, sol))
                {
                    sol[next_x, next_y] = imove;
                    if (KTUtil(sol, xmove, ymove, imove + 1, next_x, next_y))
                        return true;
                    else
                        sol[next_x, next_y] = -1;
                }
            }

            return false;
        }

        static bool isSafe(int x, int y, int[,] sol)
        {
            if (x >= 0 && y >= 0 && x < N && y < N && sol[x, y] == -1)
                return true;
            return false;
        }

        static void Main(string[] args)
        {
            KTour();
            Console.ReadLine();
        }
    }
}
