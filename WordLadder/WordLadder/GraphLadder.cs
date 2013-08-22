using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WordLadder
{
    class Node
    {
        public string word { get; set; }
        public Node parent { get; set; }

        public Node(string w) : this(w, null) { }
        public Node(string w, Node p)
        {
            this.word = w;
            this.parent = p;
        }
    }

    class GraphLadder
    {
        public Node root;
        public Node target = null;
        private Dictionary<string, bool> dict;

        public GraphLadder(string source)
        {
            root = new Node(source);
            dict = DictionaryWords.getInstance(source.Length).getDict();
        }

        private bool IsSimilar(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

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

        public void generateChildren(Node parent, string t, Queue<Node> queue)
        {
            string s = parent.word;
            List<string> lstWords = dict.Keys.ToList();            
            foreach (string word in lstWords)
            {
                if (dict[word])
                    continue;
                
                if (IsSimilar(word, s))
                {
                    dict[word] = true;
                    Node n = new Node(word, parent);
                    
                    queue.Enqueue(n);
                    if (word == t)
                    {
                        target = n;
                        return;
                    }
                }
            }            
        }
        private void printLadder(Node n)
        {
            while (n != null)
            {
                Console.WriteLine(n.word);
                n = n.parent;
            }
        }

        private void ladder(string t)
        {            
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();
                generateChildren(n, t, queue);
                if (target != null)
                {
                    printLadder(target);
                    break;
                }
            }

            if (target == null)
                Console.WriteLine("Ladder not found");
        }

        public static void driver()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string s = "stone";
            string target = "mxoney";
            GraphLadder graph = new GraphLadder(s);
            graph.ladder(target);
            sw.Stop();
            Console.WriteLine("Time taken with graphs = {0} ms", sw.ElapsedMilliseconds);
        }    
    }
}
