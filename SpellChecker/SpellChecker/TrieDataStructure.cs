using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellChecker
{
    class Node
    {
        public char ch {get; set;}
        public string value {get; set;}
        private Dictionary<string, Node> children = new Dictionary<string, Node>();
        public bool isWord { get; set; }

        public Node(char ch, string str)
        {
            this.ch = ch;
            this.value = str;
            this.isWord = false;
        }

        public bool addchild(Node node)
        {
            if (children.ContainsKey(node.ch.ToString()))
                return false;

            children.Add(node.ch.ToString(), node);
            return true;
        }

        public Node getchild(string s)
        {
            if (!children.ContainsKey(s))
                return null;
            return children[s];
        }

        public List<string> getChildWords()
        {
            List<string> childs = new List<string>();
            foreach (Node n in children.Values)
            {
                childs.Add(n.value);
            }

            return childs;
        }
    }
    
    class TrieDataStructure
    {
        public Dictionary<string, Node> root = new Dictionary<string, Node>();

        public TrieDataStructure(List<string> words)
        {
            foreach (string word in words)
                addWord(word);
        }

        public void addWord(string word)
        {
            Node cur;

            if(!root.ContainsKey(word[0].ToString()))
                root.Add(word[0].ToString(), new Node(word[0], word[0].ToString()));

            cur = root[word[0].ToString()];

            for (int i = 1; i < word.Length; i++)
            {
                if(cur.getchild(word[i].ToString()) == null)
                    cur.addchild(new Node(word[i], cur.value + word[i]));
                cur = cur.getchild(word[i].ToString());
            }

            cur.isWord = true;
        }

        public bool validatePrefix(string s)
        {
            if (s == null || s.Length <= 0)
                return false;

            Node cur = root[s[0].ToString()];

            for(int i = 1; i < s.Length; i++)
            {
                Node temp = null;
                if ((temp = cur.getchild(s[i].ToString())) == null)
                    return false;

                cur = temp;
            }

            return cur.value == s;
        }

        public void T9Dictionary(string s)
        {
            if (s == null || s.Length <= 0)
                return;

            Node cur = root[s[0].ToString()];

            for (int i = 1; i < s.Length; i++)
            {
                Node temp = null;
                if ((temp = cur.getchild(s[i].ToString())) == null)
                    break;
                cur = temp;
            }

            Console.WriteLine("Prefix founds = {0}", cur.value);
            Console.WriteLine("Predicted text = ");
            List<string> pred = cur.getChildWords();
            foreach (string word in pred)
            {
                Console.WriteLine(word);
            }
        }
    }
}
