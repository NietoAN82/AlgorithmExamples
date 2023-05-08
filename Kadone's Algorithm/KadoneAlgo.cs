using System;
using System.Diagnostics;

namespace KadoneAlgo
{
    class Program
    {
        static int KadonesAlgorithm(int[] inputArray)
        {
            int length = inputArray.Length;
            int localMax = 0;
            int globalMax = int.MinValue; //negative infinity

            for (int i = 0; i < length; i++)
            {
                localMax = Math.Max(inputArray[i], inputArray[i] + localMax);
                if (localMax > globalMax)
                {
                    globalMax = localMax;
                }
            }
            return globalMax;
        }
        public static void Main(string[] args)
        {
            int[] exampleArray = new int[] { -3, -1, -3, 4, -1, 2, 1, -5, 4 };
            Debug.WriteLine(KadonesAlgorithm(exampleArray));
        }
    }
}