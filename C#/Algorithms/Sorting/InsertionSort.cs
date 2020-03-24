using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public static class InsertionSort
    {
        /// <summary>
        /// In insertion sort elements are bubbled into the sorted section, while in bubble sort the maximums are bubbled out of the unsorted section.
        ///
        /// sorted  | unsorted
        /// 1 3 5 8 | 4 6 7 9 2
        /// 1 3 4 5 8 | 6 7 9 2
        /// 
        /// In each iteration the next element is bubbled through the sorted section until it reaches the right spot
        /// </summary>
        public static void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
                for (int j = i; j > 0 && arr[j - 1] > arr[j]; j--)
                    swap(arr, j - 1, j);
        }

        private static void swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
