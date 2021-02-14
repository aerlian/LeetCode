using System;
using System.Collections.Generic;

namespace Main
{
    public class GroupPeople
    {
        public static void Execute()
        {
            //var groupList =  GroupThePeopleImpl(new[] { 3, 3, 3, 3, 3, 1, 3 });
            var groupList =  GroupThePeopleImpl(new[] { 2, 1, 3, 3, 3, 2 });

            foreach (var list in groupList)
            {
                Console.WriteLine(string.Join(",", list));
            }
        }

        public static IList<IList<int>> GroupThePeopleImpl(int[] groupSizes)
        {
            var listOfGroups = new List<IList<int>>();
            var sizeCountMap = new Dictionary<int, List<int>>();

            if (groupSizes.Length == 0)
            {
                return listOfGroups;
            }

            for (var i = 0; i < groupSizes.Length; i++)
            {
                if (!sizeCountMap.TryGetValue(groupSizes[i], out var lst))
                {
                    lst = new List<int>();
                    sizeCountMap.Add(groupSizes[i], lst);
                }

                lst.Add(i);
            }

            foreach (var kvp in sizeCountMap)
            {
                var size = kvp.Key;
                var group = kvp.Value;

                for (var i = 0; i < group.Count / size; i++)
                {
                    var groupList = new List<int>();
                    listOfGroups.Add(groupList);

                    for (var j = i * size; j < (i + 1) * size; j++)
                    {
                        groupList.Add(group[j]);
                    }
                }
            }

            return listOfGroups;
        }
    }
}
