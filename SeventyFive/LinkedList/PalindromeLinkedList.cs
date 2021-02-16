using System;
using System.Collections.Generic;
using Main.Common;
namespace Main.SeventyFive.LinkedList
{
    /// <summary>
    /// https://leetcode.com/problems/palindrome-linked-list/
    /// </summary>
    public class PalindromeLinkedList
    {
        public static void Execute()
        {            
            //Console.WriteLine(IsPalindromeImpl(ListNode.Create(new[] { 1, 2 })));
            Console.WriteLine(IsPalindromeLinkedListImpl(ListNode.Create(new[] { 1, 2, 2, 1 })));
        }

        public static bool IsPalindromeLinkedListImpl(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            if (head.next == null)
            {
                return true;
            }

            var t = head;
            var h = head;
            var c = 0;
            var s = new Stack<int>();
            var nodeCount = 0;

            while (h != null)
            {
                if (c % 2 == 0)
                {
                    s.Push(t.val);
                    t = t.next;
                }

                h = h.next;
                nodeCount += 1;
                c += 1;
            }

            if (nodeCount % 2 != 0)
            {
                s.Pop();
            }

            while (t != null)
            {
                var num = s.Pop();
                if (num != t.val)
                {
                    return false;
                }

                t = t.next;
            }

            return true;
        }
    }
}
