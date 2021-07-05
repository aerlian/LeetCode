using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main.SeventyFive.Strings
{
    /// <summary>
    /// https://leetcode.com/problems/encode-and-decode-strings/
    /// </summary>
    public class EncodeDecodeStrings
    {
        public static void Execute()
        {
            //or just string.Join((char) 257, words);
            //then string.Split((char) 257, words);

            //var s = encode(new List<string>(new string[] { "the", "cat" }));
            var s = encode(new List<string>(new string[] { "" }));
            Console.WriteLine(string.Join(",", decode(s)));
        }

        private static string createEncodedLength(int length)
        {
            var buffer = Enumerable.Repeat('0', 4).ToArray();
            var number = length.ToString();
            var numLen = number.Length;
            var strPos = 0;
            for (var i = 4 - numLen; i < 4; i++)
            {
                buffer[i] = number[strPos];
                strPos += 1;
            }

            return new string(buffer);
        }

        // Encodes a list of strings to a single string.
        public static string encode(IList<string> strs)
        {
            //return string.Join((char)257, strs);
            var sb = new StringBuilder();
            foreach (var w in strs)
            {
                var word = w.ToString();

                var encLen = createEncodedLength(word.Length);

                for (var i = 0; i < encLen.Length; i++)
                {
                    sb.Append(encLen[i]);
                }

                for (var i = 0; i < w.Length; i++)
                {
                    sb.Append(w[i]);
                }
            }

            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public static IList<string> decode(string s)
        {
            var output = new List<string>();

            var pos = 0;
            while (pos < s.Length)
            {
                var sb = new StringBuilder();
                for (var i = pos; i < pos + 4; i++)
                {
                    sb.Append(s[i]);
                }

                var wordLengthStr = sb.ToString().TrimStart(new Char[] { '0' });
                var wordLen = wordLengthStr.Length == 0 ? 0 : int.Parse(wordLengthStr);

                sb.Clear();
                for (var j = pos + 4; j < pos + wordLen + 4; j++)
                {
                    sb.Append(s[j]);
                }

                output.Add(sb.ToString());

                pos += (4 + wordLen);
            }

            return output;
        }
    }
}
