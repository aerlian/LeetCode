
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main.Common
{
    public static class Arrays
    {
        //[[0,1],[1,2],[2,3],[1,3],[1,4]]

        public static int[] Extract(string part)
        {
            var nextPart = part.Substring(1).Substring(0, part.Length - 2);
            var pieces = nextPart.Split(',');
            return new int[] { int.Parse(pieces[0]), int.Parse(pieces[1]) };
        }

        public static int [][] CreateFrom(string source)
        {
            var source2 = ReplaceColon(source);
            var parts = source2.Split(';');
            return parts.Select(p => Extract(p)).ToArray();
        }

        private static string ReplaceColon(string source)
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
