using System;
using System.Collections.Generic;
using Algorithms.Sorting;
using Xunit;

namespace XUnitTests.Algorithms
{
    public class CountingSearchTests
    {
        [Fact(DisplayName = "Counting sort works correct")]
        public void CountingSortIsCorrect()
        {
            int[] arr1 = new int[] { 1, 2, 2, 2, 3, 1, 3 };
            int[] arr2 = new int[0];
            int[] arr3 = new int[] { 1, 1, 1 };
            int[] arr4 = new int[] { 0, 1, 0, 1, 2, 2, 5, 5, 1, 1 };

            CountingSort.Sort(arr1, 1, 3);
            CountingSort.Sort(arr2, 0, 0);
            CountingSort.Sort(arr3, 1, 1);
            CountingSort.Sort(arr4, 0, 5);

            int[] sorted1 = new int[] { 1, 1, 2, 2, 2, 3, 3 };
            int[] sorted3 = new int[] { 1, 1, 1 };
            int[] sorted4 = new int[] { 0, 0, 1, 1, 1, 1, 2, 2, 5, 5 };

            for (int i = 0; i < arr1.Length; i++)
                Assert.Equal(arr1[i], sorted1[i]);

            for (int i = 0; i < arr3.Length; i++)
                Assert.Equal(arr3[i], sorted3[i]);

            for (int i = 0; i < arr3.Length; i++)
                Assert.Equal(arr3[i], sorted3[i]);
        }
    }
}
