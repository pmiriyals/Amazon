using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeIterator
{
    class InOrderIterator : Iterator
    {
        private Node next = null;

        //Pass root of the current binary tree
        public InOrderIterator(Node root)
        {
            while (root.left != null)
                root = root.left;

            next = root;    //While initializing the iterator, set next node to first node of inorder traversal
        }

        public bool hasNext()
        {
            return next != null;
        }

        private Node MinNode(Node node)
        {
            if (node == null)
                return node;
            while (node.left != null)
                node = node.left;
            return node;
        }

        public int Next()
        {
            if (next == null)
                throw new Exception("No next element available");
            
            Node cur = next;
            inorderSucc();
            return cur.data;
        }

        private void inorderSucc()
        {
            if (next.right != null)
            {
                next = MinNode(next.right);
            }
            else
            {
                Node parent = next.parent;
                while (parent != null && parent.right == next)
                {
                    next = parent;
                    parent = next.parent;
                }
                next = parent;
            }
        }
    }
}
