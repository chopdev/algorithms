package DataStructures.Trie;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;


public class RadixTreeTest {
    private RadixTree<String> trie;

    @Before
    public void setUp() {
        trie = new RadixTree.Builder<String>()
                .build();

        List<String> words = Arrays
                .asList("algorithm", "bake", "bald", "balsamic", "banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt", "bed", "king", "zebra");
        Collections.shuffle(words);

        for (String word : words) {
            trie.insert(word, word);
        }
    }

    @Test
    public void testGet() {
        assertTrue(trie.get("banana").get().equals("banana"));
        assertTrue(trie.get("BANANA").get().equals("banana"));
        assertTrue(trie.get("Banana").get().equals("banana"));
        assertTrue(trie.get("bankrupt").get().equals("bankrupt"));
    }

    @Test
    public void testInsertAndGet() {
        trie.insert("foo", "fooVal");
        trie.insert("bar", "barVal");
        trie.insert("", "emptyVal");

        assertTrue(trie.get("foo").get().equals("fooVal"));
        assertTrue(trie.get("bar").get().equals("barVal"));
        assertTrue(trie.get("").get().equals("emptyVal"));
        assertFalse(trie.get("unknown").isPresent());
    }

    @Test
    public void testFindPrefix() {
        assertTrue(
                trie.findPrefix("").equals(Arrays.asList("algorithm", "bake", "bald", "balsamic", "banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt", "bed", "king", "zebra")));
        assertTrue(trie.findPrefix("foo").equals(Collections.emptyList()));
        assertTrue(trie.findPrefix("z").equals(Arrays.asList("zebra")));
        assertTrue(
                trie.findPrefix("b").equals(Arrays.asList("bake", "bald", "balsamic", "banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt", "bed")));
        assertTrue(
                trie.findPrefix("ba").equals(Arrays.asList("bake", "bald", "balsamic", "banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt")));
        assertTrue(
                trie.findPrefix("ban").equals(Arrays.asList("banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt")));
        assertTrue(trie.findPrefix("bana").equals(Arrays.asList("banality", "banana")));
        assertTrue(trie.findPrefix("banan").equals(Arrays.asList("banana")));
        assertTrue(trie.findPrefix("banaz").equals(Collections.emptyList()));
        assertTrue(trie.findPrefix("bananaz").equals(Collections.emptyList()));

        // case insensitiveness
        assertTrue(trie.findPrefix("Banan").equals(Arrays.asList("banana")));
        assertTrue(trie.findPrefix("BaNaN").equals(Arrays.asList("banana")));
    }

    @Test
    public void testCaseSensitiveness() {
        trie = new RadixTree.Builder<String>()
                .caseSensitive(true)
                .build();

        trie.insert("Foo", "fooVal");
        assertTrue(trie.get("Foo").get().equals("fooVal"));
        assertFalse(trie.get("foo").isPresent());
        assertFalse(trie.get("FOO").isPresent());
    }

}
