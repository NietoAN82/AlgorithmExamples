using System;
using System.Collections.Generic;

namespace FloydTHAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a linked list with a cycle
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddFirst(4);
            list.AddFirst(5);



            // Test for a cycle using Floyd's cycle detection algorithm
            bool hasCycle = FloydCycleDetection(list);

            // Print the result
            Console.WriteLine("The linked list {0} a cycle.", hasCycle ? "contains" : "does not contain");
        }
        public static bool FloydCycleDetection<T>(LinkedList<T> list)
        {
            if (list.Count <= 2)
            {
                return false;
            }

            LinkedListNode<T> tortoise = list.First.Next;
            LinkedListNode<T> hare = list.First.Next.Next;

            while (tortoise != null && hare != null)
            {
                if (tortoise == hare)
                {
                    return true;
                }

                if (hare.Next != null)
                {
                    hare = hare.Next.Next;
                }

                tortoise = tortoise.Next;

            }

            return false;
        }
    }
}