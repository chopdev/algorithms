using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trie
{
    public class TrieNode
    {
        private IDictionary<char, TrieNode> childs;
        /// <summary>
        /// Character of the node
        /// </summary>
        public char Char { get; private set; }
        /// <summary>
        /// If last letter of word
        /// </summary>
        public bool Terminates { get; private set; }

        public TrieNode(char currChar) {
            Char = currChar;
            childs = new Dictionary<char, TrieNode>();
        }

        public TrieNode getChild(char currChar) {
            return childs.ContainsKey(currChar) ? childs[currChar] : null;
        }

        public void addWord(string word) {
            if (word == null || word.Length == 0) return;

            char firstChar = word[0];
            var childNode = getChild(firstChar);
            if (childNode == null) {
                childNode = new TrieNode(firstChar);
                childs.Add(firstChar, childNode);
            }

            string rest = word.Substring(1);
            if (rest.Length > 0)
                childNode.addWord(rest);
            else
                Terminates = true;
        }
    }
}
