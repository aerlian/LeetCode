using System;
namespace Main.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/unique-paths-ii/
    /// </summary>
    public class UniquePathsWithObstacles
    {
        public static void Execute()
        {
            //var grid = new int[][] {
            //    new [] { 0, 0, 0 },
            //    new [] { 0, 1, 0 },
            //    new [] { 0, 0, 0 },
            //};

            var grid = new int[][] {
                new [] { 0, 1},
                new [] { 0, 0},
            };

            var rows = grid.Length;
            var cols = grid[0].Length;

            Console.WriteLine(UniquePathsWithObstaclesImpl(grid, rows - 1, cols - 1, 0, 0, new int [rows, cols]));
        }

        public static int UniquePathsWithObstaclesImpl(int[][] grid, int rows, int cols, int currRow, int currCol, int [,] cache)
        {
            if (currRow > rows || currCol > cols || grid[currRow][currCol] == 1)
            {
                return 0;
            }

            if (currRow == rows && currCol == cols)
            {
                return 1;
            }

            if (cache[currRow, currCol] != 0)
            {
                return cache[currRow, currCol];
            }

            var ways = UniquePathsWithObstaclesImpl(grid, rows, cols, currRow + 1, currCol, cache) +
                        UniquePathsWithObstaclesImpl(grid, rows, cols, currRow, currCol + 1, cache);

            cache[currRow, currCol] = ways;

            return ways;
        }
    }
}
