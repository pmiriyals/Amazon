using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeIterator
{
    class Node
    {
        public int data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node parent { get; set; }

        public Node(int data) : this(data, null, null, null) { }
        public Node(int data, Node parent) : this(data, null, null, parent) { }
        public Node(int data, Node left, Node right, Node parent)
        {
            this.data = data;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }
    }
    
    class Tree
    {
        public Node root { get; set; }

        public Node insert(Node node, int data, Node parent)
        {
            if (node == null)
                return new Node(data, parent);
            else
            {
                if (node.data < data)
                    node.right = insert(node.right, data, node);
                else
                    node.left = insert(node.left, data, node);
                return node;
            }
        }

        public void buildTree()
        {
            int[] arr = { 5, 2, 8, 1, 9, 6, 3, 7, 4, 10 };

            foreach (int i in arr)
                root = insert(root, i, null);
        }

        //Morris
        public void inorder()
        {
            Node cur = root;
            Console.WriteLine("Inorder: ");
            while (cur != null)
            {
                if (cur.left == null)
                {
                    Console.Write("Data: {0} ", cur.data);
                    if (cur.parent != null)
                        Console.Write("& Parent: {0}", cur.parent.data);
                    Console.WriteLine();
                    cur = cur.right;
                }
                else
                {
                    Node succ = cur.left;

                    while (succ.right != null && succ.right != cur)
                        succ = succ.right;

                    if (succ.right == null)
                    {
                        succ.right = cur;
                        cur = cur.left;
                    }
                    else if (succ.right == cur)
                    {
                        succ.right = null;
                        Console.Write("Data: {0} ", cur.data);
                        if (cur.parent != null)
                            Console.Write("& Parent: {0}", cur.parent.data);
                        Console.WriteLine();
                        cur = cur.right;
                    }
                }
            }
            Console.WriteLine();
        }

        public static void driver()
        {
            Tree tree = new Tree();
            tree.buildTree();
            tree.inorder();
            InOrderIterator iter = new InOrderIterator(tree.root);
            while (iter.hasNext())
                Console.Write("{0} ", iter.Next());
        }

    }
}
