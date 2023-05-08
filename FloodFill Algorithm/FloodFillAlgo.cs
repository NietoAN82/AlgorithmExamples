namespace FloodFillAlgo
{
    class Program
    {
        static ConsoleColor[,] pixels = new ConsoleColor[5, 5];

        static void FloodFill(int height, int width, int x, int y, ConsoleColor fill, ConsoleColor old)
        {
            if ((x < 0) || (x >= width)) return;
            if ((y < 0) || (y >= height)) return;
            if (pixels[x, y] == old) //If color of the pixel we are on is the same as the color we clicked
            {
                pixels[x, y] = fill;
                FloodFill(5, 5, x + 1, y, fill, old);
                FloodFill(5, 5, x, y + 1, fill, old);
                FloodFill(5, 5, x - 1, y, fill, old);
                FloodFill(5, 5, x, y - 1, fill, old);
            }
        }
    }
}