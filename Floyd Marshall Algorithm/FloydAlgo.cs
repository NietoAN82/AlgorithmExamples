using System.Diagnostics;


namespace FloydWarshallAlgo
{
    class Program
    {
        public static void FloydMarshall(int[,] graph, int verticesCount)
        {
            //Use verticesCount as the rows and columns for this 2d array.
            int[,] distance = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    distance[i, j] = graph[i, j];
                }
            }

            for (int k = 0; k < verticesCount; k++)
            {
                for (int i = 0; i < verticesCount; i++)
                {
                    for (int j = 0; j < verticesCount; j++)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                        }
                    }
                }
            }
        }
    }
}