using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuffixTree
{
    public class Node
    {
        public char c { get; set; }
        public string str { get; set; }
        public Dictionary<char, Node> children = new Dictionary<char, Node>();

        public Node(char c, string str)
        {
            this.c = c;
            this.str = str;
        }

        public bool AddChild(Node node)
        {
            if (children.ContainsKey(node.c))    //node already present as child
                return false;
            children.Add(node.c, node);
            return true;
        }
    }
    
    public class SuffixLRS
    {
        public Dictionary<char, Node> root = new Dictionary<char, Node>();
        public string LongestRepeatedStr = "";
        public HashSet<string> hs = new HashSet<string>(); //stores unique substrings in a string
        public List<string> lststr = new List<string>();

        public string LargestRepeatedSubString(string s)
        {
            string lrs = "";

            for (int i = s.Length; i > 0; i--)
            {
                AddStringToTree(s.Substring(0, i));
                //After adding each path we check if we found a common substring
                //Depth decrease with each new path added to root
                if (LongestRepeatedStr.Length > lrs.Length)
                {
                    lrs = LongestRepeatedStr;                    
                }
            }   //at this point I have my suffix tree ready

            Console.WriteLine(lrs);

            return lrs;
        }

        //Adds new path from root to leaf node;
        //Eg: Input to this method is,
        //banana, banan, bana, ban, ba, b
        //Each of the above words creates a new path from root to leaf, with leaf being the above word
        public void AddStringToTree(string s)   
        {
            int end = s.Length - 1;

            Node cur_node = null;

            if (!root.ContainsKey(s[end]))
            { 
                root.Add(s[end], new Node(s[end], s[end].ToString()));
            }

            cur_node = root[s[end]];
            AddSubString(cur_node);

            //Add children to current path
            for (int i = end - 1; i >= 0; i--)
            {
                if (!cur_node.children.ContainsKey(s[i]))
                {
                    cur_node.AddChild(new Node(s[i], s[i].ToString() + cur_node.str));
                }
                cur_node = cur_node.children[s[i]];
                AddSubString(cur_node);
            }
        }

        //Add every substring found along the way to a hashset
        private void AddSubString(Node cur_node)
        {
            if (hs.Contains(cur_node.str))
            {
                if (cur_node.str.Length > LongestRepeatedStr.Length)
                {
                    LongestRepeatedStr = cur_node.str;  //update if this is the max repeating substring
                }
            }
            else
                hs.Add(cur_node.str);            
        }
    }
}
