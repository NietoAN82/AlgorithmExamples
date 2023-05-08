using System;

namespace KruskalAlgo
{
    class Program
    {
        //Represents edge in the graph
        class Edge
        {
            public int Src;//source vertex of the edge
            public int Dest;//destination vertex of the edge
            public int Weight;//weight or cost of the edge
        }
        //Represents the entire graph
        class Graph
        {
            public int NumberOfVertices;
            public int NumberOfEdges;
            public Edge[] edges;
        }
        //Represents subset of the vertices and is used in the Find and Union methods to keep track Parent and Rank.
        class Subset
        {
            public int Parent;
            public int Rank;
        }

        //The Find method takes an array of Subset objects and and index i and recursively finds the parent of the subset that i belongs to
        private static int Find(Subset[] subsets, int i)
        {
            if (subsets[i].Parent != i)
            {
                subsets[i].Parent = Find(subsets, subsets[i].Parent);
            }
            return subsets[i].Parent;
        }
        //The Union method takes an array of Subset objects and two indices x, and y, and merges the subsets that x and y belong to.
        private static void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].Rank < subsets[yroot].Rank)
            {
                subsets[xroot].Parent = yroot;
            }
            else if (subsets[xroot].Rank > subsets[yroot].Rank)
            {
                subsets[yroot].Parent = xroot;
            }
            else
            {
                subsets[yroot].Parent = xroot;
                subsets[xroot].Rank++;
            }
        }
        //The Kruskal's Algorithm method takes a Graph object as input and uses Kruskal's algorithm
        //to find the MST of the graph. 
        static void KruskalsAlgorithm(Graph graph)
        {
            Edge[] result = new Edge[graph.NumberOfVertices];
            int nodeIndex = 0;
            int edgeIndex = 0;
            //Sorts the edges in non-decreasing order of weight
            Array.Sort(graph.edges, delegate (Edge a, Edge b)
            {
                return a.Weight.CompareTo(b.Weight);
            });

            Subset[] subsets = new Subset[graph.NumberOfVertices];

            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                subsets[i].Parent = i;
                subsets[i].Rank = 0;
            }
            //Selects the next cheapest edge that does not form a cycle in the MST and adds it to the result
            while (edgeIndex < graph.NumberOfEdges - 1)
            {
                Edge nextEdge = graph.edges[nodeIndex++];
                int x = Find(subsets, nextEdge.Src);
                int y = Find(subsets, nextEdge.Dest);

                if (x != y)
                {
                    result[edgeIndex++] = nextEdge;
                    Union(subsets, x, y);
                }
            }
        }

    }
}