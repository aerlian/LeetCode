using System;
using System.Collections.Generic;

namespace Main.SeventyFive.Bits
{
    public class CountBits
    {
        public static void Execute()
        {
            Console.WriteLine(string.Join(",", CountBitsImpl(5)));
        }

        public static int[] CountBitsImpl(int n)
        {
            var l = new List<int>();
            for (var i = 0; i <= n; i++)
            {
                l.Add(CountBitsNum(i));
            }

            return l.ToArray();
        }

        public static int CountBitsNum(int n)
        {
            var bitCount = 0;

            for (var i = 0; i < 32; i++)
            {
                var o = (n & 1);
                if (o > 0)
                {
                    bitCount += 1;
                }

                n = n >> 1;
            }

            return bitCount;
        }
    }
}
