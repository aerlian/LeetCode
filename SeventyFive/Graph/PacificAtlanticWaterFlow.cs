using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.SeventyFive.Graph
{
    /// <summary>
    /// https://leetcode.com/problems/pacific-atlantic-water-flow/
    /// </summary>
    public class PacificAtlanticWaterFlow
    {
        public static void Execute()
        {
            var input = new int[][]
            {
                new int[] { 1, 2, 2, 3, 5 },
                new int[] { 3, 2, 3, 4, 4 },
                new int[] { 2, 4, 5, 3, 1 },
                new int[] { 6, 7, 1, 4, 5 },
                new int[] { 5, 1, 1, 2, 4 }
            };

            var output = PacificAtlanticImpl(input);
            Console.WriteLine(string.Join(",", output.Select(l => $"({l[0]}:{l[1]})")));
        }

        // commence search for higher places from pacific top row and pacific left side
        // commence search for higher places from atlantic bottom row and atlantic right side
        public static IList<IList<int>> PacificAtlanticImpl(int[][] heights)
        {
            var atlSet = new HashSet<(int, int)>(); //set of squares that can be visited from atlantic sides
            var pacSet = new HashSet<(int, int)>(); //set of squares that can be visited from pacific sides

            var maxRow = heights.Length - 1;
            var maxCol = heights[0].Length - 1;

            void dfs(int r, int c, ISet<(int, int)> visited, int priorHeight)
            {
                if (visited.Contains((r, c)) || r < 0 || c < 0 || r > maxRow || c > maxCol ||
                   heights[r][c] < priorHeight)
                {
                    return;
                }

                visited.Add((r, c));

                dfs(r + 1, c, visited, heights[r][c]);
                dfs(r - 1, c, visited, heights[r][c]);
                dfs(r, c + 1, visited, heights[r][c]);
                dfs(r, c - 1, visited, heights[r][c]);
            }

            for (var c = 0; c <= maxCol; c++)
            {
                dfs(0, c, pacSet, heights[0][c]);
                dfs(maxRow, c, atlSet, heights[maxRow][c]);
            }

            for (var r = 0; r <= maxRow; r++)
            {
                dfs(r, 0, pacSet, heights[r][0]);
                dfs(r, maxCol, atlSet, heights[r][maxCol]);
            }

            IList<IList<int>> output = new List<IList<int>>();

            for (var r = 0; r <= maxRow; r++)
            {
                for (var c = 0; c <= maxCol; c++)
                {
                    if (atlSet.Contains((r, c)) && pacSet.Contains((r, c)))
                    {
                        output.Add(new List<int>(new int[] { r, c }));
                    }
                }
            }

            return output;
        }
    }
}
