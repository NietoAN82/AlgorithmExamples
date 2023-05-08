using System;
using System.Diagnostics;

namespace UnionFind
{
    class Program
    {
        public class Graph
        {
            int V = 0;
            int E = 0;
            public Edge[] edges;

            public class Edge
            {
                public int src;
                public int dest;
            }

            public Graph(int v, int e)
            {
                V = v;
                E = e;
                edges = new Edge[E];

                for (int i = 0; i < e; i++)
                {
                    edges[i] = new Edge();
                }
            }
            int Find(int[] parent, int i)
            {
                if (parent[i] == -1)
                {
                    return i;
                }
                return Find(parent, parent[i]);
            }
            void Union(int[] parent, int x, int y)
            {
                int xset = Find(parent, x);
                int yset = Find(parent, y);
                parent[xset] = yset;
            }

            public int HasCycle(Graph graph)
            {
                int[] parent = new int[graph.V];

                for (int i = 0; i < graph.V; i++)
                {
                    parent[i] = -1;
                }

                for (int i = 0; i < graph.E; i++)
                {
                    int x = graph.Find(parent, graph.edges[i].src);
                    int y = graph.Find(parent, graph.edges[i].dest);

                    if (x == y)
                    {
                        return 1;
                    }

                    graph.Union(parent, x, y);
                }
                return 0;
            }
        }

        public static void Main(string[] args)
        {
            int V = 3;
            int E = 3;

            Graph graph = new Graph(V, E);
            graph.edges[0].src = 0;
            graph.edges[0].dest = 1;

            graph.edges[1].src = 1;
            graph.edges[1].dest = 2;

            graph.edges[2].src = 0;
            graph.edges[2].dest = 2;
            if (graph.HasCycle(graph) == 1)
            {
                Debug.WriteLine("Contains Cycle");
            }
            else
            {
                Debug.WriteLine("Doesn't contain a cycle");
            }
        }
    }
}