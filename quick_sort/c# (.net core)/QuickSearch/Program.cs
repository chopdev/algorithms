using System;
using System.Collections.Generic;

namespace QuickSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var arr = new int[] { 10, 8, 9, 2, 3, 6, 5, 4, 1, 7, 10 };
            QuickSort(arr);
            arr = new int[] { 4, 1, 8, 2, 3, 5 };
            QuickSort(arr);
            arr = new int[] { 4, 1 };
            QuickSort(arr);
            arr = new int[] { 1, 4};
            QuickSort(arr);

            var strings = new string[] { "e", "a", "w", "b", "d", "c", "f",  "g", "h", "e" };

            //var strings = new string[] { "e", "g", "w" };

            QuickSort(strings);
        }

        #region Quick sort for int

        public static void QuickSort(IList<int> arr)
        {
            QuickSort(arr, 0, arr.Count - 1);
        }

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

        public static void Swap(IList<int> arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        #endregion

        #region Quick sort generic

        public static void QuickSort<T>(IList<T> arr) where T : IComparable
        {
            QuickSort(arr, 0, arr.Count - 1);
        }

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

        public static void Swap<T>(IList<T> arr, int i, int j) where T : IComparable
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        #endregion
    }
}
