using System;
using System.Collections.Generic;

namespace Main.SeventyFive.Backtracking
{
    /// <summary>
    /// https://leetcode.com/problems/generate-parentheses/
    /// 1. You can only add a close when close < open
    /// 2. Base can is when openCount == closeCount
    /// </summary>
    public class GenerateParenthesis
    {
        public static void Execute()
        {
            Console.WriteLine(string.Join(",", GenerateParenthesisImpl(3)));
        }

        public static IList<string> GenerateParenthesisImpl(int n)
        {
            var s = new List<string>();
            var output = new List<string>();

            backTrack(0, 0);

            return output;

            void backTrack(int open, int closed)
            {
                if (open == n && closed == n)
                {
                    output.Add(new string(string.Join("", s)));
                }

                if (open < n)
                {
                    s.Add("(");
                    backTrack(open + 1, closed);
                    s.RemoveAt(s.Count - 1);
                }

                if (closed < open)
                {
                    s.Add(")");
                    backTrack(open, closed + 1);
                    s.RemoveAt(s.Count - 1);
                }
            }
        }
    }
}
