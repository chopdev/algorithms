using Xunit;
using Algorithms.Sorting;

namespace XUnitTests.Algorithms
{
    public class BucketSortTests
    {
        [Fact(DisplayName = "Bucket sort works correct")]
        public void BucketSortIsCorrect()
        {
            var arr = new double[] { 0.66, 0.668, 0.2, 0.33, 0.001, 0.1, 0.35, 0.78 };
            BucketSort.Sort(arr);

            var arrCorrect = new double[] { 0.001, 0.1, 0.2, 0.33, 0.35, 0.66, 0.668, 0.78 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.Equal(arr[i], arrCorrect[i]);
            }
        }
    }
}
