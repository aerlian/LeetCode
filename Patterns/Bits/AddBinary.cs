using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.SeventyFive.Bits
{
    public class AddBinary
    {
        public static void Execute()
        {
            Console.WriteLine(AddBinaryImpl("11", "1"));
        }

        public static string AddBinaryImpl(string a, string b)
        {
            var term = (char)257;
            var i = a.Length - 1;
            var j = b.Length - 1;
            var carry = 0;
            var output = new Stack<char>();

            while (true)
            {
                var chFirst = (i < 0 && j < 0) ? term : (i < 0 ? '0' : a[i]);
                var chSecond = (i < 0 && j < 0) ? term : (j < 0 ? '0' : b[j]);
                if (chFirst == term || chSecond == term)
                {
                    break;
                }

                var x = chFirst - '0';
                var y = chSecond - '0';
                var sum = x + y + carry;
                carry = 0;

                if (sum >= 2)
                {
                    carry = sum / 2;
                    sum = sum % 2;
                }
                output.Push((char)(sum + '0'));
                i -= 1;
                j -= 1;
            }

            if (carry > 0)
            {
                output.Push('1');
            }

            return new string(output.ToArray());
        }
    }
}

//IEnumerable<int> CreatePadding(int x, int y)
//{
//    return x > y ? Enumerable.Repeat(0, x - y) : Enumerable.Empty<int>();
//}

//var first = CreatePadding(b.Length, a.Length).Concat(a.Select(x => x - '0'));
//var second = CreatePadding(a.Length, b.Length).Concat(b.Select(x => x - '0'));
//var output = new Stack<int>();
//var carry = 0;

//foreach (var pair in first.Zip(second, (i, j) => (i, j)).Reverse())
//{
//    var x = pair.Item1;
//    var y = pair.Item2;
//    var sum = x + y + carry;
//    carry = 0;

//    if (sum >= 2)
//    {
//        carry = sum / 2;
//        sum = sum % 2;
//    }
//    output.Push(sum);
//}

//if (carry > 0)
//{
//    output.Push(1);
//}

//return new string(output.Select(i => (char)(i + '0')).ToArray());
