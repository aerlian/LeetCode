using System;
using Main.Common;

namespace Main.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
    /// </summary>
    public class LowestCommonAncestor
    {
        public static void Execute()
        {
            var tree = TreeNode.BuildTreeFromData(new object[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
            var node = LowestCommonAncestorImpl(tree, new TreeNode { val = 2 }, new TreeNode { val = 8 });
            Console.WriteLine(node.val);
        }

        public static TreeNode LowestCommonAncestorImpl(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < root.val && q.val < root.val)
            {
                return LowestCommonAncestorImpl(root.left, p, q);
            }

            if (p.val > root.val && q.val > root.val)
            {
                return LowestCommonAncestorImpl(root.right, p, q);
            }

            return root;
        }
    }
}
