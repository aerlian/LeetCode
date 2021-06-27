using System;
namespace Main.SeventyFive.Strings
{
    public class PalindromeSubstrings
    {
        public static void Execute()
        {
            Console.WriteLine(CountSubstrings("fdsklf"));
        }

        public static int CountPalindromeOdd(string source, int offset)
        {
            var l = offset;
            var r = offset;

            var count = 0;

            while (l >= 0 && r < source.Length)
            {
                if (source[l] == source[r])
                {
                    count += 1;
                }
                else
                {
                    break;
                }

                l -= 1;
                r += 1;
            }

            return count;
        }

        public static int CountPalindromeEven(string source, int left, int right)
        {
            var l = left;
            var r = right;

            var count = 0;

            while (l >= 0 && r < source.Length)
            {
                if (source[l] == source[r])
                {
                    count += 1;
                }
                else
                {
                    break;
                }

                l -= 1;
                r += 1;
            }

            return count;
        }

        public static int CountSubstrings(string s)
        {
            var count = 0;

            for (var i = 0; i < s.Length; i++)
            {
                count += CountPalindromeOdd(s, i);
                count += CountPalindromeEven(s, i, i + 1);
            }

            return count;
        }
    }
}
