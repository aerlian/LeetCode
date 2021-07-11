using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.Patterns
{
    public class ZigZagConversion
    {
        public static void Execute()
        {
            Console.WriteLine(Convert("PAYPALISHIRING", 2));
        }

        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            var arrList = new List<char>[numRows];

            for (var i = 0; i < numRows; i++)
            {
                arrList[i] = new List<char>();
            }

            var letterCount = 0;
            var row = 0;
            var rowDirection = 1;

            while (letterCount < s.Length)
            {
                var ch = s[letterCount];
                arrList[row].Add(ch);

                letterCount += 1;

                if ((rowDirection == 1 && row >= arrList.Length - 1) || (rowDirection == -1 && row == 0))
                {
                    rowDirection *= -1;
                }

                row += rowDirection;
            }

            var chs = arrList.SelectMany(p => p.ToArray()).ToArray();


            return new string(chs);
        }
    }
}
