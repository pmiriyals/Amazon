using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
    class Matrix
    {
        private const int m = -1;//Int32.MaxValue;

        public void printMatrix(int[, ] mat)
        {
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.WriteLine();
            }
        }

        public struct point
        {
            public int x;
            public int y;

            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private bool isvalidPoint(int x, int y, int[,] mat)
        {
            if (x < 0 || x >= mat.GetLength(0) || y < 0 || y >= mat.GetLength(1) || mat[x, y] == 0)
                return false;
            return true;
        }

        public void BFS(int[,] mat, point pt)
        {
            Queue<point> queue = new Queue<point>();
            queue.Enqueue(pt);
            while (queue.Count > 0)
            {
                point p = queue.Dequeue();
                mat[p.x, p.y] = 0;
                if (isvalidPoint(p.x, p.y + 1, mat))
                    queue.Enqueue(new point(p.x, p.y + 1));
                if (isvalidPoint(p.x, p.y - 1, mat))
                    queue.Enqueue(new point(p.x, p.y - 1));
                if (isvalidPoint(p.x + 1, p.y, mat))
                    queue.Enqueue(new point(p.x + 1, p.y));
                if (isvalidPoint(p.x - 1, p.y, mat))
                    queue.Enqueue(new point(p.x - 1, p.y));
            }
        }

        public int Influencer()
        {
            int[,] mat = { 
                         {0, 0, 1, 1, 1, 0},
                         {0, 0, 1, 1, 1, 0},
                         {0, 0, 0, 1, 1, 0},
                         {0, 0, 0, 0, 1, 0},
                         {0, 0, 0, 0, 0, 0},
                         {1, 0, 1, 1, 1, 0},
                         }; //influencer is 3

            int y = 0;
            int x = 0;
            Console.WriteLine("\n\nFindCandidate(0, {0}): ", y);
            x = findcandidate(mat, x, y);
            if (x > 0 && IsCandidate(mat, x))
            {
                Console.WriteLine("Influencer = {0}", x);
                return x;
            }
            else
            {
                Console.WriteLine("Influencer = {0}", -1);
                return -1;
            }
        }

        private bool IsCandidate(int[,] mat, int x)
        {
            for (int y = 0; y < mat.GetLength(0) && y < mat.GetLength(1); y++)
            {
                if ((mat[y, x] != 1 && y != x) || mat[x, y] != 0)
                    return false;
            }

            return true;
        }

        private int findcandidate(int[,] mat, int x, int y)
        {
            if (x >= 0 && x < mat.GetLength(0) && y >= 0 && y < mat.GetLength(1))
            {
                Console.WriteLine(" x = {0}, y = {1} ", x, y);
                if (y == mat.GetLength(1) - 1)
                    return x;

                if (mat[x, y] == 0)
                    return findcandidate(mat, x, y + 1);
                else
                    return findcandidate(mat, x + 1, y);
            }
            return -1;
        }

        public int CountShapes()
        {
            int[,] mat = { 
                         {0, 0, 1, 0, 0, 0},
                         {0, 0, 1, 1, 0, 0},
                         {0, 0, 0, 0, 1, 0},
                         {1, 1, 0, 1, 1, 0},
                         {0, 0, 0, 0, 0, 0},
                         {1, 0, 1, 1, 1, 0},
                         }; //5 shapes

            //4-way flood fill will give the answer but complexity is O(n4)
            //BFS preferred
            int shapes = 0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] == 1)
                    {
                        shapes++;
                        BFS(mat, new point(i, j));
                    }
                }
            }
            Console.WriteLine("Shapes = {0}", shapes);
            return shapes;
        }

        
        //refer: http://www.geeksforgeeks.org/greedy-algorithms-set-6-dijkstras-shortest-path-algorithm/
        public void DijkstrasUsingMatrix()
        {
            int[,] mat = { 
                         {m, 1, m, m},
                         {m, m, 3, m},
                         {1, 2, m, 1},
                         {m, m, 10, m}
                         };


            int[] dist = new int[mat.GetLength(0)];
            bool[] sptV = new bool[mat.GetLength(0)];
            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = Int32.MaxValue;
                sptV[i] = false;
            }

            int src = 0;
            dist[src] = 0;
            int[] p = new int[mat.GetLength(0)];

            for (int i = 0; i < mat.GetLength(0) - 1; i++)
            {
                int u = getMin(dist, sptV);
                sptV[u] = true;

                for (int v = 0; v < mat.GetLength(0); v++)
                {
                    if (!sptV[v] && mat[u, v] != m && dist[u] != Int32.MaxValue && (dist[u] + mat[u, v] < dist[v]))
                    {
                        dist[v] = dist[u] + mat[u, v];
                        p[v] = u;
                    }
                }
            }

            for (int i = 0; i < dist.Length; i++)
            {
                Console.WriteLine("V = {0}\t d = {1}\t p = {2}", i, dist[i], p[i]);
            }
        }

        private int getMin(int[] dist, bool[] sptV)
        {
            int min = Int32.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < dist.Length; i++)
            {
                if (!sptV[i] && min > dist[i])
                {
                    min = dist[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public void FloydWarshall()
        {
            int[,] mat = { 
                         {0, 5, -1, 10},
                         {-1, 0, 3, -1},
                         {-1, -1, 0, 1},
                         {-1, -1, -1, 0}
                         };

            int N = mat.GetLength(0);   //4x4 matrix

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (mat[i, k] > 0 && mat[k, j] > 0)  //if there is a path between i to j via k
                        {
                            if ((mat[i, k] + mat[k, j]) < mat[i, j] || mat[i, j] == -1)
                                mat[i, j] = mat[i, k] + mat[k, j];
                        }
                    }
                }
            }

            printMatrix(mat);
        }

        public static void driver()
        {
            Matrix graph = new Matrix();
            //graph.FloydWarshall();
            //graph.DijkstrasUsingMatrix();
            //graph.CountShapes();
            //graph.Influencer();
            graph.DijkstrasUsingMatrix();
        }

    }
}
