using System;
namespace Main.SeventyFive.TwoPointers
{
    public class IsPermutationOf
    {
        public static void Execute()
        {
            //Console.WriteLine(IsPermutationOfImpl("thecatsat", "cfh") == false);
            //Console.WriteLine(IsPermutationOfImpl("thecatsat", "ceh") == true);
            Console.WriteLine(IsPermutationOfImpl("thecatsat", "che") == true);
        }

        private static int[] primes = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };

        private static int CreateHash(string source)
        {
            var lower = source.ToLower();

            var hash = 1;

            for(var i = 0; i < lower.Length; i++)
            {
                hash *= primes[lower[i] - 'a'];
            }

            return hash;
        }

        public static bool IsPermutationOfImpl(string source, string contained)
        {
            if (contained.Length > source.Length)
            {
                return false;
            }

            var containedHash = CreateHash(contained);
            var sourceWindowHash = 1;            

            for(var i = 0; i < source.Length; i++)
            {
                sourceWindowHash *= primes[char.ToLower(source[i]) - 'a'];

                if (i >= contained.Length)
                {
                    sourceWindowHash /= primes[char.ToLower(source[i - contained.Length]) - 'a'];
                }

                if (sourceWindowHash == containedHash)
                {
                    return true;
                }
            }

            return false;

        }
    }
}
