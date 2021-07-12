using System;
using System.Collections.Generic;
using System.Text;

namespace Main.Patterns.Backtracking
{
    /// <summary>
    /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
    /// </summary>
    public class LetterCombinations
    {
        public static void Execute()
        {
            Console.WriteLine(string.Join(",", LetterCombinationsImpl("23")));
        }

        public static IList<string> LetterCombinationsImpl(string digits)
        {
            if (digits.Length == 0)
            {
                return new List<string>();
            }
            var d = new Dictionary<char, string>
            {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" }
            };

            var output = new List<string>();
            var combinationSoFar = new StringBuilder();
            var digitIndex = 0;

            backTrack(digitIndex);

            return output;

            void backTrack(int digitIndex)
            {
                if (combinationSoFar.Length == digits.Length)
                {
                    output.Add(new string(combinationSoFar.ToString()));
                    return;
                }

                var digit = digits[digitIndex];
                var lettersOfDigit = d[digit];
                for (var i = 0; i < lettersOfDigit.Length; i++)
                {
                    var letter = lettersOfDigit[i];
                    combinationSoFar.Append(letter);
                    backTrack(digitIndex + 1);
                    combinationSoFar.Remove(combinationSoFar.Length - 1, 1);
                }
            }
        }
    }
}
