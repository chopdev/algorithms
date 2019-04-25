namespace Algorithms.Sorting
{
    // https://www.youtube.com/watch?v=7zuGmKfUt7s
    // when we know the range of numbers, we could calculate count of each number in the array
    // then just use this count array to create sorted array
    public class CountingSort
    {
        /// <summary>
        /// Sorts numbers in range from min to max
        /// </summary>
        /// <param name="min">Minimum number including</param>
        /// <param name="max">Maximum number including</param>
        public static void Sort(int[] nums, int min, int max)
        {
            int[] counts = new int[max - min + 1];
            for (int i = 0; i < nums.Length; i++)
                counts[nums[i] - min]++;    // count each number

            int ind = 0;
            for (int i = 0; i < counts.Length; i++)
                for (int j = 0; j < counts[i]; j++)
                    nums[ind++] = i + min;      // insert each number count times
        }
    }
}
