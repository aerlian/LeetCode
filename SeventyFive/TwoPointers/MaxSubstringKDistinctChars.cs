using System;
using System.Collections.Generic;

namespace Main.SeventyFive.TwoPointers
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters
    /// </summary>
    public class MaxSubstringKDistinctChars
    {
        public static void Execute()
        {
            Console.WriteLine(MaxSubstringKDistinctCharsImpl("araaci", 2) == 4);
            Console.WriteLine(MaxSubstringKDistinctCharsImpl("araaci", 1) == 2);
            Console.WriteLine(MaxSubstringKDistinctCharsImpl("cbbebi", 3) == 5);
        }

        /// <summary>
        /// 1. Contiunally move through the array using the right pointer
        /// 2. If the number is distinct characters exceeds the allowed k then fast forward left pointer
        /// and reduce the distinct count back down to k
        /// </summary>
        public static int MaxSubstringKDistinctCharsImpl(string source, int k)
        {
            var l = 0;
            var r = 0;
            var maxLen = int.MinValue;
            var d = new Dictionary<char, int>();

            while(r < source.Length)
            {
                if (!d.ContainsKey(source[r]))
                {
                    d[source[r]] = 0;
                }

                d[source[r]] += 1; 

                while (d.Count > k)
                {
                    d[source[l]] -= 1;
                    if (d[source[l]] == 0)
                    {
                        d.Remove(source[l]);
                    }

                    l += 1;
                }

                maxLen = Math.Max(maxLen, r - l + 1);
                r += 1;
            }

            return maxLen;
        }
    }
}
