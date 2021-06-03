using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/validate-binary-search-tree/
    /// </summary>
    public class IsValidBST
    {
        public static void Execute()
        {
            var tree = TreeNode.BuildTreeFromData(new object[] { 2, 1, 3 });
            Console.WriteLine(IsValidBSTImpl(tree, int.MaxValue, int.MinValue));
        }

        public static bool IsValidBSTImpl(TreeNode node, int left, int right)
        {
            if (node == null)
            {
                return true;
            }

            if (node.val >= left)
            {
                return false;
            }

            if (node.val <= right)
            {
                return false;
            }

            return IsValidBSTImpl(node.left, node.val, right) &&
                    IsValidBSTImpl(node.right, left, node.val);
        }
    }
}
