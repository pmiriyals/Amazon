using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KthClosestToGivenNodeBinaryTree
{
    class FindKthClosestToGiven
    {
        public static void KthClosest(Node node, int data, int k)
        {
            Node cur = findNode(node, data);
            List<int> closest = new List<int>();
            Node KthSucc = FindKthClosestSucc(cur, k, closest);
            Node KthPred = FindKthClosestPred(cur, k, closest);
            Console.WriteLine("K succs and preds: ");
            foreach (int i in closest)
                Console.Write("{0} ", i);
        }

        static Node FindKthClosestSucc(Node node, int k, List<int> closest)
        {
            if (node == null)
                return null;

            if(k == 0)
                return node;

            if (node.right != null)
            {
                Node min = minNode(node.right);
                if (min != null)
                    closest.Add(min.data);
                return FindKthClosestSucc(min, k - 1, closest);
            }
            else
            {
                Node parent = node.parent;
                while (parent != null && parent.right == node)
                {
                    node = parent;
                    parent = node.parent;
                }
                if (parent != null)
                    closest.Add(parent.data);
                return FindKthClosestSucc(parent, k - 1, closest);
            }
        }

        static Node FindKthClosestPred(Node node, int k, List<int> closest)
        {
            if (node == null)
                return null;

            if (k == 0)
                return node;

            if (node.left != null)
            {
                Node max = maxNode(node.left);
                if (max != null)
                    closest.Add(max.data);
                return FindKthClosestPred(max, k - 1, closest);
            }
            else
            {
                Node parent = node.parent;
                while (parent != null && parent.left == node)
                {
                    node = parent;
                    parent = node.parent;
                }
                if (parent != null)
                    closest.Add(parent.data);
                return FindKthClosestPred(parent, k - 1, closest);
            }
        }

        static Node maxNode(Node node)
        {
            while (node.right != null)
                node = node.right;
            return node;
        }

        static Node minNode(Node node)
        {
            while (node.left != null)
                node = node.left;
            return node;
        }

        static Node findNode(Node node, int data)
        {
            if (node == null)
                return null;
            if (node.data == data)
                return node;

            if (node.data < data)
                return findNode(node.right, data);
            else
                return findNode(node.left, data);
        }
        
        public static void driver()
        {
            Tree tree = new Tree();
            int[] arr = { 7, 2, 4, 1, 6, 3, 9, 5, 8, 10};
            Node root = tree.buildtree(arr);
            KthClosest(root, 3, 3);
        }
    }
}
