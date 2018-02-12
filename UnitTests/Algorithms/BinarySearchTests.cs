using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Search;

namespace UnitTests.Algorithms
{
    public class Apple : IComparable<Apple>
    {
        public double Weight { get; set; }
        public string Color { get; set; }

        public int CompareTo(Apple other)
        {
            if (Weight > other.Weight)
                return 1;

            if (Weight < other.Weight)
                return -1;

            return 0;
        }
    }

    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void IsResultCorrect()
        {
            var array = new int[] { 1, 3, 5, 9, 17, 19 };

            var res = BinarySearcher.BinarySearch(array, 1);
            Assert.IsTrue(res == 0);
            res = BinarySearcher.BinarySearch(array, 3);
            Assert.IsTrue(res == 1);
            res = BinarySearcher.BinarySearch(array, 5);
            Assert.IsTrue(res == 2);
            res = BinarySearcher.BinarySearch(array, 9);
            Assert.IsTrue(res == 3);
            res = BinarySearcher.BinarySearch(array, 17);
            Assert.IsTrue(res == 4);
            res = BinarySearcher.BinarySearch(array, 19);
            Assert.IsTrue(res == 5);
            res = BinarySearcher.BinarySearch(array, 2);
            Assert.IsTrue(res == null);
            res = BinarySearcher.BinarySearch(array, 20);
            Assert.IsTrue(res == null);
            res = BinarySearcher.BinarySearch(array, 4);
            Assert.IsTrue(res == null);
            res = BinarySearcher.BinarySearch(array, -1);
            Assert.IsTrue(res == null);
        }

        [TestMethod]
        public void IsResultForIComparablesCorrect()
        {
            var apples = new Apple[] {
                new Apple {Color = "Red", Weight= 50.57 },
                new Apple {Color = "Yellow", Weight= 70.2 },
                new Apple {Color = "Green", Weight= 75 },
                new Apple {Color = "Pink", Weight= 90 },
            };

            var apple = BinarySearcher.BinarySearch(apples, new Apple { Color = "Green", Weight = 70.2 });
            Assert.IsTrue(apple == 1);
            apple = BinarySearcher.BinarySearch(apples, new Apple { Color = "lol", Weight = 90 });
            Assert.IsTrue(apple == 3);
            apple = BinarySearcher.BinarySearch(apples, new Apple { Color = "Green", Weight = 1000 });
            Assert.IsTrue(apple == null);
        }
    }
}
