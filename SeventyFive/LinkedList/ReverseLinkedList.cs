using System;
using Main.Common;

namespace Main.SeventyFive.LinkedList
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-linked-list/
    /// </summary>
    public class ReverseLinkedList
    {
        public static void Execute()
        {
            var output = ReverseLinkedListImpl(ListNode.Create(new[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(output);
        }

        public static ListNode ReverseLinkedListImpl(ListNode head)
        {
            if (head == null)
            {
                return null;
            }


            ListNode current = head;
            ListNode next = null;
            ListNode temp = null;

            while (current != null)
            {
                next = current.next;
                current.next = temp;
                temp = current;
                current = next;
            }

            return temp;
        }
    }
}
