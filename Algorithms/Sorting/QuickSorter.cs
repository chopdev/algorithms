using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public static class QuickSorter
    {
        #region Quick sort for int

        /// <summary>
        /// Quick sort of array
        /// </summary>
        public static void QuickSort(IList<int> arr)
        {
            QuickSort(arr, 0, arr.Count - 1);
        }

        /// <summary>
        /// Recursive quick sort implementation
        /// </summary>
        /// <param name="arr">Initial array</param>
        /// <param name="low">Low index of array from which it should be sorted</param>
        /// <param name="high">High index of array till which it should be sorted</param>
        public static void QuickSort(IList<int> arr, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int pivot = Partition(arr, low, high);

            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
        }

        /// <summary>
        /// Devides array (or part of array, depending from low and high indexes) into two parts. 
        /// One part - all numbers that bigger than some pivot number,
        /// second part - all numbers that smaller than this pivot number
        /// </summary>
        /// <param name="arr">Initial array of numbers</param>
        /// <param name="low">Low index of array that need to be partioned</param>
        /// <param name="high">High index of array that need to be partioned</param>
        /// <returns>Index of pivot number (by which array was devided)</returns>
        public static int Partition(IList<int> arr, int low, int high)
        {
            int pivot = high;
            int less = low - 1;

            for (int i = low; i < high; i++)
            {
                if (arr[pivot] >= arr[i])
                {
                    less++;
                    Swap(arr, less, i);
                }
            }

            Swap(arr, pivot, less + 1);

            return less + 1;
        }

        /// <summary>
        /// Swaps two elements of array
        /// </summary>
        /// <param name="arr">array of integers</param>
        /// <param name="i">index of first element to swipe</param>
        /// <param name="j">index of second element to swipe</param>
        public static void Swap(IList<int> arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        #endregion

        #region Quick sort generic

        /// <summary>
        /// Quick sort of array
        /// </summary>
        public static void QuickSort<T>(IList<T> arr) where T : IComparable
        {
            QuickSort(arr, 0, arr.Count - 1);
        }

        /// <summary>
        /// Recursive quick sort implementation
        /// </summary>
        /// <param name="arr">Initial array</param>
        /// <param name="low">Low index of array from which it should be sorted</param>
        /// <param name="high">High index of array till which it should be sorted</param>
        public static void QuickSort<T>(IList<T> arr, int low, int high) where T : IComparable
        {
            if (high <= low)
            {
                return;
            }

            int pivot = Partition(arr, low, high);

            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
        }

        /// <summary>
        /// Devides array (or part of array, depending from low and high indexes) into two parts. 
        /// One part - all objects that bigger than some pivot object,
        /// second part - all objects that smaller than this pivot object
        /// </summary>
        /// <param name="arr">Initial array of objects</param>
        /// <param name="low">Low index of array that need to be partioned</param>
        /// <param name="high">High index of array that need to be partioned</param>
        /// <returns>Index of pivot objects (by which array was devided)</returns>
        public static int Partition<T>(IList<T> arr, int low, int high) where T : IComparable
        {
            int pivot = high;
            int less = low - 1;

            for (int i = low; i < high; i++)
            {
                if (arr[pivot].CompareTo(arr[i]) >= 0)
                {
                    less++;
                    Swap(arr, less, i);
                }
            }

            Swap(arr, pivot, less + 1);

            return less + 1;
        }

        /// <summary>
        /// Swaps two elements of array
        /// </summary>
        /// <param name="arr">array of objects</param>
        /// <param name="i">index of first element to swipe</param>
        /// <param name="j">index of second element to swipe</param>
        public static void Swap<T>(IList<T> arr, int i, int j) where T : IComparable
        {
            if (i == j) return;

            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        #endregion

        #region Extensions

        /// <summary>
        /// Enables to use quick sort by collections, like their own method
        /// </summary>
        /// <typeparam name="T">IComparable type</typeparam>
        /// <param name="arr">array of IComparable objects</param>
        public static void QSort<T>(this IList<T> arr) where T : IComparable
        {
            QuickSort(arr, 0, arr.Count - 1);
        }

        #endregion
    }
}
