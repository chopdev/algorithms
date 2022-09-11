package DataStructures.Graphs;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.*;

public class TopologicalSortBFSTest {
    private TopologicalSortBFS topologicalSortBFS = new TopologicalSortBFS();

    @Test
    public void getInOrderSimple() {
        // arrange
        Map<Integer, List<Integer>> graph = new HashMap<>();
        graph.put(1, Arrays.asList(2));
        graph.put(2, Arrays.asList());
        // act
        List<Integer> res = topologicalSortBFS.getInOrder(graph);
        // assert
        assertEquals(2, res.size());
        assertEquals(2, res.get(0));
        assertEquals(1, res.get(1));
    }

    @Test
    public void getInOrderSimple_Reverse() {
        Map<Integer, List<Integer>> graph = new HashMap<>();
        graph.put(1, Arrays.asList());
        graph.put(2, Arrays.asList(1));
        List<Integer> res = topologicalSortBFS.getInOrder(graph);
        assertEquals(2, res.size());
        assertEquals(1, res.get(0));
        assertEquals(2, res.get(1));
    }

    @Test
    public void getInOrder_EmptyGraph() {
        Map<Integer, List<Integer>> graph = new HashMap<>();
        List<Integer> res = topologicalSortBFS.getInOrder(graph);
        assertEquals(0, res.size());
    }

    @Test
    public void getInOrder_Looped() {
        // graph is a bit changed version of this one https://www.geeksforgeeks.org/topological-sorting/
        Map<Integer, List<Integer>> graph = new HashMap<>();
        graph.put(5, Arrays.asList(0, 2));
        graph.put(2, Arrays.asList(3));
        graph.put(0, Arrays.asList(3));
        graph.put(3, Arrays.asList(1));
        graph.put(4, Arrays.asList(0, 1, 5));
        graph.put(1, Arrays.asList(4));

        assertThrows(IllegalArgumentException.class, () -> topologicalSortBFS.getInOrder(graph));
    }

    @Test
    public void getInOrder_NotLooped() {
        // graph is a bit changed version of this one https://www.geeksforgeeks.org/topological-sorting/
        Map<Integer, List<Integer>> graph = new HashMap<>();
        graph.put(5, Arrays.asList(0, 2));
        graph.put(2, Arrays.asList(3));
        graph.put(0, Arrays.asList());
        graph.put(3, Arrays.asList(1));
        graph.put(4, Arrays.asList(0, 1, 5));
        graph.put(1, Arrays.asList(0));

        List<Integer> res = topologicalSortBFS.getInOrder(graph);
        assertEquals(6, res.size());

        assertEquals(0, res.get(0));
        assertEquals(1, res.get(1));
        assertEquals(3, res.get(2));
        assertEquals(2, res.get(3));
        assertEquals(5, res.get(4));
        assertEquals(4, res.get(5));
    }
}