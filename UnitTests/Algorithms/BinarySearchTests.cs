using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void TestMethod1()
        {
            //var array = new int[] { 1, 3, 5, 9, 17, 19 };

            //var res = BinarySearch(array, 1);
            //res = BinarySearch(array, 3);
            //res = BinarySearch(array, 5);
            //res = BinarySearch(array, 9);
            //res = BinarySearch(array, 17);
            //res = BinarySearch(array, 19);
            //res = BinarySearch(array, 2);
            //res = BinarySearch(array, 20);
            //res = BinarySearch(array, 4);
            //res = BinarySearch(array, 7);
            //res = BinarySearch(array, 18);
            //res = BinarySearch(array, -1);
            //res = BinarySearch(array, 0);
            //res = BinarySearchRecursive(array, 19);

            //var apples = new Apple[] {
            //    new Apple {Color = "Red", Weight= 50.57 },
            //    new Apple {Color = "Yellow", Weight= 70.2 },
            //    new Apple {Color = "Green", Weight= 75 },
            //    new Apple {Color = "Pink", Weight= 90 },
            //};

            //var apple = BinarySearch(apples, new Apple { Color = "Green", Weight = 70 });
        }
    }
}
