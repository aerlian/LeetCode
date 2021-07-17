using System;
using System.Linq;
using Main.Common;

namespace Main.Patterns.LinkedList
{
    public class AddTwoNumbers
    {
        public static void Execute()
        {
            var l1 = ListNode.Create(new int[] { 9, 9, 9, 9, 9, 9, 9 });
            var l2 = ListNode.Create(new int[] { 9, 9, 9, 9 });

            var result = AddTwoNumbersImpl(l1, l2);
            Console.WriteLine(ListNode.ToEnumerable(result).SequenceEqual(new int[] { 8, 9, 9, 9, 0, 0, 0, 1 }));
        }

        public static ListNode AddTwoNumbersImpl(ListNode l1, ListNode l2)
        {
            var x1 = l1;
            var x2 = l2;
            ListNode output = null;
            ListNode current = null;

            var carry = 0;
            while (x1 != null || x2 != null)
            {
                var x = x1 == null ? 0 : x1.val;
                var y = x2 == null ? 0 : x2.val;

                var sum = x + y + carry;
                carry = 0;
                if (sum >= 10)
                {
                    carry = sum / 10;
                    sum = sum % 10;
                }

                var next = new ListNode(sum);

                if (current == null)
                {
                    current = next;
                    output = current;
                }
                else
                {
                    current.next = next;
                    current = next;
                }

                x1 = x1?.next;
                x2 = x2?.next;
            }

            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }

            return output;
        }
    }
}
