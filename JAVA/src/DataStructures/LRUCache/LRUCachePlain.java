package DataStructures.LRUCache;

import java.util.HashMap;

import static com.google.common.base.Preconditions.checkArgument;

/**
 * Implementation of LRU cache with the help of HashTable & Double linked list
 * https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU
 * */
public class LRUCachePlain<K,V> {

    /**
     * Double linked node
     * */
    class Node {
        private K key;
        private V value;
        private Node prev;
        private Node next;

        public Node(K key, V value) {
            this.key = key;
            this.value = value;
        }
    }

    private int capacity = 0;
    private Node head;
    private Node tail;
    private HashMap<K, Node> keyToNode;

    public LRUCachePlain(int capacity) {
        checkArgument(capacity > 0, "Capacity should be a positive number");
        this.capacity = capacity;
        head = new Node(null, null); // dummy head & tail to omit null checks
        tail = new Node(null, null);
        head.next = tail;
        tail.prev = head;
        keyToNode = new HashMap<>();
    }

    public V get(K key) {
        if (!keyToNode.containsKey(key)) {
            return null;
        }
        Node curr = keyToNode.get(key);
        updatePriority(curr);
        return curr.value;
    }

    public void put(K key, V value) {
        if (keyToNode.containsKey(key)) {
            Node curr = keyToNode.get(key);
            curr.value = value;
            updatePriority(curr);
        } else {
            Node curr = new Node(key, value);
            enqueue(curr);
            keyToNode.put(key, curr);
            if (keyToNode.size() > capacity) {
                keyToNode.remove(tail.prev.key);
                removeNode(tail.prev);
            }
        }
    }

    private void updatePriority(Node curr) {
        removeNode(curr);
        enqueue(curr);
    }

    private void removeNode(Node curr) {
        Node left = curr.prev;
        Node right = curr.next;
        left.next = right;
        right.prev = left;
    }

    private void enqueue(Node curr) {
        Node tempNext = head.next;
        head.next = curr;
        curr.prev = head;
        curr.next = tempNext;
        tempNext.prev = curr;
    }

}
