package DataStructures.Trie;

import java.util.List;
import java.util.Optional;

/**
 * Trie structure for finding efficiently if a string key is in a set of string keys,
 * also it efficiently finds all the string keys with a specific key prefix.
 *
 * https://en.wikipedia.org/wiki/Trie
 *
 * @param <V> the values stored in the trie
 */
public interface Trie<V> {

    /**
     * Insert a new key-value pair in the trie.
     *
     * @param key
     * @param value
     */
    void insert(String key, V value);

    /**
     * Returns the value associated with the specified key.
     *
     * @param key
     * @return the value of the key
     */
    Optional<V> get(String key);

    /**
     * Returns a list of all the values that have keys starting with the given key prefix.
     *
     * @param keyPrefix
     * @return the values of the keys that match the prefix
     */
    List<V> findPrefix(String keyPrefix);

}