using System;

namespace PrimmAlgo
{
    class Program
    {
        private static int GetMinimumNode(int[] nodes, bool[] set, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; v++)
            {
                if (set[v] == false && nodes[v] < min)
                {
                    min = nodes[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        public static void PrimmsAlgorithm(int[,] graph, int verticesCount)
        {
            int[] parent = new int[verticesCount];
            int[] node = new int[verticesCount];
            bool[] minimumSpanningTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                node[i] = int.MaxValue;
                minimumSpanningTreeSet[i] = false;
            }

            node[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int minNode = GetMinimumNode(node, minimumSpanningTreeSet, verticesCount);
                minimumSpanningTreeSet[minNode] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (Convert.ToBoolean(graph[minNode, v]) && minimumSpanningTreeSet[v] == false
                        && graph[minNode, v] < node[v])
                    {
                        parent[v] = minNode;
                        node[v] = graph[minNode, v];
                    }
                }
            }
        }
    }
}