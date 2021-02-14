using System;
using System.Collections.Generic;

namespace Main.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/longest-palindromic-substring/
    /// </summary>
    public class LongestPalindrome
    {
        public static void Execute()
        {
            var word = "0x1noon2x";
            //var word = "abbc";
            //var word = "mwwfjysbkebpdjyabcfkgprtxpwvhglddhmvaprcvrnuxifcrjpdgnktvmggmguiiquibmtviwjsqwtchkqgxqwljouunurcdtoeygdqmijdympcamawnlzsxucbpqtuwkjfqnzvvvigifyvymfhtppqamlgjozvebygkxawcbwtouaankxsjrteeijpuzbsfsjwxejtfrancoekxgfyangvzjkdskhssdjvkvdskjtiybqgsmpxmghvvicmjxqtxdowkjhmlnfcpbtwvtmjhnzntxyfxyinmqzivxkwigkondghzmbioelmepgfttczskvqfejfiibxjcuyevvpawybcvvxtxycrfbcnpvkzryrqujqaqhoagdmofgdcbhvlwgwmsmhomknbanvntspvvhvccedzzngdywuccxrnzbtchisdwsrfdqpcwknwqvalczznilujdrlevncdsyuhnpmheukottewtkuzhookcsvctsqwwdvfjxifpfsqxpmpwospndozcdbfhselfdltmpujlnhfzjcgnbgprvopxklmlgrlbldzpnkhvhkybpgtzipzotrgzkdrqntnuaqyaplcybqyvidwcfcuxinchretgvfaepmgilbrtxgqoddzyjmmupkjqcypdpfhpkhitfegickfszermqhkwmffdizeoprmnlzbjcwfnqyvmhtdekmfhqwaftlyydirjnojbrieutjhymfpflsfemkqsoewbojwluqdckmzixwxufrdpqnwvwpbavosnvjqxqbosctttxvsbmqpnolfmapywtpfaotzmyjwnd";
            //var word = "s";
            var cache = new Dictionary<(int, int), (int, int, int)>();
            var result = LongestPalindromeImpl(cache, word.ToCharArray(), 0, word.Length - 1);
            Console.WriteLine(word.Substring(result.i, result.len));
        }

        public static (int i, int o, int len) LongestPalindromeImpl(Dictionary<(int, int), (int, int, int)> cache, char [] source, int index, int offset)
        {
            if (index > offset)
            {
                return (index, offset, 0); 
            }

            if (cache.TryGetValue((index, offset), out var cachedResult))
            {
                return cachedResult;
            }

            var candidate1 = LongestPalindromeImpl(cache, source, index + 1, offset);
            var candidate2 = LongestPalindromeImpl(cache, source, index, offset - 1);

            var i = index;
            var j = offset;

            var isMatch = true;

            while (i < j)
            {
                if (source[i] != source[j])
                {
                    isMatch = false;
                    break;
                }

                i += 1;
                j -= 1;
            }

            var result = isMatch ? (index, offset, offset - index + 1) : (index, offset, 0);

            var longest = result;

            if (candidate1.len > longest.Item3)
            {
                longest = candidate1;
            }

            if (candidate2.len > longest.Item3)
            {
                longest = candidate2;
            }

            cache.Add((index, offset), longest);
            
            return longest;
        }
    }
}
