package DataStructures.SegmentTree;

/**
 * Implementation of Segment Tree
 * https://cp-algorithms.com/data_structures/segment_tree.html
 * https://leetcode.com/articles/a-recursive-approach-to-segment-trees-range-sum-queries-lazy-propagation/
 *
 * A Segment Tree is a data structure that stores information about array intervals as a tree.
 * The root of segment tree typically represents the entire interval of data we are interested in. This would be arr[0:n-1].
 * Each leaf of the tree represents a range comprising of just a single element. Thus the leaves represent arr[0], arr[1] and so on till arr[n-1].
 **/
public class SegmentTree {

    int[] arr; // initial array
    int[] tree; // it can be an array of objects or Pair in a case of more complex tasks

    public void build(int[] arr) {
        //The first level of the tree contains a single node (the root), the second level will contain two vertices,
        // in the third it will contain four vertices, until the number of vertices reaches .
        // Thus the number of vertices in the worst case can be estimated by the sum 1 + 2 + 4 + ... + 2^(logN) < 2^(logN + 1) < 4n
        tree = new int[4 * arr.length];
        this.arr = arr;
        build(1, 0, arr.length - 1); // building tree from 1 index, childs are on 2*i and 2*i+1
    }

    public int query(int left, int right) {
        int l = left <= 0 ? 0 : left;
        int r = right >= arr.length ? arr.length - 1 : right;
        return query(1, 0, arr.length - 1, l, r);
    }

    public void update(int arrayIndex, int newValue) {
        update(1, 0, arr.length - 1, arrayIndex, newValue);
    }

    /**
     * Build a segment tree.
     * O(N) time, assuming that the merge operation is constant time,
     * O(N) space
     *
     * @param treeIndex - current index in tree
     * @param left - left index of the array range. It represents current tree node boundaries tree[treeIndex] as arr[left..right]
     * @param right - right index of the array range. It represents current tree node boundaries tree[treeIndex] as arr[left..right]
     */
    private void build(int treeIndex, int left, int right) {
        if (left == right) {
            tree[treeIndex] = arr[left];
        } else {
            int mid = (left + right) / 2;
            build(treeIndex * 2, left, mid);
            build(treeIndex * 2 + 1, mid + 1, right); // mid is rounded to lower value, so add + 1 on the right side

            // merge logic here, depending on how you want to analyze range from array (sum, min/max, GCD/LCM etc)
            // here we keep range sums
            tree[treeIndex] = merge(tree[treeIndex * 2], tree[treeIndex * 2 + 1]);
        }
    }

    /**
     * @param treeIndex index of current vertex in the tree
     * @param left - left index of the array range. It represents current tree node boundaries tree[treeIndex] as arr[left..right]
     * @param right - right index of the array range. It represents current tree node boundaries tree[treeIndex] as arr[left..right]
     * @param queryLeft - left boundary of query range
     * @param queryRight - right boundary of query range
     *
     *   O(logN) time complexity, O(logN) space because of recursion
     *
    /To do this, we will traverse the Segment Tree and use the precomputed sums of the segments.
    // Let's assume that we are currently at the vertex that covers the segment .
    //
    // There are three possible cases.
    //
    //The easiest case is when the segment  is equal to the corresponding segment of the current vertex (i.e. ), a[l..r] == a[ql..qr]
    // then we are finished and can return the precomputed sum that is stored in the vertex.
    //
    //Alternatively the segment of the query can fall completely into the domain of either the left or the right child.
    // Recall that the left child covers the segment  and the right vertex covers the segment  with .
    // In this case we can simply go to the child vertex, which corresponding segment covers the query segment, and execute the algorithm described here with that vertex.
    //
    //And then there is the last case, the query segment intersects with both children.
    // In this case we have no other option as to make two recursive calls, one for each child.
    // First we go to the left child, compute a partial answer for this vertex (i.e. the sum of values of
    // the intersection between the segment of the query and the segment of the left child), then go to
    // the right child, compute the partial answer using that vertex, and then combine the answers by adding
    // them. In other words, since the left child represents the segment  and the right child the segment ,
    // we compute the sum query  using the left child, and the sum query  using the right child.
     **/
    private int query(int treeIndex, int left, int right, int queryLeft, int queryRight) {
        if (queryLeft > queryRight) {
            return 0; // return null as seeking range is less than 1 item
        } else if (left == queryLeft && right == queryRight) {
            return tree[treeIndex];
        } else {
            int mid = (left + right) / 2;
            int leftRes = query(treeIndex * 2, left, mid, queryLeft, Math.min(mid, queryRight));
            int rightRes = query(treeIndex * 2 + 1, mid + 1, right, Math.max(mid + 1, queryLeft), queryRight);
            // merge results
            return merge(leftRes, rightRes);
        }
    }


    /**
     * @param treeIndex index of current vertex in the tree
     * @param left - left index of the array range. It represents current tree node boundaries tree[treeIndex] as arr[left..right]
     * @param right - right index of the array range. It represents current tree node boundaries tree[treeIndex] as arr[left..right]
     * @param arrayIndex - index of the element in array to update
     * @param newValue - new value of the arr[arrayIndex]
     *
     *   O(logN) time complexity, O(logN) space because of recursion
     */
    //O(logN) time complexity, O(logN) space because of recursion
    private void update(int treeIndex, int left, int right, int arrayIndex, int newValue) {
        if (left == right) {
            tree[treeIndex] = newValue;
        } else {
            int mid = (left + right) / 2;
            if (arrayIndex <= mid)
                update(treeIndex * 2, left, mid, arrayIndex, newValue);
            else
                update(treeIndex * 2 + 1, mid + 1, right, arrayIndex, newValue);

            tree[treeIndex] = merge(tree[treeIndex * 2], tree[treeIndex * 2 + 1]);
        }
    }


    // Merge function can be supplied through constructor in real code
    private int merge(int leftSubTreeResult, int rightSubTreeResult) {
        return leftSubTreeResult + rightSubTreeResult;
    }
}
