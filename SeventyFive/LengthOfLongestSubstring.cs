using System;
using System.Collections.Generic;

namespace Main.SeventyFive
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// </summary>
    public class LengthOfLongestSubstring
    {
        public static void Execute()
        {
            //var source = "abcabc";
            //var source = "bbbb";
            var source = "pwwkew";
            //var source = "";
            Console.WriteLine(LengthOfLongestSubstringImpl(source));
        }

        public static int LengthOfLongestSubstringImpl(string source)
        {
            var maxLen = 0;

            for(var i = 0; i < source.Length; i++)
            {
                var set = new HashSet<char>();
                maxLen = Math.Max(maxLen, 1);

                set.Add(source[i]);

                for(var j = i + 1; j < source.Length; j++)
                {
                    if (!set.Contains(source[j]))
                    {
                        set.Add(source[j]);
                        maxLen = Math.Max(maxLen, j - i + 1);
                    }
                    else
                    {
                        break;
                    }                    
                }
            }

            return maxLen;
        }
    }
}
