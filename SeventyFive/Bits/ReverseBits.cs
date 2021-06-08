using System;
using System.Collections.Generic;

namespace Main.SeventyFive.Bits
{
    public class ReverseBits
    {
        static void DumpBits(uint value)
        {
            var bitList = new List<char>();

            for(var i = 31; i >= 0; i--)
            {
                var v = value & (0x1 << i);
                bitList.Add(v > 0 ? '1' : '0');
            }

            Console.WriteLine(string.Join(".", bitList));
        }

        public static void Execute()
        {
            uint x = 1024;

            DumpBits(x);

            uint r = ReverseBitsImpl(x);

            DumpBits(r);
        }

        public static uint ReverseBitsImpl(uint n)
        {
            uint o = 0;
            uint maskRead = 0x1;

            for (int i = 0; i < 32; i++)
            {
                maskRead = (0x1U << i);
                var x = maskRead & n;

                if (x > 0)
                {
                    x = 0x1U << (31 - i);
                    o |= x;
                }
            }

            return o;
        }
    }
}
