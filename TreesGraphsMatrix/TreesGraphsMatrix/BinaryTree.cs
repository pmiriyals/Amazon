using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
    public class Node
    {
        public int data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(int data) : this(data, null, null) { }        
        public Node(int data, Node left, Node right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }
    
    class BinaryTree
    {
        public Node root { get; set; }
        public readonly int size;

        private Node insert(Node node, int data)
        {
            if (node == null)
                return new Node(data);
            else
            {
                if (node.data >= data)
                    node.left = insert(node.left, data);
                else
                    node.right = insert(node.right, data);

                return node;
            }
        }

        private void buildTree()
        {
            int[] vals = { 6, 2, 8, 1, 3, 7, 10, 5, 4, 9 };
            foreach (int data in vals)
            {
                root = insert(root, data);
            }
        }

        public BinaryTree()
        {            
            buildTree();
        }

        //O(n), recursion takes extra O(n) space
        public void inorderRecur(Node node)
        {
            if (node == null)
                return;

            inorderRecur(node.left);
            Console.Write(" {0} ", node.data);
            inorderRecur(node.right);
        }
        //using stack, time: O(n) and space: O(1) (no extra space)
        public void inorderIter(Node node)
        {
            Stack<Node> stk = new Stack<Node>();
            Node cur = node;
            bool done = false;
            Console.WriteLine("\nIn order traversal using stack (iterative): ");
            while (!done)
            {
                if (cur != null)
                {
                    stk.Push(cur);
                    cur = cur.left;
                }
                else
                {
                    if (stk.Count > 0)
                    {
                        cur = stk.Pop();
                        Console.Write(" {0} ", cur.data);
                        cur = cur.right;
                    }
                    else
                        done = true;
                }
            }
        }

        public void inorderMorris(Node node)
        {
            Node cur = node;
            Console.WriteLine("\nIn order traversal using Morris traversal (threaded binary tree): ");
            while (cur != null)
            {
                if (cur.left == null)
                {
                    Console.Write(" {0} ", cur.data);
                    cur = cur.right;
                }
                else 
                {
                    Node succ = cur.left;

                    while (succ.right != null && succ.right != cur)
                        succ = succ.right;

                    if (succ.right == null)
                    {
                        succ.right = cur;   //form a thread between leaf nodes right to its successor
                        cur = cur.left;
                    }
                    else if (succ.right == cur)
                    {
                        succ.right = null;  //remove thread formed previously
                        Console.Write(" {0} ", cur.data);
                        cur = cur.right;
                    }
                }
            }
        }

        public int MinNode(Node node)
        {
            while (node.left != null)
                node = node.left;

            return node.data;
        }

        public int MaxNode(Node node)
        {
            while (node.right != null)
                node = node.right;

            return node.data;
        }

        public int inorderSuccBST(Node node)
        {
            Node cur = root;
            if (node.right != null)
                return MinNode(node.right);

            Node succ = null;

            while (cur != null)
            {
                if (cur.data > node.data)
                {
                    succ = cur;
                    cur = cur.left;
                }
                else if (cur.data < node.data)
                {
                    cur = cur.right;
                }
                else
                    break;
            }

            return (succ == null) ? -1 : succ.data;
        }

        public int inorderPredBST(Node node)
        {
            Node cur = root;
            if (node.left != null)
                return MaxNode(node.left);

            Node pred = null;

            while (cur != null)
            {
                if (cur.data < node.data)
                {
                    pred = cur;
                    cur = cur.right;
                }
                else if (cur.data > node.data)
                    cur = cur.left;
                else
                    break;
            }
            return (pred == null) ? -1 : pred.data;
        }

        public void preorderRecur(Node node)
        {
            if (node == null)
                return;

            Console.Write(" {0} ", node.data);
            preorderRecur(node.left);
            preorderRecur(node.right);
        }

        public void preorderIter(Node node)
        {
            Node cur = node;
            Stack<Node> stk = new Stack<Node>();
            stk.Push(cur);
            Console.WriteLine("\nPreorder traversal iterative (using stack): ");
            while (stk.Count > 0)
            {
                cur = stk.Pop();
                Console.Write(" {0} ", cur.data);

                if (cur.right != null)
                    stk.Push(cur.right);
                if (cur.left != null)
                    stk.Push(cur.left);
            }
        }

        public void preorderMorris(Node node)
        {
            Node cur = node;
            Console.WriteLine("\nPreorder traversal using Morris traversal (threaded binary tree): ");

            while (cur != null)
            {
                if (cur.left == null)
                {
                    Console.Write(" {0} ", cur.data);
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
                        Console.Write(" {0} ", cur.data);
                        cur = cur.left;
                    }
                    else if (succ.right == cur)
                    {
                        succ.right = null;
                        cur = cur.right;
                    }
                }
            }
        }

        public int preorderSuccBST(Node node)
        {
            Node cur = root;

            if (node.left != null)
                return node.left.data;
            if (node.right != null)
                return node.right.data;

            Node succ = null;

            while (cur != null)
            {
                if (cur.data > node.data)
                {
                    if (cur.right != null)
                        succ = cur.right;
                    cur = cur.left;
                }
                else if (cur.data < node.data)
                    cur = cur.right;
                else
                    break;
            }

            return (succ == null) ? -1 : succ.data;
        }

        public int preorderPredBST(Node node)
        {
            Node cur = root;
            while (cur != null && cur != node)
            {
                if (cur.right == node && cur.left != null)
                    return MaxNode(cur.left);

                if (cur.left == node || cur.right == node)
                    return cur.data;

                if (cur.data > node.data)
                    cur = cur.left;
                if (cur.data < node.data)
                    cur = cur.right;
            }

            return -1;
        }

        public void postorderRecur(Node node)
        {
            if (node == null)
                return;

            postorderRecur(node.left);
            postorderRecur(node.right);
            Console.Write(" {0} ", node.data);
        }

        //using 2 stacks (this can be done using 1 stack also)
        public void postorderIter(Node node)
        {
            Node cur = node;
            Console.WriteLine("\n Postorder iterative using two stack: ");
            Stack<Node> stk = new Stack<Node>();
            Stack<Node> rem = new Stack<Node>();
            stk.Push(cur);
            while (stk.Count > 0)
            {
                cur = stk.Pop();
                rem.Push(cur);
                if (cur.left != null)
                    stk.Push(cur.left);
                if (cur.right != null)
                    stk.Push(cur.right);
            }

            while (rem.Count > 0)
            {
                Console.Write(" {0} ", rem.Pop().data);
            }
        }

        public void postorderIterOneStack(Node node)
        {
            Console.WriteLine("\nPostorder iterative using only one stack: ");
            Node cur = node;
            Stack<Node> stk = new Stack<Node>();

            do
            {
                while (cur != null)
                {
                    if (cur.right != null)
                        stk.Push(cur.right);
                    stk.Push(cur);
                    cur = cur.left;
                }

                cur = stk.Pop();
                if (cur.right != null && stk.Count > 0 && cur.right == stk.Peek())
                {
                    stk.Pop();
                    stk.Push(cur);
                    cur = cur.right;
                }
                else
                {
                    Console.Write(" {0} ", cur.data);
                    cur = null;
                }
            } while (stk.Count > 0);
        }

        public void levelorder(Node node)
        {
            Node cur = node;
            Queue<Node> queue = new Queue<Node>();
            int nextLevel = 1;
            int curLevel;
            queue.Enqueue(cur);

            while (queue.Count > 0)
            {                
                curLevel = nextLevel;
                nextLevel = 0;

                for (int i = 0; i < curLevel; i++)
                {
                    cur = queue.Dequeue();
                    Console.Write(" {0} ", cur.data);
                    if (cur.left != null)
                    {
                        queue.Enqueue(cur.left);
                        nextLevel++;
                    }
                    if (cur.right != null)
                    {
                        queue.Enqueue(cur.right);
                        nextLevel++;
                    }
                }
                Console.WriteLine();
            }

        }
                
        public Node InPreToBinaryTree(int[] pre, int[] inorder, int instart, int inend, ref int preIndex)
        {
            if (instart > inend)
                return null;
            
            Node node = new Node(pre[preIndex++]);

            if (instart == inend)
                return node;

            int inIndex;
            for (inIndex = 0; inIndex < inorder.Length; inIndex++)
            {
                if (inorder[inIndex] == node.data)
                    break;
            }
            
            node.left = InPreToBinaryTree(pre, inorder, instart, inIndex - 1, ref preIndex);
            node.right = InPreToBinaryTree(pre, inorder, inIndex + 1, inend, ref preIndex);

            return node;
        }


        public Node SortedArrToBinaryTree(int[] arr, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            Node node = new Node(arr[mid]);

            node.left = SortedArrToBinaryTree(arr, start, mid - 1);
            node.right = SortedArrToBinaryTree(arr, mid + 1, end);
            return node;
        }

        public static void driver()
        {
            BinaryTree tree = new BinaryTree();
            Console.WriteLine("Tree Traversals: \n\nInorder traversal recursive: ");
            tree.inorderRecur(tree.root);
            tree.inorderIter(tree.root);
            tree.inorderMorris(tree.root);

            Console.WriteLine("\nInorder successor = {0}", tree.inorderSuccBST(tree.root.left.right.right));
            Console.WriteLine("Inorder predecessor = {0}", tree.inorderPredBST(tree.root.left.right.right.left)); 

            Console.WriteLine("\n\nPreorder traversal recursive: ");
            tree.preorderRecur(tree.root);
            tree.preorderIter(tree.root);
            tree.preorderMorris(tree.root);

            Console.WriteLine("\nPreorder successor = {0}", tree.preorderSuccBST(tree.root.left.left));
            Console.WriteLine("Preorder predecessor = {0}", tree.preorderPredBST(tree.root));

            Console.WriteLine("\n\nPostorder traversal recursive: ");
            tree.postorderRecur(tree.root);
            tree.postorderIter(tree.root);
            tree.postorderIterOneStack(tree.root);

            Console.WriteLine("\n\nLevelorder traversal: ");
            tree.levelorder(tree.root);

            int[] pre = {6, 2, 1, 3, 5, 4, 8, 7, 10, 9};
            int[] inorder = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            int preIndex = 0;
            Node inpreNode = tree.InPreToBinaryTree(pre, inorder, 0, inorder.Length - 1, ref preIndex);
            Console.WriteLine("\nNewly constructed tree from inorder and preorder traversals: ");
            tree.levelorder(inpreNode);

            Console.WriteLine("\nSorted Array to Balanced BST: ");
            Node arrToBSTNode = tree.SortedArrToBinaryTree(inorder, 0, inorder.Length - 1);
            tree.levelorder(arrToBSTNode);
        }
    }
}
