using System;
using System.Collections.Generic;

namespace Main.SeventyFive.Graph
{
    /// <summary>
    /// https://leetcode.com/problems/clone-graph/
    /// </summary>
    public class CloneGraph
    {
        public CloneGraph()
        {
        }

        public Node CloneGraphImpl(Node node, IDictionary<int, Node> cloneMap)
        {
            if (node == null)
            {
                return null;
            }

            if (cloneMap.ContainsKey(node.val))
            {
                return cloneMap[node.val];
            }

            var adjList = new List<Node>();
            var clone = new Node(node.val, adjList);

            cloneMap.Add(node.val, clone);

            foreach (var n in node.neighbors)
            {
                if (cloneMap.ContainsKey(n.val))
                {
                    adjList.Add(cloneMap[n.val]);
                }
                else
                {
                    adjList.Add(CloneGraphImpl(n, cloneMap));
                }
            }

            return clone;
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
