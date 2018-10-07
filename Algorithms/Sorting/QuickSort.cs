namespace Algorithms.Sorting
{
    public class QuickSort
    {
        public void sort(int[] arr) {
            if (arr == null) return;

            int left = 0, right = arr.Length - 1;
            sort(arr, left, right);
        }

        private void sort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            int index = partition(arr, left, right);
            sort(arr, left, index - 1);
            sort(arr, index, right);
        }

        private int partition(int[] arr, int left, int right) {
            int pivot = arr[(left + right) / 2];

            while (left <= right)
            {
                while (arr[left] < pivot) left++;
                while (arr[right] > pivot) right--;

                if (left <= right)
                {
                    swap(arr, left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }

        private void swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
