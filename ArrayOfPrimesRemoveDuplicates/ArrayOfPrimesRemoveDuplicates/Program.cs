using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayOfPrimesRemoveDuplicates
{
    public class Score
    {
        public int id { get; set; }
        public int score { get; set; }
        public DateTime date { get; set; }
        public Score(int id, int score, DateTime date)
        {
            this.id = id;
            this.score = score;
            this.date = date;
        }
    }

    public class FinalScore
    {
        public static Dictionary<int, List<Score>> FinalScorePerStudent(List<Score> scores)
        {
            Dictionary<int, List<Score>> dict = new Dictionary<int, List<Score>>();

            List<Score> lstscore;
            lstscore = scores.OrderBy(o => o.id).ToList();

            foreach (Score score in scores)
            {
                if (dict.ContainsKey(score.id))
                {
                    dict[score.id].Add(score);
                }
                else
                {
                    lstscore = new List<Score>();
                    lstscore.Add(score);
                    dict.Add(score.id, lstscore);
                }
            }
            int[] keys = dict.Keys.ToArray();
            foreach(int i in keys)
            {
                List<Score> score = dict[i];
                List<Score> sort = score.OrderBy(o => o.score).ToList();
                sort.RemoveRange(0, sort.Count - 5);
                dict[i] = sort;
            }

            return dict;

        }
    }
    
    class Program
    {

        static void PrintSeqMatrix(int[,] mat)
        {
            int xl = mat.GetLength(0);
            int yl = mat.GetLength(1);
            int prev = mat[0, 0];
            bool seq = false;
            for (int x = 0; x < xl; x++)
            {
                for (int y = 0; y < yl; y++)
                {
                    if (prev + 1 == mat[x, y])
                    {
                        Console.Write(" {0} ", prev);
                        seq = true;
                    }
                    else if (seq)
                    {
                       Console.WriteLine(" {0} ", prev);                       
                       seq = false;
                    }
                    prev = mat[x, y];
                }
                if (seq)
                {
                    Console.Write(" {0} ", prev);
                    seq = false;
                }
                Console.WriteLine();
            }
        }

        static void RemoveDupFromPrimes(int[] a)
        {
            int prod = 1, j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (prod % a[i] != 0)
                {
                    a[j++] = a[i];
                    prod *= a[i];
                }
            }
            for (int i = 0; i < j; i++)
                Console.Write(" {0} ", a[i]);
            
        }

        static void Main(string[] args)
        {
            //int[] a = { 3, 7, 13, 2, 3, 17, 7, 7, 5, 19, 17 };
            //RemoveDupFromPrimes(a);
            int[,] mat = { {3, 5, 6, 7, 2}, {1, 5, 6, 7, 8}, {2, 3, 10, 11, 12}};
            PrintSeqMatrix(mat);
            //List<Score> lstscore = new List<Score>();
            //Random r = new Random();
            //for (int i = 1; i <= 10; i++)
            //{ 
            //    Console.WriteLine("\n\nScores for id = {0}\n", i);                
            //    for(int j = 1; j<=10; j++)
            //    {
            //        int val = r.Next(0, 100);
            //        Console.Write(" {0} ", val);
            //        lstscore.Add(new Score(i, val, DateTime.Today));
            //    }
            //}
            //Dictionary<int, List<Score>> dict = FinalScore.FinalScorePerStudent(lstscore);
            Console.ReadLine();
        }
    }
}
