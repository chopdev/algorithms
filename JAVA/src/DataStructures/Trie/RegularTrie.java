package DataStructures.Trie;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

public class RegularTrie {
    Node root;

    public RegularTrie() {
        root = new Node('*');
    }

    public void insert(String key) {

    }

    public boolean get(String key) {
        return Optional.empty();
    }

    public List<String> findPrefix(String keyPrefix) {
        return null;
    }

    private void walk(String keyPrefix) {
        if (prefix == null || prefix.length() == 0) {
            return;
        }
    }

    private void findByPrefix(String prefix, List<String> res, Node node) {
        if (node.isEnding)
            res.add();
        if (prefix == null || prefix.length() == 0) {

            return;
        }
        Character nextChar = prefix.charAt(0);
        if (node.next.containsKey(nextChar)) {
            Node nextNode = node.next.get(nextChar);

        }

    }

    public static class Node {
        private Character letter;
        private Map<Character, Node> next;
        private boolean isEnding;

        public Node(Character letter) {
            this.letter = letter;
            this.next = new HashMap<>();
        }

        public void insert(String ending) {
            if (ending == null || ending.length() == 0) {
                isEnding = true;
                return;
            }
            Character nextChar = ending.charAt(0);
            Node nextNode = new Node(nextChar);
            next.put(nextChar, nextNode);
            nextNode.insert(ending.substring(1));
        }
    }
}
