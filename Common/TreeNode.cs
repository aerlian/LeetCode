using System.Linq;
using System.Collections.Generic;

namespace Main.Common
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode BuildTreeFromData(object[] source)
        {
            var node = BuildTreeFromDataImpl(source);

            return node;
        }

        private static TreeNode BuildTreeFromDataImpl(object[] source)
        {
            var q = new Queue<TreeNode>();
            var currentIndex = 0;
            var root = new TreeNode { val = (int)source[currentIndex] };
            q.Enqueue(root);

            currentIndex += 1;

            while (q.Count > 0)
            {
                var node = q.Dequeue();                

                if (currentIndex >= source.Length)
                {
                    break;
                }

                if (source[currentIndex] is int x)
                {                    
                    node.left = new TreeNode { val = x };
                    q.Enqueue(node.left);
                }

                currentIndex += 1;

                if (source[currentIndex] is int y)
                {                    
                    node.right = new TreeNode { val = y };
                    q.Enqueue(node.right);
                }

                currentIndex += 1;
            }

            return root;
        }
    }
}
