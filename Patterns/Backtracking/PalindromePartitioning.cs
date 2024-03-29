﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.Patterns.Backtracking
{
    public class PalindromePartitioning
    {
        public static void Execute()
        {
            var output = Partition("aabb");
            Console.WriteLine("final:\n" + string.Join(", ", output.Select(lst => $"[{string.Join(",", lst)}]" )));
        }

        public static IList<IList<string>> Partition(string s)
        {
            var output = new List<IList<string>>();
            var current = new List<string>();

            dfs(0);
            return output;

            void dfs(int start) {
                if (start >= s.Length)
                {
                    output.Add(new List<string>(current));
                    return;
                }

                for(var end = start; end < s.Length; end++)
                {
                    var candidate = s.Substring(start, end + 1 - start);
                    
                    if (IsPalidrome(candidate))
                    {
                        current.Add(candidate);
                        dfs(end + 1);
                        current.RemoveAt(current.Count - 1);
                    }
                }
            }
        }

        static bool IsPalidrome(string s)
        {
            Console.WriteLine(s);
            var i = 0;
            var j = s.Length - 1;
            while (i < j)
            {
                if (s[i++] != s[j--])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
