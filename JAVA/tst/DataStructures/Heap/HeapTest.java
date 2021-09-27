package DataStructures.Heap;

import org.junit.Assert;
import org.junit.Test;

import java.util.Arrays;

/**
 * 			    0
 * 		1		        2
 *
 * 	3	    4	   5		6
 * */
public class HeapTest {
    @Test
    public void testCreation() {
        Assert.assertArrayEquals(Arrays.asList(2, 1).toArray(), new Heap<>(Arrays.asList(1, 2)).toArray());
        Assert.assertArrayEquals(Arrays.asList(2, 1).toArray(), new Heap<>(Arrays.asList(2, 1)).toArray());
        Assert.assertArrayEquals(Arrays.asList(1).toArray(), new Heap<>(Arrays.asList(1)).toArray());

        Assert.assertArrayEquals(Arrays.asList(3, 1, 2).toArray(), new Heap<>(Arrays.asList(2, 1, 3)).toArray());
        Assert.assertArrayEquals(Arrays.asList(4, 2, 3, 1).toArray(), new Heap<>(Arrays.asList(2, 1, 3, 4)).toArray());

        Assert.assertArrayEquals(new Object[0], new Heap<>().toArray());
    }

    @Test // , 3, 5, 5, 6, 2
    public void testOffer() {
        Heap<Integer> heap = new Heap<>();
        heap.offer(1);
        Assert.assertArrayEquals(Arrays.asList(1).toArray(), heap.toArray());
        heap.offer(3);
        Assert.assertArrayEquals(Arrays.asList(3, 1).toArray(), heap.toArray());
        heap.offer(5);
        Assert.assertArrayEquals(Arrays.asList(5, 1, 3).toArray(), heap.toArray());
        heap.offer(2);
        Assert.assertArrayEquals(Arrays.asList(5, 2, 3, 1).toArray(), heap.toArray());
    }

}
