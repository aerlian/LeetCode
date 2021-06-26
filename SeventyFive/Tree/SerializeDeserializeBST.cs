using System;
using System.Text;
using Main.Common;

namespace Main.SeventyFive.Tree
{
    /// <summary>
    /// https://leetcode.com/problems/serialize-and-deserialize-bst/
    /// DFS pre-order dump
    /// </summary>
    public class SerializeDeserializeBST
    {
        public static void Execute()
        {
            var tree = TreeNode.BuildTreeFromData(new object[] { 2, 1, 3 });
            var data = serialize(tree);
            Console.WriteLine(data);
            var treeout = deserialize(data);
            Console.WriteLine(IsSameTree(tree, treeout));
        }

        private static bool IsSameTree(TreeNode a, TreeNode b)
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

        private static int offset = 0;

        public static string serialize(TreeNode root)
        {
            var sb = new StringBuilder();
            serializeImpl(root, sb);
            return sb.ToString();
        }

        public static void serializeImpl(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("n,");
                return;
            }

            sb.Append(root.val.ToString() + ",");
            serializeImpl(root.left, sb);
            serializeImpl(root.right, sb);
        }

        // Decodes your encoded data to tree.
        public static TreeNode deserialize(string data)
        {
            offset = -1;

            return deserializeImpl(data.Split(","));
        }

        private static TreeNode deserializeImpl(string[] parts)
        {
            offset += 1;

            var elem = parts[offset];

            if (elem.StartsWith("n"))
            {
                return null;
            }

            var value = int.Parse(parts[offset]);

            var node = new TreeNode
            {
                val = value,
                left = deserializeImpl(parts),
                right = deserializeImpl(parts)
            };

            return node;
        }

    }
}
