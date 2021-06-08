using System;
using System.Linq;
using Main.Common;

namespace Main.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
    /// </summary>
    public class PreorderInorderTraversal
    {
        public static void Execute()
        {
            var pre = new int[] {3, 9, 20, 15, 7};
            var ino = new int[] { 9, 3, 15, 20, 7 };

            var result = PreorderInorderTraversalImpl(pre, ino);
        }

        public static TreeNode PreorderInorderTraversalImpl(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0 || inorder.Length == 0) {
                return null;
            }

            var n = new TreeNode { val = preorder[0] };

            var mid = Array.FindIndex(inorder, i => i == preorder[0]);

            n.left = PreorderInorderTraversalImpl(preorder.Skip(1).Take(mid).ToArray(), inorder.Take(mid).ToArray());
            n.right = PreorderInorderTraversalImpl(preorder.Skip(1 + mid).ToArray(), inorder.Skip(mid + 1).ToArray());

            return n;
        }
    }
}
