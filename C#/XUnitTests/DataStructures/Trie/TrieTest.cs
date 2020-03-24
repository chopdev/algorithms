using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DataStructures.Trie;

namespace XUnitTests.DataStructures
{
    public class TrieTest
    {
        [Fact(DisplayName = "Trie init works correct")]
        public void TrieInitCorrect()
        {
            Trie trie = new Trie(new string[] {"correct", "action", "active",
                "activist", "activistyk", "actor",
                "actress", "actual", "actually",
                "lol", "pop"});

            Assert.True(trie.contains("activist", true));
            Assert.True(trie.contains("lol", true));
            Assert.True(trie.contains("activistyk", true));
            Assert.True(trie.contains("acti", false));
            Assert.True(trie.contains("po", false));

            Assert.False(trie.contains("activisty", true));
            Assert.False(trie.contains("acti", true));
            Assert.False(trie.contains("lol1", true));
            Assert.False(trie.contains("ddd", true));
        }

        [Fact(DisplayName = "Trie add works correct")]
        public void TrieAddCorrect()
        {
            Trie trie = new Trie(new string[] {"lol"});

            Assert.True(trie.contains("lol", true));
            Assert.True(trie.contains("lo", false));

            Assert.False(trie.contains("lol1", false));
            Assert.False(trie.contains("ddd", false));

            trie.addWord("lol1");
            trie.addWord("ddd");

            Assert.True(trie.contains("lol1", false));
            Assert.True(trie.contains("ddd", false));
        }
    }
}
