using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/kth-smallest-element-in-a-bst/
    /// </summary>
    public class KthSmallestElementBST
    {
        public static void Execute()
        {
            var tree = TreeNode.BuildTreeFromData(new object[] { 3, 1, 4, null, 2 });
            var list = new List<int>();
            KthSmallestElementBSTImpl(tree, list);
            Console.WriteLine(list[3]);
        }

        public static void KthSmallestElementBSTImpl(TreeNode node, List<int> list)
        {
            if (node == null)
            {
                return;
            }

            KthSmallestElementBSTImpl(node.left, list);
            list.Add(node.val);
            KthSmallestElementBSTImpl(node.right, list);
        }
    }
}
