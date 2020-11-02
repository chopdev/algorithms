package DataStructures.LRUCache;

import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class LRUCacheTest {

    @Test
    public void testWorksCorrectly() {
        LRUCache lRUCache = new LRUCache<Integer, Integer>(2);
        lRUCache.put(1, 1); // cache is {1=1}
        lRUCache.put(2, 2); // cache is {1=1, 2=2}
        assertEquals(lRUCache.get(1), 1);

        lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        assertEquals(lRUCache.get(2), null);    // returns null (not found)


        lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        assertEquals(lRUCache.get(1), null);    // return -1 (not found)
        assertEquals(lRUCache.get(3), 3);    // return 3
        assertEquals(lRUCache.get(4), 4);    // return 4
    }

    @Test
    public void testWorksCorrectlyPlain() {
        LRUCachePlain lRUCache = new LRUCachePlain<Integer, Integer>(2);
        lRUCache.put(1, 1); // cache is {1=1}
        lRUCache.put(2, 2); // cache is {1=1, 2=2}
        assertEquals(lRUCache.get(1), 1);

        lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        assertEquals(lRUCache.get(2), null);    // returns null (not found)


        lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        assertEquals(lRUCache.get(1), null);    // return -1 (not found)
        assertEquals(lRUCache.get(3), 3);    // return 3
        assertEquals(lRUCache.get(4), 4);    // return 4
    }
}
