using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoublyLinkedList
{
    class Program
    {
        class Node
        {
            public int data { get; set; }
            public Node prev { get; set; }
            public Node next { get; set; }

            public Node(int data) : this(data, null, null) { }
            public Node(int data, Node prev, Node next)
            {
                this.data = data;
                this.prev = prev;
                this.next = next;
            }
        }

        static Node rev(Node dll)
        {
            Node prev = dll.prev;
            Node next;
            Node cur = dll;
            Node save = cur;
            while (prev.prev != save)
            {
                next = cur.next;
                cur.next = prev;
                cur.prev = next;
                prev = cur;
                cur = next;
            }
            return prev;
        }

        static void printDLL(Node node, bool fwd)
        {
            Node cur = node;
            if (fwd)
            {
                Console.Write("DLL fwd: ");
                while (true)
                {
                    Console.Write("{0} ", cur.data);
                    if (cur.next == node)
                        break;
                    cur = cur.next;
                }
            }
            else
            {
                Console.Write("DLL back: ");
                while (true)
                {
                    Console.Write("{0} ", cur.data);
                    if (cur.prev == node)
                        break;
                    cur = cur.prev;
                }
            }
            Console.WriteLine("\n");
        }
        
        static void Main(string[] args)
        {
            Node node = new Node(1);
            node.next = new Node(2);
            node.next.next = new Node(3);
            node.prev = node.next.next;
            node.next.prev = node;
            node.next.next.prev = node.next;
            node.next.next.next = node;
            Console.WriteLine("Before reversing");
            printDLL(node, true);
            printDLL(node, false);
            Console.WriteLine("After reversing");
            node = rev(node);
            printDLL(node, true);
            printDLL(node, false);
            Console.ReadLine();
        }
    }
}
