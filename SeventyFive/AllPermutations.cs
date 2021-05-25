using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.SeventyFive
{
    /// <summary>
    /// This can be reasoned as follows:
    /// 1. Take every character in the string and append in to it's permutations
    /// 2. So if the string is: abe
    /// 3. The iterate through each character in the string one at a time a -> b -> e
    /// 4. Remove the character from the string (e.g. a) and with the remaining string
    /// 5. Recursively obtain the permutations of the remaining string 'be' -> {be, eb}
    /// 5. Append the character we removed to each result: bea, eba
    /// 6. If the string is passed a single character as input, well that's the base case so you can only return
    /// the input in the output array
    /// </summary>
    public class AllPermutations
    {
        public static void Execute()
        {
            Console.Clear();
            var allPerms = AllPermutationsImpl("abes");

            foreach(var perm in allPerms)
            {
                Console.WriteLine(perm);
            }
        }

        public static string [] AllPermutationsImpl(string source)
        {
            var perms = new List<string>();

            if (source.Length == 1)
            {
                perms.Add(source);
                return perms.ToArray();
            }

            for(var i = 0; i < source.Length; i++)
            {
                var ch = source[i];
                var chList = source.ToCharArray().ToList();
                chList.RemoveAt(i);
                var all = AllPermutationsImpl(new string(chList.ToArray()));

                foreach (var p in all)
                {
                    perms.Add(new string(p.ToCharArray().Concat(new char[] { ch }).ToArray()));
                }
            }

            return perms.ToArray();
        }
    }
}
