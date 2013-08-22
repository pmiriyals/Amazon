using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrefixTree
{
    //1. Time to construct a prefix tree = O(n)
    
    class Node
    {
        public char c { get; set; }
        public string val { get; set; }
        public bool IsVisited { get; set; }
        public bool IsWord { get; set; }
        public Dictionary<char, Node> children = new Dictionary<char, Node>();

        public Node(char c, string val)
        {
            this.c = c;
            this.val = val;
            this.IsVisited = false;
            this.IsWord = false;
        }

        public bool AddChild(Node node)
        {
            if (node == null || children.ContainsKey(node.c))
                return false;

            children.Add(node.c, node);
            return true;
        }
    }
    
    class PrefixTrie
    {
        public Node root = new Node('0', "");

        public void AddWord(string s)
        {
            Node cur;
            if (!root.children.ContainsKey(s[0]))   //if root does not have the first letter as child
            {
                root.AddChild(new Node(s[0], s[0].ToString()));
            }

            cur = root.children[s[0]];  //get the 1st Node of the path that leads to string s

            for (int i = 1; i < s.Length; i++)
            {
                if (!cur.children.ContainsKey(s[i]))    //if the next letter does not exist as a child for the current node
                {
                    cur.AddChild(new Node(s[i], cur.val + s[i]));
                }

                cur = cur.children[s[i]];
            }

            cur.IsWord = true;
        }

        public bool IsPrefix(string s)
        {
            Node cur = root;
            for (int i = 0; i < s.Length; i++)
            {
                if (!cur.children.ContainsKey(s[i]))
                    return false;
                cur = cur.children[s[i]];
            }

            return true;
        }

        public static void driver()
        {
            string[] words = {"this", "is", "was", "tea", "today", "total" };
            PrefixTrie trie = new PrefixTrie();
            foreach (string s in words)
                trie.AddWord(s);
            Console.WriteLine("IsPrefix = {0}", trie.IsPrefix("tot"));
        }

    }
}
