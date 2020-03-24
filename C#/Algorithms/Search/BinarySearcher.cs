using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Search
{
    public class BinarySearcher
    {
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
