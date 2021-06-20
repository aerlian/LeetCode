using System;
using System.Collections.Generic;

namespace Main.SeventyFive.Graph
{
    public class CourseSchedule
    {
        public static void Execute()
        {
            Console.WriteLine(CanFinish(20, preReqs));
        }

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (prerequisites.Length == 0)
            {
                return true;
            }

            var adjList = new Dictionary<int, List<int>>();

            foreach (var i in prerequisites)
            {
                List<int> lst;
                var course = i[0];

                if (adjList.ContainsKey(course))
                {
                    lst = adjList[i[0]];
                }
                else
                {
                    lst = new List<int>();
                    adjList.Add(course, lst);
                }

                lst.Add(i[1]);
            }

            foreach (var j in prerequisites)
            {
                if (!dfs(adjList, j[0], new HashSet<int>()))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool dfs(Dictionary<int, List<int>> adjList, int course, ISet<int> pathSet)
        {
            if (pathSet.Contains(course))
            {
                return false;
            }

            if (!adjList.ContainsKey(course))
            {
                return true;
            }

            var list = adjList[course];

            pathSet.Add(course);

            foreach (var c in list)
            {
                if (!dfs(adjList, c, pathSet))
                {
                    return false;
                }
            }

            adjList[course] = new List<int>();

            pathSet.Remove(course);

            return true;
        }

        private static int[][] preReqs = new int[][] {
            new int [] {0, 10 },
            new int [] {3, 18 },
            new int [] {5, 5 },
            new int [] {6, 11 },
            new int [] {11, 14 },
            new int [] {13, 1 },
            new int [] {15, 1 },
            new int [] {17, 4 }
        };
    }
}
