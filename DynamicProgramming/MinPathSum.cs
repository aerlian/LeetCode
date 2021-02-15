using System;
using System.Collections.Generic;
namespace Main.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-path-sum/
    /// </summary>
    public class MinPathSum
    {
        public static void Execute()
        {
            //var g = new int [][] {
            //    new int[] { 1, 3, 1 },
            //    new int[] { 1, 5, 1},
            //    new int[] { 4, 2, 1 },
            //};

            var g = new int[][]
            {                
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6},
            };

            int rows = g.Length;
            int cols = g[0].Length;
            
            Console.WriteLine(MinPathSumImpl(g, rows - 1, cols - 1, 0, 0, new Dictionary<(int, int), long>()));
        }

        public static long MinPathSumImpl(int[][] grid, int rows, int cols, int currentRow, int currentCol, Dictionary<(int, int), long> cache)
        {
            if (currentRow > rows || currentCol > cols)
            {
                return int.MaxValue;
            }

            if (currentRow == rows && currentCol == cols)
            {
                return grid[currentRow][currentCol];
            }

            if (cache.ContainsKey((currentRow, currentCol)))
            {
                return cache[(currentRow, currentCol)];
            }

            var currentValue = grid[currentRow][currentCol];

            var minPath = Math.Min(
                MinPathSumImpl(grid, rows, cols, currentRow + 1, currentCol, cache),
                MinPathSumImpl(grid, rows, cols, currentRow, currentCol + 1, cache)
                );

            var total = currentValue + minPath;

            cache.Add((currentRow, currentCol), total);

            return total;
        }
    }
}
