using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
    public class gNode
    {
        public int data { get; set; }
        public List<gNode> adj = new List<gNode>();
        public List<int> cost = new List<int>();
        public bool visited = false;
        public int key = Int32.MaxValue;
        public gNode parent = null;

        public gNode(int data)
        {
            this.data = data;            
        }
    }

    
    class Graph
    {
        public gNode start { get; set; }
        public List<gNode> nodeList = new List<gNode>();

        public Graph(gNode root)
        {
            start = root;
            if(start != null)
                start.key = 0;
        }

        public void AddEdge(gNode a, gNode b, int cost)
        {
            if (!nodeList.Contains(a))
                nodeList.Add(a);
            if (!nodeList.Contains(b))
                nodeList.Add(b);

            if (!a.adj.Contains(b))
            {
                a.adj.Add(b);
                a.cost.Add(cost);
            }
            if (!b.adj.Contains(a))
            {
                b.adj.Add(a);
                b.cost.Add(cost);
            }
        }

        public void BFS(gNode node)
        {
            Queue<gNode> queue = new Queue<gNode>();
            node.visited = true;
            queue.Enqueue(node);
            gNode cur;
            Console.WriteLine("BFS traversal of graph: ");
            while (queue.Count > 0)
            {
                cur = queue.Dequeue();
                Console.Write(" {0} ", cur.data);

                foreach (gNode n in cur.adj)
                {
                    if (!n.visited)
                    {
                        n.visited = true;
                        queue.Enqueue(n);
                    }
                }
            }
        }

        private void SwapNodes(int i, int j)
        {
            gNode temp = nodeList[i];
            nodeList[i] = nodeList[j];
            nodeList[j] = temp;
        }

        public void Heapify()
        {
            int start = (nodeList.Count - 2) / 2;

            while (start >= 0)
            {
                Heapify(start, nodeList.Count - 1);
                start--;
            }
        }

        public void Heapify(int start, int end)
        {            
            int root = start;

            while ((root * 2 + 1) < end)
            {
                int child = root * 2 + 1;
                int swap = root;

                if (nodeList[child].key < nodeList[swap].key)
                    swap = child;
                if ((child + 1) < end && nodeList[child + 1].key < nodeList[swap].key)
                    swap = child + 1;

                if (swap != root)
                {
                    SwapNodes(swap, root);
                    root = swap;
                }
                else
                    break;
            }
        }

        public Graph Prims()
        {
            Graph minSpan = new Graph(null);
            List<gNode> temp = new List<gNode>();
            while (nodeList.Count > 0)
            {

                Heapify();  //place graph in min heap
                gNode root = nodeList[0];   //extract node with min key
                gNode n = new gNode(root.data);

                if (root.parent != null)
                {
                    if (minSpan.start == null)
                        minSpan.start = root.parent;

                    minSpan.AddEdge(root.parent, n, root.key);
                    root.parent = null;
                }

                for (int i = 0; i < root.adj.Count; i++)
                {
                    if (root.adj[i].key > root.cost[i])
                    {
                        root.adj[i].key = root.cost[i];
                        root.adj[i].parent = n;
                    }
                }

                temp.Add(root);
                nodeList.RemoveAt(0);
            }

            nodeList = temp;
            return minSpan;
        }

        public Graph Dijkstras()
        {
            Graph minSpan = new Graph(null);
            List<gNode> temp = new List<gNode>();
            while (nodeList.Count > 0)
            {

                Heapify();  //place graph in min heap
                gNode root = nodeList[0];   //extract node with min key
                gNode n = new gNode(root.data);

                if (root.parent != null)
                {
                    if (minSpan.start == null)
                        minSpan.start = root.parent;

                    minSpan.AddEdge(root.parent, n, root.key);
                    root.parent = null;
                }

                for (int i = 0; i < root.adj.Count; i++)
                {
                    if (root.adj[i].key > (root.cost[i] + root.key))
                    {
                        root.adj[i].key = root.cost[i] + root.key;
                        root.adj[i].parent = n;
                    }
                }

                temp.Add(root);
                nodeList.RemoveAt(0);
            }

            nodeList = temp;
            return minSpan;
        }

        public void printEdges()
        {
            Console.WriteLine("Edges in the graph: ");
            for (int i = 0; i < nodeList.Count; i++)
            {
                gNode n = nodeList[i];
                for (int j = 0; j < n.adj.Count; j++)
                {
                    Console.WriteLine("Edge between {0} and {1}: cost = {2}", n.data, n.adj[j].data, n.cost[j]);
                }
                Console.WriteLine("\n");
            }
        }
    }

    public class GraphDriver
    {
        public static void driver()
        {
            Graph graph = buildgraph();
            //graph.BFS(graph.start);
            //Graph minspan = graph.Prims();
            Graph minspan = graph.Dijkstras();
            minspan.printEdges();
        }

        private static Graph buildgraph()
        {
            gNode n0 = new gNode(0);
            gNode n1 = new gNode(1);
            gNode n2 = new gNode(2);
            gNode n3 = new gNode(3);
            gNode n4 = new gNode(4);
            gNode n5 = new gNode(5);
            gNode n6 = new gNode(6);
            gNode n7 = new gNode(7);
            gNode n8 = new gNode(8);

            Graph graph = new Graph(n0);
            graph.AddEdge(n0, n1, 4);
            graph.AddEdge(n0, n7, 8);
            graph.AddEdge(n1, n7, 11);
            graph.AddEdge(n1, n2, 9);
            graph.AddEdge(n2, n8, 2);
            graph.AddEdge(n7, n8, 7);
            graph.AddEdge(n7, n6, 1);
            graph.AddEdge(n8, n6, 6);
            graph.AddEdge(n6, n5, 2);
            graph.AddEdge(n5, n2, 4);
            graph.AddEdge(n2, n3, 7);
            graph.AddEdge(n3, n5, 14);
            graph.AddEdge(n5, n4, 10);
            graph.AddEdge(n3, n4, 9);

            return graph;
        }

    }
}
