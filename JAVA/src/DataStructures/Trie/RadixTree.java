package DataStructures.Trie;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Deque;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Optional;
import java.util.Set;
import java.util.TreeMap;

import static java.util.Objects.requireNonNull;

/**
 * https://en.wikipedia.org/wiki/Radix_tree
 * */
public final class RadixTree<V> implements Trie<V> {

    private final boolean caseSensitive;
    private final Node<V> root = new Node<>(null, "", null);

    private RadixTree(boolean caseSensitive) {
        this.caseSensitive = caseSensitive;
    }

    @Override
    public void insert(String key, V value) {
        requireNonNull(key);
        requireNonNull(value);

        if (!caseSensitive) {
            key = key.toLowerCase();
        }

        Node.WalkStop<V> stop = root.walk(key);
        String partialKey = key.substring(stop.getWalkOffset());
        switch (stop.getState()) {
            case EXACT_MATCH:
                stop.getNode().setValue(value);
                break;
            case DIFFERENT:
                insertDifferentNode(value, stop, partialKey);
                break;
            case SUBSTRING_KEY:
                insertPreviousNode(partialKey, value, stop.getNode());
                break;
            case SUPERSTRING_KEY:
                insertNextNode(partialKey.substring(stop.getNode().getPartialKey().length()), value,
                        stop.getNode());
                break;
        }
    }

    private Node<V> insertDifferentNode(V value, Node.WalkStop<V> stop, String partialKey) {
        int index = stop.getPartialKeyDifferenceIndex();
        assert index > 0;
        Node<V> midNode = insertPreviousNode(partialKey.substring(0, index), null, stop.getNode());
        partialKey = partialKey.substring(index);
        return insertNextNode(partialKey, value, midNode);
    }

    private Node<V> insertPreviousNode(String partialKey, V value, Node<V> node) {
        Node<V> prevNode = new Node<>(node.getParent(), partialKey, value);
        node.getParent().getNext().put(partialKey.charAt(0), prevNode);
        node.setPartialKey(node.getPartialKey().substring(partialKey.length()));
        prevNode.getNext().put(node.getPartialKey().charAt(0), node);
        node.setParent(prevNode);
        return prevNode;
    }

    private Node<V> insertNextNode(String partialKey, V value, Node<V> node) {
        Node<V> nextNode = new Node<>(node, partialKey, value);
        node.getNext().put(partialKey.charAt(0), nextNode);
        return nextNode;
    }

    @Override
    public Optional<V> get(String key) {
        requireNonNull(key);

        if (!caseSensitive) {
            key = key.toLowerCase();
        }

        Node.WalkStop<V> stop = root.walk(key);
        return stop.getState() == Node.WalkState.EXACT_MATCH ? Optional
                .ofNullable(stop.getNode().getValue()) : Optional.<V>empty();
    }

    @Override
    public List<V> findPrefix(String keyPrefix) {
        requireNonNull(keyPrefix);

        if (!caseSensitive) {
            keyPrefix = keyPrefix.toLowerCase();
        }

        Node.WalkStop<V> stop = root.walk(keyPrefix);
        if (stop.getState() == Node.WalkState.SUPERSTRING_KEY
                || stop.getState() == Node.WalkState.DIFFERENT) {
            return Collections.emptyList();
        }

        List<V> ret = new ArrayList<>();
        Deque<Node<V>> stack = new LinkedList<>();
        stack.push(stop.getNode());
        Set<Node<V>> visited = new HashSet<>();

        while (!stack.isEmpty()) {
            Node<V> node = stack.peek();
            if (!visited.contains(node)) {
                if (node.getValue() != null) {
                    ret.add(node.getValue());
                }
                visited.add(node);

                Deque<Node<V>> next = new LinkedList<>();
                node.getNext().values().forEach(next::addFirst);
                next.forEach(stack::push);
            } else {
                stack.pop();
            }
        }

        return ret;
    }

    public static class Node<V> {

        private Node parent;
        private String partialKey;
        private TreeMap<Character, Node> next = new TreeMap<>();
        private V value;

        Node(Node parent, String partialKey, V value) {
            this.parent = parent;
            this.partialKey = partialKey;
            this.value = value;
        }

        Node getParent() {
            return parent;
        }

        void setParent(Node parent) {
            this.parent = parent;
        }

        String getPartialKey() {
            return partialKey;
        }

        void setPartialKey(String partialKey) {
            this.partialKey = partialKey;
        }

        TreeMap<Character, Node> getNext() {
            return next;
        }

        V getValue() {
            return value;
        }

        void setValue(V value) {
            this.value = value;
        }

        WalkStop<V> walk(String key) {
            Node<V> current = this;
            int keyOffset = 0;

            for (;;) {
                int differenceIndex = findDifferenceIndex(key, keyOffset, current.partialKey, 0);
                if (differenceIndex != -1) {
                    WalkStop<V> stop = new WalkStop<>(current, keyOffset, WalkState.DIFFERENT);
                    stop.setPartialKeyDifferenceIndex(differenceIndex);
                    return stop;
                }

                if (keyOffset + current.partialKey.length() > key.length()) {
                    return new WalkStop<>(current, keyOffset, WalkState.SUBSTRING_KEY);
                }

                if (keyOffset + current.partialKey.length() == key.length()) {
                    return new WalkStop<>(current, keyOffset, WalkState.EXACT_MATCH);
                }

                assert keyOffset + current.partialKey.length() < key.length();

                Node nextNode = current.next
                        .get(key.charAt(keyOffset + current.partialKey.length()));
                if (nextNode == null) {
                    return new WalkStop<>(current, keyOffset, WalkState.SUPERSTRING_KEY);
                }
                keyOffset += current.partialKey.length();
                current = nextNode;
            }
        }

        private int findDifferenceIndex(String first, int firstOffset, String second,
                                        int secondOffset) {
            for (int i = firstOffset, j = secondOffset; i < first.length() && j < second.length();
                 i++, j++) {
                if (first.charAt(i) != second.charAt(j)) {
                    return i - firstOffset;
                }
            }
            return -1;
        }

        static class WalkStop<V> {

            private Node<V> node;
            private int walkOffset;
            private WalkState state;
            private int partialKeyDifferenceIndex;

            WalkStop(Node stop, int walkOffset, WalkState state) {
                this.node = stop;
                this.walkOffset = walkOffset;
                this.state = state;
            }

            Node<V> getNode() {
                return node;
            }

            int getWalkOffset() {
                return walkOffset;
            }

            WalkState getState() {
                return state;
            }

            int getPartialKeyDifferenceIndex() {
                return partialKeyDifferenceIndex;
            }

            void setPartialKeyDifferenceIndex(int partialKeyDifferenceIndex) {
                this.partialKeyDifferenceIndex = partialKeyDifferenceIndex;
            }
        }

        static enum WalkState {
            EXACT_MATCH,
            DIFFERENT,
            SUBSTRING_KEY,
            SUPERSTRING_KEY
        }
    }

    public static class Builder<V> {

        private boolean caseSensitive;

        public Builder caseSensitive(boolean value) {
            caseSensitive = value;
            return this;
        }

        public RadixTree<V> build() {
            return new RadixTree<>(caseSensitive);
        }

    }
}
