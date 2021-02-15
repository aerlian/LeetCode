using System;
namespace Main.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/unique-paths/
    /// </summary>
    public class UniquePaths
    {
        public static void Execute()
        {
            Console.Clear();
            var rows = 3;
            var cols = 7;
            int[,] cache = new int[rows - 1, cols - 1];
            Console.WriteLine(UniquePathsImpl(rows - 1, cols - 1, 0, 0, cache)); 
        }

        public static int UniquePathsImpl(int rows, int cols, int currentRow, int currentCol, int [,] cachedWays)
        {
            if (currentRow > rows || currentCol > cols)
            {
                return 0;
            }

            if (currentRow == rows || currentCol == cols)
            {
                return 1;
            }

            if (cachedWays[currentRow, currentCol] != 0)
            {
                return cachedWays[currentRow, currentCol];
            }

            var ways = UniquePathsImpl(rows, cols, currentRow + 1, currentCol, cachedWays) +
                        UniquePathsImpl(rows, cols, currentRow, currentCol + 1, cachedWays);

            cachedWays[currentRow, currentCol] = ways;

            return ways;
        }
    }
}
