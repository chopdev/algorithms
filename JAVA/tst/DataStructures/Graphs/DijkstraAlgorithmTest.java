package DataStructures.Graphs;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class DijkstraAlgorithmTest {
    DijkstrasAlgorithm dijkstraAlgorithm = new DijkstrasAlgorithm();

    @Test
    public void testDistances() {
        // {vertex1, vertex2, distance} ; graph visually https://leetcode.com/problems/number-of-ways-to-arrive-at-destination/
        int[][] edges = new int[][] {{0,6,7},{0,1,2},{1,2,3},{1,3,3},{6,3,3},{3,5,1},{6,5,1},{2,5,1},{0,4,5},{4,6,2}};
        // act
        int[] dist = dijkstraAlgorithm.dfs(edges, 0);
        // assert
        assertEquals(0, dist[0]);
        assertEquals(2, dist[1]);
        assertEquals(5, dist[2]);
        assertEquals(5, dist[3]);
        assertEquals(5, dist[4]);
        assertEquals(6, dist[5]);
        assertEquals(7, dist[6]);
    }
}