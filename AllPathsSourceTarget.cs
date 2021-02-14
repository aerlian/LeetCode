using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class AllPathsSourceTarget
    {
        

        public static IList<IList<int>> AllPathsSourceTargetImpl(int loc, int[][] graph, Stack<int> currentPath)
        {
            var pathList = new List<IList<int>>();

            try
            {
                currentPath.Push(loc);

                if (loc == graph.Length - 1)
                {
                    pathList.Add(currentPath.Reverse().ToList());
                    return pathList;
                }

                var pathsAvail = graph[loc];

                foreach(var next in pathsAvail)
                {
                    var lst = AllPathsSourceTargetImpl(next, graph, currentPath);
                    if (lst.Count > 0)
                    {
                        foreach(var p in lst)
                        {
                            pathList.Add(p);
                        }
                    }
                }
            }
            finally
            {
                currentPath.Pop();                
            }

            return pathList;
        }

        public static void Execute()
        {
            //[4,3,1],[3,2,4],[3],[4],
            //var result = AllPathsSourceTargetImpl(0, new[] { new[] { 1, 2 }, new[] { 3 }, new[] { 3 }, Array.Empty<int>() }, new Stack<int>());
            var result = AllPathsSourceTargetImpl(0, new[] { new[] { 4, 3, 1 }, new[] { 3, 2, 4 }, new[] { 3 }, new[] { 4 }, Array.Empty<int>() }, new Stack<int>());

            foreach(var i in result)
            {
                Console.WriteLine($"{string.Join(",", i)}");
            }
        }
    }
}
