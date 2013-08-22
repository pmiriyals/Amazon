using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrefixMatching
{
    class Node
    {
        public char c { get; set; }
        public string str { get; set; }
        public Dictionary<char, Node> dict = new Dictionary<char, Node>();
        public bool IsWord { get; set; }

        public Node(char c, string str)
        {
            this.c = c;
            this.str = str;
            this.IsWord = false;
        }

        public void AddChild(Node n)
        {
            if(!dict.ContainsKey(n.c))
            {
                dict.Add(n.c, n);
            }
        }

        public Node getChild(char c)
        { 
            if(!dict.ContainsKey(c))
                return null;
            return dict[c];
        }

        public bool hasChild(char c)
        {
            return dict.ContainsKey(c);
        }
    }
    
    class PrefixTrie
    {
        Dictionary<char, Node> root = new Dictionary<char, Node>();
        private const int maxPredictions = 10;

        public void insert(string s)
        {
            if (s == null || s.Length == 0)
                return;

            Node cur;
            if (!root.ContainsKey(s[0]))
            {
                root.Add(s[0], new Node(s[0], s[0].ToString()));
            }
            cur = root[s[0]];

            for (int i = 1; i < s.Length; i++)
            {
                if (!cur.hasChild(s[i]))
                {
                    cur.AddChild(new Node(s[i], cur.str + s[i]));
                }
                cur = cur.getChild(s[i]);
            }
            cur.IsWord = true;
        }

        public List<string> Predictions(string prefix)
        {
            List<string> pred = new List<string>();

            if(prefix == null || prefix.Length == 0 || !root.ContainsKey(prefix[0]))
                return pred;           

            Node cur = root[prefix[0]];
            for(int i = 1; i < prefix.Length; i++)
            {
                if (cur.hasChild(prefix[i]))
                    cur = cur.getChild(prefix[i]);
                else
                    break;
            }
            
            GetWords(cur, pred);
            return pred;
        }

        private void GetWords(Node node, List<string> pred)
        {
            if (pred.Count >= maxPredictions)
                return;

            foreach (char c in node.dict.Keys)
            {
                Node cur = node.getChild(c);
                if (cur.IsWord)
                {
                    pred.Add(cur.str);
                    if (pred.Count > maxPredictions)
                        return;
                }
                
                GetWords(cur, pred);
            }
        }

        public static void driver()
        {
            string[] words = {"to", "tea", "ten", "ted", "toll", "trail", "tall", "inn", "tele", "telemat", "teleport", "tell" };
            PrefixTrie tree = new PrefixTrie();
            foreach (string s in words)
                tree.insert(s);

            List<string> lstWords = tree.Predictions("tel");            
            foreach(string word in lstWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
