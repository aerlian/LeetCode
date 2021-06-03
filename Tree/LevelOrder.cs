using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
    /// </summary>
    public class LevelOrder
    {
        public static void Execute()
        {
            var tree = TreeNode.BuildTreeFromData(new object [] {3, 9, 20, null, null, 15, 7});
            var output = LevelOrderImpl(tree);

            foreach(var lst in output)
            {
                Console.WriteLine($"{string.Join(",", lst)}");
            }
        }

        public static List<IList<int>> LevelOrderImpl(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var ol = new List<IList<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var currentLevel = new List<int>();
                var qCount = queue.Count;
                for (var i = 0; i < qCount; i++)
                {
                    var n = queue.Dequeue();
                    if (n != null)
                    {
                        currentLevel.Add(n.val);
                        queue.Enqueue(n.left);
                        queue.Enqueue(n.right);
                    }
                }

                if (currentLevel.Count > 0)
                {
                    ol.Add(currentLevel);
                }
            }

            return ol;
        }
    }
}
