
using System;
using System.Linq;
using System.Text;

namespace Main.Common
{
    public static class Arrays
    {
        //[[0,1],[1,2],[2,3],[1,3],[1,4]]
        ////[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]
        public static T [][] CreateFrom<T>(string source, Func<string, T> converter)
        {
            var source2 = ReplaceWithColon(source);
            var parts = source2.Split(';');
            var output = parts.Select(p => p.Substring(1).Substring(0, p.Length - 2).Split(",").Select(q => converter(q)).ToArray()).ToArray();
            return output;
        }

        private static string ReplaceWithColon(string source)
        {
            var elementCount = 0;
            var bld = new StringBuilder();

            for (var i = 0; i < source.Length; i++)
            {
                var ch = source[i];
                bld.Append(ch);

                if (ch == '[')
                {
                    elementCount += 1;
                    continue;
                }

                if (ch == ']')
                {
                    elementCount -= 1;
                    continue;
                }

                if (ch == ',' && elementCount == 1)
                {
                    bld.Remove(bld.Length - 1, 1);
                    bld.Append(";");
                }
            }

            bld.Remove(0, 1);
            bld.Remove(bld.Length - 1, 1);

            return bld.ToString();
        }
    }
}
