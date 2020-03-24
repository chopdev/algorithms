using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trie
{
    public class Trie
    {
        public TrieNode Root { get; private set; }

        public Trie() {
            Root = new TrieNode('*');
        }

        public Trie(IList<string> words) : this() {
            foreach (var word in words)
            {
                Root.addWord(word);
            }
        }

        /// <summary>
        /// Cheks whether word exists in Trie
        /// </summary>
        /// <param name="word">Searching word</param>
        /// <param name="fullWord">If set to true, word should be finished (not prefix of the word)</param>
        public bool contains(string word, bool fullWord) {
            TrieNode currNode = Root;

            for (int i = 0; i < word.Length; i++)
            {
                char currChar = word[i];
                currNode = currNode.getChild(currChar);
                if (currNode == null) return false;
            }

            if (!fullWord)
                return true;

            return currNode.Terminates;
        }

        public void addWord(string word) {
            Root.addWord(word);
        }
    }
}
