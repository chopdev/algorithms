using Xunit;
using DataStructures;

namespace XUnitTests.DataStructures
{
    public class UnionFindTests
    {
        [Fact(DisplayName = "Union Find works correct")]
        public void UnionFindWorksCorrect()
        {
            int[][] arr = new int[5][];
            arr[0] = new int[] { 0, 0, 0, 1, 1 };
            arr[1] = new int[] { 0, 1, 0, 0, 1 };
            arr[2] = new int[] { 0, 0, 1, 0, 0 };
            arr[3] = new int[] { 0, 0, 1, 0, 0 };
            arr[4] = new int[] { 0, 0, 1, 0, 1 };

            UnionFind uf = new UnionFind(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == 0) continue;
                    if (i - 1 >= 0 && arr[i - 1][j] == 1) uf.Union(new Point(i - 1, j), new Point(i, j));
                    if (j - 1 >= 0 && arr[i][j - 1] == 1) uf.Union(new Point(i, j - 1), new Point(i, j));
                    if (i + 1 < arr.Length && arr[i + 1][j] == 1) uf.Union(new Point(i + 1, j), new Point(i, j));
                    if (j + 1 < arr[0].Length && arr[i][j + 1] == 1) uf.Union(new Point(i, j + 1), new Point(i, j));
                }
            }

            int id1 = uf.GetId(0, 4);
            int id2 = uf.GetId(1, 4);
            int id3 = uf.GetId(0, 3);

            int res1 = uf.Find(id1);
            int res2 = uf.Find(id2);
            int res3 = uf.Find(id3);

            Assert.True(res1 == res2 && res2 == res3);
            Assert.True(res1 == id1 || res1 == id2 || res1 == id3);

            int id4 = uf.GetId(1, 1);
            int res4 = uf.Find(id4);
            Assert.True(id4 == res4 && id4 == 6);
        }
    }
}
