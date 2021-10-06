package DataStructures.Trie;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.containsInAnyOrder;
import static org.junit.jupiter.api.Assertions.*;

class RegularTrieTest extends TrieTest {
    @Override
    protected Trie<String> createInstance() {
        return new RegularTrie<String>();
    }
}

class RadixTrieTest extends TrieTest {
    @Override
    protected Trie<String> createInstance() {
        return new RadixTree.Builder<String>().build();
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

public abstract class TrieTest {
    protected Trie<String> trie;

    protected abstract Trie<String> createInstance();

    @BeforeEach
    public void setUp() {
        trie = createInstance();
                //new RadixTree.Builder<String>().build();

        //trie = new RegularTrie<String>();

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
        assertThat(trie.findPrefix(""),
                containsInAnyOrder(Arrays.asList("algorithm", "bake", "bald", "balsamic", "banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt", "bed", "king", "zebra").toArray()));
        assertTrue(trie.findPrefix("foo").equals(Collections.emptyList()));
        assertTrue(trie.findPrefix("z").equals(Arrays.asList("zebra")));
        assertThat(trie.findPrefix("b"),
                containsInAnyOrder(Arrays.asList("bake", "bald", "balsamic", "banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt", "bed").toArray()));
        assertThat(trie.findPrefix("ba"),
                containsInAnyOrder(Arrays.asList("bake", "bald", "balsamic", "banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt").toArray()));
        assertThat(trie.findPrefix("ban"),
                containsInAnyOrder(Arrays.asList("banality", "banana", "bandit", "banished", "banister", "bank", "bankrupt").toArray()));
        assertThat(trie.findPrefix("bana"),
                containsInAnyOrder(Arrays.asList("banality", "banana").toArray()));
        assertTrue(trie.findPrefix("banan").equals(Arrays.asList("banana")));
        assertTrue(trie.findPrefix("banaz").equals(Collections.emptyList()));
        assertTrue(trie.findPrefix("bananaz").equals(Collections.emptyList()));

        // case insensitiveness
        assertTrue(trie.findPrefix("Banan").equals(Arrays.asList("banana")));
        assertTrue(trie.findPrefix("BaNaN").equals(Arrays.asList("banana")));
    }

}

