using System;
using Main.Common;

namespace Main.SeventyFive.TwoPointers
{
    /// <summary>
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// </summary>
    public class MergeTwoSortedLists
    {
        public static void Execute()
        {
            //var l = new[] { 1, 2, 4 };
            //var r = new[] { 1, 3, 4 };

            var l = new int[] { 2};
            var r = new[] { 1, 1, 1, 1 };
            var result = MergeTwoSortedListsImpl(ListNode.Create(l), ListNode.Create(r));
            Console.WriteLine(result);
        }

        public static ListNode MergeTwoSortedListsImpl(ListNode l, ListNode r)
        {
            if (l == null)
            {
                return r;
            }

            if (r == null)
            {
                return l;
            }

            ListNode current = new ListNode { val = -1 };
            ListNode root = current;

            while (l != null && r != null)
            {
                if (l.val <= r.val)
                {
                    current.next = l;                    
                    l = l.next;
                }
                else
                {
                    current.next = r;
                    r = r.next;
                }

                current = current.next;
            }

            var rem = l ?? r;

            while(rem != null)
            {
                current.next = rem;
                current = current.next;
                rem = rem.next;
            }

            return root.next;
        }
    }
}
