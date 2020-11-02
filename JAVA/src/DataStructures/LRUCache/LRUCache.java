package DataStructures.LRUCache;

import java.util.LinkedHashMap;
import java.util.Map;

import static com.google.common.base.Preconditions.checkArgument;

/**
 * Implementation of the Least recently used cache
 * https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU
**/
public class LRUCache<K, V> {
    int capacity;
    LinkedHashMap<K, V> hash;

    public LRUCache(int capacity) {
        checkArgument(capacity > 0, "Capacity should be a positive number");
        this.capacity = capacity;
        this.hash = new LinkedHashMap<>(capacity, 0.75f, true) {
            /**
             * Returns <tt>true</tt> if this map should remove its eldest entry.
             * This method is invoked by <tt>put</tt> and <tt>putAll</tt> after
             * inserting a new entry into the map.  It provides the implementor
             * with the opportunity to remove the eldest entry each time a new one
             * is added.  This is useful if the map represents a cache: it allows
             * the map to reduce memory consumption by deleting stale entries.
             * */
            @Override
            protected boolean removeEldestEntry(Map.Entry<K,V> eldest) {
                return size() > capacity;
            }
        };
    }

    public V get(K key) {
        V val = hash.get(key);
        return val;
    }

    public void put(K key, V value) {
        hash.put(key, value);
    }
}
