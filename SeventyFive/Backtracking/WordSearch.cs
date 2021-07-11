using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.SeventyFive.Backtracking
{
    /// <summary>
    /// https://leetcode.com/problems/word-search/
    /// </summary>
    public class WordSearch
    {
        public static void Execute()
        {
            var input = Arrays.CreateFrom("[[A,B,C,E],[S,F,C,S],[A,D,E,E]]", a => a[0]);
            Console.WriteLine(Exist(input, "ABCCED"));
        }

        public static bool Exist(char[][] board, string word)
        {
            var maxRows = board.Length;
            var maxCols = board[0].Length;

            for (var row = 0; row < maxRows; row++)
            {
                for (var col = 0; col < maxCols; col++)
                {
                    if (dfs(row, col, new HashSet<(int, int)>(), 0))
                    {
                        return true;
                    }
                }
            }

            return false;

            bool dfs(int row, int col, ISet<(int, int)> visited, int wordIndex)
            {
                if (wordIndex > word.Length - 1 ||
                    row < 0 || row >= maxRows ||
                    col < 0 || col >= maxCols ||
                    visited.Contains((row, col)))
                {
                    return false;
                }

                visited.Add((row, col));
                var isLetterMatch = word[wordIndex] == board[row][col];

                if (isLetterMatch && wordIndex == word.Length - 1)
                {
                    return true;
                }

                if (isLetterMatch)
                {
                    if (
                        dfs(row + 1, col, visited, wordIndex + 1) ||
                        dfs(row - 1, col, visited, wordIndex + 1) ||
                        dfs(row, col + 1, visited, wordIndex + 1) ||
                        dfs(row, col - 1, visited, wordIndex + 1))
                    {
                        return true;
                    }
                }

                visited.Remove((row, col));

                return false;
            }
        }
    }
}
