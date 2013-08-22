using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KthClosestToGivenNodeBinaryTree
{
    public class Node
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
            else {
                if (node.data < data)
                    node.right = insert(node.right, data, node);
                else
                    node.left = insert(node.left, data, node);
                return node;
            }
        }

        public Node buildtree(int[] arr)
        {
            foreach (int i in arr)
                root = insert(root, i, null);

            return root;
        }
    }
}
