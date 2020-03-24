using System;

namespace Algorithms.Sorting
{
    public static class MergeSorter
    {
        /// <summary>
        /// Merge sort of an array
        /// </summary>s
        public static void MergeSort(int[] arr)
        {
            if (arr == null)
                throw new ArgumentException("Array is not initialized");

            MergeSort(arr, 0, arr.Length);
        }

        /// <summary>
        /// Merge sort of an array
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="left">left index inclusive</param>
        /// <param name="right">right index exclusive</param>
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right - 1) // if less or equal than 1 element
                return;

            int middle = (right + left) / 2; 
            MergeSort(arr, left, middle); // not including middle index 
            MergeSort(arr, middle, right); // not including rigth index 

            Merge(arr, left, middle, right);
        }

        /// <summary>
        /// Merge to sub arrays (left-middle and middle-left)
        /// </summary>
        /// <param name="arr">initial array</param>
        /// <param name="left">left index inclusive</param>
        /// <param name="middle">middle index</param>
        /// <param name="right">rigth index exclusive</param>
        private static void Merge(int[] arr, int left, int middle, int right)
        {
            int i = left;
            int j = middle;
            int resInd = 0;
            int[] res = new int[right - left]; // temp array

            while (i < middle && j < right)
            {
                if (arr[i] < arr[j])
                {
                    res[resInd] = arr[i];
                    i++;
                }
                else
                {
                    res[resInd] = arr[j];
                    j++;
                }

                resInd++;
            }

            while (i < middle) // add remaining elements in result app
            {
                res[resInd] = arr[i];
                resInd++;
                i++;
            }
                
            while (j < right) // add remaining elements in result app
            {
                res[resInd] = arr[j];
                resInd++;
                j++;
            }
            
            // copy from result array to initial
            for (int h = left; h < right; h++)
                arr[h] = res[h - left];
        }

        /// <summary>
        /// Extension method
        /// </summary>
        public static void MSort(this int[] arr)
        {
            MergeSort(arr);
        }
    }
}
