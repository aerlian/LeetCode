using System;
using Main.Common;

namespace Main.SeventyFive.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/subtree-of-another-tree/
    /// </summary>
    public class SubtreeOfAnotherTree
    {
        public static void Execute()
        {
            var root = TreeNode.BuildTreeFromData(new object[] { 3, 4, 5, 1, 2 });
            var sub = TreeNode.BuildTreeFromData(new object[] { 4, 1, 2 });

            Console.WriteLine(IsSubtree(root, sub));

            sub = TreeNode.BuildTreeFromData(new object[] { 4, 5, 6 });
            Console.WriteLine(IsSubtree(root, sub));
        }

        public static bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            return IsSubtreeImpl(root, subRoot);
        }

        public static bool IsSubtreeImpl(TreeNode a, TreeNode b)
        {
            if (a == null)
            {
                return false;
            }

            var isSame = false;

            if (a.val == b.val)
            {
                isSame = IsSameTree(a, b);
            }

            return isSame || IsSubtreeImpl(a.left, b) || IsSubtreeImpl(a.right, b);
        }

        public static bool IsSameTree(TreeNode a, TreeNode b)
        {
            if (a == null && b != null)
            {
                return false;
            }

            if (b == null && a != null)
            {
                return false;
            }

            if (a == null && b == null)
            {
                return true;
            }

            if (a.val != b.val)
            {
                return false;
            }

            return IsSameTree(a.left, b.left) && IsSameTree(a.right, b.right);
        }
    }
}
