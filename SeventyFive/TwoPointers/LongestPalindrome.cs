using System;
namespace Main.SeventyFive.TwoPointers
{
    public class LongestPalindrome
    {
        public static void Execute()
        {
            var input = "ehciuenoonoiwhsi";
            Console.WriteLine(LongestPalindromeImpl(input));
        }

        public static string LongestPalindromeImpl(string source)
        {
            var start = 0;
            var end = 0;

            for(var i = 0; i < source.Length; i++)
            {
                var l1 = Expand(i, i, source);
                var l2 = Expand(i, i + 1, source);

                var len = Math.Max(l1, l2);

                if (len > end - start)
                {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }
            }

            return source.Substring(start, end - start + 1);
        }

        // "noon"
        public static int Expand(int offsetLo, int offsetHi, string source)
        {
            if (offsetLo > offsetHi)
            {
                return 0;
            }
            var lo = offsetLo;
            var hi = offsetHi;

            while(lo >= 0 && hi < source.Length && source[lo] == source[hi])
            {
                lo -= 1;
                hi += 1;
            }

            return hi - lo - 1;
        }
    }
}
