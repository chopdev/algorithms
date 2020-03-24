using System.Collections.Generic;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Bucket sort is an efficient sorting with time complexity O(N). 
    /// But it can be only applied to specific kind of data. 
    /// It is useful when input is uniformly distributed over a range.
    /// 
    /// For example when the data - is array of ages of the people. People live max till 120-130
    /// Another example: Sort a large set of floating point numbers which are in range from 0.0 to 1.0 and are uniformly distributed across the range. 
    /// </summary>
    public class BucketSort
    {
        /// <summary>
        /// Sort set of floating point numbers which are in range from 0.0 to 1.0 and are uniformly distributed across the range. 
        /// </summary>
        public static void Sort(double[] arr, int n = 10)
        {
            var buckets = new List<double>[n];
            for (int i = 0; i < arr.Length; i++)
            {
                int bucket = (int)(arr[i] * n);
                if (buckets[bucket] == null)
                    buckets[bucket] = new List<double>();
                buckets[bucket].Add(arr[i]);
            }

            for (int i = 0; i < n; i++)
                if(buckets[i] != null)
                    buckets[i].Sort();

            int index = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; buckets[i] != null && j < buckets[i].Count; j++)
                    arr[index++] = buckets[i][j];
        }
    }
}
