using System;
using System.Collections.Generic;

namespace Main.SeventyFive
{
    /// <summary>
    /// https://leetcode.com/problems/implement-trie-prefix-tree/
    /// </summary>
    public class Trie
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> map = new Dictionary<char, TrieNode>();

            public bool IsWordEnd { get; set; }
        }

        private TrieNode root = new TrieNode();

        public void Insert(string word)
        {
            var current = root;

            foreach(var ch in word)
            {
                if (current.map.ContainsKey(ch))
                {
                    current = current.map[ch];
                }
                else
                {
                    var next = new TrieNode();
                    current.map.Add(ch, next);
                    current = next;
                }
            }

            current.IsWordEnd = true;
        }

        public bool Search(string word)
        {
            return SearchImpl(word, false);
        }

        public bool SearchImpl(string word, bool isPrefix)
        {
            var current = root;

            foreach(var ch in word)
            {
                if (current.map.ContainsKey(ch))
                {
                    current = current.map[ch];
                }
                else
                {
                    return false;
                }
            }

            return isPrefix || current.IsWordEnd;
        }

        public bool StartsWith(string prefix)
        {
            return SearchImpl(prefix, true);
        }
    }

    public class ImplementTrie
    {
        public static void Execute()
        {
            var t = new Trie();
            t.Insert("hello");
            t.Insert("hell");

            Console.WriteLine(t.Search("hello"));
            Console.WriteLine(t.StartsWith("hel"));
            Console.WriteLine(t.StartsWith("hed"));
        }
    }
}
