using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.SeventyFive.LinkedList
{
    /// <summary>
    /// https://leetcode.com/problems/reorder-list/
    /// </summary>
    public class ReorderList
    {
        public static void Execute()
        {
            var list = ListNode.Create(new[] { 1, 2, 3, 4, 5 });
            ReorderListImpl(list);
            Console.WriteLine(list);
        }

        public static IDictionary<int, ListNode> CreateMap(ListNode node)
        {
            var map = new Dictionary<int, ListNode>();
            var current = node;
            var index = 0;

            while (current != null)
            {
                map.Add(index, current);
                current = current.next;
                index += 1;
            }

            return map;
        }

        public static void ReorderListImpl(ListNode head)
        {
            if (head == null)
            {
                return;
            }

            var map = CreateMap(head);

            if (map.Count <= 2)
            {
                return;
            }

            var current = head;
            var last = map.Count - 1;
            var count = 0;

            while (count < map.Count)
            {
                ListNode tmp;
                tmp = current.next;
                current.next = map[last];
                current = map[last];

                if (ReferenceEquals(tmp, current))
                {
                    current.next = null;
                    return;
                }

                current.next = tmp;
                current = current.next;
                count += 2;
                last -= 1;
            }

            current = current.next;
            current.next = null;
        }
    }
}
