package DataStructures.Heap;

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
public class MaxHeap {

    public Integer offer() {
        return 0;
    }

    public Integer poll() {
        return 0;
    }

    private void siftUp() {

    }

    private void siftDown() {

    }

    private void heapify() {

    }
}
