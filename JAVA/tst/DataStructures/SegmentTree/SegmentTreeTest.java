package DataStructures.SegmentTree;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertArrayEquals;
import static org.junit.jupiter.api.Assertions.assertEquals;

class SegmentTreeTest {

    @Test
    public void build() {
        // arrange
        int arr[] = { 18, 17, 13, 19, 15, 11, 20, 12, 33, 25 };
        SegmentTree segmentTree = new SegmentTree();
        // act
        segmentTree.build(arr);
        // assert
        int[] expectedTree = new int[] { 0, 183, 82, 101, 48, 34, 43, 58, 35, 13, 19, 15, 31, 12, 33, 25, 18, 17, 0, 0, 0, 0, 0, 0, 11, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        assertArrayEquals(expectedTree, segmentTree.tree);
    }

    @Test
    public void query() {
        // arrange
        int arr[] = { 18, 17, 13, 19, 15, 11, 20, 12, 33, 25 };
        SegmentTree segmentTree = new SegmentTree();
        segmentTree.build(arr);
        // act && assert
        assertEquals(123, segmentTree.query(2, 8)); // [2,8] is 13 + 19 + 15 + 11 + 20 + 12 + 33 = 12313+19+15+11+20+12+33=123
        assertEquals(13, segmentTree.query(2, 2)); // [2,2] is 13
        assertEquals(18, segmentTree.query(0, 0));
        assertEquals(183, segmentTree.query(0, 9));
    }

    @Test
    public void update() {
        // arrange
        int arr[] = { 18, 17, 13, 19, 15, 11, 20, 12, 33, 25 };
        SegmentTree segmentTree = new SegmentTree();
        segmentTree.build(arr);
        // act
        segmentTree.update(2, 15);
        // assert
        assertEquals(185, segmentTree.query(0, 9));
        assertEquals(15, segmentTree.query(2, 2));
    }
}