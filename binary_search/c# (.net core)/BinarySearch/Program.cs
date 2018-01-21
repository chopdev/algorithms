using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 3, 5, 9, 17, 19 };

            var res = BinarySearch(array, 1);
            res = BinarySearch(array, 3);
            res = BinarySearch(array, 5);
            res = BinarySearch(array, 9);
            res = BinarySearch(array, 17);
            res = BinarySearch(array, 19);
            res = BinarySearch(array, 2);
            res = BinarySearch(array, 20);
            res = BinarySearch(array, 4);
            res = BinarySearch(array, 7);
            res = BinarySearch(array, 18);
            res = BinarySearch(array, -1);
            res = BinarySearch(array, 0);
            res = BinarySearchRecursive(array, 19);

            var apples = new Apple[] {
                new Apple {Color = "Red", Weight= 50.57 },
                new Apple {Color = "Yellow", Weight= 70.2 },
                new Apple {Color = "Green", Weight= 75 },
                new Apple {Color = "Pink", Weight= 90 },
            };

            var apple = BinarySearch(apples, new Apple { Color = "Green", Weight = 70 });
        }

        #region Iterative approach

        public static int? BinarySearch(IList<int> sortedArray, int searchItem)
        {
            int low = 0;
            int high = sortedArray.Count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int midValue = sortedArray[mid];

                if (midValue == searchItem)
                    return mid;

                if (midValue > searchItem)
                    high = mid - 1;
                else
                    low = mid + 1;
            }

            return null;
        }

        public static int? BinarySearch<T>(IList<T> sortedArray, T searchItem) where T : IComparable<T>
        {
            int low = 0;
            int high = sortedArray.Count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                var midValue = sortedArray[mid];
                int compare = midValue.CompareTo(searchItem);

                if (compare == 0)
                    return mid;

                if (compare > 0)
                    high = mid - 1;
                else
                    low = mid + 1;
            }

            return null;
        }

        #endregion

        #region Recursive approach

        public static int? BinarySearchRecursive(IList<int> sortedArray, int searchItem)
        {
            int low = 0;
            int high = sortedArray.Count - 1;

            return BinarySearchRecursive(sortedArray, searchItem, low, high);
        }

        public static int? BinarySearchRecursive(IList<int> sortedArray, int searchItem, int low, int high)
        {
            if (low > high)
                return null;

            int mid = low + (high - low) / 2;
            int midValue = sortedArray[mid];

            if (midValue == searchItem)
                return mid;

            if (midValue > searchItem)
                return BinarySearchRecursive(sortedArray, searchItem, low, mid - 1);
            else
                return BinarySearchRecursive(sortedArray, searchItem, mid + 1, high);
        }

        #endregion
    }
}
