using System;
using System.Collections.Generic;

namespace Main.SeventyFive
{
    /// <summary>
    /// https://leetcode.com/problems/design-add-and-search-words-data-structure/
    /// </summary>
    public class WdTrie
    {
        public class WdTrieNode
        {
            public Dictionary<char, WdTrieNode> map = new Dictionary<char, WdTrieNode>();
            public bool IsWordEnd { get; set; }
        }

        private WdTrieNode root = new WdTrieNode();

        public void Insert(string word)
        {
            var current = root;

            foreach (var ch in word)
            {
                if (current.map.ContainsKey(ch))
                {
                    current = current.map[ch];
                }
                else
                {
                    var next = new WdTrieNode();
                    current.map.Add(ch, next);
                    current = next;
                }
            }

            current.IsWordEnd = true;
        }

        public bool Search(string word)
        {
            bool dfs(int offset, WdTrieNode node)
            {
                var current = node;

                for (var i = offset; i < word.Length; i++)
                {
                    var ch = word[i];

                    if (ch == '.')
                    {
                        var children = current.map.Values;

                        foreach (var c in children)
                        {
                            if (dfs(i + 1, c))
                            {
                                return true;
                            }
                        }

                        return false;
                    }
                    else
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
                }

                return current.IsWordEnd;
            }

            return dfs(0, root);
        }
    }

    public class WordDictionary
    {
        private static WdTrie trie = new WdTrie();

        public static void AddWord(string word)
        {
            trie.Insert(word);
        }

        public static bool Search(string word)
        {
            return trie.Search(word);
        }

        public static void Execute()
        {
            AddWord("bad");
            AddWord("dad");
            AddWord("mad");
            Console.WriteLine(Search("pad"));
            Console.WriteLine(Search("bad"));
            Console.WriteLine(Search(".ad"));
            Console.WriteLine(Search("b.."));
        }
    }
}
