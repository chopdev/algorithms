using Algorithms.Sorting;
using System;
using Xunit;

namespace XUnitTests.Algorithms
{
    public class MergeSortTests
    {
        [Fact(DisplayName = "MergeSortIsCorrect")]
        public void MergeSortIsCorrect()
        {
            var arr = new int[] { 23, 42, 4, 16, 8, 15, 3, 9, 55, 0, 34, 12, 2, 46, 25 };
            //int[] arr = { 12, 11, 13, 5, 6, 7 };
            MergeSorter.MergeSort(arr);

            var orderedArray = new int[] { 0, 2, 3, 4, 8, 9, 12, 15, 16, 23, 25, 34, 42, 46, 55 };

            for (int i = 0; i < orderedArray.Length; i++)
            {
                Assert.Equal(orderedArray[i], arr[i]);
            }

            arr = new int[] { 4, 1 };
            arr.MSort();
            Assert.Equal(arr[0], 1);
            Assert.Equal(arr[1], 4);
        }

        [Fact(DisplayName = "MergeSortEdgeCases")]
        public void MergeSortEdgeCases()
        {
            int[] arr = null;
            Assert.Throws(typeof(ArgumentException), ()=> MergeSorter.MergeSort(arr));

            arr = new int[0];
            MergeSorter.MergeSort(arr);
            Assert.Equal(arr.Length, 0);
        }
    }
}
