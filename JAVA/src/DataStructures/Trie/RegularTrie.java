package DataStructures.Trie;

import java.util.*;

/**
 * Regular implementation of Trie
 * The interface might be different depending on requirements.
 *
 * Other simpler implementation can be found here:
 * https://github.com/chopdev/leetcode_tasks/blob/master/tree/208_implement_trie/Trie.java
 * https://github.com/chopdev/leetcode_tasks/blob/master/tree/208_implement_trie/TreeNode.java
 * */
public class RegularTrie<V> implements Trie<V> {
    Node root;

    public RegularTrie() {
        root = new Node('*');
    }

    public void insert(String key, V value) {
        root.insert(key, value);
    }

    public Optional<V> get(String key) {
        Node<V> node = walk(key);
        if (node == null)
            return Optional.empty();
        return Optional.ofNullable(node.value);
    }

    public List<V> findPrefix(String keyPrefix) {
        Node prefixEnd = walk(keyPrefix);
        List<V> res = new ArrayList<>();
        if (prefixEnd == null) return res;

        // do bfs to find all the words starting with prefix
        Queue<Node> queue = new LinkedList<>();
        queue.add(prefixEnd);
        while (!queue.isEmpty()) {
            Node<V> node = queue.poll();
            if (node.value != null)
                res.add(node.value);
            queue.addAll(node.next.values());
        }
        return res;
    }

    private Node<V> walk(String keyPrefix) {
        Node<V> node = root;
        for (Character letter : keyPrefix.toLowerCase().toCharArray()) {
            if (!node.next.containsKey(letter))
                return null;
            node = node.next.get(letter);
        }
        return node;
    }

    public static class Node<V> {
        private Character letter;
        private Map<Character, Node> next;
        private V value; // value is only present on the ending node of the word

        public Node(Character letter) {
            this.letter = letter;
            this.next = new HashMap<>();
        }

        public void insert(String ending, V word) {
            if (ending == null || ending.length() == 0) {
                this.value = word;
                return;
            }
            Character nextChar = Character.toLowerCase(ending.charAt(0));
            Node nextNode = this.next.getOrDefault(nextChar, new Node(nextChar));
            this.next.put(nextChar, nextNode);
            nextNode.insert(ending.substring(1), word);
        }
    }
}
