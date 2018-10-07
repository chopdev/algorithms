using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Sorting;

namespace XUnitTests.Algorithms
{
    public class InsertionSortTests
    {
        [Fact(DisplayName = "Insetion sort works correct")]
        public void InsertionSortIsCorrect()
        {
            var arr = new int[] { 5, 3, 10, 1, 2, 44, 55 };
            InsertionSort.Sort(arr);

            var arrCorrect = new int[] { 1, 2, 3, 5, 10, 44, 55 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.Equal(arr[i], arrCorrect[i]);
            }
        }
    }
}
