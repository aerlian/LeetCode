using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.SeventyFive.LinkedList
{
    /// <summary>
    /// https://leetcode.com/problems/remove-linked-list-elements/
    /// </summary>
    public class RemoveLinkedListElements
    {
        public static void Execute()
        {
            //var source = ListNode.Create(new[] { 1, 2, 6, 3, 4, 5, 6 });
            var source = ListNode.Create(new[] { 6, 6, 6 });
            var output = RemoveLinkedListElementsImpl(source, 6);

            Console.WriteLine(output);
        }

        public static ListNode RemoveLinkedListElementsImpl(ListNode head, int val)
        {
            if (head == null)
            {
                return head;
            }

            List<int> ToListExcept(ListNode head, int value)
            {
                var lst = new List<int>();

                var p = head;

                while(p != null)
                {
                    if (p.val != value)
                    {
                        lst.Add(p.val);
                    }

                    p = p.next;
                }

                return lst;
            }

            var cleanLst = ToListExcept(head, val);

            ListNode ToListNode(List<int> source)
            {
                ListNode root = null;

                for(var i = source.Count - 1; i >= 0; i--)
                {
                    var node = new ListNode { val = source[i] };

                    if (root == null)
                    {
                        root = node;
                    }
                    else
                    {
                        node.next = root;
                        root = node;
                    }
                }

                return root;
            }

            var output = ToListNode(cleanLst);

            return output;
        }
    }
}
