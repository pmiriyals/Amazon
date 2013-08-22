using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesIn2DArr
{
    class Program
    {


        static void FlipOnes(int[,] arr, int x, int y)
        {
            if (x < 0 || x >= arr.GetLength(0) || y < 0 || y >= arr.GetLength(1) || arr[x, y] != 1)
                return;

            if (arr[x, y] == 1)
                arr[x, y] = 0;

            FlipOnes(arr, x - 1, y);
            FlipOnes(arr, x + 1, y);
            FlipOnes(arr, x, y - 1);
            FlipOnes(arr, x, y + 1);
        }
        
        static int ShapeCount(int[,] arr)
        {
            int cnt = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 1)
                    {
                        FlipOnes(arr, i, j);
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        static void Main(string[] args)
        {
            int[,] arr = {{1, 0, 1, 1, 0}, 
                           {1, 0, 1, 0, 0},
                           {0, 0, 0, 0, 1},
                           {1, 0, 1, 1, 0}};

            Console.WriteLine(ShapeCount(arr));
            Console.ReadLine();
        }
    }
}
