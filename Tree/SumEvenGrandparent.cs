using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/sum-of-nodes-with-even-valued-grandparent/
    /// </summary>
    public class SumEvenGrandparent
    {        
        public static int SumEvenGrandparentImpl(TreeNode root, List<int> path)
        {
            var runningTotal = 0;

            if (root == null)
            {
                return runningTotal;
            }

            path.Add(root.val);
            var pathLength = path.Count;

            if (pathLength >= 3)
            {
                var gp = path[path.Count - 3];
                if (gp % 2 == 0)
                {
                    runningTotal += root.val;
                }
            }

            runningTotal += SumEvenGrandparentImpl(root.left, path);
            runningTotal += SumEvenGrandparentImpl(root.right, path);

            path.RemoveAt(pathLength - 1);

            return runningTotal;
        }

        public static void Execute()
        {
            var tree = TreeNode.BuildTreeFromData(new object[] { 6, 7, 8, 2, 7, 1, 3, 9, null, 1, 4, null, null, null, 5 });
            //var tree = TreeNode.BuildTreeFromData(new object[] { 50, null, 54, 98, 6, null, null, null, 34 });
            Console.WriteLine(SumEvenGrandparentImpl(tree, new List<int>()));
        }
    }
}
