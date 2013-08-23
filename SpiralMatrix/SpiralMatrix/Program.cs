using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpiralMatrix
{
    class Program
    {
        
        //i - start row index
        //m - end row index
        //j - start col index
        //n - end col index

        static void printSpiral(int[,] mat)
        {
            int sr = 0, sc = 0;
            int er = mat.GetLength(0) - 1;
            int ec = mat.GetLength(1) - 1;

            while (sr < er && sc < ec)
            {
                for (int k = sc; k <= ec; k++)
                    Console.Write("{0:00} ", mat[sr, k]);   //print 1st row

                sr++;    //next row                
                for (int k = sr; k <= er; k++)
                    Console.Write("{0:00} ", mat[k, ec]);    //print last col

                ec--;    //decrement column
                for (int k = ec; k >= sc; k--)
                    Console.Write("{0:00} ", mat[er, k]);    //print last row

                er--;    //decrement row
                for (int k = er; k >= sr; k--)
                    Console.Write("{0:00} ", mat[k, sc]);
                
                sc++;    //inc col
            }
        }
        
        static void Main(string[] args)
        {
            int[,] mat = { 
                         {1, 2, 3, 4},
                         {5, 6, 7, 8},
                         {9, 10, 11, 12},
                         {13, 14, 15, 16}
                         };

            printSpiral(mat);
            Console.ReadLine();
        }
    }
}
