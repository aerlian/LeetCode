using System;
using Main.Common;

namespace Main.SeventyFive.LinkedList
{
    /// <summary>
    /// https://leetcode.com/problems/remove-duplicates-from-sorted-list/
    /// </summary>
    public class DeleteDuplicates
    {
        public static void Execute()
        {
            var output = DeleteDuplicatesImpl(ListNode.Create(new[] { 1, 1, 1 }));
            Console.WriteLine(output);
        }

        public static ListNode DeleteDuplicatesImpl(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var dummy = new ListNode { val = -1, next = head };
            var p = dummy;

            while (p != null)
            {
                var q = p.next;

                if (q != null)
                {
                    if (q.val == p.val)
                    {
                        p.next = q.next;
                        continue;
                    }
                }

                p = p.next;
            }

            return dummy.next;
        }
    }
}
