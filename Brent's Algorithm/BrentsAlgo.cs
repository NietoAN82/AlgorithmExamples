using System;


namespace BrentAlgo
{
    class Program<T> where T : IEquatable<T>
    {
        public static Tuple<int, int> FindCycle(T x0, Func<T, T> yielder)
        {
            int power = 1;
            int lambda = 1;
            int mu = 0;

            T tortoise = x0;
            T hare = yielder(x0);

            while (!tortoise.Equals(hare))
            {
                if (power == lambda)
                {
                    tortoise = hare;
                    power *= 2;
                    lambda = 0;
                }
                hare = yielder(hare);
                lambda += 1;
            }
            tortoise = x0;
            hare = x0;

            for (int j = 0; j < lambda; j++)
            {
                hare = yielder(hare);
            }

            while (!tortoise.Equals(hare))
            {
                tortoise = yielder(tortoise);
                hare = yielder(hare);
                mu += 1;
            }

            return new Tuple<int, int>(lambda, mu);
        }
    }
}