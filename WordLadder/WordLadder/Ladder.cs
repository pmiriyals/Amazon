using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WordLadder
{
    class Ladder
    {
        private static DictionaryWords dw;
        private static Dictionary<string, bool> dict;

        private static bool IsSimilar(string a, string b)
        {
            int cnt = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    cnt++;
                    if (cnt > 1)
                        return false;
                }
            }

            return cnt == 1;
        }
                
        public static Queue<Stack<string>> InitializeQueue(string s)//, string target)
        {
            Stack<string> stk;
            Queue<Stack<string>> queue = new Queue<Stack<string>>();
            List<string> words = new List<string>();
            foreach (string word in dict.Keys)
            {
                if (dict[word])
                    continue;
                
                //if (word == target) //found target at first level of word itself
                //{
                //    queue.Clear();
                //    stk = new Stack<string>();
                //    stk.Push(s);
                //    stk.Push(word);
                //    queue.Enqueue(stk);
                //    return queue;
                //}                
                if (IsSimilar(s, word))
                {                    
                    stk = new Stack<string>();
                    stk.Push(s);
                    stk.Push(word);
                    queue.Enqueue(stk);
                    words.Add(word);
                }
            }

            foreach (string w in words)
                dict[w] = true;

            return queue;
        }

        private static List<string> GetWords(string s)
        {
            List<string> lstSimilar = new List<string>();
            ICollection<string> keys = dict.Keys.ToList();
            foreach (string word in keys)
            {
                if (dict[word])
                    continue;

                if (IsSimilar(s, word))
                {
                    lstSimilar.Add(word);
                    dict[word] = true;
                }
            }

            return lstSimilar;
        }

        private static Stack<string> GenerateLadder(string s, string target)
        {
            Queue<Stack<string>> queue = InitializeQueue(s);//, target);
            Stack<string> stk = new Stack<string>();

            while (queue.Count > 0)
            {
                stk = queue.Dequeue();
                string w = stk.Peek();
                if (w == target)
                {
                    return stk;
                }
                else
                {                    
                    foreach(string word in GetWords(w))
                    {
                        Stack<string> nstk = new Stack<string>(new Stack<string>(stk));
                        nstk.Push(word);
                        queue.Enqueue(nstk);
                    }                    
                }
            }

            return new Stack<string>();
        }

        public static void driver()
        { 
            string s = "stone";
            string target = "money";
            dw = DictionaryWords.getInstance(s.Length);
            dict = dw.getDict();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Stack<string> stk = GenerateLadder(s, target);
            if (stk.Count <= 0)
                Console.WriteLine("No ladder found");
            else
            {
                Console.WriteLine("Words in ladder: ");
                foreach (string str in stk)
                {
                    Console.WriteLine(str);
                }
            }

            sw.Stop();
            Console.WriteLine("Time taken with stacks and queues = {0} ms", sw.ElapsedMilliseconds);
        }
    }
}
