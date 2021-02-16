namespace Main.Common
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode Create(int[] source)
        {
            if (source == null || source.Length == 0)
            {
                return null;
            }

            ListNode latest = null;

            for (var i = source.Length - 1; i >= 0; i--)
            {
                var node = new ListNode { val = source[i] };

                if (latest != null)
                {
                    node.next = latest;
                }

                latest = node;
            }

            return latest;
        }
    }
}
