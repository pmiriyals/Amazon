using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    public class Node
    {
        public int data { get; set; }
        public Node next { get; set; }

        public Node(int data) : this(data, null) { }
        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
        }

    }
    
    class LinkedList
    {
        public Node head { get; set; }

        public LinkedList()
        {
            head = null;
        }

        public void buildlist(int n)
        {
            Node tail = null;
            for (int i = 1; i <= n; i++)
            {
                if (tail == null)
                {
                    tail = new Node(i);
                    head = tail;
                }
                else
                {
                    tail.next = new Node(i);
                    tail = tail.next;
                }
            }
        }

        public void printList()
        {
            Node cur = head;
            while (cur != null)
            {
                Console.Write(" {0} ->", cur.data);
                cur = cur.next;
            }
            Console.WriteLine();
        }

        public void revIter()
        {
            Node prev = null;
            Node next;
            Node cur = head;

            while (cur != null)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }
            head = prev;
        }

        public void revRecur(Node node)
        {
            if (node == null)
                return;

            Node first = node;
            Node rem = node.next;

            if (rem == null)
                return;

            revRecur(rem);

            first.next.next = first;
            first.next = null;

            head = rem;
        }

        public static void driver()
        {
            LinkedList lnkd = new LinkedList();
            lnkd.buildlist(10);
            lnkd.printList();
            //lnkd.revIter();
            lnkd.revRecur(lnkd.head);
            lnkd.printList();
        }
    }
}
