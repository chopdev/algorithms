using Xunit;
using DataStructures;
using DataStructures.UnionFind;

namespace XUnitTests.DataStructures
{
    public class UnionFindTests
    {
        [Fact(DisplayName = "Union Find 2 dimensional works correct")]
        public void TwoDimansionalUnionFindWorksCorrect()
        {
            int[][] arr = new int[5][];
            arr[0] = new int[] { 0, 0, 0, 1, 1 };
            arr[1] = new int[] { 0, 1, 0, 0, 1 };
            arr[2] = new int[] { 0, 0, 1, 0, 0 };
            arr[3] = new int[] { 0, 0, 1, 0, 0 };
            arr[4] = new int[] { 0, 0, 1, 0, 1 };

            TwoDimensionalUnionFind uf = new TwoDimensionalUnionFind(arr);

            // connect all the 1th that are adjacent to each other vertically of horizontally
            for (int rowInd = 0; rowInd < arr.Length; rowInd++)
            {
                for (int colInd = 0; colInd < arr[rowInd].Length; colInd++)
                {
                    if (arr[rowInd][colInd] == 0) continue;
                    if (rowInd - 1 >= 0 && arr[rowInd - 1][colInd] == 1) uf.Union(new Point(rowInd - 1, colInd), new Point(rowInd, colInd));
                    if (colInd - 1 >= 0 && arr[rowInd][colInd - 1] == 1) uf.Union(new Point(rowInd, colInd - 1), new Point(rowInd, colInd));
                    if (rowInd + 1 < arr.Length && arr[rowInd + 1][colInd] == 1) uf.Union(new Point(rowInd + 1, colInd), new Point(rowInd, colInd));
                    if (colInd + 1 < arr[0].Length && arr[rowInd][colInd + 1] == 1) uf.Union(new Point(rowInd, colInd + 1), new Point(rowInd, colInd));
                }
            }

            // all these points should look on one parent (and this parent is one of them)
            int id1 = uf.GetId(0, 4);
            int id2 = uf.GetId(1, 4);
            int id3 = uf.GetId(0, 3);

            int res1 = uf.Find(id1);
            int res2 = uf.Find(id2);
            int res3 = uf.Find(id3);

            Assert.True(res1 == res2 && res2 == res3); 
            Assert.True(res1 == id1 || res1 == id2 || res1 == id3);

            // element has no neighbors, it should look on itself
            int id4 = uf.GetId(1, 1);
            int res4 = uf.Find(id4);
            Assert.True(id4 == res4 && id4 == 6);  
        }

        [Fact(DisplayName = "Union Find works correct")]
        public void UnionFindWorksCorrect()
        {
            UnionFind uf = new UnionFind(10);
            Assert.False(uf.Connected(0, 2));
            uf.Union(0, 2);
            Assert.True(uf.Connected(0, 2));
            uf.Union(0, 2);
            uf.Union(1, 0);
            uf.Union(1, 2);
            uf.Union(3, 0);
            uf.Union(4, 3);
            uf.Union(5, 1);
            Assert.True(uf.Count == 5);
            Assert.True(uf.Connected(5, 2));

            uf.Union(6, 7);
            uf.Union(6, 8);
            uf.Union(6, 9);
            Assert.True(uf.Count == 2);
            uf.Union(9, 1);
            Assert.True(uf.Count == 1);
            Assert.True(uf.Connected(9, 0));
        }
    }
}
