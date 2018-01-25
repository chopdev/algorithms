using System;
using System.Collections.Generic;

namespace QuickSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var arr = new int[] { 10, 8, 9, 2, 3, 6, 5, 4, 1, 7 };

            var t = QuickSort(arr);
        }

        public static IList<int> QuickSort(IList<int> arr)
        {
            return QuickSort(arr, 0, arr.Count);
        }

        public static IList<int> QuickSort(IList<int> arr, int low, int high)
        {
            if (arr.Count <= 1 || high <= low + 1) 
            {
                return arr;
            }

            int pivot = low;

            for (int i = low + 1; i < high; i++)
            {
                if (arr[i] > arr[pivot])
                {
                    swap(arr, pivot, i);
                    pivot = i;
                }
            }

            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
            return arr;
        }

        public static void swap(IList<int> arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
