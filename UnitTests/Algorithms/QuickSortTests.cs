using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting;

namespace UnitTests.Algorithms
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void QuickSortIsCorrect()
        {
            var arr = new int[] { 23, 42, 4, 16, 8, 15, 3, 9, 55, 0, 34, 12, 2, 46, 25 };
            QuickSorter.QuickSort(arr);

            var orderedArray = new int[] { 0, 2, 3, 4, 8, 9, 12, 15, 16, 23, 25, 34, 42, 46, 55 };

            for (int i = 0; i < orderedArray.Length; i++)
            {
                Assert.AreEqual(orderedArray[i], arr[i]);
            }

            arr = new int[] { 4, 1 };
            arr.QSort();
            Assert.AreEqual(arr[0], 1);
            Assert.AreEqual(arr[1], 4);
        }

        [TestMethod]
        public void QuickSortIsCorrectIComparable()
        {
            var strings = new string[] { "e", "a", "w", "b", "d", "c", "f", "g", "h", "e" };
            strings.QSort();
            var ordered = new string[] { "a", "b", "c", "d", "e", "e", "f", "g", "h", "w" };

            for (int i = 0; i < ordered.Length; i++)
            {
                Assert.AreEqual(ordered[i], strings[i]);
            }
        }
    }
}
