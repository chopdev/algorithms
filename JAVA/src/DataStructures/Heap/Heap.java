package DataStructures.Heap;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Some facts:
 *
 * Binary tree has capacity of 2^H - 1 elements (where H is a height of tree)
 * Leaf nodes take half of elements of a tree (in complete tree), because we add 1 layer, so 2^(H+1) - 1 total elements
 * @see java.util.PriorityQueue - for details of implementation
 *
 * Explains why initial creation of a heap (or heapify operation) in general takes O(N) time
 * https://stackoverflow.com/questions/9755721/how-can-building-a-heap-be-on-time-complexity
 *
 * Removal/adding to heap - O(logN) as one time siftUp or siftDown operation
 * */
public class Heap<T extends Comparable<T>> {
    private final ArrayList<T> heap = new ArrayList<>();

    public Heap() {
    }

    public Heap(Collection<T> collection) {
        heap.addAll(collection);
        heapify();
    }

    public Object[] toArray() {
        return heap.toArray();
    }

    public void offer(T element) {
        heap.add(element);
        siftUp(heap.size() - 1);
    }

    public T poll() {
        swap(0, heap.size() - 1); // swap last node with the root and sift it down
        T result = heap.remove(heap.size() - 1);
        siftDown(0);
        return result;
    }

    private void siftUp(int i) {
        while (i > 0) {
            int parent = (i - 1) / 2;
            if (heap.get(i).compareTo(heap.get(parent)) <= 0)
                break;
            swap(i, parent);
            i = parent;
        }
    }

    private void heapify() {
        int i = heap.size() / 2 - 1; // leaf nodes take half of the binary tree size, no need to consider them
        for (; i>=0; i--) {
            siftDown(i);
        }
    }

    /**
     * siftDown swaps a node that is too small with its largest child (thereby moving it down)
     * until it is at least as large as both nodes below it.
     * */
    private void siftDown(int i) {
        int n = heap.size();
        while (2*i + 1 < n) { // while there is at least one child
            int left = 2*i + 1;
            int right = 2*i + 2;
            int biggestChild = left;
            if (right < n && heap.get(right).compareTo(heap.get(left)) > 0)
                biggestChild = right;
            if (heap.get(i).compareTo(heap.get(biggestChild)) > 0)
                break;
            swap(i, biggestChild);
            i = biggestChild;
        }
    }


    private void swap(int i, int j) {
        T temp = heap.get(i);
        heap.set(i, heap.get(j));
        heap.set(j, temp);
    }
}
