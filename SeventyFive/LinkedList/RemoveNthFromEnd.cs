using Main.Common;

namespace Main.SeventyFive.LinkedList
{
    public static class RemoveNthFromEnd
    {
        public static void Execute()
        {
            var lst = ListNode.Create(new[] { 1, 2, 3, 4 });
            var r = RemoveNthFromEndImpl(lst, 4);
            System.Console.WriteLine(r.ToString());
        }
        
        public static ListNode Advance(ListNode n, int count)
        {
            var current = n;
            while (count > 0)
            {
                current = current.next;
                count -= 1;
            }

            return current;
        }

        public static ListNode RemoveNthFromEndImpl(ListNode head, int n)
        {
            if (head == null)
            {
                return null;
            }

            if (head != null && head.next == null && n == 1)
            {
                return null;
            }

            var dummy = new ListNode(0, head);

            var behind = dummy;
            var end = Advance(head, n);

            while (end != null)
            {
                behind = behind.next;
                end = end.next;
            }

            behind.next = behind.next.next;

            return dummy.next;
        }
    }
}
